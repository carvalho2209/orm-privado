using System;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using Nampula.DI;
using Nampula.DI.Logs;
using Nampula.UI;
using Nampula.UI.Helpers.Extentions;

namespace Nampula.UI.Helpers.Extentions
{
    public partial class DifferencesForm : Nampula.UI.Form
    {
        
        public DifferencesForm(List<LogDifferences> pTableLog)
        {
            InitializeComponent();

            FormatGrid(pTableLog);

            okButton.Click += new System.EventHandler(cmdOK_Click);
        }

        void cmdOK_Click(object sender, System.EventArgs e)
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

        private void FormatGrid(List<LogDifferences> pTableLog)
        {
            diffView.FormatGrid(new LogDifferences().Collumns);

            diffGrid.DataSource = pTableLog;
            diffView.BestFitColumns();
        }
    }
}
