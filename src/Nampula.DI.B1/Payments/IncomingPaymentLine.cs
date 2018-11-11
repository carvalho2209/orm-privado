using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.Payments
{
    public class IncomingPaymentLine : TableAdapter
    {

        public struct Definition
        {
            public static string TableName = "RCT2";
        }

        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string DocNum = "DocNum";
            public static readonly string ObjType = "ObjType";
            public static readonly string SumApplied = "SumApplied";
        }

        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Número";
            public static readonly string DocNum = "Número Manual";
            public static readonly string ObjType = "Tipo";
            public static readonly string SumApplied = "Parcela";
        }

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_DocNum = new TableAdapterField(FieldsName.DocNum, FieldsDescription.DocNum, DbType.Int32);
        TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, 1);
        TableAdapterField m_SumApplied = new TableAdapterField(FieldsName.SumApplied, FieldsDescription.SumApplied, DbType.Decimal);

        public IncomingPaymentLine(string pCompany)
            :this()
        {
            DBName = pCompany;
        }

        public IncomingPaymentLine()
            :base(Definition.TableName) { }

        public IncomingPaymentLine(IncomingPaymentLine paymentLine)
            :this()
        {
            CopyBy(paymentLine);
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

        public String ObjType
        {
            get { return m_ObjType.GetString(); }
            set { m_ObjType.Value = value; }
        }

        public Decimal SumApplied 
        {
            get { return m_SumApplied.GetDecimal(); }
            set { m_SumApplied.Value = value; }
        }

        public List<IncomingPaymentLine> GetByDocEntry(Int32 pDocEntry)
        {
            return FillCollection<IncomingPaymentLine>(GetByDocEntry(pDocEntry, true).Rows); 
        }

        public DataTable GetByDocEntry(Int32 pDocEntry, bool pResultData)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(m_DocNum, pDocEntry));

            return GetData(tableQuery); 
        }
    }
}
