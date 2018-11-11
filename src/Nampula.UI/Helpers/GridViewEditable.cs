using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using Nampula.UI.Helpers.Extentions;
using System.Windows.Forms;
using Nampula.Framework;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Tem como objetivo gerenciar grids de configurações, Exemplo: Grupo de Parceiro, 
    /// </summary>
    /// <typeparam name="t">Um Table Adapter</typeparam>
    public class GridViewEditable<t> where t : TableAdapter, new()
    {

        /// <summary>
        /// Evento disparado quando há uma alteração na coleção de registro (Remoção, Alteração, Adição e Atualização)
        /// </summary>
        public event EventHandler OnChangeList;

        /// <summary>
        /// Evento disparado quando há uma adição na lista
        /// </summary>
        public event EventHandler<GridViewEditableEventArgs> OnAddList;

        /// <summary>
        /// Evento disparado quando há uma remoção de um item da lista
        /// </summary>
        public event EventHandler<GridViewEditableEventArgs> OnRemoveList;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="pGridView"></param>
        /// <param name="cmdOk"></param>
        /// <param name="cmdCancel"></param>
        /// <param name="pEditableColumns"></param>
        public GridViewEditable(
            GridView pGridView,
            List<t> pLines,
            params KeyValuePair<string, Dictionary<object, string>>[] pColumns
            )
        {
            GridView = pGridView;
            SetOptions();
            this.Lines = pLines;
            this.Columns = pColumns.ToList();
            InitializeBeahvior();
        }

        /// <summary>
        /// Atribui as opções das opções
        /// </summary>
        private void SetOptions()
        {
            this.GridView.OptionsCustomization.AllowFilter = false;
            this.GridView.OptionsCustomization.AllowGroup = false;
            this.GridView.OptionsCustomization.AllowSort = false;

            this.GridView.OptionsDetail.EnableMasterViewMode = false;
            this.GridView.OptionsDetail.ShowDetailTabs = false;
            this.GridView.OptionsDetail.SmartDetailExpand = false;
            this.GridView.OptionsDetail.SmartDetailExpandButtonMode = DetailExpandButtonMode.Default;
            this.GridView.OptionsDetail.SmartDetailHeight = false;
        }



        /// <summary>
        /// GridView daas Colunas
        /// </summary>
        public GridView GridView { get; set; }
        /// <summary>
        /// Linhas da grid
        /// </summary>
        public IList<t> Lines { get; set; }
        /// <summary>
        /// Lista de Colunas de Relação com outras colunas
        /// </summary>
        public List<KeyValuePair<string, Dictionary<object, string>>> Columns { get; set; }
        private BaseEdit AtiveEditor;

        public bool InactiveBestFitColumns { get; set; }

        /// <summary>
        /// Inicializar o processamento de todo o comportamento da tela
        /// </summary>
        private void InitializeBeahvior()
        {
            var obj = new t();

            //if (obj.KeyFields.IsEmpty())
            //    ExpHelper.ThrowException("O objeto [{1}] deve ter chave primária", obj.ToString());

            //if (obj.KeyFields.Count > 1 || !obj.KeyFields.First().DbTypeIsNumeric())
            //    ExpHelper.ThrowException("O objeto [{0}] deve ter apenas uma chave primária e do tipo inteiro", obj.ToString());

            FormatControls();
            FillAll();
        }

        private void FormatControls()
        {
            if (Columns != null)
                GridView.FormatGrid(new t().Collumns, Columns.ToArray());
            else
                GridView.FormatGrid(new t().Collumns);

            //GridView.CellValueChanged += new CellValueChangedEventHandler( GridView_CellValueChanged );
            GridView.ShownEditor += new EventHandler(GridView_ShownEditor);
            GridView.HiddenEditor += new EventHandler(GridView_HiddenEditor);

            CreatePopupMenu();
        }

        void GridView_HiddenEditor(object sender, EventArgs e)
        {
            if (AtiveEditor != null)
                AtiveEditor.EditValueChanged -= new EventHandler(AtiveEditor_EditValueChanged);
            FillAll();
        }

        void AtiveEditor_EditValueChanged(object sender, EventArgs e)
        {
            t CurrentLine = GridView.GetSelected<t>();

            //Verifica se o registro á o último se for
            //adicina a lista 
            switch (CurrentLine.StateRecord)
            {
                case eState.eAdd:
                    {
                        var line = Lines.IndexOf(CurrentLine);

                        if (line < 0)
                        {
                            //var nextID = Lines.Count == 0 ? 1 : Lines.Max(p => p.KeyFields[0].GetInt32()) + 1;
                            //CurrentLine.KeyFields[0].Value = nextID;

                            if (OnAddList != null)
                            {
                                var args = new GridViewEditableEventArgs() { item = CurrentLine };
                                OnAddList(this, args);
                                if (args.Cancel)
                                    return;
                            }

                            if (!Lines.Contains(CurrentLine))
                                Lines.Add(CurrentLine);
                        }
                    }
                    break;
                case eState.eDatabase:
                    CurrentLine.StateRecord = eState.eUpdate;
                    break;
            }

            if (OnChangeList != null)
                OnChangeList(this, new EventArgs());
        }

        void GridView_ShownEditor(object sender, EventArgs e)
        {
            AtiveEditor = GridView.ActiveEditor;
            AtiveEditor.EditValueChanged += new EventHandler(AtiveEditor_EditValueChanged);
        }

        private ToolStripItem _removeMenu;

        /// <summary>
        /// Cria o menu popup da grid
        /// </summary>
        private void CreatePopupMenu()
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.Opening += new System.ComponentModel.CancelEventHandler(contextMenu_Opening);
            _removeMenu = contextMenu.Items.Add("Remover Linha", null, RemoveLine);
            GridView.GridControl.ContextMenuStrip = contextMenu;
        }

        void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _removeMenu.Enabled = !ReadOnly;
        }

        private void RemoveLine(object sender, EventArgs e)
        {
            var current = GridView.GetSelected<t>();

            if (current.StateRecord == eState.eAdd && Lines.IndexOf(current) < 0)
            {
                if (OnRemoveList != null)
                {
                    var args = new GridViewEditableEventArgs() { item = current };
                    OnRemoveList(this, args);

                    if (args.Cancel)
                        return;
                }

                Lines.Remove(current);
            }
            else
            {
                if (OnRemoveList != null)
                {
                    var args = new GridViewEditableEventArgs() { item = current };
                    OnRemoveList(this, args);

                    if (args.Cancel)
                        return;
                }

                current.StateRecord = eState.eRemove;
            }

            FillAll();

            if (OnChangeList != null)
                OnChangeList(this, new EventArgs());
        }

        public void FillAll()
        {
            try
            {
                GridView.BeginUpdate();

                var focusedRow = GridView.FocusedRowHandle;

                var lineTotShow = this.Lines.Where(c => c.StateRecord != eState.eRemove).ToList();

                if (!ReadOnly)
                {
                    lineTotShow.Add(new t());
                    lineTotShow.Last().StateRecord = eState.eAdd;
                }

                GridView.GridControl.DataSource = null;
                GridView.GridControl.DataSource = lineTotShow;

                if (!this.InactiveBestFitColumns)
                    GridView.BestFitColumns();

                if (focusedRow >= 0)
                {
                    GridView.FocusedRowHandle = focusedRow;
                }
            }
            finally
            {
                GridView.EndUpdate();
                GridView.RefreshData();
            }
        }

        private bool _readOnly;
        /// <summary>
        /// Determina que a grid será para leitura apenas
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
                FillAll();
            }
        }
    }
}
