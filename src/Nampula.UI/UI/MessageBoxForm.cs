using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nampula.UI
{

    internal partial class frmMessageBox : Form
    {

        private frmMessageBox()
        {
            InitializeComponent();
            this.TopLevel = true;
            //this.TopMost = true;
            //WinAPI.SetParent ( this.Handle, UI.Application.GetInstance ( ).MDIHandle );
            this.Load += new EventHandler(frmMessageBox_Load);
        }

        void frmMessageBox_Load(object sender, EventArgs e)
        {
            if (FocusControl != null)
                FocusControl.Select();
        }

        private Button FocusControl { get; set; }
        private MessageBoxButtons MessageBoxButtons { get; set; }
        private MessageBoxIcon MessageBoxIcon { get; set; }

        public static DialogResult Show(string pText, string pCaption, System.Windows.Forms.MessageBoxButtons pButtons, System.Windows.Forms.MessageBoxIcon pIcon)
        {

            var myMessageBox = new frmMessageBox();

            myMessageBox.Text = pCaption;
            myMessageBox.lblMessage.Text = pText;
            myMessageBox.MessageBoxButtons = pButtons;
            myMessageBox.MessageBoxIcon = pIcon;

            myMessageBox.SetMessageStyle();

            //Application.GetInstance ( ).Forms.ActiveForm;
            myMessageBox.PlaySong();

            if (ActiveForm != null && !ActiveForm.InvokeRequired)
                return myMessageBox.ShowDialog(ActiveForm);

            myMessageBox.TopMost = true;

            return myMessageBox.ShowDialog(true);
        }

        private void PlaySong()
        {
            switch (MessageBoxIcon)
            {
                case MessageBoxIcon.Asterisk:
                    icoImage.Image = Properties.Resources.message_ico_information;
                    System.Media.SystemSounds.Asterisk.Play();
                    break;
                case MessageBoxIcon.Question:
                    icoImage.Image = Properties.Resources.message_ico_question;
                    System.Media.SystemSounds.Question.Play();
                    break;
                case MessageBoxIcon.Error:
                    icoImage.Image = Properties.Resources.message_ico_exclamation;
                    System.Media.SystemSounds.Hand.Play();
                    break;
                case MessageBoxIcon.Exclamation:
                    icoImage.Image = Properties.Resources.message_ico_information;
                    System.Media.SystemSounds.Exclamation.Play();
                    break;
                default:
                    icoImage.Image = Properties.Resources.message_ico_information;
                    break;
            }
        }

        private void SetMessageStyle()
        {
            try
            {

                switch (MessageBoxButtons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        SetAbortRetryIgnore();
                        FocusControl = cmdAbort;
                        break;
                    case MessageBoxButtons.OK:
                        SetOk();
                        this.AcceptButton = cmdOk;
                        this.CancelButton = cmdOk;
                        FocusControl = cmdOk;
                        break;
                    case MessageBoxButtons.OKCancel:
                        SetOkCancel();
                        this.AcceptButton = cmdOk;
                        this.CancelButton = cmdCancel;
                        FocusControl = cmdCancel;
                        break;
                    case MessageBoxButtons.RetryCancel:
                        SetRetryCancel();
                        this.AcceptButton = cmdRetry;
                        this.CancelButton = cmdCancel;
                        FocusControl = cmdRetry;
                        break;
                    case MessageBoxButtons.YesNo:
                        SetYesNo();
                        this.AcceptButton = cmdCancel;
                        this.CancelButton = cmdCancel;
                        FocusControl = cmdNo;
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        SetYesNoCancel();
                        this.AcceptButton = cmdNo;
                        this.CancelButton = cmdCancel;
                        FocusControl = cmdCancel;
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SetYesNoCancel()
        {

            SetYesNo();
            SetPosByButton(cmdNo, cmdCancel);
            cmdCancel.Visible = true;
        }

        private void SetYesNo()
        {

            SetFirstButton(cmdYes);
            SetPosByButton(cmdYes, cmdNo);

            cmdYes.Visible = true;
            cmdNo.Visible = true;

        }

        private void SetRetryCancel()
        {

            SetFirstButton(cmdRetry);
            SetPosByButton(cmdRetry, cmdCancel);

            cmdRetry.Visible = true;
            cmdCancel.Visible = true;

        }

        private void SetOkCancel()
        {

            SetFirstButton(cmdOk);
            SetPosByButton(cmdOk, cmdCancel);

            cmdCancel.Visible = true;
            cmdOk.Visible = true;

        }

        private void SetOk()
        {

            SetFirstButton(cmdOk);
            cmdOk.Visible = true;

        }

        private const int iDefaultDistance = 10;
        private void SetFirstButton(Button pButton)
        {
            pButton.Top = this.Height - 60;
            pButton.Left = iDefaultDistance;
        }

        private void SetPosByButton(Button pReferente, Button pPos)
        {
            pPos.Top = pReferente.Top;
            pPos.Left = (pReferente.Width + pReferente.Left) + iDefaultDistance;
        }

        private void SetAbortRetryIgnore()
        {

            SetFirstButton(cmdAbort);
            SetPosByButton(cmdAbort, cmdRetry);
            SetPosByButton(cmdRetry, cmdIgnore);

            cmdAbort.Visible = true;
            cmdRetry.Visible = true;
            cmdIgnore.Visible = true;

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void cmdRetry_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
