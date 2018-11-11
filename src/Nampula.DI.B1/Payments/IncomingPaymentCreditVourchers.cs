using System;
using System.Data;

namespace Nampula.DI.B1.Payments
{
    public class IncomingPaymentCreditVourchers : TableAdapter
    {
        public struct Definition
        {
            public static string TableName = "RCT3";
        }

        public struct FieldsName
        {
            public static readonly string DocNum = "DocNum";
            public static readonly string LineID = "LineID";
            public static readonly string CreditCard = "CreditCard";
            public static readonly string CreditAcct = "CreditAcct";
            public static readonly string CrCardNum = "CrCardNum";
            public static readonly string VoucherNum = "VoucherNum";
            public static readonly string CreditSum = "CreditSum";
            public static readonly string CreditCur = "CreditCur";
            public static readonly string CreditRate = "CreditRate";
            public static readonly string CreditType = "CreditType";
        }

        public struct FieldsDescription
        {
            public static readonly string DocNum = "Número";
            public static readonly string LineID = "LineID";
            public static readonly string CreditCard = "CreditCard";
            public static readonly string CreditAcct = "CreditAcct";
            public static readonly string CrCardNum = "CrCardNum";
            public static readonly string VoucherNum = "VoucherNum";
            public static readonly string CreditSum = "CreditSum";
            public static readonly string CreditCur = "CreditCur";
            public static readonly string CreditRate = "CreditRate";
            public static readonly string CreditType = "CreditType";
        }

        TableAdapterField m_DocNum = new TableAdapterField(FieldsName.DocNum, FieldsDescription.DocNum, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_LineID = new TableAdapterField(FieldsName.LineID, FieldsDescription.LineID, DbType.Int32);
        TableAdapterField m_CreditCard = new TableAdapterField(FieldsName.CreditCard, FieldsDescription.CreditCard, DbType.Int32);
        TableAdapterField m_CreditAcct = new TableAdapterField(FieldsName.CreditAcct, FieldsDescription.CreditAcct, 30);
        TableAdapterField m_CrCardNum = new TableAdapterField(FieldsName.CrCardNum, FieldsDescription.CrCardNum, 128);
        TableAdapterField m_VoucherNum = new TableAdapterField(FieldsName.VoucherNum, FieldsDescription.VoucherNum, 20);
        TableAdapterField m_CreditSum = new TableAdapterField(FieldsName.CreditSum, FieldsDescription.CreditSum, DbType.Decimal);
        TableAdapterField m_CreditCur = new TableAdapterField(FieldsName.CreditCur, FieldsDescription.CreditCur, 6);
        TableAdapterField m_CreditRate = new TableAdapterField(FieldsName.CreditRate, FieldsDescription.CreditRate, DbType.Decimal);
        TableAdapterField m_CreditType = new TableAdapterField(FieldsName.CreditType, FieldsDescription.CreditType, 1);

        public IncomingPaymentCreditVourchers(string pCompany)
            :this()
        {
            DBName = pCompany;
        }

        public IncomingPaymentCreditVourchers()
            :base(Definition.TableName) { }

        public IncomingPaymentCreditVourchers(IncomingPaymentCreditVourchers paymentCredit)
            :this()
        {
            CopyBy(paymentCredit);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public Int32 DocNum
        {
            get { return m_DocNum.GetInt32(); }
            set { m_DocNum.Value = value; }
        }

        public Int32 LineID
        {
            get { return m_LineID.GetInt32(); }
            set { m_LineID.Value = value; }
        }

        public Int32 CreditCard
        {
            get { return m_CreditCard.GetInt32(); }
            set { m_CreditCard.Value = value; }
        }

        public String CreditAcct
        {
            get { return m_CreditAcct.GetString(); }
            set { m_CreditAcct.Value = value; }
        }

        public String CrCardNum
        {
            get { return m_CrCardNum.GetString(); }
            set { m_CrCardNum.Value = value; }
        }

        public String VoucherNum
        {
            get { return m_VoucherNum.GetString(); }
            set { m_VoucherNum.Value = value; }
        }

        public Decimal CreditSum
        {
            get { return m_CreditSum.GetDecimal(); }
            set { m_CreditSum.Value = value; }
        }

        public String CreditCur
        {
            get { return m_CreditCur.GetString(); }
            set { m_CreditCur.Value = value; }
        }

        public Decimal CreditRate
        {
            get { return m_CreditRate.GetDecimal(); }
            set { m_CreditRate.Value = value; }
        }


        public String CreditType
        {
            get { return m_CreditType.GetString(); }
            set { m_CreditType.Value = value; }
        }


    }
}
