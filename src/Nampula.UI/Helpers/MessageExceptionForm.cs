using System;
using System.Drawing;
using System.Windows.Forms;
using Nampula.Framework;

namespace Nampula.UI.Helpers
{
    public partial class MessageExceptionForm : Form
    {
        private Exception _exception;

        public MessageExceptionForm(Exception exception)
        {
            _exception = exception;
            InitializeComponent();

            TopMost = true;
            StartPosition = FormStartPosition.CenterScreen;

            FillControls();

            messageSpplitContainer.SplitGroupPanelCollapsed += this.messageSpplitContainer_SplitGroupPanelCollapsed;
        }

        private String GetMessageByExceptions(Exception ex)
        {
            var message = ex.Message;

            if (ex.InnerException != null)
                message = string.Format("{0}\n{1}", message, GetMessageByExceptions(ex.InnerException));

            return message;
        }

        private void FillControls()
        {
            messageExceptionStatic.Text = GetMessageByExceptions(_exception);
            stackExceptionEditMemo.Text = _exception.StackTrace;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var clipboardMessage = "MESSAGE ======================= \n{0}\n\nSTACKTRACE =======================\n {1}"
                    .Fmt(messageExceptionStatic.Text, stackExceptionEditMemo.Text);

                Clipboard.SetText(clipboardMessage, TextDataFormat.Text);

                ShowSucessfullMessage();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        public static DialogResult Show(Exception exception)
        {
            var messageExceptionBox = new MessageExceptionForm(exception);

            //Application.GetInstance ( ).Forms.ActiveForm;
            System.Media.SystemSounds.Hand.Play();

            if (ActiveForm != null && !ActiveForm.InvokeRequired)
                return messageExceptionBox.ShowDialog(ActiveForm);

            messageExceptionBox.TopMost = true;

            return messageExceptionBox.ShowDialog(true);
        }

        private void messageSpplitContainer_SplitGroupPanelCollapsed(object sender, DevExpress.XtraEditors.SplitGroupPanelCollapsedEventArgs e)
        {
            Size = e.Collapsed ? new Size(564, 211) : new Size(564, 339);
        }
    }
}
