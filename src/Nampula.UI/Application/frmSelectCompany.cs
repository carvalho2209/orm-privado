using System;
using System.Data;
using System.Windows.Forms;
using Nampula.DI;
using Nampula.UI.Helpers.Extentions;
using Nampula.DI.B1;
using Nampula.Framework;

namespace Nampula.UI
{

    public partial class frmSelectCompany : Form
    {

        public frmSelectCompany()
        {
            InitializeComponent();

            FormatCompany();
            FillServerType();
            FillControls();
        }

        private void FormatCompany()
        {
            var company = new CompanyDb(true);
            ViewCompany.FormatGrid(company.Collumns);
        }

        public void FillControls()
        {
            var myParam = Connection.Instance.ConnectionParameter;

            txtServerName.Text = myParam.Server;
            txtUserName.Text = myParam.UserName;
            txtPassword.Text = myParam.Password;
            cboServerType.Select(myParam.DbServerType.To<Int32>(), BoSearchKey.psk_ByValue);

            FillCompanies();

        }

        private void FillCompanies()
        {
            if (!IsConnected())
                return;

            var myCompany = new CompanyDb();
            grdCompany.DataSource = myCompany.GetAll().ToDataTable();
        }

        private static bool IsConnected()
        {
            var myParam = Connection.Instance.ConnectionParameter;

            return !String.IsNullOrEmpty(myParam.Server)
                && !String.IsNullOrEmpty(myParam.DBUser)
                && !String.IsNullOrEmpty(myParam.DBPassword);
        }

        private void FillServerType()
        {
            foreach (var item in Enum.GetValues(typeof(eDataServerType)))
            {
                cboServerType.ValidValues.Add(item.To<Int32>(), item.ToString());
            }
            cboServerType.Select(eDataServerType.SqlServer2005.To<Int32>(), BoSearchKey.psk_ByValue);
        }

        private void cmdServer_Click(object sender, EventArgs e)
        {
            try
            {
                ShowServer();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void ShowServer()
        {
            FillClass(false);
            var myFowm = new frmServer();

            if (myFowm.ShowDialog(this) == DialogResult.OK)
            {
                FillControls();
            }
        }

        private void FillClass(bool pShowMessage)
        {
            var myParam = Connection.Instance.ConnectionParameter;

            myParam.UserName = txtUserName.Text;
            myParam.Password = txtPassword.Text;
            myParam.DbServerType = (eDataServerType)cboServerType.Selected.Value.To<Int32>();
            myParam.CompanyDb = GetSelectedCompany(pShowMessage);
            myParam.LicenseServer = GetLicenseServer();

        }

        private static string GetLicenseServer()
        {
            return IsConnected() ? 
                new LicenseServer().GetByLienseServer() 
                : string.Empty;
        }

        private string GetSelectedCompany(bool pMessage)
        {

            if (ViewCompany.FocusedRowHandle < 0)
            {
                if (pMessage)
                    throw new Exception("Não ha empresa selecionada");
                return string.Empty;
            }

            return ViewCompany.GetDataRow(ViewCompany.FocusedRowHandle).Field<string>(CompanyDb.FieldsName.dbName);
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                FillCompanies();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
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

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TestConnection()) return;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private bool TestConnection()
        {

            FillClass(true);

            if (Connection.Instance.Connect())
            {
                return ApplicationWinForm.ConnectToDI(true);
            }

            return false;

        }
    }
}
