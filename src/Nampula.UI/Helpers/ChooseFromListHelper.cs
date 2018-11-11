using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Nampula.DI;
using System.Data;
using System.Windows.Forms;
using Nampula.Framework;
using Nampula.DI.ScriptWizard;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Columns;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Classe que ajuda a trabalhar com registros relacionadas na tela
    /// : o famoso ChooseFromList
    /// </summary>
    public class ChooseFromListHelper
    {
        private bool _editValueChangedByKeyDown;
        private readonly Form _ownerForm;
        private readonly List<FormatConditionChoose> _formatConditions;
        private readonly KeyValuePair<string, Dictionary<object, string>>[] _columnsParamns;
        private readonly EditText _txtId;
        private readonly EditTextButton _txtDescription;

        protected bool Validated;
        protected bool InExecution;

        /// <summary>
        /// Antes de tentar buscar algum registro
        /// </summary>
        public event ChooseFromListHandler AfterTryGetRecord;

        /// <summary>
        /// Depois de buscar o regitro
        /// </summary>
        public event ChooseFromListHandler BeforeTryGetRecord;

        /// <summary>
        /// Construtor Interno
        /// </summary>
        private ChooseFromListHelper()
        {
            VisbleColumns = new List<string>();
            WhereColumns = new List<TableAdapterField>();
        }

        /// <summary>
        /// Construtor para habilitar os recursos de choose em um cenário
        /// </summary>
        /// <param name="ptxtId">EditText do ID</param>
        /// <param name="ptxtDescription">EditText do Description</param>
        /// <param name="pQuery">Query que será executada</param>
        /// <param name="pFieldId">Nome Campo do ID</param>
        /// <param name="pFieldName">Nome do Campo do Description</param>
        /// <param name="pWindowText">Nome da Janela quando pesquisa</param>
        public ChooseFromListHelper(
                EditText ptxtId, EditTextButton ptxtDescription, TableQuery pQuery, string pFieldId,
                string pFieldName, string pWindowText)
            : this()
        {

            FieldNameId = pFieldId;
            FieldNameDescription = pFieldName;
            WindowText = pWindowText;
            Query = pQuery;
            _ownerForm = ptxtId.FindForm() as Form;
            _txtId = ptxtId;
            _txtDescription = ptxtDescription;

            HandleEditEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptxtId"></param>
        /// <param name="ptxtDescription"></param>
        /// <param name="pFormatConditions"></param>
        /// <param name="pQuery"></param>
        /// <param name="pFieldId"></param>
        /// <param name="pFieldName"></param>
        /// <param name="pWindowText"></param>
        public ChooseFromListHelper(
            EditText ptxtId, EditTextButton ptxtDescription, List<FormatConditionChoose> pFormatConditions,
            TableQuery pQuery, string pFieldId, string pFieldName, string pWindowText, params KeyValuePair<string, Dictionary<object, string>>[] pColumnsParamns
            )
            : this()
        {

            FieldNameId = pFieldId;
            FieldNameDescription = pFieldName;
            WindowText = pWindowText;
            Query = pQuery;
            _formatConditions = pFormatConditions;
            _columnsParamns = pColumnsParamns;
            _txtId = ptxtId;
            _txtDescription = ptxtDescription;

            _ownerForm = ptxtId.FindForm() as Form;


            HandleEditEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptxtId"></param>
        /// <param name="ptxtDescription"></param>
        /// <param name="pFormatConditions"></param>
        /// <param name="pQuery"></param>
        /// <param name="pFieldId"></param>
        /// <param name="pFieldName"></param>
        /// <param name="pWindowText"></param>
        public ChooseFromListHelper(
            EditText ptxtId, EditTextButton ptxtDescription, List<FormatConditionChoose> pFormatConditions,
            TableQuery pQuery, string pFieldId, string pFieldName, string pWindowText
            )
            : this()
        {

            FieldNameId = pFieldId;
            FieldNameDescription = pFieldName;
            WindowText = pWindowText;
            Query = pQuery;
            _formatConditions = pFormatConditions;
            _txtId = ptxtId;
            _txtDescription = ptxtDescription;

            _ownerForm = ptxtId.FindForm() as Form;

            HandleEditEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptxtId"></param>
        /// <param name="ptxtDescription"></param>
        /// <param name="pQuery"></param>
        /// <param name="pConditionQuery"></param>
        /// <param name="pFieldId"></param>
        /// <param name="pFieldName"></param>
        /// <param name="pWindowText"></param>
        public ChooseFromListHelper(
           EditText ptxtId,
           EditTextButton ptxtDescription,
           TableQuery pQuery,
            eCondition pConditionQuery,
           string pFieldId,
           string pFieldName,
           string pWindowText)
            : this(ptxtId, ptxtDescription, pQuery, pFieldId, pFieldName, pWindowText)
        {
            ConditionQuery = pConditionQuery;
        }

        /// <summary>
        /// Construtor para habilitar os recursos de choose em um cenário
        /// </summary>
        /// <param name="idColumn">EditText do ID</param>
        /// <param name="ptxtDescription">EditText do Description</param>
        /// <param name="pQuery">Query que será executada</param>
        /// <param name="pFieldId">Nome Campo do ID</param>
        /// <param name="pFieldName">Nome do Campo do Description</param>
        /// <param name="pWindowText">Nome da Janela quando pesquisa</param>
        public ChooseFromListHelper(
            GridColumn idColumn, GridColumn ptxtDescription,
            TableQuery pQuery, string pFieldId, string pFieldName, string pWindowText)
            : this()
        {

            idColumn.CheckForArgumentNull("ptxtID");

            //this.ChooseButton = pButton;
            FieldNameId = pFieldId;
            FieldNameDescription = pFieldName;
            WindowText = pWindowText;
            Query = pQuery;
            _ownerForm = idColumn.View.GridControl.FindForm() as Form;
            ViewSearch = idColumn.View as GridView;

            CreateOrUpdateChooseButton(idColumn, false);

            idColumn.ColumnEdit.KeyDown += IdColumnEditKeyDown;
            idColumn.ColumnEdit.Leave += IdColumnEditLeave;

            if (ptxtDescription == null)
                return;

            CreateOrUpdateChooseButton(ptxtDescription, true);

            ptxtDescription.ColumnEdit.KeyDown += DescriptionColumnEditKeyDown;
        }

        private void CreateOrUpdateChooseButton(GridColumn gridColumn, Boolean isFieldNameColumn)
        {
            const string strImage64 = @"iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAYdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuNWWFMmUAAAC4SURBVDhPpZKxEcMgDEW9SsbIPFmHNVKmdMkKlJRpKSkpFR534gSBxi7+2aD/vkD2ISJ/cs7JrNmDhoUavf9IjEFKTpJSlBD8MmQAz/PdzDl/G1hKVX2yZp+6DRjABgFsRN0GdJjkFTALX4d54Y7a9fF8bUUdH364ButwbIetqg9/h+2RVx1V6tGj3+98+c63pq3w5e9sA0huITqD+mTNvgUHGFFA/MuYEcPRO1oQDbBKjVazR0SOHx99yDQxYsFkAAAAAElFTkSuQmCC";

            var itemButonEditForGridColumn = gridColumn.ColumnEdit as RepositoryItemButtonEdit;

            if (itemButonEditForGridColumn == null)
            {
                itemButonEditForGridColumn = new RepositoryItemButtonEdit();
                itemButonEditForGridColumn.Buttons.Clear();
                itemButonEditForGridColumn.TextEditStyle = TextEditStyles.Standard;
            }

            var button = new EditorButton
            {
                IsLeft = false
            };

            button.Appearance.Options.UseImage = true;
            button.Kind = ButtonPredefines.Glyph;
            button.Image = strImage64.Base64ToImage();
            button.Tag = "ChooseButton";

            itemButonEditForGridColumn.Buttons.Add(button);
            itemButonEditForGridColumn.ButtonClick += (s, e) =>
            {
                try
                {
                    if (!ReferenceEquals(e.Button.Tag, "ChooseButton"))
                        return;

                    DataRow row = null;

                    Validated = TryGetRecord(isFieldNameColumn, string.Empty, true, ref row);

                    if (Validated)
                        SetRecord(row);

                }
                catch (Exception exception)
                {
                    _ownerForm.ShowMessageError(exception);
                }
            };

            gridColumn.OptionsColumn.AllowEdit = true;
            gridColumn.ColumnEdit = itemButonEditForGridColumn;
            gridColumn.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
        }

        private void CreateOrUpdateChooseButton(TreeListColumn gridColumn, Boolean isFieldNameColumn)
        {
            const string strImage64 = @"iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAYdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuNWWFMmUAAAC4SURBVDhPpZKxEcMgDEW9SsbIPFmHNVKmdMkKlJRpKSkpFR534gSBxi7+2aD/vkD2ISJ/cs7JrNmDhoUavf9IjEFKTpJSlBD8MmQAz/PdzDl/G1hKVX2yZp+6DRjABgFsRN0GdJjkFTALX4d54Y7a9fF8bUUdH364ButwbIetqg9/h+2RVx1V6tGj3+98+c63pq3w5e9sA0huITqD+mTNvgUHGFFA/MuYEcPRO1oQDbBKjVazR0SOHx99yDQxYsFkAAAAAElFTkSuQmCC";

            var itemButonEditForGridColumn = gridColumn.ColumnEdit as RepositoryItemButtonEdit;

            if (itemButonEditForGridColumn == null)
            {
                itemButonEditForGridColumn = new RepositoryItemButtonEdit();
                itemButonEditForGridColumn.Buttons.Clear();
            }

            var button = new EditorButton
            {
                IsLeft = false
            };

            button.Appearance.Options.UseImage = true;
            button.Kind = ButtonPredefines.Glyph;
            button.Image = strImage64.Base64ToImage();
            button.Tag = "ChooseButton";

            itemButonEditForGridColumn.TextEditStyle = TextEditStyles.DisableTextEditor;
            itemButonEditForGridColumn.Buttons.Add(button);
            itemButonEditForGridColumn.ButtonClick += (s, e) =>
            {
                try
                {
                    if (!ReferenceEquals(e.Button.Tag, "ChooseButton"))
                        return;

                    DataRow row = null;

                    Validated = TryGetRecord(isFieldNameColumn, string.Empty, true, ref row);

                    if (Validated)
                        SetRecord(row);

                }
                catch (Exception exception)
                {
                    _ownerForm.ShowMessageError(exception);
                }
            };

            gridColumn.TreeList.RepositoryItems.Add(itemButonEditForGridColumn);

            gridColumn.ColumnEdit = itemButonEditForGridColumn;
            gridColumn.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
        }

        /// <summary>
        /// Construtor para habilitar os recursos de choose em um cenário
        /// </summary>
        /// <param name="idColumn">EditText do ID</param>
        /// <param name="ptxtDescription">EditText do Description</param>
        /// <param name="pFormatConditions">Conjunto de cores personalziadas para grid do choose</param>
        /// <param name="pQuery">Query que será executada</param>
        /// <param name="pFieldId">Nome Campo do ID</param>
        /// <param name="pFieldName">Nome do Campo do Description</param>
        /// <param name="pWindowText">Nome da Janela quando pesquisa</param>
        public ChooseFromListHelper(
           GridColumn idColumn, GridColumn ptxtDescription,
            List<FormatConditionChoose> pFormatConditions,
           TableQuery pQuery, string pFieldId, string pFieldName, string pWindowText
           )
            : this(idColumn, ptxtDescription, pQuery, pFieldId, pFieldName, pWindowText)
        {

            _formatConditions = pFormatConditions;
        }


        /// <summary>
        /// Construtor para habilitar os recursos de choose em um cenário.
        /// </summary>
        /// <param name="pId">Coluna de Código.</param>
        /// <param name="pDescription">Coluna de Descrição.</param>
        /// <param name="pQuery">TableQuery com os filtros.</param>
        /// <param name="pFieldId">Nome da coluna com o código.</param>
        /// <param name="pFieldName">Nome da coluna com a descrição.</param>
        /// <param name="pWindowText">Título da janela.</param>
        public ChooseFromListHelper(
            TreeListColumn pId, TreeListColumn pDescription, TableQuery pQuery,
            string pFieldId, string pFieldName, string pWindowText)
            : this()
        {

            pId.CheckForArgumentNull("pID");

            FieldNameId = pFieldId;
            FieldNameDescription = pFieldName;
            WindowText = pWindowText;
            Query = pQuery;

            _ownerForm = pId.TreeList.FindForm() as Form;
            CreateOrUpdateChooseButton(pId, true);

            // KeyDown
            pId.ColumnEdit.KeyDown += IdColumnEditKeyDown;

            if (pDescription != null)
            {
                CreateOrUpdateChooseButton(pDescription, false);
                pDescription.ColumnEdit.KeyDown += DescriptionColumnEditKeyDown;
            }

            // LostFocus
            pId.ColumnEdit.Leave += IdColumnEditLeave;

            // TODO: Tirar essa gambiarra
            // Seta um valor apenas para não ficar nulo
            ViewSearch = new GridView();
        }

        /// <summary>
        /// Caso for view armazena a view
        /// </summary>
        public GridView ViewSearch { get; set; }

        /// <summary>
        /// Nome do Campo ID 
        /// </summary>
        public string FieldNameId { get; set; }
        /// <summary>
        /// Nome do Campo da Descrição
        /// </summary>
        public string FieldNameDescription { get; set; }

        /// <summary>
        /// Descrição da Janela de Pesquisa
        /// </summary>
        private string WindowText { get; set; }

        /// <summary>
        /// Query de consulta
        /// </summary>
        public TableQuery Query { get; set; }

        /// <summary>
        /// Condição para consulta
        /// </summary>
        public eCondition ConditionQuery { get; set; }

        /// <summary>
        /// Colunas que serão visiveis para o usuário
        /// </summary>
        public List<String> VisbleColumns { get; set; }

        /// <summary>
        /// Colunas que serão pesquisa ao digitar em algum campo
        /// </summary>
        public List<TableAdapterField> WhereColumns { get; set; }

        /// <summary>
        /// Formulário de ChooseFromList
        /// </summary>
        public IChooseFromListFormBase FormChoose { get; set; }

        /// <summary>
        /// Permitir selecionar mais de um item
        /// </summary>
        public bool AllowSelectionsMultiples { get; set; }

        private void HandleEditEvents()
        {
            _txtId.DataType = Query.Fields[FieldNameId]
                                  .DbTypeIsNumeric()
                                  ? BoDataType.dt_LONG_NUMBER
                                  : BoDataType.dt_SHORT_TEXT;

            _txtId.KeyPress += TextIdKeyPress;
            _txtId.LostFocus += TextIdLostFocus;
            _txtId.EditValueChanged += TxtIdEditValueChanged;
            _txtId.PreviewKeyDown += PtxtIdPreviewKeyDown;

            _txtDescription.KeyPress += TextDescriptionKeyPress;
            _txtDescription.LostFocus += TextDescriptionLostFocus;

            _txtDescription.Properties.Buttons[0].Image = Properties.Resources.ChooseFromLstBtn;
            _txtDescription.Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            _txtDescription.ButtonPressed += PtxtDescriptionButtonClick;

            _txtDescription.PreviewKeyDown += TxtDescriptionPreviewKeyDown;

            _txtId.EnabledChanged += TxtIdEnabledChanged;
            _txtDescription.EnabledChanged += TxtDescriptionEnabledChanged;
        }

        void TxtDescriptionEnabledChanged(object sender, EventArgs e)
        {
            _txtId.Enabled = _txtDescription.Enabled;
        }

        void TxtIdEnabledChanged(object sender, EventArgs e)
        {
            _txtDescription.Enabled = _txtId.Enabled;
        }

        void PtxtIdPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                var senderText = sender as EditText;

                if (senderText != null)
                    KeyPress(false, senderText.EditValue, e.KeyCode);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        void PtxtDescriptionButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ChooseButtonClick();
            }
            finally
            {
                _txtDescription.Properties.Buttons[0].Image = Properties.Resources.ChooseFromLstBtn;
            }
        }

        void TxtDescriptionPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                var senderText = sender as EditTextButton;

                if (senderText != null)
                {
                    if (e.KeyCode == Keys.Tab && string.IsNullOrEmpty(senderText.Text))
                        _txtId.EditValue = null;

                    KeyPress(true, senderText.EditValue, e.KeyCode);
                }
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        private void IdColumnEditKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var senderText = sender as TextEdit;

                if (senderText != null)
                    KeyPress(false, senderText.EditValue, e.KeyCode);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        private void DescriptionColumnEditKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                var senderText = sender as TextEdit;

                if (senderText != null)
                    KeyPress(true, senderText.EditValue, e.KeyCode);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        private void IdColumnEditLeave(object sender, EventArgs e)
        {
            try
            {
                var senderText = sender as TextEdit;

                if (senderText != null)
                    LostFocus(false, senderText.EditValue);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        private void TextIdLostFocus(object sender, EventArgs e)
        {
            try
            {
                var senderText = sender as EditText;

                if (senderText != null)
                    LostFocus(false, senderText.EditValue);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        private void TextDescriptionLostFocus(object sender, EventArgs e)
        {
            try
            {
                var senderText = sender as EditTextButton;
                if (senderText != null)
                    LostFocus(true, senderText.EditValue);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        /// <summary>
        /// Comportamento do Choose quando o controle perder o focu
        /// </summary>
        /// <param name="pIsDescriptionField"></param>
        /// <param name="pValue"></param>
        private void LostFocus(bool pIsDescriptionField, object pValue)
        {
            if (!InExecution && !Validated)
            {
                if (!IsEmpty(pValue, pIsDescriptionField))
                {
                    try
                    {
                        InExecution = true;
                        DataRow row = null;
                        Validated = TryGetRecord(pIsDescriptionField, pValue, true, ref row);
                        if (Validated)
                            SetRecord(row);
                    }
                    finally
                    {
                        InExecution = false;
                    }
                }
            }
        }

        void TextIdKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                var senderText = sender as EditText;

                if (senderText != null)
                    KeyPress(false, senderText.EditValue, (Keys)e.KeyChar);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        void TextDescriptionKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                var senderText = sender as EditTextButton;

                if (senderText != null)
                    KeyPress(true, senderText.EditValue, (Keys)e.KeyChar);
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        private void KeyPress(bool pIsDescriptionField, object pValue, Keys pKeyPress)
        {
            _editValueChangedByKeyDown = true;

            try
            {
                if (pKeyPress == Keys.Return || pKeyPress == Keys.Tab)
                {
                    InExecution = true;
                    DataRow row = null;
                    Validated = TryGetRecord(pIsDescriptionField, pValue, true, ref row);
                    if (Validated)
                        SetRecord(row);
                }
                else
                {
                    Validated = false;
                }
            }
            finally
            {
                InExecution = false;
            }
        }

        void TxtIdEditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var senderText = sender as EditText;
                if (senderText != null)
                {
                    var isIdEmpty = IsEmpty(senderText.EditValue, false);

                    if (isIdEmpty && !IsEmpty(_txtDescription.Text, true))
                        _txtDescription.Text = string.Empty;

                    if (!_editValueChangedByKeyDown && !isIdEmpty)
                    {
                        DataRow row = null;
                        Validated = TryGetRecord(false, senderText.EditValue, false, ref row);
                        if (Validated)
                            SetRecord(row);
                    }
                }
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
        }

        void ChooseButtonClick()
        {
            try
            {
                InExecution = true;

                var args = new ChooseFromListEventArgs
                {
                    Cancel = false,
                    SearchBy = string.Empty
                };

                if (BeforeTryGetRecord != null)
                    BeforeTryGetRecord(this, args);

                if (args.Cancel)
                    return;

                if (!GetBySearchForm(FieldNameDescription, ref args))
                    return;

                _editValueChangedByKeyDown = true;
                Validated = true;

                if (AfterTryGetRecord != null)
                    AfterTryGetRecord(this, args);

                if (!args.Cancel)
                    SetRecord(args.Record);

                _editValueChangedByKeyDown = false;
            }
            catch (Exception ex)
            {
                _ownerForm.ShowMessageError(ex);
            }
            finally
            {
                InExecution = false;
            }
        }

        private bool IsEmpty(object pTextEditValue, bool pIsDescriptionField)
        {
            if (pTextEditValue == null)
                return true;

            var fieldName = pIsDescriptionField ? FieldNameDescription : FieldNameId;

            if (Query.Fields[fieldName].DbTypeIsNumeric())
                return pTextEditValue.To<Int64>() == 0;

            return string.IsNullOrEmpty(pTextEditValue.ToString());
        }

        private void SetRecord(DataRow row)
        {
            if (ViewSearch != null)
            {
                ViewSearch.RefreshEditor(true);
                return;
            }


            _txtId.EditValue = row.Field<Object>(FieldNameId);
            _txtDescription.EditValue = row.Field<Object>(FieldNameDescription);
        }

        /// <summary>
        /// Tenta obter um registro através da pesquisa passada
        /// </summary>
        /// <param name="pIsDescriptionField">O Campo Id é descrição do texto</param>
        /// <param name="pTextSearch">Texto de Pesquisa</param>
        /// <param name="pShowForm">Exibir formulário</param>
        /// <param name="pRow">Linha Corrente de pesquisa</param>
        /// <returns></returns>
        protected bool TryGetRecord(bool pIsDescriptionField, object pTextSearch, bool pShowForm, ref DataRow pRow)
        {
            var args = new ChooseFromListEventArgs { Cancel = false, SearchBy = pTextSearch };

            if (BeforeTryGetRecord != null)
                BeforeTryGetRecord(this, args);

            if (args.Cancel)
                return false;

            var fieldName = pIsDescriptionField ? FieldNameDescription : FieldNameId;

            if (!HasOneLine(fieldName, ref args))
            {
                if (!pShowForm)
                    return false;

                if (!GetBySearchForm(fieldName, ref args))
                    return false;
            }

            if (AfterTryGetRecord != null)
                AfterTryGetRecord(this, args);

            pRow = args.Record;

            return !args.Cancel;
        }



        /// <summary>
        /// Pega o registro através do formulário
        /// </summary>
        /// <param name="pFieldName">Nome do Campo que está sendo pesquisado</param>
        /// <param name="args">Argumentos do Evento gerado</param>
        /// <returns>True se pesquisou com sucesso</returns>
        private bool GetBySearchForm(string pFieldName, ref ChooseFromListEventArgs args)
        {

            try
            {
                IChooseFromListFormBase form;

                if (FormChoose == null)
                    form = _formatConditions == null
                        ? new ChooseFromListForm()
                        : new ChooseFromListForm(_formatConditions, _columnsParamns);
                else
                    form = FormChoose.GetType().Assembly.CreateInstance(FormChoose.GetType().FullName) as IChooseFromListFormBase;

                Debug.Assert(form != null, "form != null");

                form.AllowSelectionsMultiples = AllowSelectionsMultiples;
                form.Query = Query;
                form.Text = WindowText;
                form.SearchBy = args.SearchBy == null ? String.Empty : args.SearchBy.ToString();
                form.VisbleColumns = VisbleColumns;
                form.SearchColumns.Add(Query.Fields.FirstOrDefault(p => p.Name.Equals(pFieldName)));
                form.SearchColumns.AddRange(WhereColumns);

                if (args.Record == null && _txtId != null)
                {
                    var argForCurrentRecord = new ChooseFromListEventArgs
                    {
                        Cancel = false,
                        SearchBy = _txtId.EditValue
                    };

                    HasOneLine(FieldNameId, ref argForCurrentRecord);
                    form.Record = argForCurrentRecord.Record;
                }

                //form.ViewResult.FocusedColumn = ViewResult.Columns[pFieldName];
                if (form.ShowDialog(_ownerForm) == DialogResult.OK)
                {
                    args.Record = form.Record;
                    args.Records = form.Records;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                _ownerForm.Select();
            }

        }

        private bool HasOneLine(string pFieldName, ref ChooseFromListEventArgs e)
        {
            var query = new TableQuery(Query) { Top = 2 };

            var serarchField = new List<TableAdapterField>
                                   {
                                       query.Fields[pFieldName]
                                   };

            if (pFieldName == FieldNameDescription)
                serarchField.AddRange(WhereColumns);

            var where = new WhereCollection();

            foreach (var column in serarchField)
            {
                where.Add(column.DbTypeIsNumeric()
                    ? new QueryParam(column, e.SearchBy == null ? 0 : e.SearchBy.To<Int64>())
                               : new QueryParam(column, e.SearchBy ?? string.Empty));

                where.Last().Relationship = eRelationship.erOr;

                if (ConditionQuery != eCondition.ecNone)
                    where.Last().Condition = ConditionQuery;

            }

            query.Wheres.Add(where);

            var script = new SqlServerScriptWizard(query);

            var command = script.GetSelectStatment();
            var data = Connection.Instance.SqlServerQuery(command.Item1, command.Item2);

            if (data.Rows.Count == 1)
            {
                e.Record = data.Rows[0];
            }
            else
            {

                serarchField = new List<TableAdapterField> { query.Fields[pFieldName] };

                if (pFieldName == FieldNameDescription)
                    serarchField.AddRange(WhereColumns);

                where = new WhereCollection();

                foreach (var column in serarchField)
                {
                    @where.Add(column.DbTypeIsNumeric()
                                   ? new QueryParam(column, e.SearchBy == null ? 0 : e.SearchBy.To<Int64>())
                                   : new QueryParam(column, eCondition.ecLike, e.SearchBy ?? String.Empty));

                    where.Last().Relationship = eRelationship.erOr;
                }

                query.Wheres.Add(where);

                var comand = script.GetSelectStatment();
                data = Connection.Instance.SqlServerQuery(comand.Item1, comand.Item2);

                if (data.Rows.Count == 1)
                    e.Record = data.Rows[0];


            }

            return data.Rows.Count == 1;
        }

    }
}
