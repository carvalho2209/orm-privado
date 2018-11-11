using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Nampula.UI.Helpers;
using NampulaDemo.DI.Factory;
using Nampula.UI;
using log4net;
using Nampula.DI.B1.BusinessPlaces;
using Nampula.DI.B1.Documents;
using Nampula.DI.B1.Helpers;
using MenuItem = Nampula.UI.MenuItem;
using Nampula.DI.B1.Itens;

namespace NampulaDemo
{

    static class Program
    {

        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        [STAThread]
        static void Main()
        {

            try
            {
                Nampula.UI.Application myApplication = Nampula.UI.Application.GetInstance();

                myApplication.AddonIdentiers.AddRange(new List<string>{
                    "5645523035496D706C656D656E746174696F6E3A4231373132393034363130CA3C0824B7491067F52C0540BA97BC0972C718D5",
                    "5645523035496D706C656D656E746174696F6E3A4231373132393034363130CA3C0824B7491067F52C0540BA97BC0972C718D5",
                    "5645523035496D706C656D656E746174696F6E3A4231373132393034363130CA3C0824B7491067F52C0540BA97BC0972C718D5",
                    "5645523035496D706C656D656E746174696F6E3A543230343431393939343369C97BAE2962F5CB368BF09B76E5AAB060239818",
                    "5645523035496D706C656D656E746174696F6E3A4231373132393034363130CA3C0824B7491067F52C0540BA97BC0972C718D5",
                    "5645523035496D706C656D656E746174696F6E3A5531313638303630393739A58DC7616FFDA9767315987630F5679A4CA310C8",                   
                });

                myApplication.OnStartCreateMenu += myApplication_OnStartCreateMenu;
                myApplication.OnStartConnection += myApplication_OnStartConnection;
                myApplication.OnShutDown += myApplication_OnShutDown;
                myApplication.CheckHostedEnvironment = false;

                if (myApplication.StartApplication("DO", eAppType.SAPForms))
                {
                    Nampula.Framework.LogHelper.EnableLog();
                    Log.Debug("Application Start Sucessfull");
                    System.Windows.Forms.Application.Run(myApplication.MainForm());
                }

            }
            catch (Exception ex)
            {
                MessageExceptionForm.Show(ex);
            }
        }

