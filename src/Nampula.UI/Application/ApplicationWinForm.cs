using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using Nampula.DI.B1.UserCaches;
using Nampula.DI.B1.Users;
using Nampula.Framework;
using Nampula.UI.DinamicInterface;

namespace Nampula.UI
{

    public class ApplicationWinForm : IApplication
    {
        private static ApplicationWinForm n_Instance;
        //private SAPbouiCOM.Application m_SAPApplication;

        private ApplicationWinForm()
        {
            //_Application = new SAPbouiCOM.Application();
            Company = new Company();

            Desktop = new Desktop(
                System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width,
                System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);

            Language = BoLanguages.ln_Portuguese_Br;
            Menus = new List<MenuItem>();
            Forms = new List<Form>();
        }

        public static IApplication GetInstance()
        {
            if (n_Instance == null)
                n_Instance = new ApplicationWinForm();
            return n_Instance;
        }

        public bool StartApplication(string pAddonIdentifier)
        {
            // SetEvent();
            ShowMainForm();

            //Carrega os dados de conexão da última versão
            //LoadConnectionApplication( );

            //Carrega os formulários padrões
            if (!StartLoggin())
                return false;

            ThemeSkinManager.Instance.SetCurrentSchema(ThemeSkinManager.GoldenThreadId);

            SetCompanyInfo();

            //SaveConnectionApplication( );

            ConnectCompany();

            StartCreateMenu();

            return true;
        }

        private void StartCreateMenu()
        {
            if (OnStartCreateMenu != null)
                OnStartCreateMenu(this, new ApplicationEventArgs());
        }

        private void ConnectCompany()
        {
            SetCompanyInfo();
            if (OnStartConnection != null)
                OnStartConnection(this, new ApplicationEventArgs());
        }

        //private void SaveConnectionApplication ( )
        //{
        //    ApplicationParameter.SaveConnectionParamter( );
        //}

        private void ShowMainForm()
        {
            //frmMain myMain = new frmMain ( );
            //myMain.Show ( );
            //this.MDIParent = myMain.Handle;
        }

        private void SetCompanyInfo()
        {
            var param = Connection.Instance.ConnectionParameter;

            Company.ServerName = param.Server;
            Company.DatabaseName = param.CompanyDb;
            Company.UserName = param.UserName;
        }

        //private void LoadConnectionApplication ( )
        //{
        //    ApplicationParameter.LoadConnectionParamter( );
        //}

        private bool StartLoggin()
        {
            frmSplash myForm = new frmSplash();
            myForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            return myForm.ShowDialog() == System.Windows.Forms.DialogResult.OK;
        }

        //private void SetDefaultValues () {

        //}

        //private void SetEvent() {
        //    try {

        //        m_SAPApplication.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(m_SAPApplication_AppEvent);
        //        m_SAPApplication.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(m_SAPApplication_ItemEvent);
        //        m_SAPApplication.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(m_SAPApplication_MenuEvent);
        //        m_SAPApplication.PrintEvent += new SAPbouiCOM._IApplicationEvents_PrintEventEventHandler(m_SAPApplication_PrintEvent);
        //        m_SAPApplication.ProgressBarEvent += new SAPbouiCOM._IApplicationEvents_ProgressBarEventEventHandler(m_SAPApplication_ProgressBarEvent);
        //        m_SAPApplication.ReportDataEvent += new SAPbouiCOM._IApplicationEvents_ReportDataEventEventHandler(m_SAPApplication_ReportDataEvent);
        //        m_SAPApplication.RightClickEvent += new SAPbouiCOM._IApplicationEvents_RightClickEventEventHandler(m_SAPApplication_RightClickEvent);
        //        m_SAPApplication.StatusBarEvent += new SAPbouiCOM._IApplicationEvents_StatusBarEventEventHandler(m_SAPApplication_StatusBarEvent);

        //    }
        //    catch (Exception ex) {
        //        throw ex;
        //    }
        //}

        void m_SAPApplication_StatusBarEvent(string Text, SAPbouiCOM.BoStatusBarMessageType MessageType)
        {
            //throw new NotImplementedException();           
        }

        void m_SAPApplication_RightClickEvent(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            // throw new NotImplementedException();
            BubbleEvent = true;
        }

        void m_SAPApplication_ReportDataEvent(ref SAPbouiCOM.ReportDataInfo eventInfo, out bool BubbleEvent)
        {
            // throw new NotImplementedException();
            BubbleEvent = true;
        }

