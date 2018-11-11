using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Ionic.Zip;
using Nampula.DI;

namespace Nampula.UI
{

    public class Application
    {

        private static Application _instance;
        private IApplication m_Concrete;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Application()
        {
            AddonIdentiers = new List<string>();
            CheckHostedEnvironment = true;
        }

        /// <summary>
        /// Pega a instancia da aplicação
        /// </summary>
        /// <returns></returns>
        public static Application GetInstance()
        {
            return _instance ?? (_instance = new Application());
        }

        /// <summary>
        /// Evento disparado ao iniciar a conecão com o SAP
        /// </summary>
        public event ApplicationEventHandler OnStartConnection;
        /// <summary>
        /// Evento disparao para criar o menu da aplicação
        /// </summary>
        public event ApplicationEventHandler OnStartCreateMenu;
        /// <summary>
        /// Evento disparado quando fecha a aplicação
        /// </summary>
        public event ApplicationEventHandler OnShutDown;
        /// <summary>
        /// Evento disparado quando altera a empresa
        /// </summary>
        public event ApplicationEventHandler OnChangeCompany;
        /// <summary>
        /// EVento disparado ao clciar em um menu do SAP
        /// </summary>
        public event EventHandler<ApplicationEventArgs> OnMenuClick;

        /// <summary>
        /// Espaço de nome da aplicação
        /// </summary>
        /// <remarks>
        /// Esse nome deve ser curto o suficiente e não pode ser repetido
        /// Ele é usado para criação de menus dentro do sistema
        /// </remarks>
        public string NameSpace { get; private set; }
        /// <summary>
        /// Empresa conectada
        /// </summary>
        public Company Company
        {
            get { return m_Concrete.Company; }
        }
        /// <summary>
        /// Dados do Ambiente do SAP
        /// </summary>
        public Desktop Desktop
        {
            get { return m_Concrete.Desktop; }
        }
        /// <summary>
        /// Lista de Formulário aberto
        /// </summary>
        public List<Form> Forms
        {
            get { return m_Concrete.Forms; }
        }
        /// <summary>
        /// Linguagem do Sistema
        /// </summary>
        public BoLanguages Language
        {
            get { return m_Concrete.Language; }
        }

        public bool CheckHostedEnvironment { get; set; }

        /// <summary>
        /// Tipo da Aplicação
        /// </summary>
        public eAppType AppType { get; private set; }

        /// <summary>
        /// Lista de Identificadores
        /// </summary>
        public List<string> AddonIdentiers { get; set; }

        /// <summary>
        /// Inicia o comportamento da aplicação dentro do SAP
        /// </summary>
        /// <param name="pNameSpace">Nome do espaço de nomes</param>
        /// <param name="pAppType">Tipo de Aplicação</param>
        /// <returns>True se iniciar</returns>
        [STAThread]
        public bool StartApplication(string pNameSpace, eAppType pAppType)
        {
            NameSpace = pNameSpace;
            AppType = pAppType;

            System.Threading.Thread.CurrentThread.CurrentCulture =
                 new System.Globalization.CultureInfo("pt-BR");

            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();

            ExtractLocation();

            switch (AppType)
            {
                case eAppType.WinForms:
                    m_Concrete = ApplicationWinForm.GetInstance();
                    break;
                case eAppType.SAPForms:
                    m_Concrete = ApplicationSAP.GetInstance();
                    break;
                default:
                    throw new NotSupportedException(AppType.ToString());
            }

            m_Concrete.CheckHostedEnvironment = CheckHostedEnvironment;
            m_Concrete.AppEvent += ConcreteAppEvent;
            m_Concrete.MenuEvent += ConcreteMenuEvent;
            m_Concrete.OnStartConnection += m_Concrete_OnStartConnection;
            m_Concrete.OnStartCreateMenu += m_Concrete_OnStartCreateMenu;
            m_Concrete.OnShutDown += m_Concrete_OnShutDown;
            m_Concrete.OnChangeCompany += m_Concrete_OnChangeCompany;
            m_Concrete.AddonIdentifiers = AddonIdentiers;

            return m_Concrete.StartApplication(NameSpace);
        }

        private void ExtractLocation()
        {
            var currentPath = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);

            if (currentPath == null)
                return;

            currentPath = Path.Combine(currentPath, "pt-BR");

            if (Directory.Exists(currentPath))
                return;

            using (var zip = ZipFile.Read(new MemoryStream(Properties.Resources.pt_BR)))
                zip.ExtractAll(currentPath, ExtractExistingFileAction.OverwriteSilently);
        }

        void m_Concrete_OnChangeCompany(object sender, ApplicationEventArgs e)
        {
            if (OnChangeCompany != null)
                OnChangeCompany(sender, e);
        }

        void m_Concrete_OnShutDown(object sender, ApplicationEventArgs e)
        {
            if (OnShutDown != null)
                OnShutDown(sender, e);
        }

        void m_Concrete_OnStartCreateMenu(object sender, ApplicationEventArgs e)
        {
            if (OnStartCreateMenu != null)
                OnStartCreateMenu(sender, e);
        }

        void m_Concrete_OnStartConnection(object sender, ApplicationEventArgs e)
        {
            if (OnStartConnection != null)
                OnStartConnection(sender, e);
        }

        void ConcreteMenuEvent(object sender, ApplicationEventArgs e)
        {
            var menu = m_Concrete.Menus.FirstOrDefault(p => p.UID == e.MenuEvent.MenuUID);

            if (menu != null)
            {
                menu.DoOnClick(e.MenuEvent);
            }
            else
            {
                if (OnMenuClick != null)
                    OnMenuClick(this, e);
            }
        }

