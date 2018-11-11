using System;
using System.Collections.Generic;
using System.Data;
using Nampula.DI.B1.Documents;

namespace Nampula.DI.B1.Payments
{
    public class IncomingPayment : TableAdapter
    {
        public struct Definition
        {
            public static string TableName = "ORCT";
        }

        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string DocNum = "DocNum";
            public static readonly string ObjType = "ObjType";
            public static readonly string Canceled = "Canceled";
            public static readonly string DocDate = "DocDate";
            public static readonly string DocDueDate = "DocDueDate";
            public static readonly string CardCode = "CardCode";
            public static readonly string CardName = "CardName";
            
            public static readonly string DdctPrcnt = "DdctPrcnt";
            public static readonly string DdctSum = "DdctSum";
            public static readonly string CashAcct = "CashAcct";
            public static readonly string CashSum = "CashSum";
            public static readonly string CreditSum = "CreditSum";
            public static readonly string CheckAcct = "CheckAcct";
            public static readonly string CheckSum = "CheckSum";
            public static readonly string TrsfrAcct = "TrsfrAcct";
            public static readonly string TrsfrSum = "TrsfrSum";
            public static readonly string TrsfrDate = "TrsfrDate";
            public static readonly string TrsfrRef = "TrsfrRef";
            public static readonly string BoeAcc = "BoeAcc";
            public static readonly string BoeSum = "BoeSum";
            public static readonly string DocCurr = "DocCurr";
            public static readonly string DocRate = "DocRate";
            public static readonly string DocTotal = "DocTotal";

            public static readonly string TransId = "TransId";
        }

        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Número";
            public static readonly string DocNum = "Número Manual";
            public static readonly string ObjType = "Tipo";
            public static readonly string Canceled = "Canceledo";
            public static readonly string DocDate = "Data do Documento";
            public static readonly string DocDueDate = "Data de Vencimento";
            public static readonly string CardCode = "Código";
            public static readonly string CardName = "Nome";
            
            public static readonly string DdctPrcnt = "% Dedução";
            public static readonly string DdctSum = "Valor Dedução";
            public static readonly string CashAcct = "Conta Caixa";
            public static readonly string CashSum = "Valor Dinheiro";
            public static readonly string CreditSum = "Valor Crédito";
            public static readonly string CheckAcct = "Conta Corrente";
            public static readonly string CheckSum = "Valor Cheque";
            public static readonly string TrsfrAcct = "Conta Transferência";
            public static readonly string TrsfrSum = "Valor Transferência";
            public static readonly string TrsfrDate = "Data Transferência";
            public static readonly string TrsfrRef = "Finalidade";
            public static readonly string BoeAcc = "Conta Boleto";
            public static readonly string BoeSum = "Valor Boleto";
            public static readonly string DocCurr = "Moeda";
            public static readonly string DocRate = "Taxa moeda";
            public static readonly string DocTotal = "Total do Documento";

