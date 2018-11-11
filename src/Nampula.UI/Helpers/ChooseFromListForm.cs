using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Nampula.DI;
using Nampula.UI.Helpers.Extentions;
using Nampula.DI.ScriptWizard;
using Nampula.Framework;
using DevExpress.XtraGrid.Views.Base;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Formulário para comportamento de selecionar um item na lista (ChooseFromList SDK do SAP)
    /// </summary>
    public partial class ChooseFromListForm : Nampula.UI.Form, IChooseFromListFormBase
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ChooseFromListForm()
        {
            InitializeComponent();
            VisbleColumns = new List<string>();
            SearchColumns = new List<TableAdapterField>();
            Conditions = new List<FormatConditionChoose>();
            ColumnsParameters = new KeyValuePair<string, Dictionary<object, string>>[] { };
            grdResult.DoubleClick += grdResult_DoubleClick;
            ViewResult.StartSorting += ViewResult_StartSorting;

            grdResult.DontSavePosition = true;
        }

        /// <summary>
        /// Construdor
        /// </summary>
        /// <param name="pFormatConditions"></param>
        public ChooseFromListForm(List<FormatConditionChoose> pFormatConditions, KeyValuePair<string, Dictionary<object, string>>[] pColumParam = null)
            : this()
        {
            Conditions = pFormatConditions;
            ColumnsParameters = pColumParam ?? new KeyValuePair<string, Dictionary<object, string>>[] { };
        }
        

        void grdResult_DoubleClick(object sender, EventArgs e)
        {
            cmdOk_Click(sender, e);
        }

        private void FillResult()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var query = new TableQuery(Query);

                if (!String.IsNullOrEmpty(SearchBy))
                {
                    var where = new WhereCollection();
                    foreach (var item in SearchColumns)
                    {
                        QueryParam param;

                        if (item.DbTypeIsNumeric())
                        {
                            int intConvert;

                            if (!int.TryParse(SearchBy, out intConvert))
                                continue;

                            param = new QueryParam(item, intConvert);
                        }
                        else
                        {
                            param = new QueryParam(item, eCondition.ecLike, SearchBy);
                        }

                        param.Relationship = eRelationship.erOr;
                        where.Add(param);

                        query.OrderBy.Add(new OrderBy(param));
                    }
                    query.Wheres.Add(where);
                }

                var command = new SqlServerScriptWizard(query).GetSelectStatment();
                grdResult.DataSource = Connection.Instance.SqlServerQuery(command.Item1, command.Item2);
                ViewResult.BestFitColumns();

                ViewResult.ClearSorting();

                if (!SearchColumns.IsEmpty())
                {
                    ViewResult.FocusedColumn = ViewResult.Columns[SearchColumns.First().Name];
                    ViewResult.FocusedColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                    if (Record != null)
                    {
                        var fieldValue = Record[ViewResult.FocusedColumn.FieldName].ToString();
                        ViewResult.StartIncrementalSearch(fieldValue);
                    }
                }

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void SetCollumns()
        {
            if (VisbleColumns.Count == 0)
            {
                ViewResult.FormatGrid(Query.Fields, ColumnsParameters);
            }
            else
            {
                var columns = Query.Fields.Where(p => VisbleColumns.Any(v => v == p.Name));
                var col = new TableAdapterFieldCollection();
                col.AddRange(columns);
                ViewResult.FormatGrid(col);
            }

            ViewResult.FocusedColumn = SearchColumns.IsEmpty()
                ? ViewResult.Columns[0]
                : ViewResult.Columns[SearchColumns.First().Name];

            ViewResult.SetColors();
            ViewResult.FormatConditions.Clear();

            foreach (var item in Conditions)
            {
                var col = ViewResult.Columns[item.ColumnName];

                if (col == null)
                    continue;

                var scon = new DevExpress.XtraGrid.StyleFormatCondition(
                    item.FormatConditionEnum,
                    col,
                    null,
                    item.val1,
                    item.val2,
                    item.applyToRow);

                scon.Appearance.BackColor = item.BackColor;
                scon.Appearance.ForeColor = item.ForeColor;
                ViewResult.FormatConditions.Add(scon);
            }
            
        }

        public bool AllowSelectionsMultiples
        {
            get
            {
                return ViewResult.OptionsSelection.MultiSelect;
            }
            set
            {
                ViewResult.OptionsSelection.MultiSelectMode = value
                    ? GridMultiSelectMode.CheckBoxRowSelect
                    : GridMultiSelectMode.RowSelect;

                ViewResult.OptionsSelection.CheckBoxSelectorColumnWidth = 20;

                ViewResult.OptionsSelection.MultiSelect = value;
            }
        }

        /// <summary>
        /// Exibe a tela e so continua a execução depois que a tela for fechada
        /// </summary>
        /// <param name="pParent">Formulário Superior</param>
        /// <returns>O Resultado do Dialogo</returns>
        public new DialogResult ShowDialog(Form pParent)
        {
            SetSearchInformation();
            return base.ShowDialog(pParent);
        }

        private void SetSearchInformation()
        {
            txtSearch.Text = SearchBy;
            SetCollumns();
            FillResult();
        }

        /// <summary>
        /// Exibe a tela e so continua a execução depois que a tela for fechada
        /// </summary>
        public new void Show()
        {
            SetSearchInformation();
            base.Show();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                SetSelectedRow();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void SetSelectedRow()
        {
            if (AllowSelectionsMultiples)
            {
                Records = ViewResult
                    .GetSelectedRows()
                    .Select(rowHandle => ViewResult.GetDataRow(rowHandle))
                    .ToArray();

                if (Records.IsEmpty())
                    throw new Exception("Selecione um item na linha!");

                Record = Records[0];
            }
            else
            {
                if (ViewResult.FocusedRowHandle < 0)
                    throw new Exception("Selecione um item na linha!");

                Record = ViewResult.GetFocusedDataRow();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ViewResult.StartIncrementalSearch(txtSearch.Text);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void FormChooseFromList_Load(object sender, EventArgs e)
        {
            if ((grdResult.DataSource as DataTable).Rows.Count > 0 && !string.IsNullOrEmpty(txtSearch.Text))
                grdResult.Select();
            else
                txtSearch.Select();
        }

        private void grdResult_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    cmdOk_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    e.Handled = true;
                    txtSearch.Focus();
                }

            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        e.Handled = true;
                        grdResult.Focus();
                        break;
                    case Keys.Return:
                        e.Handled = true;
                        SearchBy = txtSearch.Text;
                        FillResult();
                        FormChooseFromList_Load(sender, e);
                        break;
                    case Keys.Escape:
                        e.Handled = true;
                        DialogResult = DialogResult.Cancel;
                        Close();
                        break;

                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }



        /// <summary>
        /// Registro selecionado
        /// </summary>
        public DataRow Record { get; set; }

        public DataRow[] Records { get; set; }

        /// <summary>
        /// TableQuery do objeto
        /// </summary>
        public TableQuery Query { get; set; }
        /// <summary>
        /// Qual o nome da coluna será considerda na pesquisa
        /// </summary>
        public string SearchBy { get; set; }
        /// <summary>
        /// Lista de colunas visiveis
        /// </summary>
        public List<string> VisbleColumns { get; set; }
        /// <summary>
        /// Colunas que serão pesquisdas
        /// </summary>
        public List<TableAdapterField> SearchColumns { get; set; }


        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void ViewResult_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            if (Visible | SearchColumns.IsEmpty())
                SetSeachColumn(e.FocusedColumn.FieldName);
        }

        private void SetSeachColumn(string pFieldName)
        {
            var column = Query.Fields.FirstOrDefault(c => c.Name == pFieldName);

            if (column != null)
            {
                SearchColumns = new List<TableAdapterField>{
                    column
                };
            }
        }

        private List<FormatConditionChoose> Conditions { get; set; }
        private KeyValuePair<string, Dictionary<object, string>>[] ColumnsParameters { get; set; }


        void ViewResult_StartSorting(object sender, EventArgs e)
        {
            if (ViewResult.SortedColumns.Count > 0)
                SetSeachColumn(ViewResult.SortedColumns[0].FieldName);
        }
    }
}
