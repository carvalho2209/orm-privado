using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using Nampula.UI.DinamicInterface;
using Nampula.UI.Helpers;

namespace Nampula.UI
{
    /// <summary>
    /// Formulária padrão da Nampula
    /// </summary>
    public partial class Form : XtraForm
    {
        /// <summary>
        /// Construtor padrã.
        /// </summary>
        public Form()
        {
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.SapDesign).Assembly);

            DevExpress.LookAndFeel.UserLookAndFeel
                .Default.SetSkinStyle(ThemeSkinManager.Instance.Theme);

            InitializeComponent();
        }

        /// <summary>
        /// Exibe uma mensagem de erro encontrada dentro da exceção
        /// </summary>
        /// <param name="exception">Exceção</param>
        /// <param name="showStackTace">Exibe ou não o StackTrace da origem do erro</param>
        public void ShowMessageError(Exception exception, bool showStackTace = false)
        {
            MessageExceptionForm.Show(exception);
        }

        /// <summary>
        /// Exibe um texto na parte debaixo da tela do SAP (Status bar)
        /// </summary>
        /// <param name="text">Texto que deseja exibir</param>
        /// <param name="seconds">tempo de exibição</param>
        /// <param name="type">Tipo de Mensagem</param>
        public void SetTextOnStatusBar(string text, BoMessageTime seconds = BoMessageTime.bmt_Short, BoStatusBarMessageType type = BoStatusBarMessageType.smt_Error)
        {
            Application.GetInstance().SetTextOnStatusBar(text, seconds, type);
        }


        /// <summary>
        /// Exibe uma mensagem de sucesso.
        /// </summary>
        /// <param name="message">Mesagem que deseja exibir</param>
        public void ShowSucessfullMessage(string message = "Operação realizada com sucesso.")
        {
            SetTextOnStatusBar(message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
        }

        /// <summary>
        /// Faz com que não exiba a tela na barra de tarefas
        /// </summary>
        [DefaultValue(false)]
        public new bool ShowInTaskbar
        {
            get { return base.ShowInTaskbar; }
            set { base.ShowInTaskbar = false; }
        }


        /// <summary>
        /// Exebi o formulário
        /// </summary>
        public new void Show()
        {
            SetFormOnCenter();

            Visible = true;
            Select(true, true);
            Activate();
        }

        private void SetFormOnCenter()
        {
            var app = Application.GetInstance();

            var topInitialPos = GetTopPos();

            var iLeft = (app.Desktop.Width / 2) - Width / 2;
            var iTop = ((app.Desktop.Height - Height) / 2) - topInitialPos;

            if (iLeft < 0)
                iLeft = 1;

            if (iTop < 0)
                iTop = 1;

            Location = new Point(iLeft, iTop);

            MaximizedBounds = new Rectangle(
                app.Desktop.Left + 1,
                app.Desktop.Top + 1,
                app.Desktop.Width - 12,
                app.Desktop.Height - topInitialPos - 60);
        }


        private static int GetTopPos()
        {
            if (Application.GetInstance().AppType == eAppType.SAPForms)
                return 65;

            return 0;
        }

        /// <summary>
        /// Exobe o formulário de forma nativa
        /// </summary>
        /// <param name="pNative">Informa se for nativa (.net) ou da nampula</param>
        public void Show(bool pNative)
        {
            base.Show();
        }

        /// <summary>
        /// NÃO USAR ESSE METODO
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            //SetFormOnCenter();

            //Visible = true;
            Select(true, true);
            Activate();
            this.TopMost = true;
            return base.ShowDialog();
        }

        /// <summary>
        /// NÃO USAR ESSE METODO
        /// </summary>
        /// <returns></returns>
        internal DialogResult ShowDialog(bool pNoForm)
        {
            return base.ShowDialog();
        }

        /// <summary>
        /// Exibe o formulário e aguarda o mesmo fechar para saber o resultado.
        /// </summary>
        /// <param name="pParent">Qual formulário pai ou dono</param>
        /// <returns>O resultado do formulário</returns>
        public DialogResult ShowDialog(Form pParent)
        {
            pParent.Activated += PParentActivated;

            pParent.FormClosed += Form_FormClosed;
            Show();
            Select();
            //this.Owner = pParent;

            do
            {
                System.Windows.Forms.Application.DoEvents();
            } while (base.Visible);

            try
            {
                pParent.Activated -= PParentActivated;
                pParent.Select();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("{0}\n{1}", ex.Message, ex.StackTrace);
            }

            System.Diagnostics.Debug.Print("ShowDialog");

            return this.DialogResult;
        }

        void PParentActivated(object sender, EventArgs e)
        {
            try
            {
                if (Visible)
                {
                    Select();
                    Invalidate();
                    Activate();
                }
            }
            catch { }
            //var form = sender as Nampula.UI.Form;

        }

        void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as Form;

            form.Select();

            System.Diagnostics.Debug.Print("Form_FormClosed");
        }

        /// <summary>
        /// Exibe uma mensagem de texto na tela
        /// </summary>
        /// <param name="message">Mensagem que deseje exibir</param>
        /// <param name="buttons">Botões que serão visualizados na tela</param>
        /// <param name="icon">Ícone que será exido depois da mensagem</param>
        /// <returns></returns>
        public DialogResult MessageBox(string message, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            return Application.GetInstance().MessageBox(message, buttons, icon);
        }

        /// <summary>
        /// Exibe ou oculta o formulário
        /// </summary>
        public new bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                if (value)
                    WinAPI.SetParent(Handle, Application.GetInstance().GetMdiWindowHandle());

                base.Visible = value;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RoundForm();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RoundForm();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            RoundForm();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RoundForm();
        }

        private void RoundForm()
        {
            if (ThemeSkinManager.Instance.IsBlueThema())
                Region = NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);
        }

        /// <summary>
        /// Modo corrente do formulário
        /// </summary>
        public BoFormMode FormMode { get; set; }

        /// <summary>
        /// Atualiza o modo do formuário
        /// </summary>
        /// <param name="pOk">Botão de Salvar</param>
        /// <param name="pBoFormMode"></param>
        public void UpdateFormMode(Button pOk, BoFormMode pBoFormMode)
        {
            if (FormMode != pBoFormMode)
            {
                FormMode = pBoFormMode;
                SetTextButton(pOk, FormMode);
            }
        }

        /// <summary>
        /// Atualiza o Texto do Botão conforme o modo do formulário
        /// </summary>
        /// <param name="pButton"></param>
        /// <param name="pState"></param>
        public void SetTextButton(Button pButton, BoFormMode pState)
        {

            string pText = string.Empty;

            switch (pState)
            {
                case BoFormMode.fm_FIND_MODE:
                    pText = "&Procurar";
                    break;
                case BoFormMode.fm_OK_MODE:
                    pText = "&Ok";
                    break;
                case BoFormMode.fm_UPDATE_MODE:
                    pText = "&Atualizar";
                    break;
                case BoFormMode.fm_ADD_MODE:
                    pText = "&Inserir";
                    break;
                case BoFormMode.fm_VIEW_MODE:
                    pText = "&Ok";
                    break;
                case BoFormMode.fm_PRINT_MODE:
                    pText = "&Imprimir";
                    break;
                case BoFormMode.fm_EDIT_MODE:
                    pText = "&Atualizar";
                    break;
            }

            pButton.Text = pText;
        }
    }
}
