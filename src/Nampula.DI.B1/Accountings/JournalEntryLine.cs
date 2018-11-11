using System;
using System.Data;

namespace Nampula.DI.B1.Accountings
{
    public class JournalEntryLine : TableAdapter
    {
        public struct TableDefinition
        {
            public static readonly string TableName = "JDT1";
        }

        public struct FieldsName
        {
            public static readonly string TransId = "TransId";
            public static readonly string Line_ID = "Line_ID";
            public static readonly string Account = "Account";
            public static readonly string Debit = "Debit";
            public static readonly string Credit = "Credit";
            public static readonly string DueDate = "DueDate";
            public static readonly string LineMemo = "LineMemo";
        }

        public struct FieldsDescription
        {
            public static readonly string TransId = "TransId";
            public static readonly string Line_ID = "Line_ID";
            public static readonly string Account = "Account";
            public static readonly string Debit = "Debit";
            public static readonly string Credit = "Credit";
            public static readonly string DueDate = "DueDate";
            public static readonly string LineMemo = "LineMemo";
        }


        TableAdapterField m_LineId = new TableAdapterField(FieldsName.Line_ID, FieldsDescription.Line_ID, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_TransId = new TableAdapterField(FieldsName.TransId, FieldsDescription.TransId, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_Account = new TableAdapterField(FieldsName.Account, FieldsDescription.Account, 15);
        TableAdapterField m_Debit = new TableAdapterField(FieldsName.Debit, FieldsDescription.Debit, DbType.Decimal, 19, 6);
        TableAdapterField m_Credit = new TableAdapterField(FieldsName.Credit, FieldsDescription.Credit, DbType.Decimal, 19, 6);
        TableAdapterField m_DueDate = new TableAdapterField(FieldsName.DueDate, FieldsDescription.DueDate, DbType.DateTime);
        TableAdapterField m_LineMemo = new TableAdapterField(FieldsName.LineMemo, FieldsDescription.LineMemo, 50);

        public JournalEntryLine()
            : base(TableDefinition.TableName)
        {

        }

        public JournalEntryLine(string companyDb)
            : base(companyDb, TableDefinition.TableName)
        {

        }

        public int TransId
        {
            get { return m_TransId.GetInt32(); }
            set { m_TransId.Value = value; }
        }

        public int Line_ID
        {
            get { return m_LineId.GetInt32(); }
            set { m_LineId.Value = value; }
        }

        public string Account
        {
            get { return m_Account.GetString(); }
            set { m_Account.Value = value; }
        }

        public decimal Debit
        {
            get { return m_Debit.GetDecimal(); }
            set { m_Debit.Value = value; }
        }

        public decimal Credit
        {
            get { return m_Credit.GetDecimal(); }
            set { m_Credit.Value = value; }
        }

        public DateTime DueDate
        {
            get { return m_DueDate.GetDateTime(); }
            set { m_DueDate.Value = value; }
        }

        public string LineMemo
        {
            get { return m_LineMemo.GetString(); }
            set { m_LineMemo.Value = value; }
        }
    }
}