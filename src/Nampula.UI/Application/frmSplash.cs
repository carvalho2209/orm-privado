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

    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void cmdCompany_Click(object sender, EventArgs e)
        {
            try
            {
                ShowCompany();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void ShowCompany()
        {

            FillClass();

            frmSelectCompany myForm = new frmSelectCompany();

            this.Visible = false;

            if (myForm.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Visible = true;
            }
        }

        private void cmdEnd_Click(object sender, EventArgs e)
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
                if (Connect())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private bool Connect()
        {
            FillClass();
            if (Connection.Instance.Connect())
            {
                return ApplicationWinForm.ConnectToDI(true);
            }
            else
            {
                return false;
            }
        }

        private void FillClass()
        {
            var param = Connection.Instance.ConnectionParameter;

            param.UserName = txtUserName.Text;
            param.Password = txtPassword.Text;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                    cmdOk_Click(cmdOk, e);
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }
    }
}
