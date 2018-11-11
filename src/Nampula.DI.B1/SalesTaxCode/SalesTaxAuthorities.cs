using System;
using System.Data;

namespace Nampula.DI.B1.SalesTaxCode
{
    
    /// <summary>
    /// Tabela de OSTA - SalesTaxAuthorities
    /// </summary>
    public class SalesTaxAuthorities : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "SalesTaxAuthorities";
        }

        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
            public static readonly string Rate = "Rate";
            public static readonly string SalesTax = "SalesTax";
            public static readonly string Type = "Type";
            public static readonly string U_Base = "U_Base";
            public static readonly string U_Isento = "U_Isento";
            public static readonly string U_Outros = "U_Outros";
            public static readonly string U_Lucro = "U_Lucro";
        }

        public struct FieldsDescription
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
            public static readonly string Rate = "Rate";
            public static readonly string SalesTax = "SalesTax";
            public static readonly string Type = "Type";
            public static readonly string U_Base = "U_Base";
            public static readonly string U_Isento = "U_Isento";
            public static readonly string U_Outros = "U_Outros";
            public static readonly string U_Lucro = "U_Lucro";
        }

        public SalesTaxAuthorities(string pCompanyDb)
            : base(pCompanyDb, "OSTA")
        {

        }

        public SalesTaxAuthorities()
        {
            base.TableName = "OSTA";
        }

        readonly TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, 30);
        readonly TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, FieldsDescription.Name, 200);
        readonly TableAdapterField m_Rate = new TableAdapterField(FieldsName.Rate, FieldsDescription.Rate, DbType.Decimal);
        readonly TableAdapterField m_SalesTax = new TableAdapterField(FieldsName.SalesTax, FieldsDescription.SalesTax, 30);
        readonly TableAdapterField m_Type = new TableAdapterField(FieldsName.Type, FieldsDescription.Type, DbType.Int32);
        readonly TableAdapterField m_U_Base = new TableAdapterField(FieldsName.U_Base, FieldsDescription.U_Base, DbType.Decimal);
        readonly TableAdapterField m_U_Isento = new TableAdapterField(FieldsName.U_Isento, FieldsDescription.U_Isento, DbType.Decimal);
        readonly TableAdapterField m_U_Outros = new TableAdapterField(FieldsName.U_Outros, FieldsDescription.U_Outros, DbType.Decimal);
        readonly TableAdapterField m_U_Lucro = new TableAdapterField(FieldsName.U_Lucro, FieldsDescription.U_Lucro, DbType.Decimal);

        //public SalesTaxAuthorities(SalesTaxAuthorities pSalesTaxAuthorities)
        //    : this()
        //{
        //    this.CopyBy(pSalesTaxAuthorities);
        //}

        public String Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public String Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public Decimal Rate
        {
            get { return m_Rate.GetDecimal(); }
            set { m_Rate.Value = value; }
        }

        public String SalesTax
        {
            get { return m_SalesTax.GetString(); }
            set { m_SalesTax.Value = value; }
        }

        public Int32 Type
        {
            get { return m_Type.GetInt32(); }
            set { m_Type.Value = value; }
        }

        public Decimal U_Base
        {
            get { return m_U_Base.GetDecimal(); }
            set { m_U_Base.Value = value; }
        }

        public Decimal U_Isento
        {
            get { return m_U_Isento.GetDecimal(); }
            set { m_U_Isento.Value = value; }
        }

        public Decimal U_Outros
        {
            get { return m_U_Outros.GetDecimal(); }
            set { m_U_Outros.Value = value; }
        }

        public Decimal U_Lucro
        {
            get { return m_U_Lucro.GetDecimal(); }
            set { m_U_Lucro.Value = value; }
        }
    }
}
