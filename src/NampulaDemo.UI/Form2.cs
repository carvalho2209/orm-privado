using System;
using System.Data;
using Nampula.UI.Helpers.Extentions;
using Nampula.DI.B1.BusinessPartners;
using Nampula.UI.Helpers;
using Nampula.DI;
using Nampula.UI;
using Nampula.UI.Permissions;
using Nampula.DI.B1.UserPermissions;
using Nampula.DI.B1.NotaFiscal;
using Nampula.DI.B1.ChartOfAccounts;

namespace NampulaDemo
{
    public partial class FormGridDemo : Form
    {
        public FormGridDemo()
        {
            InitializeComponent();

            Permission.HasPermission(Security.PackinlistRemove, PermissionType.Full);

            gridView1.FormatGrid<BusinessPartner>(
                Program.GetCurrentCompanyDb());

            var bp = new BusinessPartner(Program.GetCurrentCompanyDb());
            var query = new TableQuery(bp);

            gridView1.Columns[BusinessPartner.FieldsName.CardCode].SetLinkedButton(BoLinkedObject.lf_BusinessPartner);

            var choose = new ChooseFromListHelper(
                gridView1.Columns[BusinessPartner.FieldsName.CardCode],
                gridView1.Columns[BusinessPartner.FieldsName.CardName],
                query,
                BusinessPartner.FieldsName.CardCode,
                BusinessPartner.FieldsName.CardName, "Clientes");

            choose.AfterTryGetRecord += delegate(object sender, ChooseFromListEventArgs e)
            {
                var rowSel = gridView1.GetFocusedDataRow();
                rowSel.SetField<string>(
                    BusinessPartner.FieldsName.CardCode,
                    e.Record.Field<String>(BusinessPartner.FieldsName.CardCode));
                rowSel.SetField<string>(
                    BusinessPartner.FieldsName.CardName,
                    e.Record.Field<String>(BusinessPartner.FieldsName.CardName));
            };

            var chooseNotaFiscalCstCode = new ChooseFromListHelper(editText2,
                editTextButton1,
                new TableQuery(new NotaFiscalCstCode(Program.GetCurrentCompanyDb())), eCondition.ecLike,
                NotaFiscalCstCode.FieldsName.Code, NotaFiscalCstCode.FieldsName.Situation,
                "Imposto Cst"
                );

            new ChooseFromListHelper(editTextChartOfAcc, editTextButtonChartOfAcc, new TableQuery(
                new ChartOfAccount(
                Program.GetCurrentCompanyDb())), 
                ChartOfAccount.FieldsName.AcctCode,
                ChartOfAccount.FieldsName.AcctName, "Contas contábeis");

            dataGrid1.DataSource = bp.GetData();

            gridView1.SetAllEditable(true);

            gridView1.Columns[BusinessPartner.FieldsName.CardCode].OptionsColumn.AllowEdit = true;
            gridView1.Columns[BusinessPartner.FieldsName.CardName].OptionsColumn.AllowEdit = true;

            //gridView1.Columns[BusinessPartner.FieldsName.CardCode].ColumnEdit.ReadOnly = false;
            //gridView1.Columns[BusinessPartner.FieldsName.CardName].ColumnEdit.ReadOnly = false;

            editText1.Select();

            this.Load += new EventHandler(Form2_Load);
        }

        void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            editText1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
