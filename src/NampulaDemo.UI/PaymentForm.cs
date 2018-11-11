using System;
using System.Collections.Generic;
using System.Data;
using Nampula.DI;
using Nampula.DI.B1.BusinessPartners;
using Nampula.DI.B1.Documents;
using Nampula.DI.B1.Payments;
using Nampula.Framework;
using Nampula.UI;
using Nampula.UI.Helpers;
using Nampula.UI.Helpers.Extentions;
using NampulaDemo.DI.Factory;

namespace NampulaDemo
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();

            FormatGrid();
        }

        private void FormatGrid()
        {
            paymentView.FormatGrid<IncomingPayment>(Program.GetCurrentCompanyDb());

            paymentView.SetVisible(new List<string>
            {
                //IncomingPayment.FieldsName.DocEntry,
                //IncomingPayment.FieldsName.DocNum,
                //IncomingPayment.FieldsName.ObjType,
                IncomingPayment.FieldsName.Canceled,
                IncomingPayment.FieldsName.DocDate,
                //IncomingPayment.FieldsName.DocDueDate,
                //IncomingPayment.FieldsName.CardCode,
                IncomingPayment.FieldsName.CardName,
                IncomingPayment.FieldsName.DdctPrcnt,
                IncomingPayment.FieldsName.DdctSum,
                IncomingPayment.FieldsName.CashAcct,
                IncomingPayment.FieldsName.CashSum,
                IncomingPayment.FieldsName.CreditSum,
                IncomingPayment.FieldsName.CheckAcct,
                //IncomingPayment.FieldsName.CheckSum,
                //IncomingPayment.FieldsName.TrsfrAcct,
                //IncomingPayment.FieldsName.TrsfrSum,
                //IncomingPayment.FieldsName.TrsfrDate,
                //IncomingPayment.FieldsName.TrsfrRef,
                IncomingPayment.FieldsName.BoeAcc,
                IncomingPayment.FieldsName.BoeSum,
                //IncomingPayment.FieldsName.DocCurr,
                //IncomingPayment.FieldsName.DocRate,
                IncomingPayment.FieldsName.DocTotal,
                //IncomingPayment.FieldsName.TransId
            }, false);

            ChoosePayment();

            paymentView.BestFitColumns();
        }



        private TableQuery GetPay(string docentry)
        {
            var incomingPayment = new IncomingPayment(Program.GetCurrentCompanyDb());
            var queryPayment = new TableQuery(incomingPayment, false, "T0");

            var paymentLine = new IncomingPaymentLine(Program.GetCurrentCompanyDb());
            var queryLine = new TableQuery(paymentLine, false, "T1");

            var joinLinePay = new QueryParam(incomingPayment.Collumns[IncomingPayment.FieldsName.DocEntry]);
            joinLinePay.Value1Column = new QueryParam(paymentLine.Collumns[IncomingPaymentLine.FieldsName.DocNum]);

            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPaymentLine.FieldsName.DocEntry]);
            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPaymentLine.FieldsName.DocNum]);
            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPayment.FieldsName.BoeSum]);
            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPayment.FieldsName.CashSum]);
            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPayment.FieldsName.CheckSum]);
            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPayment.FieldsName.TrsfrSum]);
            queryPayment.Fields.Add(incomingPayment.Collumns[IncomingPayment.FieldsName.CreditSum]);

            queryPayment.Joins.Add(new Join(queryLine, new WhereCollection(joinLinePay)));

            queryPayment.Where.Add(new QueryParam(paymentLine.Collumns[IncomingPaymentLine.FieldsName.DocEntry], docentry));

            incomingPayment.FillCollection<IncomingPaymentLine>(queryPayment);

            return queryPayment;

        }

        private void ChoosePayment()
        {
            var payment = new IncomingPayment(Program.GetCurrentCompanyDb());
            var query = new TableQuery(payment);

            var choose = new ChooseFromListHelper(
                paymentView.Columns[IncomingPayment.FieldsName.DocEntry],
                paymentView.Columns[IncomingPayment.FieldsName.DocNum],
                query,
                IncomingPayment.FieldsName.DocEntry,
                IncomingPayment.FieldsName.DocNum, "Pagamentos");

            choose.AfterTryGetRecord += delegate(object sender, ChooseFromListEventArgs e)
            {
                var rowSel = paymentView.GetFocusedDataRow();
              
                rowSel.SetField(IncomingPayment.FieldsName.DocEntry,
                    e.Record.Field<String>(IncomingPayment.FieldsName.DocEntry));
                
                rowSel.SetField(IncomingPaymentLine.FieldsName.DocNum,
                    e.Record.Field<String>(IncomingPaymentLine.FieldsName.DocNum));
            };

            paymentGrid.DataSource = payment.GetData();
        }

        private void txtDoc_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GetPay(txtDoc.Text);

            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }
    }
}
