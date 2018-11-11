using System;
using System.Data;

namespace Nampula.DI.B1.Documents
{
    public class DocumentLinesAdditionalExpenses : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string ExpnsCode = "ExpnsCode";
            public static readonly string LineTotal = "LineTotal";
            public static readonly string ObjType = "ObjType";
            public static readonly string BaseGroup = "BaseGroup";
            public static readonly string TaxCode = "TaxCode";

        }

        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Nº do Documento";
            public static readonly string LineNum = "Nº da Linha";
            public static readonly string ExpnsCode = "Cód. da Despesa";
            public static readonly string LineTotal = "Total da Linha";
            public static readonly string ObjType = "Tipo do Objeto";
            public static readonly string BaseGroup = "Nº Base da Despesa";
            public static readonly string TaxCode = "Tipo do Imposto";

        }

        readonly TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32);
        readonly TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32);
        readonly TableAdapterField m_ExpnsCode = new TableAdapterField(FieldsName.ExpnsCode, FieldsDescription.ExpnsCode, DbType.Int32);
        readonly TableAdapterField m_LineTotal = new TableAdapterField(FieldsName.LineTotal, FieldsDescription.LineTotal, DbType.Decimal);
        readonly TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, FieldsDescription.ObjType, DbType.Int32);
        readonly TableAdapterField m_BaseGroup = new TableAdapterField(FieldsName.BaseGroup, FieldsDescription.BaseGroup, DbType.Int32);
        readonly TableAdapterField m_TaxCode = new TableAdapterField(FieldsName.TaxCode, FieldsDescription.TaxCode, 8);

        public DocumentLinesAdditionalExpenses()
        {
 
        }
        
        public DocumentLinesAdditionalExpenses(string companyDb, eDocumentObjectType documentObjectType)
            : base(companyDb, documentObjectType.GetTableNameSufix() + "2")
        {
            this.ObjType = documentObjectType;
        }

        public DocumentLinesAdditionalExpenses(DocumentLinesAdditionalExpenses docExpns)
            : this()
        {
            this.CopyBy(docExpns);
        }

        public Int32 DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public Int32 LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public Int32 ExpnsCode
        {
            get { return m_ExpnsCode.GetInt32(); }
            set { m_ExpnsCode.Value = value; }
        }

        public Decimal LineTotal
        {
            get { return m_LineTotal.GetDecimal(); }
            set { m_LineTotal.Value = value; }
        }
        
        public eDocumentObjectType ObjType
        {
            get { return (eDocumentObjectType)m_ObjType.GetInt32(); }
            set { m_ObjType.Value = (int)value; }
        }

        public Int32 BaseGroup
        {
            get { return m_BaseGroup.GetInt32(); }
            set { m_BaseGroup.Value = value; }
        }

        public String TaxCode
        {
            get { return m_TaxCode.GetString(); }
            set { m_TaxCode.Value = value; }
        }

        public bool GetByKey(int docEntry, int expnsCode, int baseGroup)
        {
            this.DocEntry = docEntry;
            this.ExpnsCode = expnsCode;
            this.BaseGroup = BaseGroup;

            return GetByKey();
        }

    }
}
