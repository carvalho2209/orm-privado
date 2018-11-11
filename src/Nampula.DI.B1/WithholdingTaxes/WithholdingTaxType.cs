using System.Data;

namespace Nampula.DI.B1.WithholdingTaxes
{

    /// <summary>
    /// Tabela de Tipos de Impostos Retidos
    /// </summary>
    public class WithholdingTaxType : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OWTT";
        }

        public struct FieldsName
        {
            public static readonly string WTTypeId = "WTTypeId";
            public static readonly string WTType = "WTType";
        }

        public struct FieldsDescription
        {
            public static readonly string WTTypeId = "Nº";
            public static readonly string WTType = "Tipo";
        }

        readonly TableAdapterField m_WTTypeId = new TableAdapterField(FieldsName.WTTypeId, FieldsDescription.WTTypeId, DbType.Int32, 11, 0, true, true);
        readonly TableAdapterField m_WTType = new TableAdapterField(FieldsName.WTType, FieldsDescription.WTType, 20);

        public WithholdingTaxType()
            : base(Definition.TableName)
        {
        }

        public WithholdingTaxType(string CompanyDb)
            : this()
        {
            DBName = CompanyDb;
        }

        public WithholdingTaxType(WithholdingTaxType pWithholdingTaxType)
            : this()
        {
            CopyBy(pWithholdingTaxType);
        }

        public int WTTypeId
        {
            get { return m_WTTypeId.GetInt32(); }
            set { m_WTTypeId.Value = value; }
        }

        public string WTType
        {
            get { return m_WTType.GetString(); }
            set { m_WTType.Value = value; }
        }


    }
}