        void ConcreteAppEvent(object sender, ApplicationEventArgs e)
        {
            if (e.BoAppEventTypes == BoAppEventTypes.aet_ShutDown)
            {
                if (OnShutDown != null)
                    OnShutDown(sender, e);
            }
            else if (e.BoAppEventTypes == BoAppEventTypes.aet_CompanyChanged)
            {
                if (OnChangeCompany != null)
                    OnChangeCompany(sender, e);
            }
        }

        /// <summary>
        /// Exbie uma mensagem de texto
        /// </summary>
        /// <param name="text">Texto que será exibido</param>
        /// <param name="buttons">COnjunto de botões</param>
        /// <param name="icon">Ícone que ser exibido</param>
        /// <returns>O Botão que foi pressionado</returns>
        public System.Windows.Forms.DialogResult MessageBox(string text, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon)
        {

            return m_Concrete.MessageBox(text, buttons, icon);
        }



        /// <summary>
        /// Exbie uma mensagem de texto
        /// </summary>
        /// <param name="text">Texto que será exibido</param>
        /// <param name="icon">Ícone que ser exibido</param>
        /// <returns>O Botão que foi pressionado</returns>
        public System.Windows.Forms.DialogResult MessageBox(string text, System.Windows.Forms.MessageBoxIcon icon)
        {
            return m_Concrete.MessageBox(text, icon);
        }

        /// <summary>
        /// Exbie uma mensagem de texto
        /// </summary>
        /// <param name="text">Texto que será exibido</param>
        /// <returns>O Botão que foi pressionado</returns>
        public System.Windows.Forms.DialogResult MessageBox(string text)
        {
            return m_Concrete.MessageBox(text);
        }

        /// <summary>
        /// Inser uma nova mensagem na barra de status
        /// </summary>
        /// <param name="text">Texto</param>
        /// <param name="seconds">Tempo</param>
        /// <param name="type">Tipo de Alerta</param>
        public void SetTextOnStatusBar(string text, BoMessageTime seconds, BoStatusBarMessageType type)
        {
            m_Concrete.StatusBar(text, seconds, type);
        }

        /// <summary>
        /// Inser uma nova mensagem na barra de status
        /// </summary>
        /// <param name="text">Texto</param>
        /// <param name="seconds">Tempo</param>
        public void SetTextOnStatusBar(string text, BoMessageTime seconds)
        {
            SetTextOnStatusBar(text, seconds, BoStatusBarMessageType.smt_Error);
        }

        /// <summary>
        /// Inser uma nova mensagem na barra de status
        /// </summary>
        /// <param name="text">Texto</param>
        public void SetTextOnStatusBar(string text)
        {
            SetTextOnStatusBar(text, BoMessageTime.bmt_Medium);
        }


        /// <summary>
        /// Captura o formulário principal da aplicação
        /// </summary>
        /// <returns></returns>
        public FormMain MainForm()
        {
            return m_Concrete.MainForm();
        }

        /// <summary>
        /// Realiza uma simulação de click no LinkedButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Event"></param>
        public void PeformLinkedButton(object sender, LinkedButtonEventArgs Event)
        {
            m_Concrete.PerformLinkedButton(sender, Event);
        }

        /// <summary>
        /// Pega os parametros de conexão do SAP
        /// </summary>
        /// <returns></returns>
        public ConnectionParameter GetParam()
        {
            var param = m_Concrete.GetParam();            

            try
            {
                param.IsHostedEnvironment = m_Concrete.IsHostedEnvironment;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Erro ao atribuir IsHostedEnviroment : {0} - {1}",
                    exception.Message,
                    exception.StackTrace);
            }

            return param;
        }

        internal void AddMenu(string pFatherMenu, MenuItem pMenuItem)
        {
            m_Concrete.AddMenu(pFatherMenu, pMenuItem);
        }

        /// <summary>
        /// Obetem um menu do B1 através do seu ID
        /// </summary>
        /// <param name="pMenuId"></param>
        /// <returns></returns>
        public MenuItem GetMenu(string pMenuId)
        {
            return m_Concrete.GetMenu(pMenuId);
        }

        /// <summary>
        /// Verifica se o licenciamento da aplicação
        /// </summary>
        /// <param name="pAddonName">Nome do Addon</param>
        /// <param name="pDateExpired">Data que expira</param>
        /// <exception cref="Exception">Licença vencida !</exception>
        public void CheckLicense(string pAddonName, DateTime pDateExpired)
        {
            var today = DataBaseAdapter.GetServerDate();
            var daysToExpire = pDateExpired.Subtract(today).Days + 1;

            if (daysToExpire < 7 && daysToExpire > 1)
                SetTextOnStatusBar(string.Format("A Licença do {0} irá vencer em {1} dia(s).", pAddonName, daysToExpire),
                    BoMessageTime.bmt_Short,
                    BoStatusBarMessageType.smt_Warning);

            if (daysToExpire == 1)
                SetTextOnStatusBar(string.Format("A Licença do {0} irá vencer hoje.", pAddonName),
                    BoMessageTime.bmt_Short);

            if (daysToExpire <= 0)
                throw new Exception("Licença vencida entre em contato com o administrador do sistema.");
        }

        internal IntPtr GetMdiWindowHandle()
        {
            return m_Concrete.GetMdiWindowHandle();
        }


    }

}