        void m_SAPApplication_ProgressBarEvent(ref SAPbouiCOM.ProgressBarEvent pVal, out bool BubbleEvent)
        {
            //throw new NotImplementedException();
            BubbleEvent = true;
        }

        void m_SAPApplication_PrintEvent(ref SAPbouiCOM.PrintEventInfo eventInfo, out bool BubbleEvent)
        {
            //throw new NotImplementedException();
            BubbleEvent = true;
        }

        void m_SAPApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            try
            {
                BubbleEvent = true;

                if (MenuEvent != null)
                {

                    //}
                    //BubbleEvent = true;

                    ////if (pVal.BeforeAction)
                    ////{

                    //MenuEvent myMenuEvent = new MenuEvent(pVal);

                    //GetMainForm().MenuEventsList.Push(myMenuEvent);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void m_SAPApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
        }

        void m_SAPApplication_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {

        }

        //private void SetWindowHandle () {
        //    this.MDIParent = new IntPtr ( 0 );
        //}

        public Company Company { get; set; }
        public Desktop Desktop { get; set; }
        public BoLanguages Language { get; set; }
        public List<MenuItem> Menus { get; set; }
        public bool IsHostedEnvironment { get; set; }
        public int SkingId { get; set; }
        public List<Form> Forms { get; set; }
        private FormMain m_FormMain;
        public bool CheckHostedEnvironment { get; set; }

        public FormMain MainForm()
        {
            return GetMainForm();
        }

        public IntPtr GetMdiWindowHandle()
        {
            throw new NotImplementedException();
        }

        private FormMain GetMainForm()
        {
            if (m_FormMain != null)
                return m_FormMain;

            m_FormMain = new FormMain(eAppType.WinForms);

            //m_FormMain.OnReseiveMenuEvent += new MenuEventsListing.OnAfterLoadEventHandler(m_MainForm_OnReseiveMenuEvent);
            //m_FormMain.OnReseiveItemEvent += new ItemEventsListing.OnAfterLoadEventHandler(m_MainForm_OnReseiveItemEvent);

            return m_FormMain;
        }

        void m_MainForm_OnReseiveMenuEvent(MenuEvent pEvent)
        {
            if (MenuEvent != null)
            {
                MenuEventArgs myMenuEventArgs = new MenuEventArgs(pEvent);
                ApplicationEventArgs myApplicationEventArgs = new ApplicationEventArgs();
                myApplicationEventArgs.MenuEvent = myMenuEventArgs;

                MenuEvent(this, myApplicationEventArgs);
            }
        }

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

        public List<string> AddonIdentifiers { get; set; }

        public event ApplicationEventHandler AppEvent;
        public event ApplicationEventHandler FormDataEvent;
        public event ApplicationEventHandler ItemEvent;
        public event ApplicationEventHandler MenuEvent;
        public event ApplicationEventHandler PrintEvent;
        public event ApplicationEventHandler ProgressBarEvent;
        public event ApplicationEventHandler ReportDataEvent;
        public event ApplicationEventHandler RightClickEvent;
        public event ApplicationEventHandler StatusBarEvent;


        public object CreateObject(BoCreatableObjectType Type)
        {
            return null;// m_SAPApplication.CreateObject((SAPbouiCOM.BoCreatableObjectType)Type);
        }

        public void ActivateMenuItem(string pMenuID)
        {
            //
        }

        /// <summary>
        /// Faz uma validação de conexão a DI API 
        /// </summary>
        /// <param name="pUseCahe">Caso queira usar um cache ( Lista de Usuário ) true , se não quiser usar ( false ) </param>
        /// <returns>True - para conectado com sucesso, false para não conectado </returns>
        internal static bool ConnectToDI(bool pUseCahe)
        {

            ApplicationWinForm myApp = new ApplicationWinForm();

            //Create table if dosent exists
            myApp.CreateUserCacheTable();

            if (pUseCahe && myApp.UserExistOnCache())
            {
                //Se a senha não mudou
                if (!myApp.IsChangedCompamyPassword())
                {
                    if (myApp.ValidatePassword())
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Usuário ou senha inválido");
                    }
                }
                //Valida a senha 

            }

            DICompany dicompany = new DICompany();
            var param = Connection.Instance.ConnectionParameter;

            dicompany.Server = param.Server;
            dicompany.DbUserName = param.DBUser;
            dicompany.DbPassword = param.DBPassword;
            dicompany.LicenseServer = param.LicenseServer;

            dicompany.CompanyDB = param.CompanyDb;
            dicompany.DbServerType = param.DbServerType;
            dicompany.UserName = param.UserName;
            dicompany.Password = param.Password;
            dicompany.language = BoLanguages.ln_Portuguese_Br;

            if (dicompany.Connect() != 0)
                throw new Exception(
                    string.Format("{0} - {1}", dicompany.GetLastErrorCode(), dicompany.GetLastErrorDescription()));

            myApp.SavePasswordOnCache();

            return true;
        }



