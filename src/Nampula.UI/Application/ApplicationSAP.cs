using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nampula.Framework;
using Nampula.UI.DinamicInterface;
using SAPbouiCOM;
using Nampula.UI.SqlUserLoggin;
using Nampula.DI;
using System.Windows.Forms;
using Nampula.UI.DataServeAccess.Exceptions;
using System.Runtime.InteropServices;

namespace Nampula.UI
{

    public class ApplicationSAP : IApplication
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        private ApplicationSAP()
        {
            Forms = new List<Form>();
            Menus = new List<MenuItem>();
            AddonIdentifiers = new List<string>();
        }

        public SAPbouiCOM.Application SAPApp { get; set; }
        public Company Company { get; set; }
        public SAPbobsCOM.Company CompanySbo { get; set; }
        public Desktop Desktop { get; set; }
        public BoLanguages Language { get; set; }
        public List<MenuItem> Menus { get; set; }
        public bool IsHostedEnvironment { get; set; }
        public bool CheckHostedEnvironment { get; set; }

        public List<Form> Forms { get; set; }

        private FormMain m_FormMain;

        SqlUserProvider sqlUserProvider;

        public static ApplicationSAP GetInstance()
        {
            return Singleton<ApplicationSAP>.Instance;
        }

        public bool StartApplication(string pAddonIdentifier)
        {

            var sboGuiApi = new SAPbouiCOM.SboGuiApi();
            var sConnectionString = "0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056";

            if (Environment.GetCommandLineArgs().Count() > 1)
                sConnectionString = (string)Environment.GetCommandLineArgs().GetValue(1);

            //m_SboGuiApi.AddonIdentifier = "5645523035496D706C656D656E746174696F6E3A5531313638303630393739A58DC7616FFDA9767315987630F5679A4CA310C8";

            //m_SboGuiApi.AddonIdentifier =
            //    "5645523035496D706C656D656E746174696F6E3A543230343431393939343369C97BAE2962F5CB368BF09B76E5AAB060239818";

            AddonIdentifiers.Insert(0, string.Empty);

            foreach (var addonIdentifier in AddonIdentifiers)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(addonIdentifier))
                    {
                        sboGuiApi.AddonIdentifier = addonIdentifier;
                    }

                    Debug.Write(string.Format(
                        "AddonIdentifier : {0}", addonIdentifier));

