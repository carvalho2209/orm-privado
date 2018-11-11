using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nampula.DI;

namespace Nampula.UI
{
    public partial class frmServer : Form
    {

        public frmServer()
        {
            InitializeComponent();
            Param = new ConnectionParameter(Connection.Instance.ConnectionParameter);
            FillControls();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
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
                if (TestConnection())
                {
                    Connection.Instance.ConnectionParameter = Param;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        ConnectionParameter Param { get; set; }

        private bool TestConnection()
        {

            FillCass();

            var myConnec =
                Connection.Instance.Clone() as Connection;

            myConnec.ConnectionParameter = Param;

            return myConnec.Connect();
        }

        private void FillControls()
        {
            txtServer.Text = Param.Server;
            txtDBPassword.Text = Param.DBPassword;
            txtDBUser.Text = Param.DBUser;
        }

        private void FillCass()
        {
            Param.Server = txtServer.Text;
            Param.DBPassword = txtDBPassword.Text;
            Param.DBUser = txtDBUser.Text;
        }

    }
}
