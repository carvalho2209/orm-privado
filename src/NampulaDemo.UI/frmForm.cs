using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nampula.DI.B1.Helpers;
using NampulaDemo.DI.Factory;
using Nampula.DI;
using Iris.DI.Settings;
using Nampula.DI.ScriptWizard;
using Nampula.DI.B1.BusinessPartners;
using Nampula.UI.Helpers;
using Nampula.UI.Permissions;
using Nampula.DI.B1.UserPermissions;
using Nampula.DI.B1.Accountings;
using Nampula.Framework;
using Nampula.UI.Helpers.Extentions;
using Nampula.DI.B1.Documents;

namespace NampulaDemo
{
    public partial class frmForm : Nampula.UI.Form
    {
        public frmForm()
        {
            Permission.HasPermission(Security.Packinlist, PermissionType.ReadOnly);

            InitializeComponent();

            FormatCardCode();

            FormatMultiplos();
            FormatJounalEntryChoose();
            var list = new List<object>();

            list.Add(new object());

            gridView2.FormatGrid<NotaFiscalSequence>(Program.GetCurrentCompanyDb());


            dataGrid2.DataSource = new Nampula.DI.B1.Documents.NotaFiscalSequence(Program.GetCurrentCompanyDb()).GetData(); ;

        }

        private void FormatJounalEntryChoose()
        {
           var chooseJournal =  new ChooseFromListHelper(editTextJournalEntry, editTextButtonJournalAccount,
                new TableQuery(new JournalEntries(Program.GetCurrentCompanyDb())),
                JournalEntries.FieldsName.TransId, JournalEntries.FieldsName.Memo, "Lançamento");

            chooseJournal.AfterTryGetRecord += ChooseJournal_AfterTryGetRecord;
        }

        private void ChooseJournal_AfterTryGetRecord(object sender, ChooseFromListEventArgs e)
        {
            try
            {
                var journal = new JournalEntries(Program.GetCurrentCompanyDb());
                if (journal.GetByKey(e.Record[JournalEntries.FieldsName.TransId].To<int>()))
                    journal.FillLines();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void FormatCardCode()
        {
            BusinessPartner bp = new BusinessPartner(Program.GetCurrentCompanyDb());
            TableQuery query = new TableQuery(bp);

            var fc = new FormatConditionChoose(DevExpress.XtraGrid.FormatConditionEnum.Equal,
                BusinessPartner.FieldsName.CardType, "C", null, true);
            fc.ForeColor = Color.Red;
            fc.BackColor = Color.Purple;
            List<FormatConditionChoose> list = new List<FormatConditionChoose>();
            list.Add(fc);

            var choose = new ChooseFromListHelper(
                txtCardCode, txtCardName, list, query,
                BusinessPartner.FieldsName.CardCode,
                BusinessPartner.FieldsName.CardName,
                "Parceiros");

            choose.AfterTryGetRecord += new ChooseFromListHandler(choose_AfterTryGetRecord);
            //choose.WhereColumns.Add( bp.Collumns[BusinessPartner.FieldsName.CardCode] );

        }

        private void FormatMultiplos()
        {
            var bp = new BusinessPartner(Program.GetCurrentCompanyDb());
            var query = new TableQuery(bp);

            var choose = new ChooseFromListHelper(
                cardCodeMultEdit, cardNameMultEdit,
                query,
                BusinessPartner.FieldsName.CardCode,
                BusinessPartner.FieldsName.CardName,
                "Parceiros");

            choose.AllowSelectionsMultiples = true;

            choose.AfterTryGetRecord += (o, args) =>
            {
                gridView1.Columns.Clear();
                var selecionados = args.Records.Select(c =>
                {
                    var newBp = B1Helper.GetByKey<BusinessPartner>( Program.GetCurrentCompanyDb(), c["CardCode"] );
                    return newBp;
                })
                .ToList();

                dataGrid1.DataSource = selecionados;
            };
        }

        void choose_AfterTryGetRecord(object sender, ChooseFromListEventArgs e)
        {
            //MessageBox(e.Record[0].ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.MessageBox.Show("Teste", "Teste", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);


            MessageBox("Teste", MessageBoxButtons.OK, MessageBoxIcon.Error);

            MessageBox("Information");

            ShowMessageError(new Exception("Error"));

            MessageBox("Question ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            MessageBox("Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (var warehouse = new frmChooseWarehouse(Program.GetCurrentCompanyDb()))
            //    {
            //        if (warehouse.ShowDialog(this) == DialogResult.OK)
            //            MessageBox(warehouse.SelectedRow.WhsName);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    base.ShowMessageError(ex);
            //}

        }

        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            ProfitabilityBase obj = DBTeste.CreateObject<ProfitabilityBase>();

            TableQuery query = new TableQuery(obj);

            WhereCollection where = new WhereCollection()
                {
                    new QueryParam( obj.Collumns[0], "1")
                };

            WhereCollection where1 = new WhereCollection()
                {
                    new QueryParam( obj.Collumns[1], eCondition.ecIsNull),
                };

            query.Wheres.Add(where);
            query.Wheres.Add(where1);

            SqlServerScriptWizard scrip = new SqlServerScriptWizard(query);

            var result = scrip.GetSelectStatment();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormGridDemo().ShowDialog(this);
        }

        private void chooseButton1_Click_1(object sender, EventArgs e)
        {
            new FormGridDemo().Show();
        }

        private void DIalog_Click(object sender, EventArgs e)
        {
            var teste = new TesteClassFormShowModal();
            teste.Dummy();
        }

        private void cmdAtivate_Click(object sender, EventArgs e)
        {
            try
            {
                var menu = Nampula.UI.Application.GetInstance().GetMenu("2563");
                menu.Activate();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void buttonEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            buttonEdit1.Properties.Buttons[0].Image = Properties.Resources.ChooseFromLstBtnPresses;
            MessageBox("Teste");
            buttonEdit1.Properties.Buttons[0].Image = Properties.Resources.ChooseFromLstBtn;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            BusinessPartner bp = new BusinessPartner(Program.GetCurrentCompanyDb());
            TableQuery query = new TableQuery(bp);

            var script = new CommandService().SqlQuery(query, 1, 20, "CardCode", eOrder.eoASC);

        }


    }
}