        private void CreateUserCacheTable()
        {

            InformationSchemaColumn infoSchema = new InformationSchemaColumn();
            UserCache myUser = new UserCache();
            infoSchema.DBName = myUser.DBName;

            if (!infoSchema.GetByKey(UserCache.Definition.TableName, UserCache.FieldsName.ID))
            {
                myUser.Create();
            }

        }

        private void SavePasswordOnCache()
        {

            var param = Connection.Instance.ConnectionParameter;

            UserCache myUser = GetUserCache(param.CompanyDb, param.UserName, false);
            User myUserComp = GetUser(param.CompanyDb, param.UserName, true);

            myUser.GetByUserName(param.CompanyDb, param.UserName);

            myUser.UserName = param.UserName;
            myUser.Password = new EncryptorWrapper<string>().EncodeToMD5(param.Password);
            myUser.PasswordCompany = myUserComp.Password;
            myUser.CompanyDb = param.CompanyDb;

            if (myUser.ID != 0)
                myUser.Update();
            else
                myUser.Add();

        }

        /// <summary>
        /// Tentativa de validação de usuário usando uma tabela de dados salva com os dados válidos
        /// </summary>
        /// <returns></returns>
        private bool UserExistOnCache()
        {
            var param = Connection.Instance.ConnectionParameter;

            UserCache myUser = GetUserCache(param.CompanyDb, param.UserName, false);

            return myUser.ID != 0;
        }

        private bool IsChangedCompamyPassword()
        {

            var param = Connection.Instance.ConnectionParameter;
            //Se existir verifca se senha armazenada na empresa ainda é a mesma que está no cache
            User myUser = GetUser(param.CompanyDb, param.UserName, true);
            UserCache myUserCache = GetUserCache(param.CompanyDb, param.UserName, true);

            return myUser.Password != myUserCache.PasswordCompany;
        }

        private User GetUser(string pCompanyDb, string pUserName, bool pShowMessage)
        {

            User myUser = new User(pCompanyDb);

            if (!myUser.GetByKey(pUserName))
            {
                if (pShowMessage)
                    throw new Exception(
                        string.Format("Não encontrado usuário [{0}] na empresa [{1}]", pUserName, pCompanyDb));
            }

            return myUser;
        }

        private UserCache GetUserCache(string pCompanyDb, string pUserName, bool pShowMessage)
        {

            UserCache myUserCache = new UserCache();

            if (!myUserCache.GetByUserName(pCompanyDb, pUserName))
            {
                if (pShowMessage)
                    throw new Exception(
                        string.Format("Não encontrado usuário [{0}] na empresa [{1}] na lista de cache", pUserName, pCompanyDb));
            }

            return myUserCache;
        }

        private bool ValidatePassword()
        {

            var param = Connection.Instance.ConnectionParameter;

            UserCache myUser = GetUserCache(param.CompanyDb, param.UserName, true);

            EncryptorWrapper<string> mySP = new EncryptorWrapper<string>();

            return myUser.Password == mySP.EncodeToMD5(param.Password);

        }



        public void StatusBar(string Text, BoMessageTime Seconds, BoStatusBarMessageType Type)
        {
            throw new NotImplementedException();
        }

        public void PerformLinkedButton(object sender, LinkedButtonEventArgs Event)
        {
            throw new NotImplementedException();
        }

        public void AddMenu(string pFatherMenu, MenuItem pMenuItem)
        {
            throw new NotImplementedException();
        }





        public MenuItem GetMenu(string pMenuID)
        {
            throw new NotImplementedException();
        }

        public ConnectionParameter GetParam()
        {
            var param = Connection.Instance.ConnectionParameter;

            var company = Company;

            param.Server = company.ServerName;
            param.UserName = company.UserName;
            param.CompanyDb = company.DatabaseName;


            return param;
        }

        public event ApplicationEventHandler OnStartConnection;

        public event ApplicationEventHandler OnStartCreateMenu;

        public event ApplicationEventHandler OnShutDown;

        public event ApplicationEventHandler OnChangeCompany;

    }
}
