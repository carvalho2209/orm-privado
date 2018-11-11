using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Impostos do Documento de Marketing
    /// </summary>
    public class DocumentTaxAmount : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string SuffixTableName = "4";
        }
        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string RelateType = "RelateType";
            public static readonly string StcCode = "StcCode";
            public static readonly string StaCode = "StaCode";
            public static readonly string staType = "staType";
            public static readonly string TaxICMS = "TaxICMS";
            public static readonly string BaseSum = "BaseSum";
            public static readonly string TaxRate = "TaxRate";
            public static readonly string TaxSum = "TaxSum";
            public static readonly string U_PrecoMin = "U_PrecoMin";
            public static readonly string U_Reducao1 = "U_Reducao1";
            public static readonly string U_Lucro = "U_Lucro";
            public static readonly string U_Base = "U_Base";
            public static readonly string TaxInPrice = "TaxInPrice";
            public static readonly string Exempt = "Exempt";
            public static readonly string U_ReduICMS = "U_ReduICMS";
            public static readonly string NonDdctPrc = "NonDdctPrc";
        }
        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "N° Documento";
            public static readonly string LineNum = "N° da Linha";
            public static readonly string RelateType = "Tipo de Relação";
            public static readonly string StcCode = "Código do Imposto";
            public static readonly string StaCode = "StaCode";
            public static readonly string staType = "staType";
            public static readonly string BaseSum = "BaseSum";
            public static readonly string TaxRate = "TaxRate";
            public static readonly string TaxSum = "TaxSum";
            public static readonly string U_PrecoMin = "U_PrecoMin";
            public static readonly string U_Reducao1 = "U_Reducao1";
            public static readonly string U_Lucro = "U_Lucro";
            public static readonly string U_Base = "U_Base";
            public static readonly string TaxInPrice = "Incluso no preço?";
            public static readonly string Exempt = "Isento?";
            public static readonly string U_ReduICMS = "Percentual de Redução de BC";
            public static readonly string NonDdctPrc = "% Não Dedutível";
        }
        
        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32);
        TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32);
        TableAdapterField m_RelateType = new TableAdapterField(FieldsName.RelateType, FieldsDescription.RelateType, DbType.Int32);
        TableAdapterField m_StcCode = new TableAdapterField(FieldsName.StcCode, FieldsDescription.StcCode, 8);
        TableAdapterField m_StaCode = new TableAdapterField(FieldsName.StaCode, FieldsDescription.StaCode, 8);
        TableAdapterField m_staType = new TableAdapterField(FieldsName.staType, FieldsDescription.staType, DbType.Int32);
        TableAdapterField m_BaseSum = new TableAdapterField(FieldsName.BaseSum, FieldsDescription.BaseSum, DbType.Decimal);
        TableAdapterField m_TaxRate = new TableAdapterField(FieldsName.TaxRate, FieldsDescription.TaxRate, DbType.Decimal);
        TableAdapterField m_TaxSum = new TableAdapterField(FieldsName.TaxSum, FieldsDescription.TaxSum, DbType.Decimal);
        TableAdapterField m_U_PrecoMin = new TableAdapterField(FieldsName.U_PrecoMin, FieldsDescription.U_PrecoMin, DbType.Decimal);
        TableAdapterField m_U_Reducao1 = new TableAdapterField(FieldsName.U_Reducao1, FieldsDescription.U_Reducao1, DbType.Decimal);
        TableAdapterField m_U_Lucro = new TableAdapterField(FieldsName.U_Lucro, FieldsDescription.U_Lucro, DbType.Decimal);
        TableAdapterField m_U_Base = new TableAdapterField(FieldsName.U_Base, FieldsDescription.U_Base, DbType.Decimal);
        TableAdapterField m_TaxInPrice = new TableAdapterField(FieldsName.TaxInPrice, FieldsDescription.TaxInPrice, 1);
        TableAdapterField m_Exempt = new TableAdapterField(FieldsName.Exempt, FieldsDescription.Exempt, 1);
        TableAdapterField m_U_ReduICMS = new TableAdapterField(FieldsName.U_ReduICMS, FieldsDescription.U_ReduICMS, DbType.Decimal);
        TableAdapterField m_NonDdctPrc = new TableAdapterField(FieldsName.NonDdctPrc, FieldsDescription.NonDdctPrc, DbType.Decimal);

        public DocumentTaxAmount()
            : base()
        {
        }
        
        public DocumentTaxAmount(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, string.Format("{0}{1}", pDocumentObjectType.GetTableNameSufix(), "4"))
        {
        }

        public DocumentTaxAmount(DocumentTaxAmount pDocumentTaxAmount)
            : this()
        {
            this.CopyBy(pDocumentTaxAmount);
        }
        
        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public RelationTypeEnum RelateType
        {
            get { return (RelationTypeEnum)m_RelateType.GetInt32(); }
            set { m_RelateType.Value = value.To<int>(); }
        }

        public string StcCode
        {
            get { return m_StcCode.GetString(); }
            set { m_StcCode.Value = value; }
        }

        public String StaCode
        {
            get { return m_StaCode.GetString(); }
            set { m_StaCode.Value = value; }
        }

        public Int32 staType
        {
            get { return m_staType.GetInt32(); }
            set { m_staType.Value = value; }
        }

        public Decimal BaseSum
        {
            get { return m_BaseSum.GetDecimal(); }
            set { m_BaseSum.Value = value; }
        }

        public Decimal TaxRate
        {
            get { return m_TaxRate.GetDecimal(); }
            set { m_TaxRate.Value = value; }
        }

        public Decimal TaxSum
        {
            get { return m_TaxSum.GetDecimal(); }
            set { m_TaxSum.Value = value; }
        }

        public Decimal U_PrecoMin
        {
            get { return m_U_PrecoMin.GetDecimal(); }
            set { m_U_PrecoMin.Value = value; }
        }

        public Decimal U_Reducao1
        {
            get { return m_U_Reducao1.GetDecimal(); }
            set { m_U_Reducao1.Value = value; }
        }

        public Decimal U_Lucro
        {
            get { return m_U_Lucro.GetDecimal(); }
            set { m_U_Lucro.Value = value; }
        }

        public Decimal U_Base
        {
            get { return m_U_Base.GetDecimal(); }
            set { m_U_Base.Value = value; }
        }

        /// <summary>
        /// Yes - No no
        /// </summary>
        public String TaxInPrice
        {
            get { return m_TaxInPrice.GetString(); }
            set { m_TaxInPrice.Value = value; }
        }

        public String Exempt
        {
            get { return m_Exempt.GetString(); }
            set { m_Exempt.Value = value; }
        }

        public Decimal U_ReduICMS
        {
            get { return m_U_ReduICMS.GetDecimal(); }
            set { m_U_ReduICMS.Value = value; }
        }

        public Decimal NonDdctPrc
        {
            get { return m_NonDdctPrc.GetDecimal(); }
            set { m_NonDdctPrc.Value = value; }
        }
        

    }
}