        static void myApplication_OnShutDown(object sender, ApplicationEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        static void myApplication_OnStartConnection(object sender, ApplicationEventArgs e)
        {
            var param = Nampula.UI.Application.GetInstance().GetParam();

            //param.ConnectionTimeout = 240;

            WaitingStatusHelper.WaintigFor(() => new DBTeste().Start(param), "Teste de Mensagem");

            var teste = B1Helper.GetByKey<BusinessPlace>(GetCurrentCompanyDb(), 1, "Business Place");

            //var item = B1Helper.GetItem("P00002", GetCurrentCompanyDb());

            //var cod = B1Helper.GetByKey<BrazilFuelIndexer>(GetCurrentCompanyDb(), item.FuelCode, "Configuração de Combustível");

            //new Security( );

            //var draft2 = B1Helper.GetDocument(4, eDocumentObjectType.oPurchaseOrders, Program.GetCurrentCompanyDb());

            //draft2.FillTaxExtension();

            //Debug.Assert(draft2.TaxExtension.MainUsage.Equals("11"),  "Utilização deveria ser 11 - 1411 - Dev. Cmp Cons");

            //draft2.FillLines();

            //var draft = B1Helper.GetDocument(15, eDocumentObjectType.oDrafts, Program.GetCurrentCompanyDb());

            //draft.FillLines();

            //var draft2 = B1Helper.GetDocument(1, eDocumentObjectType.oInvoices, Program.GetCurrentCompanyDb());
            //draft2.FillLines();

            //var draft3 = B1Helper.GetDocument(2, eDocumentObjectType.oInvoices, Program.GetCurrentCompanyDb());
            //draft3.FillLines();

            //var items = B1Helper.GetAll<Item>(Program.GetCurrentCompanyDb(),
            //    new KeyValuePair<string, object>(Item.FieldsName.CodeBars, "1212121212"));

            //if (items.IsEmpty())
            //{
            //    var codeBars = B1Helper.GetAll<BarCodeMasterData>(Program.GetCurrentCompanyDb(),
            //        new KeyValuePair<string, object>(BarCodeMasterData.FieldsName.BcdCode, "1212121212"));

            //    items = codeBars.Select(c => 
            //        B1Helper.GetByKey<Item>(GetCurrentCompanyDb(), c.ItemCode)).ToList();
            //}

            //var draft3 = B1Helper.GetDocument(2, eDocumentObjectType.oInvoices, Program.GetCurrentCompanyDb());
            //draft3.FillLines();

        }

        static void myApplication_OnStartCreateMenu(object sender, ApplicationEventArgs e)
        {

            var myMenuModulo = Nampula.UI.Application.GetInstance().GetMenu(MenuID.cBoUIModulesMenu);

            var menu = new Nampula.UI.MenuItem("Lista de Empresas");

            var mnuTeste =
                new Nampula.UI.MenuItem(myMenuModulo, BoMenuType.mt_POPUP, "Nampula Teste");

            var mnuFormBind = new Nampula.UI.MenuItem(mnuTeste, BoMenuType.mt_STRING, "Form Binding");
            mnuFormBind.OnAfterClick += mnuFormBind_OnAfterClick;
            var mnuTesteForm =
                new Nampula.UI.MenuItem(mnuTeste, BoMenuType.mt_STRING, "Teste");

            mnuTesteForm.OnBeforeClick += mnuTesteForm_OnBeforeClick;

            var gridViewEditMenu = new Nampula.UI.MenuItem(mnuTeste, BoMenuType.mt_STRING, "GridView Editable Sample");

            gridViewEditMenu.OnBeforeClick += gridViewEditMenu_OnBeforeClick;

            var menuPayment = new Nampula.UI.MenuItem(mnuTeste, BoMenuType.mt_STRING, "Incoming Payment");

            new MenuItem(mnuTeste, BoMenuType.mt_STRING, "Grid Demo")
                .OnAfterClick += Program_OnAfterClick;

            menuPayment.OnBeforeClick += menuPayment_OnBeforeClick;

            FormSystemManager.Instance().AddFormWath(new BusinessPartnerForm());

            ApplicationSAP.GetInstance().CreateLogginMenu(mnuTeste);

        }

        private static void Program_OnAfterClick(object sender, MenuEventArgs e)
        {
            try
            {
                var form = new FormGridDemo();
                form.Show();
            }
            catch (Exception ex)
            {
                Nampula.UI.Application.GetInstance().MessageBox(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void menuPayment_OnBeforeClick(object sender, MenuEventArgs e)
        {
            try
            {
                var form = new PaymentForm();
                form.Show();
            }
            catch (Exception ex)
            {
                Nampula.UI.Application.GetInstance().MessageBox(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void mnuFormBind_OnAfterClick(object sender, MenuEventArgs e)
        {
            try
            {
                var form = new frmBind();
                form.Show();
            }
            catch (Exception ex)
            {
                Nampula.UI.Application.GetInstance().MessageBox(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void gridViewEditMenu_OnBeforeClick(object sender, MenuEventArgs e)
        {
            try
            {
                var form = new GridViewEditorDemo();
                form.Show();
            }
            catch (Exception ex)
            {
                Nampula.UI.Application.GetInstance().MessageBox(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void mnuTesteForm_OnBeforeClick(object sender, MenuEventArgs e)
        {
            try
            {
                new frmForm().Show();
            }
            catch (Exception ex)
            {
                Nampula.UI.Application.GetInstance().MessageBox(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal static string GetCurrentCompanyDb()
        {
            return Nampula.UI.Application.GetInstance().Company.DatabaseName;
        }


        internal static string GetCurrentUserName()
        {
            return Nampula.UI.Application.GetInstance().Company.UserName;
        }
    }

}
