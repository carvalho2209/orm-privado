using System;
using System.Data;

namespace Nampula.DI.B1.SalesTaxCode
{
    
    /// <summary>
    /// Tabela STC1 SalesTaxCodesRows
    /// </summary>
    public class SalesTaxCodesRows : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "STC1";
        }

        public struct FieldsName
        {
            public static readonly string STCCode = "STCCode";
            public static readonly string Line_ID = "Line_ID";
            public static readonly string STACode = "STACode";
            public static readonly string STAType = "STAType";
            public static readonly string TaxOnTCode = "TaxOnTCode";
            public static readonly string TaxOnTType = "TaxOnTType";
            public static readonly string EfctivRate = "EfctivRate";
            public static readonly string FmlId = "FmlId";
            public static readonly string CstCodeIn = "CstCodeIn";
            public static readonly string CstSuffix = "CstSuffix";
        }

        public struct FieldsDescription
        {
            public static readonly string STCCode = "STCCode";
            public static readonly string Line_ID = "Line_ID";
            public static readonly string STACode = "STACode";
            public static readonly string STAType = "STAType";
            public static readonly string TaxOnTCode = "TaxOnTCode";
            public static readonly string TaxOnTType = "TaxOnTType";
            public static readonly string EfctivRate = "EfctivRate";
            public static readonly string FmlId = "FmlId";
            public static readonly string CstCodeIn = "CstCodeIn";
            public static readonly string CstSuffix = "CstSuffix";
        }

        readonly TableAdapterField m_STCCode = new TableAdapterField(FieldsName.STCCode, FieldsDescription.STCCode, 30);
        readonly TableAdapterField m_Line_ID = new TableAdapterField(FieldsName.Line_ID, FieldsDescription.Line_ID, DbType.Int32);
        readonly TableAdapterField m_STACode = new TableAdapterField(FieldsName.STACode, FieldsDescription.STACode, 30);
        readonly TableAdapterField m_STAType = new TableAdapterField(FieldsName.STAType, FieldsDescription.STAType, DbType.Int32);
        readonly TableAdapterField m_TaxOnTCode = new TableAdapterField(FieldsName.TaxOnTCode, FieldsDescription.TaxOnTCode, 30);
        readonly TableAdapterField m_TaxOnTType = new TableAdapterField(FieldsName.TaxOnTType, FieldsDescription.TaxOnTType, DbType.Int32);
        readonly TableAdapterField m_EfctivRate = new TableAdapterField(FieldsName.EfctivRate, FieldsDescription.EfctivRate, DbType.Decimal);
        readonly TableAdapterField m_FmlId = new TableAdapterField(FieldsName.FmlId, FieldsDescription.FmlId, DbType.Int32);
        readonly TableAdapterField m_CstCodeIn = new TableAdapterField(FieldsName.CstCodeIn, FieldsDescription.CstCodeIn, 30);
        readonly TableAdapterField m_CstSuffix = new TableAdapterField(FieldsName.CstSuffix, FieldsDescription.CstSuffix, 30);

        public SalesTaxCodesRows(string pCompanyDb)
            : base(pCompanyDb, "STC1")
        {

        }

        public SalesTaxCodesRows()
        {
            base.TableName = "STC1";
        }

        public SalesTaxCodesRows(SalesTaxCodesRows pSalesTaxCodesRows)
            : this()
        {
            this.CopyBy(pSalesTaxCodesRows);
        }

        public String STCCode
        {
            get { return m_STCCode.GetString(); }
            set { m_STCCode.Value = value; }
        }

        public Int32 Line_ID
        {
            get { return m_Line_ID.GetInt32(); }
            set { m_Line_ID.Value = value; }
        }

        public String STACode
        {
            get { return m_STACode.GetString(); }
            set { m_STACode.Value = value; }
        }

        public Int32 STAType
        {
            get { return m_STAType.GetInt32(); }
            set { m_STAType.Value = value; }
        }

        public String TaxOnTCode
        {
            get { return m_TaxOnTCode.GetString(); }
            set { m_TaxOnTCode.Value = value; }
        }

        public Int32 TaxOnTType
        {
            get { return m_TaxOnTType.GetInt32(); }
            set { m_TaxOnTType.Value = value; }
        }

        public Decimal EfctivRate
        {
            get { return m_EfctivRate.GetDecimal(); }
            set { m_EfctivRate.Value = value; }
        }

        public Int32 FmlId
        {
            get { return m_FmlId.GetInt32(); }
            set { m_FmlId.Value = value; }
        }

        public String CstCodeIn
        {
            get { return m_CstCodeIn.GetString(); }
            set { m_CstCodeIn.Value = value; }
        }

        public String CstSuffix
        {
            get { return m_CstSuffix.GetString(); }
            set { m_CstSuffix.Value = value; }
        }

        

    }
}
