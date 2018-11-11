using System;
using System.Collections.Generic;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI
{

    /// <summary>
    /// Classe que gerencia conexões com o banco de dados
    /// </summary>
    public class Connection : ICloneable
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        private Connection()
        {
            ConnectionParameter = new ConnectionParameter();
            MarsEnaled = true;
        }

        /// <summary>
        /// Pega a instancia
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use a propriedade Instance")]
        public static Connection GetInstance()
        {
            return Instance;
        }


        /// <summary>
        /// Parametros de Conexão
        /// </summary>
        public ConnectionParameter ConnectionParameter { get; set; }

        /// <summary>
        /// Pega uma única instancia da classe
        /// </summary>
        public static Connection Instance
        {
            get { return Singleton<Connection>.Instance; }
        }

        /// <summary>
        /// Clona o objeto
        /// </summary>
        /// <returns>Um objeto connection</returns>
        public object Clone()
        {
            var connection = new Connection
                {
                    ConnectionParameter = new ConnectionParameter(ConnectionParameter)
                };

            return connection;
        }

        /// <summary>
        /// Tenta uma conexão com o banco de dados
        /// </summary>
        /// <returns>True de conectar, false se não conectar</returns>
        public bool Connect()
        {
            using (var trans = TransManager.GetTrans())
            {
                var dbConn = trans.Connection;
                var isOpened = dbConn.State == ConnectionState.Open;

                trans.Complete();

                return isOpened;
            }
        }

        /// <summary>
        /// Pega a string de conecão
        /// </summary>
        /// <returns>Um string</returns>
        internal string GetConnString()
        {
            if (ConnectionParameter.IsHostedEnvironment && ConnectionParameter.TrustedConnection)
            {
                return string.Format(@"
                    server={0};
                    Initial Catalog={1};
                    MultipleActiveResultSets=false;Trusted_Connection=Yes;",
                    ConnectionParameter.Server,
                    ConnectionParameter.CompanyDb);
            }
            else if (ConnectionParameter.IsHostedEnvironment
                     && !ConnectionParameter.TrustedConnection)
            {
                var sqlConnStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();

                sqlConnStringBuilder.DataSource = ConnectionParameter.Server;
                sqlConnStringBuilder.UserID = ConnectionParameter.DBUser;
                sqlConnStringBuilder.Password = ConnectionParameter.DBPassword;
                sqlConnStringBuilder.InitialCatalog = ConnectionParameter.CompanyDb;
                sqlConnStringBuilder.ConnectTimeout = ConnectionParameter.ConnectionTimeout;

                return sqlConnStringBuilder.ToString();
            }
            else
            {
                 var sqlConnStringBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();

                sqlConnStringBuilder.DataSource = ConnectionParameter.Server;
                sqlConnStringBuilder.UserID = ConnectionParameter.DBUser;
                sqlConnStringBuilder.Password = ConnectionParameter.DBPassword;
                sqlConnStringBuilder.InitialCatalog = ConnectionParameter.Database;
                sqlConnStringBuilder.ConnectTimeout = ConnectionParameter.ConnectionTimeout == 0
                                                          ? 15
                                                          : ConnectionParameter.ConnectionTimeout;

                return sqlConnStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Executa um command e retorna o último valor adicionado
        /// </summary>
        /// <param name="command">Comando</param>
        /// <param name="parameters">Parametros do Comando</param>
        /// <returns>Ultimo Id Inserido</returns>
        public long SqlServerExecuteAndGetLastInsertId(string command, List<TableAdapterField> parameters = null)
        {
            using (var trans = TransManager.GetTrans())
            {
                var dbConn = trans.Connection;
                ChangeDatabaseIfNeeded(dbConn);

                var commnadAndLastInsertId = string.Format("{0};{1}", command, GetGetLastInsertId);

                var valueResult = ExecuteScalar<long>(commnadAndLastInsertId, parameters, dbConn, trans);

                trans.Complete();

                return valueResult;
            }
        }

        private void ChangeDatabaseIfNeeded(IDbConnection dbConn)
        {
            if(string.Equals(ConnectionParameter.Database, dbConn.Database, StringComparison.InvariantCultureIgnoreCase))
                return;

            dbConn.ChangeDatabase(ConnectionParameter.Database);
        }

        string GetGetLastInsertId { get { return "Select SCOPE_IDENTITY() AS 'Identity'"; } }

        /// <summary>
        /// Executa um comando SQl na conexão atual
        /// </summary>
        /// <param name="pCommand">Um sting com o comando SQl</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>True se for executado com sucesso</returns>
        public void SqlServerExecute(string pCommand, IEnumerable<TableAdapterField> parameters = null)
        {
            using (var trans = TransManager.GetTrans())
            {
                var dbConn = trans.Connection;
                ChangeDatabaseIfNeeded(dbConn);

                ExecuteCommnad(pCommand, parameters, dbConn, trans);

                trans.Complete();
            }
        }

        private static void ExecuteCommnad(string pCommand, IEnumerable<TableAdapterField> parameters, IDbConnection dbConn, TransManager trans)
        {
            using (var command = dbConn.CreateCommand())
            {
                command.Transaction = trans.Transaction;
                command.CommandText = pCommand;
                command.CommandTimeout = 0;

                SetParameters(command, parameters);

                command.ExecuteNonQuery();
            }
        }

        private static void SetParameters(IDbCommand command, IEnumerable<TableAdapterField> parameters)
        {
            foreach (var parameter in parameters ?? new List<TableAdapterField>())
            {
                var dataParameter = command.CreateParameter();

                dataParameter.ParameterName = parameter.Name;
                dataParameter.DbType = parameter.DbType;
                dataParameter.Value = parameter.Value ?? DBNull.Value;

                command.Parameters.Add(dataParameter);
            }
        }

        /// <summary>
        /// Executa um comando no banco de dados e retorna o resultado.
        /// </summary>
        /// <param name="pCommand">Um comando sql que retorna resultado</param>
        /// <param name="parameters">Parametros da Query</param>
        /// <returns>Um DataTable com o resultado da query</returns>
        public DataTable SqlServerQuery(string pCommand, IEnumerable<TableAdapterField> parameters = null)
        {
            using (var trans = TransManager.GetTrans())
            {var dbConn = trans.Connection;
                ChangeDatabaseIfNeeded(dbConn);

                using (var command = dbConn.CreateCommand())
                {
                    command.Transaction = trans.Transaction;
                    command.CommandText = pCommand;
                    command.CommandTimeout = 0;

                    SetParameters(command, parameters);

                    using (var dataReader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();

                        dataTable.Load(dataReader);

                        foreach (DataColumn dataColun in dataTable.Columns)
                            dataColun.ReadOnly = false;

                        trans.Complete();

                        return dataTable;
                    }
                }
            }
        }

        /// <summary>
        /// Executa um comando scalar no banco de dados e retorna o resultado.
        /// </summary>
        /// <typeparam name="TT">O tipo do resultado</typeparam>
        /// <param name="pCommand">Um comando sql que retorna resultado</param>
        /// <param name="parameters"></param>
        /// <returns>o valor da consulta</returns>
        public TT SqlExecuteScalar<TT>(string pCommand, IEnumerable<TableAdapterField> parameters = null)
        {
            using (var trans = TransManager.GetTrans())
            {
                var dbConn = trans.Connection;
                ChangeDatabaseIfNeeded(dbConn);

                var value = ExecuteScalar<TT>(pCommand, parameters, dbConn, trans);

                trans.Complete();

                return value;
            }
        }

        private static TT ExecuteScalar<TT>(string commnad, IEnumerable<TableAdapterField> parameters, IDbConnection dbConn, TransManager trans)
        {
            using (var command = dbConn.CreateCommand())
            {
                command.Transaction = trans.Transaction;
                command.CommandText = commnad;
                command.CommandTimeout = 0;

                SetParameters(command, parameters);

                return command.ExecuteScalar().To<TT>();
            }
        }

        /// <summary>
        /// Renomei uma tabela
        /// </summary>
        /// <param name="dbName">Nome do Banco de dados</param>
        /// <param name="tableName">Nome da Tabela</param>
        /// <param name="pNewTableName">Nome da Nova tabela</param>
        public void RenameTable(string dbName, string tableName, string pNewTableName)
        {
            var query = string.Format("exec [{0}]..sp_rename '{1}', '{2}';",
                dbName, tableName, pNewTableName);
            SqlServerExecute(query);
        }

        /// <summary>
        /// Renomeia uma columna
        /// </summary>
        /// <param name="pDbName">Nome do Banco de dados</param>
        /// <param name="pTableName">Nome da Tabela</param>
        /// <param name="pColumn">Nome da Coluna</param>
        /// <param name="pNewColumn">Nome da Nova Coluna</param>
        public void RenameColumn(string pDbName, string pTableName, string pColumn, string pNewColumn)
        {
            var query = string.Format("exec [{0}]..sp_rename '{1}.{2}', '{3}'",
                pDbName, pTableName, pColumn, pNewColumn);
            SqlServerExecute(query);
        }



        /// <summary>
        /// Exclui uam tabela se a mesma existir
        /// </summary>
        /// <param name="pTableName">Nome da Tabela</param>
        public void DropTable(string pTableName)
        {
            var query = string.Format(
                "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U')) DROP TABLE [dbo].[{0}]",
                pTableName);

            SqlServerExecute(query);
        }

        /// <summary>
        /// Renomei uma tabela
        /// </summary>
        /// <param name="pDbName">Nome do Banco de dados</param>
        /// <param name="pIndex">Indice</param>
        /// <param name="pNewIndex">Nome da Novo Indece</param>
        public void RenameIndex(string pDbName, string pIndex, string pNewIndex)
        {
            SqlServerExecute(string.Format(
                "exec [{0}]..sp_rename '{1}', '{2}';", pDbName, pIndex, pNewIndex));
        }

        internal void ChangeMars(bool newMars)
        {
            //_dbConn

            //if (newMars != MarsEnaled && Connected())
            //    Connect();

            //MarsEnaled = newMars;
        }

        /// <summary>
        /// 
        /// </summary>
        protected bool MarsEnaled { get; set; }
    }



}

