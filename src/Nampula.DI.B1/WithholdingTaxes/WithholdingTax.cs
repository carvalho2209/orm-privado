using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.WithholdingTaxes
{
    /// <summary>
    /// Tabela de Impostos Retidos na fonte
    /// </summary>
    public class WithholdingTax : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OWHT";
        }
        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string WTCode = "WTCode";
            public static readonly string WTName = "WTName";
            public static readonly string Rate = "Rate";
            public static readonly string EffecDate = "EffecDate";
            public static readonly string BaseType = "BaseType";
            public static readonly string PrctBsAmnt = "PrctBsAmnt";
            public static readonly string Account = "Account";
            public static readonly string Inactive = "Inactive";
            public static readonly string Category = "Category";
            public static readonly string WtTypeId = "WtTypeId";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string WTCode = "Codigo IRF";
            public static readonly string WTName = "Nome do Imposto";
            public static readonly string Rate = "Taxa";
            public static readonly string EffecDate = "Efetivo desde";
            public static readonly string BaseType = "Tipo Básico";
            public static readonly string PrctBsAmnt = "% do Valor Base";
            public static readonly string Account = "Conta";
            public static readonly string Inactive = "Inativo";
            public static readonly string Category = "Categoria";
            public static readonly string WtTypeId = "Tipo";
        }

        readonly TableAdapterField m_WTCode = new TableAdapterField(FieldsName.WTCode, FieldsDescription.WTCode, DbType.String, 4, 0, true, false);
        readonly TableAdapterField m_WTName = new TableAdapterField(FieldsName.WTName, FieldsDescription.WTName, 50);
        readonly TableAdapterField m_Rate = new TableAdapterField(FieldsName.Rate, FieldsDescription.Rate, DbType.Decimal);
        readonly TableAdapterField m_EffecDate = new TableAdapterField(FieldsName.EffecDate, FieldsDescription.EffecDate, DbType.DateTime);
        readonly TableAdapterField m_BaseType = new TableAdapterField(FieldsName.BaseType, FieldsDescription.BaseType, 1);
        readonly TableAdapterField m_PrctBsAmnt = new TableAdapterField(FieldsName.PrctBsAmnt, FieldsDescription.PrctBsAmnt, DbType.Decimal);
        readonly TableAdapterField m_Account = new TableAdapterField(FieldsName.Account, FieldsDescription.Account, 20);
        readonly TableAdapterField m_Inactive = new TableAdapterField(FieldsName.Inactive, FieldsDescription.Inactive, 1);
        readonly TableAdapterField m_Category = new TableAdapterField(FieldsName.Category, FieldsDescription.Category, 1);
        TableAdapterField m_WtTypeId = new TableAdapterField(FieldsName.WtTypeId, FieldsDescription.WtTypeId, DbType.Int32);

        public WithholdingTax()
            : base(Definition.TableName)
        {
        }

        public WithholdingTax(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public WithholdingTax(WithholdingTax pWithholdingTax)
            : this()
        {
            CopyBy(pWithholdingTax);
        }
        
        public string WTCode
        {
            get { return m_WTCode.GetString(); }
            set { m_WTCode.Value = value; }
        }

        public String WTName
        {
            get { return m_WTName.GetString(); }
            set { m_WTName.Value = value; }
        }

        public Decimal Rate
        {
            get { return m_Rate.GetDecimal(); }
            set { m_Rate.Value = value; }
        }

        public DateTime EffecDate
        {
            get { return m_EffecDate.GetDateTime(); }
            set { m_EffecDate.Value = value; }
        }

        public String BaseType
        {
            get { return m_BaseType.GetString(); }
            set { m_BaseType.Value = value; }
        }

        public Decimal PrctBsAmnt
        {
            get { return m_PrctBsAmnt.GetDecimal(); }
            set { m_PrctBsAmnt.Value = value; }
        }

        public String Account
        {
            get { return m_Account.GetString(); }
            set { m_Account.Value = value; }
        }

        /// <summary>
        /// SAP YesNoBoolean
        /// </summary>
        public String Inactive
        {
            get { return m_Inactive.GetString(); }
            set { m_Inactive.Value = value; }
        }

        /// <summary>
        /// I para imposto retido no documento e
        /// P para imposto retido no Pagemeto
        /// </summary>
        public String Category
        {
            get { return m_Category.GetString(); }
            set { m_Category.Value = value; }
        }

        public Int32 WtTypeId
        {
            get { return m_WtTypeId.GetInt32(); }
            set { m_WtTypeId.Value = value; }
        }


        ///// <summary>
        ///// Pega o valor do imposto
        ///// </summary>
        ///// <param name="pDateBase">DataBase</param>
        ///// <param name="pTaxBase">Base do imposto</param>
        ///// <returns></returns>
        //public decimal GetTaxSum(DateTime pDateBase, decimal pTaxBase)
        //{
        //    if (this.EffecDate > pDateBase)
        //        return Decimal.Zero;

        //    return pTaxBase * (this.PrctBsAmnt / 100) * (this.Rate / 100);
        //}

    }

}
