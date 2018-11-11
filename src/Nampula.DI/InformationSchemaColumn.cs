using System.Collections.Generic;
using System.Data;

namespace Nampula.DI
{
    /// <summary>
    /// Informação dos Registros de objetos de dados
    /// </summary>
    public class InformationSchemaColumn : TableAdapter
    {
        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string TableName = "TABLE_NAME";
            public static readonly string ColumnName = "COLUMN_NAME";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {
            public static readonly string TableName = "Nome da Tabela";
            public static readonly string ColumnName = "Nome da Coluna";
        }

        readonly TableAdapterField m_TableName = new TableAdapterField(FieldsName.TableName, Description.TableName, DbType.String, 100, null, true, false);
        readonly TableAdapterField m_ColumName = new TableAdapterField(FieldsName.ColumnName, Description.ColumnName, DbType.String, 100, null, true, false);

        public InformationSchemaColumn() :
            base("[INFORMATION_SCHEMA].[COLUMNS]")
        {
            SchemaTable = true;
        }

        public new string TableName
        {
            get { return m_TableName.GetString(); }
            set { m_TableName.Value = value; }
        }

        public string ColumName
        {
            get { return m_ColumName.GetString(); }
            set { m_ColumName.Value = value; }
        }

        public bool GetByKey(string pTableName, string pColumnName)
        {
            TableName = pTableName;
            ColumName = pColumnName;
            return base.GetByKey();
        }

        /// <summary>
        /// Pega todos os registros
        /// </summary>
        /// <returns>Uma lista de informações dos schemas de banco</returns>
        public List<InformationSchemaColumn> GetAll()
        {
            return FillCollection<InformationSchemaColumn>(GetData().Rows);
        }

    }

}
