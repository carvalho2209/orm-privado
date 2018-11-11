using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Accountings
{
    public class JournalEntries : TableAdapter
    {
        public struct TableDefinition
        {
            public  static readonly string TableName = "OJDT";
        }

        public struct FieldsName
        {
            public static readonly string BatchNum = "BatchNum";
            public static readonly string TransId = "TransId";
            public static readonly string BtfStatus = "BtfStatus";
            public static readonly string TransType = "TransType";
            public static readonly string BaseRef = "BaseRef";
            public static readonly string RefDate = "RefDate";
            public static readonly string Memo = "Memo";
            public static readonly string Ref1 = "Ref1";
            public static readonly string Ref2 = "Ref2";
            public static readonly string Number = "Number";
            public static readonly string Project = "Project";
            public static readonly string DueDate = "DueDate";
            public static readonly string TaxDate = "TaxDate";
            public static readonly string CreateDate = "CreateDate";
        }

        public struct FieldsDescription
        {
            public static readonly string BatchNum = "BatchNum";
            public static readonly string TransId = "Nº transação";
            public static readonly string BtfStatus = "Status";
            public static readonly string TransType = "Tipo transação";
            public static readonly string BaseRef = "Base ref";
            public static readonly string RefDate = "Data ref";
            public static readonly string Memo = "Observações";
            public static readonly string Ref1 = "Ref 1";
            public static readonly string Ref2 = "Ref 2";
            public static readonly string Number = "Nº";
            public static readonly string Project = "Projeto";
            public static readonly string DueDate = "Vencimento";
            public static readonly string TaxDate = "Data doc";
            public static readonly string CreateDate = "Criação";
        }

        TableAdapterField m_BatchNum = new TableAdapterField(FieldsName.BatchNum, FieldsDescription.BatchNum, DbType.Int32);
        TableAdapterField m_TransId = new TableAdapterField(FieldsName.TransId, FieldsDescription.TransId, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_BtfStatus = new TableAdapterField(FieldsName.BtfStatus, FieldsDescription.BtfStatus, 1);
        TableAdapterField m_TransType = new TableAdapterField(FieldsName.TransType, FieldsDescription.TransType, 20);
        TableAdapterField m_BaseRef = new TableAdapterField(FieldsName.BaseRef, FieldsDescription.BaseRef, 11);
        TableAdapterField m_RefDate = new TableAdapterField(FieldsName.RefDate, FieldsDescription.RefDate, DbType.DateTime);
        TableAdapterField m_Memo = new TableAdapterField(FieldsName.Memo, FieldsDescription.Memo, 50);
        TableAdapterField m_Ref1 = new TableAdapterField(FieldsName.Ref1, FieldsDescription.Ref1, 100);
        TableAdapterField m_Ref2 = new TableAdapterField(FieldsName.Ref2, FieldsDescription.Ref2, 100);
        TableAdapterField m_Number = new TableAdapterField(FieldsName.Number, FieldsDescription.Number, DbType.Int32);
        TableAdapterField m_Project = new TableAdapterField(FieldsName.Project, FieldsDescription.Project, 20);
        TableAdapterField m_DueDate = new TableAdapterField(FieldsName.DueDate, FieldsDescription.DueDate, DbType.DateTime);
        TableAdapterField m_TaxDate = new TableAdapterField(FieldsName.TaxDate, FieldsDescription.TaxDate, DbType.DateTime);
        TableAdapterField m_CreateDate = new TableAdapterField(FieldsName.CreateDate, FieldsDescription.CreateDate, DbType.DateTime);


        public JournalEntries()
            : base(TableDefinition.TableName)
        {

        }

        public JournalEntries(string companyDb)
          : base(companyDb, TableDefinition.TableName)
        {
          
        }

        public int BatchNum
        {
            get { return m_BatchNum.GetInt32(); }
            set { m_BatchNum.Value = value; }
        }

        public int TransId
        {
            get { return m_TransId.GetInt32(); }
            set { m_TransId.Value = value; }
        }

        public string BtfStatus
        {
            get { return m_BtfStatus.GetString(); }
            set { m_BtfStatus.Value = value; }
        }

        public string TransType
        {
            get { return m_TransType.GetString(); }
            set { m_TransType.Value = value; }
        }

        public string BaseRef
        {
            get { return m_BaseRef.GetString(); }
            set { m_BaseRef.Value = value; }
        }

        public DateTime RefDate
        {
            get { return m_RefDate.GetDateTime(); }
            set { m_RefDate.Value = value; }
        }

        public string Memo
        {
            get { return m_Memo.GetString(); }
            set { m_Memo.Value = value; }
        }

        public string Ref1
        {
            get { return m_Ref1.GetString(); }
            set { m_Ref1.Value = value; }
        }

        public string Ref2
        {
            get { return m_Ref2.GetString(); }
            set { m_Ref2.Value = value; }
        }

        public int Number
        {
            get { return m_Number.GetInt32(); }
            set { m_Number.Value = value; }
        }

        public string Project
        {
            get { return m_Project.GetString(); }
            set { m_Project.Value = value; }
        }

     
        public DateTime DueDate
        {
            get { return m_DueDate.GetDateTime(); }
            set { m_DueDate.Value = value; }
        }

        public DateTime TaxDate
        {
            get { return m_TaxDate.GetDateTime(); }
            set { m_TaxDate.Value = value; }
        }

        public DateTime CreateDate
        {
            get { return m_CreateDate.GetDateTime(); }
            set { m_CreateDate.Value = value; }
        }

        public bool GetByKey(int transId)
        {
            this.TransId = transId;
            return GetByKey();
        }

        public List<JournalEntryLine> Lines { get; set; }

        public void FillLines()
        {
            var line = new JournalEntryLine(this.DBName);
            var tbQuery = new TableQuery(line);

            tbQuery.Where.Add(new QueryParam( line.Collumns[JournalEntryLine.FieldsName.TransId], this.TransId));

            Lines = line.FillCollection<JournalEntryLine>(tbQuery);
        }
    }
}
