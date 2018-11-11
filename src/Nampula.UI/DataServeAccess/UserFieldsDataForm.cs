using System;
using Nampula.Framework;

namespace Nampula.UI.SqlUserLoggin
{
    partial class UserFieldsDataForm : Form
    {
        public UserFieldsData _user = new UserFieldsData();
        public SqlUserProvider _sqlUserProvider;

        public UserFieldsDataForm(UserFieldsData user, SqlUserProvider sqlUserProvider)
        {
            InitializeComponent();

            _user = user;
            _sqlUserProvider = sqlUserProvider;

            FillControls();
        }

        private void FillControls()
        {
            txtUser.Text = _user.UserName ;            
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                FillClass();

                _user.Validate();

                if (!_sqlUserProvider.TestConnection(_user))
                    throw new Exception("Não foi possível logar com o usuário [{0}] e a senha informada.".Fmt(_user.UserName));

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();

                ShowSucessfullMessage();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void FillClass()
        {
            _user.UserName = txtUser.Text.Trim();
            _user.PassWord = txtPassword.Text.Trim();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }
    }
}