            public static readonly string TransId = "Número Transação";
        }

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_DocNum = new TableAdapterField(FieldsName.DocNum, FieldsDescription.DocNum, DbType.Int32);
        TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, DbType.Int32);
        TableAdapterField m_Canceled = new TableAdapterField(FieldsName.Canceled, FieldsDescription.Canceled, 1);
        TableAdapterField m_DocDate = new TableAdapterField(FieldsName.DocDate, FieldsDescription.DocDate, DbType.DateTime);
        TableAdapterField m_DocDueDate = new TableAdapterField(FieldsName.DocDueDate, FieldsDescription.DocDueDate, DbType.DateTime);
        TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, FieldsDescription.CardCode, 15);
        TableAdapterField m_CardName = new TableAdapterField(FieldsName.CardName, FieldsDescription.CardName, 200);
        TableAdapterField m_DdctPrcnt = new TableAdapterField(FieldsName.DdctPrcnt, FieldsDescription.DdctPrcnt, DbType.Decimal, 19, 6);
        TableAdapterField m_DdctSum = new TableAdapterField(FieldsName.DdctSum, FieldsDescription.DdctSum, DbType.Decimal, 19, 6);
        TableAdapterField m_CashAcct = new TableAdapterField(FieldsName.CashAcct, FieldsDescription.CashAcct, DbType.Int16);
        TableAdapterField m_CashSum = new TableAdapterField(FieldsName.CashSum, FieldsDescription.CashSum, DbType.Decimal, 19, 6);
        TableAdapterField m_CreditSum = new TableAdapterField(FieldsName.CreditSum, FieldsDescription.CreditSum, DbType.Decimal, 19, 6);
        TableAdapterField m_CheckAcct = new TableAdapterField(FieldsName.CheckAcct, FieldsDescription.CheckAcct, DbType.Int16);
        TableAdapterField m_CheckSum = new TableAdapterField(FieldsName.CheckSum, FieldsDescription.CheckSum, DbType.Decimal, 19, 6);
        TableAdapterField m_TrsfrAcct = new TableAdapterField(FieldsName.TrsfrAcct, FieldsDescription.TrsfrAcct, DbType.Int32);
        TableAdapterField m_TrsfrSum = new TableAdapterField(FieldsName.TrsfrSum, FieldsDescription.TrsfrSum, DbType.Decimal, 19, 6);
        TableAdapterField m_TrsfrDate = new TableAdapterField(FieldsName.TrsfrDate, FieldsDescription.TrsfrDate, DbType.DateTime);
        TableAdapterField m_TrsfrRef = new TableAdapterField(FieldsName.TrsfrRef, FieldsDescription.TrsfrRef, 50);
        TableAdapterField m_BoeAcc = new TableAdapterField(FieldsName.BoeAcc, FieldsDescription.BoeAcc, DbType.Int32);
        TableAdapterField m_BoeSum = new TableAdapterField(FieldsName.BoeSum, FieldsDescription.BoeSum, DbType.Decimal, 19, 6);
        TableAdapterField m_DocCurr = new TableAdapterField(FieldsName.DocCurr, FieldsDescription.DocCurr, 3);
        TableAdapterField m_DocRate = new TableAdapterField(FieldsName.DocRate, FieldsDescription.DocRate, DbType.Decimal, 19, 6);
        TableAdapterField m_DocTotal = new TableAdapterField(FieldsName.DocTotal, FieldsDescription.DocTotal, DbType.Decimal, 19, 6);
        TableAdapterField m_TransId = new TableAdapterField(FieldsName.TransId, FieldsDescription.TransId, DbType.Int32);

        public IncomingPayment()
            :base(Definition.TableName)
        {
            PaymentLines = new List<IncomingPaymentLine>();
        }

        public IncomingPayment(string pComapny)
            :this()
        {
            DBName = pComapny;
        }

        public IncomingPayment(IncomingPayment payment)
            : this()
        {
            CopyBy(payment);

            payment.PaymentLines.ForEach(
                l => PaymentLines.Add(new IncomingPaymentLine(l))); 
        }
        
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public Int32 DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public Int32 DocNum
        {
            get { return m_DocNum.GetInt32(); }
            set { m_DocNum.Value = value; }
        }

        public UInt32 ObjType
        {
            get { return m_ObjType.GetUInt32(); }
            set { m_ObjType.Value = value; }
        }

        public String Canceled
        {
            get { return m_Canceled.GetString(); }
            set { m_Canceled.Value = value; }
        }

        public DateTime DocDate
        {
            get { return m_DocDate.GetDateTime(); }
            set { m_DocDate.Value = value; }
        }

        public DateTime DocDueDate
        {
            get { return m_DocDueDate.GetDateTime(); }
            set { m_DocDueDate.Value = value; }
        }

        public String CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public String CardName
        {
            get { return m_CardName.GetString(); }
            set { m_CardName.Value = value; }
        }

        public Decimal DdctPrcnt
        {
            get { return m_DdctPrcnt.GetDecimal(); }
            set { m_DdctPrcnt.Value = value; }
        }

        public Decimal DdctSum
        {
            get { return m_DdctSum.GetDecimal(); }
            set { m_DdctSum.Value = value; }
        }

        public Int32 CashAcct
        {
            get { return m_CashAcct.GetInt32(); }
            set { m_CashAcct.Value = value; }
        }

        public Decimal CashSum
        {
            get { return m_CashSum.GetDecimal(); }
            set { m_CashSum.Value = value; }
        }

        public Decimal CreditSum
        {
            get { return m_CreditSum.GetDecimal(); }
            set { m_CreditSum.Value = value; }
        }

        public Int32 CheckAcct
        {
            get { return m_CheckAcct.GetInt32(); }
            set { m_CheckAcct.Value = value; }
        }

        public Decimal CheckSum
        {
            get { return m_CheckSum.GetDecimal(); }
            set { m_CheckSum.Value = value; }
        }

        public Int32 TrsfrAcct
        {
            get { return m_TrsfrAcct.GetInt32(); }
            set { m_TrsfrAcct.Value = value; }
        }

        public Decimal TrsfrSum
        {
            get { return m_TrsfrSum.GetDecimal(); }
            set { m_TrsfrSum.Value = value; }
        }


        public DateTime TrsfrDate
        {
            get { return m_TrsfrDate.GetDateTime(); }
            set { m_TrsfrDate.Value = value; }
        }

        public String TrsfrRef
        {
            get { return m_TrsfrRef.GetString(); }
            set { m_TrsfrRef.Value = value; }
        }

        public Int32 BoeAcc
        {
            get { return m_BoeAcc.GetInt32(); }
            set { m_BoeAcc.Value = value; }
        }

        public Decimal BoeSum
        {
            get { return m_BoeSum.GetDecimal(); }
            set { m_BoeSum.Value = value; }
        }

        public String DocCur
        {
            get { return m_DocCurr.GetString(); }
            set { m_DocCurr.Value = value; }
        }

        public Decimal DocRate
        {
            get { return m_DocRate.GetDecimal(); }
            set { m_DocRate.Value = value; }
        }

        public Decimal DocTotal
        {
            get { return m_DocTotal.GetDecimal(); }
            set { m_DocTotal.Value = value; }
        }

        public Int32 TransId
        {
            get { return m_TransId.GetInt32(); }
            set { m_TransId.Value = value; }
        }

        public List<IncomingPaymentLine> PaymentLines { get; set; } 

        private List<IncomingPaymentLine> GetLines() 
        {
            var line = new IncomingPaymentLine(DBName);

            var lines = line.GetByDocEntry(DocEntry);

            foreach (var line1 in lines)
            {
                line1.TableName = line.TableName;
                line1.DBName = line.DBName;
            }

            return lines;
        }

        public void FillLines() 
        {
            var lines = GetLines();

            PaymentLines = lines;
        }
    }
}

