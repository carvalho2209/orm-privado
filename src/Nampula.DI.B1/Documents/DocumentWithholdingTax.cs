using System;
using System.Data;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Tabela de Imposto Retido na fonte para Documento de Marketing 
    /// </summary>
    public class DocumentWithholdingTax : TableAdapter
    {
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsEntry = "AbsEntry";
            public static readonly string WTCode = "WTCode";
            public static readonly string Rate = "Rate";
            public static readonly string TaxbleAmnt = "TaxbleAmnt";
            public static readonly string WTAmnt = "WTAmnt";
            public static readonly string Category = "Category";
            public static readonly string LineNum = "LineNum";
            public static readonly string Doc1LineNo = "Doc1LineNo";
        }

        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsEntry = "N° Documento";
            public static readonly string WTCode = "Código do Imposto";
            public static readonly string Rate = "Alíquota";
            public static readonly string TaxbleAmnt = "Valor sujeito a Imposto";
            public static readonly string WTAmnt = "Valor IRF";
            public static readonly string Category = "Categoria";
            public static readonly string LineNum = "LineNum";
            public static readonly string Doc1LineNo = "Linha do Documento";

        }

        readonly TableAdapterField m_AbsEntry = new TableAdapterField(FieldsName.AbsEntry, FieldsDescription.AbsEntry, DbType.Int32, 11, 0, true, false);
        readonly TableAdapterField m_WTCode = new TableAdapterField(FieldsName.WTCode, FieldsDescription.WTCode, DbType.String, 4, 0, true, false);
        readonly TableAdapterField m_Rate = new TableAdapterField(FieldsName.Rate, FieldsDescription.Rate, DbType.Decimal);
        readonly TableAdapterField m_TaxbleAmnt = new TableAdapterField(FieldsName.TaxbleAmnt, FieldsDescription.TaxbleAmnt, DbType.Decimal);
        readonly TableAdapterField m_WTAmnt = new TableAdapterField(FieldsName.WTAmnt, FieldsDescription.WTAmnt, DbType.Decimal);
        readonly TableAdapterField m_Category = new TableAdapterField(FieldsName.Category, FieldsDescription.Category, 1);
        TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32);
        TableAdapterField m_Doc1LineNo = new TableAdapterField(FieldsName.Doc1LineNo, FieldsDescription.Doc1LineNo, DbType.Int32);

        public DocumentWithholdingTax()
            : base(string.Empty)
        {
        }

        public DocumentWithholdingTax(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "5")
        {
        }

        public DocumentWithholdingTax(DocumentWithholdingTax pDocumentWithholdingTax)
            : this()
        {
            CopyBy(pDocumentWithholdingTax);
        }
        
        public int AbsEntry
        {
            get { return m_AbsEntry.GetInt32(); }
            set { m_AbsEntry.Value = value; }
        }

        public string WTCode
        {
            get { return m_WTCode.GetString(); }
            set { m_WTCode.Value = value; }
        }
        
        public decimal Rate
        {
            get { return m_Rate.GetDecimal(); }
            set { m_Rate.Value = value; }
        }

        public Decimal TaxbleAmnt
        {
            get { return m_TaxbleAmnt.GetDecimal(); }
            set { m_TaxbleAmnt.Value = value; }
        }

        public Decimal WTAmnt
        {
            get { return m_WTAmnt.GetDecimal(); }
            set { m_WTAmnt.Value = value; }
        }

        public string Category
        {
            get { return m_Category.GetString(); }
            set { m_Category.Value = value; }
        }

        public WTCategoryEnum CategoryEnum
        {
            get { return Category.ToCatEnum(); }
            set { m_Category.Value = value.ToCatString(); }
        }

        public Int32 LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public Int32 Doc1LineNo
        {
            get { return m_Doc1LineNo.GetInt32(); }
            set { m_Doc1LineNo.Value = value; }
        }
    }
}
