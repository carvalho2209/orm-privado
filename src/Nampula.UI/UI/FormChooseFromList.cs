using System;
using System.Data;
using System.Windows.Forms;
using Nampula.DI;


namespace Nampula.UI
{

    /// <summary>
    /// Formulário de ChooseFromList
    /// </summary>
    /// <typeparam name="TT"></typeparam>
    public partial class FormChooseFromList<TT> : Form where TT : TableAdapter, new()
    {

        /// <summary>
        /// 
        /// </summary>
        public FormChooseFromList()
        {
            InitializeComponent();
            Collumns = new TableAdapterFieldCollection();
        }

        private void FillResult()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                TT myTableAdapter = TableAdapter;

                var myQuery = new TableQuery(TableQuery);

                if (!String.IsNullOrEmpty(txtSearch.Text))
                    TableQuery.Where.Add(
                        new QueryParam(DefaultSearch, txtSearch.Text));

                myQuery.OrderBy.Add(
                    new OrderBy(
                        new QueryParam(DefaultSearch)));

                DataTable data = myTableAdapter.GetData(myQuery);
                grdResult.DataSource = data;
                ViewResult.BestFitColumns();

                if (!string.IsNullOrEmpty(DefaultSearch.Name))
                    ViewResult.FocusedColumn = ViewResult.Columns[DefaultSearch.Name];

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void SetCollumns()
        {
            if (Collumns.Count == 0)
                Collumns.AddRange(TableQuery.Fields);

            foreach (TableAdapterField item in Collumns)
            {
                ViewResult.Columns.AddVisible(
                    String.IsNullOrEmpty(item.Alias) ? item.Name : item.Alias, 
                    item.Description);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TableAdapterFieldCollection Collumns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TableAdapterField DefaultSearch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TableQuery TableQuery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TableAdapterFieldCollection ChooseCollumns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TT TableAdapter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TT SelectedRow { get; set; }

        private void CmdCancelarClick(object sender, EventArgs e)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParent"></param>
        /// <returns></returns>
        public new DialogResult ShowDialog(Form pParent)
        {
            SetCollumns();
            FillResult();
            return base.ShowDialog(pParent);
        }

        private void CmdOkClick(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private bool Save()
        {
            if (ViewResult.GetFocusedDataSourceRowIndex() < 0)
                throw new Exception("Selecione um item na linha");

            SelectedRow = new TT();
            SelectedRow.CopyBy(TableAdapter);

            SelectedRow.FillFields(((DataTable)grdResult.DataSource).Rows[ViewResult.GetFocusedDataSourceRowIndex()]);

            return true;
        }

        private void TxtSearchEditValueChanged(object sender, EventArgs e)
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

        private void FormChooseFromListLoad(object sender, EventArgs e)
        {
            if ((grdResult.DataSource as DataTable).Rows.Count > 0)
                grdResult.Select();
            else
                txtSearch.Select();
        }

        private void GrdResultKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    CmdOkClick(sender, e);
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

        /// <summary>
        /// 
        /// </summary>
        public string SearchBy
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        private void GrdResultDoubleClick(object sender, EventArgs e)
        {
            CmdOkClick(sender, e);
        }

    }
}