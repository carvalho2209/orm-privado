using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nampula.UI.DinamicInterface
{
    /// <summary>
    /// Tela para determinas a descrição de um controle / coluna na tela
    /// </summary>
    internal partial class frmSettingDescription : Nampula.UI.Form
    {
        /// <summary>
        /// Model Corrente
        /// </summary>
        UserControlProperty tblObj = null;

        /// <summary>
        /// Ctr
        /// </summary>
        public frmSettingDescription(UserControlProperty pUserControl, string pDesc)
        {
            InitializeComponent();

            tblObj = pUserControl;
            txtDesc.Text = pDesc;
            txtNewDesc.Text = pUserControl.Caption;
        }

        private void cmdRestore_Click(object sender, EventArgs e)
        {
            try
            {
                txtNewDesc.Text = txtDesc.Text;
            }
            catch (Exception ex)
            {
                base.ShowMessageError(ex);
            }
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
                this.DialogResult = DialogResult.OK;
                this.tblObj.Caption = txtNewDesc.Text;

                if (tblObj.StateRecord == Nampula.DI.eState.eUpdate)
                    tblObj.Update();
                else
                    tblObj.Add();

                base.ShowSucessfullMessage();
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

    }
}
