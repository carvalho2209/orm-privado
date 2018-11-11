using System.Data;
using System.Text;

namespace Nampula.DI.ScriptWizard
{
    /// <summary>
    /// Classe para tratamento de scripts de alteração de tabelas do SQL Server
    /// </summary>
    public partial class SqlServerScriptWizard
    {
        
        /// <summary>
        /// Pega o comando de alteração da tabela
        /// </summary>
        /// <param name="pTable">Um Table Adapter</param>
        /// <returns>Um string com o comando de alteração</returns>
        public string GetAlterTableCommand(TableAdapter pTable)
        {
            var stringBulder = new StringBuilder();

            stringBulder.AppendLine(" ALTER TABLE ");
            stringBulder.Append(GetTableName(pTable.DBName, pTable.TableName, string.Empty, false));

            stringBulder.Append(GetAddColumns(pTable.Collumns));

            return stringBulder.ToString();

        }
        

        
        /// <summary>
        /// Pega a lista de colunas que devem ser adicionada
        /// </summary>
        /// <param name="pTable">Uma lista de campos</param>
        /// <returns>Um strng com os comandos para adiciona as colunas</returns>
        private string GetAddColumns(TableAdapterFieldCollection pTable)
        {
            //[,] {Nome do Campo} {Tipo}
            var mySp = new StringBuilder();

            foreach (var item in pTable)
                mySp.AppendFormat("{0} {1} {2}",
                    mySp.Length > 0 ? "," : "",
                    GetFieldName(string.Empty, item.Name, string.Empty),
                    GetCreateFieldType(item.DbType, item.Size, item.Precision, item.Scale));

            mySp.Insert(0, " ADD ");

            return mySp.ToString();

        }
        

        
        /// <summary>
        /// Pega o tipo de campo no sql server
        /// </summary>
        /// <param name="pDbType">Tipo do Campo no ADO.NET </param>
        /// <param name="pSize">Tamanho</param>
        /// <param name="pPrecision">Precisão de milhar</param>
        /// <param name="pScale">Escala de decimais</param>
        /// <returns>uma string com o tipo do sql</returns>
        private string GetCreateFieldType(DbType pDbType, int pSize, int pPrecision, int pScale)
        {
            string fieldType = string.Empty;

            switch (pDbType)
            {
                case DbType.AnsiString:
                    fieldType = string.Format(" VARCHAR ({0})", pSize);
                    break;
                case DbType.StringFixedLength:
                case DbType.AnsiStringFixedLength:
                    fieldType = string.Format(" CHAR ({0})", pSize);
                    break;
                case DbType.String:
                    fieldType = string.Format(" NVARCHAR ({0})", pSize);
                    break;
                case DbType.Boolean:
                    fieldType = " BIT ";
                    break;
                case DbType.Binary:
                    fieldType = " VarBinary (MAX)";
                    break;
                case DbType.Byte:
                    fieldType = " BYTE ";
                    break;
                case DbType.Currency:
                    fieldType = string.Format(" MONEY ({0}, {1})", pPrecision, pScale);
                    break;
                case DbType.Date:
                    fieldType = " DATETIME ";
                    break;
                case DbType.DateTime:
                    fieldType = " DATETIME ";
                    break;
                case DbType.DateTime2:
                    fieldType = " DATETIME ";
                    break;
                case DbType.DateTimeOffset:
                    fieldType = " TIMESTANT ";
                    break;
                case DbType.Decimal:
                    fieldType = string.Format(" DECIMAL ({0}, {1})", pPrecision, pScale);
                    break;
                case DbType.Double:
                    fieldType = " DOUBLE ";
                    break;
                case DbType.Guid:
                    fieldType = " uniqueidentifier ";
                    break;
                case DbType.Int16:
                    fieldType = " smallint ";
                    break;
                case DbType.Int32:
                    fieldType = " int ";
                    break;
                case DbType.Int64:
                    fieldType = " BigInt ";
                    break;
                case DbType.Object:
                    fieldType = " VarBinary(MAX) ";
                    break;
                case DbType.SByte:
                    fieldType = " TINYINT ";
                    break;
                case DbType.Single:
                    fieldType = string.Format(" DECIMAL ({0}, {1})", pPrecision, pScale);
                    break;
                case DbType.Time:
                    fieldType = " DateTime ";
                    break;
                case DbType.UInt16:
                    fieldType = " SMALLINT  ";
                    break;
                case DbType.UInt32:
                    fieldType = " INT ";
                    break;
                case DbType.UInt64:
                    fieldType = " BIGINT ";
                    break;
                case DbType.VarNumeric:
                    fieldType = " BIGINT ";
                    break;
                case DbType.Xml:
                    break;
            }

            return fieldType;
        }
        

    }

}
