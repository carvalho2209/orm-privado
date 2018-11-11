using System;
using System.Data;

namespace Nampula.DI.B1.Itens
{


    /// <summary>
    /// Tabela de Origem de Produto
    /// </summary>
    public class ProductSourceCode : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OPSC";
        }

        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Desc = "Desc";
        }

        public struct FieldsDescription
        {
            public static readonly string Code = "Código de Origem";
            public static readonly string Desc = "Descrição";
        }

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_Desc = new TableAdapterField(FieldsName.Desc, FieldsDescription.Desc, 100);

        public ProductSourceCode()
            : base(Definition.TableName)
        {
        }

        public ProductSourceCode(ProductSourceCode pProductSourceCode)
            : this()
        {
            this.CopyBy(pProductSourceCode);
        }

        public int Code
        {
            get { return m_Code.GetInt32(); }
            set { m_Code.Value = value; }
        }

        public String Desc
        {
            get { return m_Desc.GetString(); }
            set { m_Desc.Value = value; }
        }

    }
}