                    sboGuiApi.Connect(sConnectionString);
                    break;
                }
                catch (Exception exception)
                {
                    if (addonIdentifier == AddonIdentifiers.Last())
                        throw new Exception("Todos os idenficadores falharam na conexão com o SAP.", exception);
                }
            }

            //// get an initialized application object            
            SAPApp = sboGuiApi.GetApplication();

            if (SAPApp == null)
            {
                return false;
            }

            ThemeSkinManager.Instance.SetCurrentSchema(SAPApp.SkinStyle.To<int>());

            SetEvent();

            SetUserSql();

            ConnectCompany();

            StartCreateMenu();

            return true;
        }

        private void SetUserSql()
        {
            try
            {
                var sboCompany = SAPApp.Company.GetDICompany() as SAPbobsCOM.Company;
                var installationId = SAPApp.Company.InstallationId;
                sqlUserProvider = new SqlUserProvider(sboCompany, installationId);
                sqlUserProvider.SetOrCreateSqlUserLoggin();
            }
            catch (COMException ex)
            {
                throw new Exception($"Verifique a instalação da DI API - {ex.Message}");
            }
            catch (CreateDataUserException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var message =
                    $"Conexão com o banco de dados falhou!\nVerifique se usuário e senha informados estão devidamente configurados no banco de dados, saia e entre novamente.\nPara maiores informações acesse: {@"http://docs.inventsoftware.info/General/BancoDados.html#privilegios-de-acesso-ao-banco-de-dados"}.";

                throw new Exception($"{ex.Message}\n{message}");
            }
        }

        public void CreateLogginMenu(MenuItem taxOneMenu)
        {
            if (taxOneMenu == null)
                throw new Exception("O menu base de administração de usuário não pode ser nulo.");

            var userAdmin = new MenuItem(taxOneMenu, BoMenuType.mt_STRING, "Usuário do Banco de Dados");
            userAdmin.OnAfterClick += configLogginMenu_OnAfterClick;
        }


        private void configLogginMenu_OnAfterClick(object sender, MenuEventArgs e)
        {
            try
            {
                var sboCompany = SAPApp.Company.GetDICompany() as SAPbobsCOM.Company;
                var InstallationId = SAPApp.Company.InstallationId;
                sqlUserProvider = new SqlUserProvider(sboCompany, InstallationId);
                sqlUserProvider.UpdateSqlUserLoggin();
            }
            catch (Exception ex)
            {
                Nampula.UI.Application.GetInstance().MessageBox(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartCreateMenu()
        {

            SAPbouiCOM.Form myMenuForm = SAPApp.Forms.GetFormByTypeAndCount(169, 1);

            try
            {

                if (myMenuForm != null)
                    myMenuForm.Freeze(true);

                if (OnStartCreateMenu != null)
                {
                    OnStartCreateMenu(this, new ApplicationEventArgs());
                }
            }
            finally
            {
                if (myMenuForm != null)
                {
                    myMenuForm.Freeze(false);
                    myMenuForm.Update();
                }
            }
        }

        private void SetEvent()
        {
            SAPApp.AppEvent += m_SAPApplication_AppEvent;
            SAPApp.MenuEvent += m_SAPApplication_MenuEvent;
        }

        void m_SAPApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            if (SAPMenuEvent != null)
            {
                SAPMenuEvent(ref pVal, out BubbleEvent);
                if (!BubbleEvent)
                    return;
            }

            BubbleEvent = true;

            if (MenuEvent != null)
                MainForm().MenuEventsList.Push(new MenuEvent(pVal));

        }

        void m_SAPApplication_AppEvent(SAPbouiCOM.BoAppEventTypes eventType)
        {
            if (AppEvent == null)
                return;

            var myApplicationEventArgs = new ApplicationEventArgs
            {
                BoAppEventTypes = (BoAppEventTypes)Convert.ToInt32(eventType)
            };

            AppEvent(this, myApplicationEventArgs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IntPtr GetMdiWindowHandle()
        {

            var currentWindowName = SAPApp.Desktop.Title;

            try
            {
                var sapMenuForm = SAPApp.Forms.GetFormByTypeAndCount(169, 1);
                var currentMenuTitle = sapMenuForm.Title;

                try
                {
                    sapMenuForm.Title = Guid.NewGuid().ToString();
                    SAPApp.Desktop.Title = Guid.NewGuid().ToString();

                    return WinAPI.GetParentWindowHandlerByName(SAPApp.Desktop.Title, sapMenuForm.Title);
                }
                finally
                {
                    sapMenuForm.Title = currentMenuTitle;
                }
            }
            finally
            {
                SAPApp.Desktop.Title = currentWindowName;
            }

        }

        //private void SetWindowHandle()
        //{
        //    var currentWindowName = SAPApp.Desktop.Title;

        //    try
        //    {
        //        var menuSapForm = SAPApp.Forms.GetFormByTypeAndCount(169, 1);

        //        menuSapForm.Title = Guid.NewGuid().ToString();

        //        this.MDIParent = WinAPI.GetWindowHandler(SAPApp.Desktop.Title);

        //    }
        //    finally
        //    {
        //        SAPApp.Desktop.Title = currentWindowName;
        //    }

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FormMain MainForm()
        {
            if (m_FormMain != null)
                return m_FormMain;

            m_FormMain = new FormMain(eAppType.SAPForms);

            m_FormMain.OnReseiveMenuEvent += m_MainForm_OnReseiveMenuEvent;

            return m_FormMain;
        }

        void m_MainForm_OnReseiveMenuEvent(MenuEvent pEvent)
        {
            var menuEvents = new MenuEventArgs(pEvent);
            var appEvents = new ApplicationEventArgs
            {
                MenuEvent = menuEvents
            };

            MenuEvent(this, appEvents);
        }

        /// <summary>
        /// Mensagem
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public System.Windows.Forms.DialogResult MessageBox(string Text, System.Windows.Forms.MessageBoxButtons buttons, System.Windows.Forms.MessageBoxIcon icon)
        {
            return Nampula.UI.frmMessageBox.Show(Text, "Mensagem do Sistema", buttons, icon);
        }

        public System.Windows.Forms.DialogResult MessageBox(string Text, System.Windows.Forms.MessageBoxIcon icon)
        {
            return MessageBox(Text, System.Windows.Forms.MessageBoxButtons.OK, icon);
        }

        public System.Windows.Forms.DialogResult MessageBox(string Text)
        {
            return MessageBox(Text, System.Windows.Forms.MessageBoxIcon.Information);
        }

        /// <summary>
        /// Identificadores do Aplicativo
        /// </summary>
        public List<string> AddonIdentifiers { get; set; }

        public event ApplicationEventHandler AppEvent;
        public event ApplicationEventHandler FormDataEvent;
        public event ApplicationEventHandler ItemEvent;
        public event ApplicationEventHandler MenuEvent;
        public event SAPbouiCOM._IApplicationEvents_MenuEventEventHandler SAPMenuEvent;
        public event ApplicationEventHandler PrintEvent;
        public event ApplicationEventHandler ProgressBarEvent;
        public event ApplicationEventHandler ReportDataEvent;
        public event ApplicationEventHandler RightClickEvent;
        public event ApplicationEventHandler StatusBarEvent;
        public event ApplicationEventHandler OnStartConnection;
        public event ApplicationEventHandler OnStartCreateMenu;
        public event ApplicationEventHandler OnShutDown;
        public event ApplicationEventHandler OnChangeCompany;

        private void ConnectCompany()
        {
            Company = SAPApp.Company.ToCompany();
            CompanySbo = SAPApp.Company.GetDICompany() as SAPbobsCOM.Company;
            Desktop = SAPApp.Desktop.ToDesktop();

            if (CheckHostedEnvironment)
                IsHostedEnvironment = SAPApp.IsHostedEnvironment;

            if (OnStartConnection == null)
                return;

            var myEventArgs = new ApplicationEventArgs();
            OnStartConnection(this, myEventArgs);
        }

        void Application_OnChangeCompany(object sender, ApplicationEventArgs e)
        {
            StartCreateMenu();
            ConnectCompany();
        }

        public void StatusBar(string pText, BoMessageTime Seconds, BoStatusBarMessageType Type)
        {
            SAPApp.StatusBar.SetText(
                pText,
                (SAPbouiCOM.BoMessageTime)Seconds.To<Int32>(),
                (SAPbouiCOM.BoStatusBarMessageType)Type.To<Int32>());
        }

        public void PerformLinkedButton(object sender, LinkedButtonEventArgs Event)
        {
            var formLinkedHelper = new FormLinkedButtonHelper(SAPApp);
            formLinkedHelper.PerformLinked(sender, Event);
        }

        public void AddMenu(string pFatherMenu, MenuItem pMenuItem)
        {

            var menu = (SAPbouiCOM.MenuCreationParams)SAPApp.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);
            SAPbouiCOM.MenuItem menuFather = null;

            if (!String.IsNullOrEmpty(pFatherMenu))
                menuFather = SAPApp.Menus.Item(pFatherMenu) as SAPbouiCOM.MenuItem;

            menu.Type = (SAPbouiCOM.BoMenuType)pMenuItem.Type.To<Int32>();
            menu.UniqueID = pMenuItem.UID;
            menu.String = pMenuItem.String;
            menu.Enabled = pMenuItem.Enabled;
            menu.Image = pMenuItem.Image;

            if (menuFather != null && menuFather.SubMenus != null)
            {
                menu.Position = menuFather.SubMenus.Count;
                if (menuFather.SubMenus.Exists(menu.UniqueID) == true)
                    menuFather.SubMenus.RemoveEx(menu.UniqueID);
                menuFather.SubMenus.AddEx(menu);
            }
            else
            {
                SAPApp.Menus.AddEx(menu);
            }

            Menus.Add(pMenuItem);
        }

        public MenuItem GetMenu(string pMenuID)
        {
            return SAPApp.Menus.Item(pMenuID).ToMenu();
        }

        public ConnectionParameter GetParam()
        {
            return sqlUserProvider.GetParam();
        }
    }
}
