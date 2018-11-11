using System;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using Nampula.DI;
using Nampula.DI.B1.UserPermissions;
using Nampula.DI.Logs;
using Nampula.UI.Permissions;
using BoFormMode = Nampula.UI.BoFormMode;
using Nampula.UI.Helpers.Extentions;

namespace Nampula.UI.Helpers.Extentions
{
    public partial class ChangeLogForm : Nampula.UI.Form
    {
        private TableAdapterLog _tableAdapter = null;

        public ChangeLogForm(TableAdapter pTableAdapter)
        {
            if (!pTableAdapter.AutoLog)
                throw new Exception(string.Format("Entidade {0} não controla log", pTableAdapter.TableName));
            _tableAdapter = new TableAdapterLog(pTableAdapter);

            InitializeComponent();
            InitilizeForm();
            SetEvents();
        }

        private void InitilizeForm()
        {
            FormatControls();
            FormatGrid();
            FillLogs();
        }

        private void FormatControls()
        {
            this.KeyPreview = true;
            this.AutoSize = true;
            this.AcceptButton = OkButton;
        }

        private void FormatGrid()
        {
            var tableAdapterFields = _tableAdapter.GetLogFields();
            var pTableColumns = new TableAdapterFieldCollection();

            foreach (var field in tableAdapterFields)
                pTableColumns.Add(field);

            logView.FormatGrid(pTableColumns);

            logView.OptionsSelection.MultiSelect = true;

            SetColumnsNoEditable(logView);
        }

        private void FillLogs()
        {
            var logs = _tableAdapter.GetByBaseId();

            logGrid.DataSource = logs;
            logView.BestFitColumns();
        }

        private void SetColumnsNoEditable(GridView pViewLog)
        {
            var collumns = _tableAdapter.GetLogFields();
            var list = new List<string>();

            foreach (var logField in collumns)
                list.Add(logField.Name);

            pViewLog.SetEditable(list, false);
        }

        private void SetEvents()
        {
            OkButton.Click += cmdOK_Click;
            ViewDiffButton.Click += ViewDiffButton_Click;
            logView.RowClick += logView_RowClick;
        }

        void logView_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                var selectedRows = logView.GetSelectedData();

                ViewDiffButton.Enabled = false;
                ViewDiffButton.Enabled = (selectedRows.Length <= 2);
            }
            catch (Exception exception)
            {
                ShowMessageError(exception);
            }
        }

        void ViewDiffButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDifferencesFormViewMode();
            }
            catch (Exception exception)
            {
                ShowMessageError(exception);
            }
        }

        private void ShowDifferencesFormViewMode()
        {
            var differences = new List<LogDifferences>();

            var selectedRows = logView.GetSelectedData();
            var dataTable = _tableAdapter.GetByBaseId();

            if (selectedRows.Length == 1)
                differences = _tableAdapter.GetDiffStartBy(selectedRows[0]);
            else if (selectedRows.Length == 2)
            {
                var selectedRow1 = selectedRows[0];
                var selectedRow2 = selectedRows[1];
                differences = _tableAdapter.GetDiff(dataTable, selectedRow1, selectedRow2);
            }
            else
                throw new Exception("Selecione no máximo duas linhas.");

            var form = new DifferencesForm(differences);
            form.Show();
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception exception)
            {
                ShowMessageError(exception);
            }
        }
    }
}
