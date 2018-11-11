using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;
using Nampula.DI.ScriptWizard;
using System.Reflection;
using Nampula.Framework;

namespace Nampula.DI
{
    /// <summary>
    /// Classe para gerenciamento do banco de dados
    /// </summary>
    public class DataBaseAdapter
    {
        private const string DefaultCollate = "SQL_Latin1_General_CP850_CI_AS";
        private const string StrDbMater = "master";

        /// <summary>
        /// Evento disparado antes de criar o banco de dados
        /// </summary>
        public event EventHandler<DBEventArgs> OnBeforeCreate;
        /// <summary>
        /// Evento disparado antes de alterar o schema do banco de dados
        /// </summary>
        public event EventHandler<DBEventArgs> OnBeforeUpdate;
        /// <summary>
        /// Evento disparado depois de criar o banco de dados
        /// </summary>
        public event EventHandler<DBEventArgs> OnAfterCreate;
        /// <summary>
        /// Evento disparado depois de alterar o banco de dados
        /// </summary>
        public event EventHandler<DBEventArgs> OnAfterUpdate;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        protected DataBaseAdapter()
        {
            StoredProcedures = new List<StoredProcedure>();
            Tables = new List<TableAdapter>();
        }

        private string _dataBaseName;

        /// <summary>
        /// Nome do banco de dados
        /// </summary>
        public string DataBaseName
        {
            get
            {
                var connectionParam = Connection.Instance.ConnectionParameter;
                return !connectionParam.IsHostedEnvironment ? _dataBaseName : connectionParam.CompanyDb;
            }
            set { _dataBaseName = value; }
        }

        /// <summary>
        /// Lista de Tabelas
        /// </summary>
        private List<TableAdapter> Tables { get; set; }
        /// <summary>
        /// Lista de Stored Procedures
        /// </summary>
        private List<StoredProcedure> StoredProcedures { get; set; }
        /// <summary>
        /// Assembly da Aplicação
        /// </summary>
        public Assembly Assembly { get; set; }



        /// <summary>
        /// Cria o banco de dados
        /// </summary>
        public void Create()
        {
            if (OnBeforeCreate != null)
                OnBeforeCreate(this, new DBEventArgs());

            if (!Exists())
            {

                var query = new StringBuilder();

                query.AppendFormat("CREATE DATABASE {0} \n", DataBaseName);
                query.AppendFormat("COLLATE {0} \n;", DefaultCollate);

                query.AppendFormat("ALTER DATABASE [{0}] SET RECOVERY SIMPLE WITH NO_WAIT;", DataBaseName);
                query.AppendFormat("ALTER DATABASE [{0}] SET READ_COMMITTED_SNAPSHOT ON;", DataBaseName);

                Connection.Instance.ConnectionParameter.Database = StrDbMater;

                using (var trans = TransManager.GetTrans(withTransaction: false))
                {
                    Connection.Instance.SqlServerExecute(query.ToString());
                    trans.Complete();
                }
            }

            Connection.Instance.ConnectionParameter.Database = DataBaseName;

            using (var trans = TransManager.GetTrans())
            {
                LoadObjects();

                CreateTables(Tables);
                CreateProcedures(StoredProcedures);

                AddVersionToDb(Assembly.GetName().Version, new AppVersion { DBName = DataBaseName });

                UpdateInitialValues();

                if (OnAfterCreate != null)
                    OnAfterCreate(this, new DBEventArgs());

                trans.Complete();
            }

        }


        /// <summary>
        /// Carrega todos os objetos do assembly do banco de dados
        /// </summary>
        private void LoadObjects()
        {
            if (Assembly == null)
                throw new Exception("Favor preencher a propriedade Assembly da classe de Banco de dados");

            foreach (Type myT in Assembly.GetTypes())
            {
                if (myT.BaseType == null | myT.IsAbstract)
                    continue;

                if (myT.BaseType == typeof(TableAdapter) || myT.BaseType.Name == typeof(TableAdapterDomain<Object>).Name)
                {
                    var table = (TableAdapter)GetInstanceObject(null, myT);
                    Tables.Add(table);
                }
                else if (myT.BaseType.IsAbstract && myT.BaseType.BaseType == typeof(TableAdapter))
                {
                    var table = (TableAdapter)GetInstanceObject(null, myT);
                    Tables.Add(table);
                }
                else if (myT.BaseType == typeof(StoredProcedure))
                {
                    var mySp = GetInstanceObject(null, myT) as StoredProcedure;
                    Debug.Assert(mySp != null, "mySp != null");
                    mySp.LoadFiles(Assembly);
                    StoredProcedures.Add(mySp);
                }
            }

            Tables.Add(new AppVersion { DBName = DataBaseName });
        }

        /// <summary>
        /// Cria todas as procedures
        /// </summary>
        /// <param name="pStoreds">Lista de Procedures</param>
        private static void CreateProcedures(IEnumerable<StoredProcedure> pStoreds)
        {

            foreach (var proc in pStoreds.ToList().OrderBy(c => c.ToString()))
            {
                try
                {
                    proc.SetConnection(Connection.Instance);
                    proc.Create();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar a Stored Procedures [{0}]]\n{1}"
                        .Fmt(proc.ProcedureName, ex.Message));
                }
            }
        }



        /// <summary>
        /// Cria todos os banco de dados
        /// </summary>
        /// <param name="pTables">Lista de tabelas</param>
        private static void CreateTables(IEnumerable<TableAdapter> pTables)
        {
            foreach (var table in pTables)
            {
                try
                {
                    table.SetConnection(Connection.Instance);
                    table.Create();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível criar a tabela [{0}]\n{1}"
                        .Fmt(table.TableName, ex.ToString()), ex);
                }
            }
        }



        /// <summary>
        /// Verifica se existe o banco de dados
        /// </summary>
        /// <returns>Tru se existir, false caso contrário</returns>
        public bool Exists()
        {
            var dataTable = ExecQuery("sp_databases", StrDbMater);

            foreach (DataRow row in dataTable.Rows)
            {
                if (String.Equals(row.Field<string>("DATABASE_NAME"), DataBaseName, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            }

            return false;
        }


        private static DataTable ExecQuery(string query, string database)
        {
            var conn = Connection.Instance;
            var pCurrentDb = conn.ConnectionParameter.Database;

            try
            {
                conn.ConnectionParameter.Database = database;

                return conn.SqlServerQuery(query);
            }
            finally
            {
                conn.ConnectionParameter.Database = pCurrentDb;
            }
        }

        /// <summary>
        /// Altera uma tabela
        /// </summary>
        /// <param name="pTable">Tabela</param>
        /// <param name="pFields">Campos as ser aterado</param>
        public void AlterTable(TableAdapter pTable, IEnumerable<TableAdapterField> pFields)
        {
            var script = new SqlServerScriptWizard();

            var table = new TableAdapter(pTable.DBName, pTable.TableName);

            table.Collumns.AddRange(pFields.ToList());

            Connection.Instance.SqlServerExecute(script.GetAlterTableCommand(table));

            pTable.RaiseAfeterAlterTable(table);
        }

        /// <summary>
        /// Verifica a versão do banco de dados e atualziar se for necessário.
        /// </summary>
        private void CheckUpdateDb()
        {
            CheckIfReadCommitedSnapshotEnabled();

            var assemblyVersion = Assembly.GetName().Version;
            var dbAppVersion = new AppVersion { DBName = DataBaseName };
            //Verifica se a tabela de versão existe;
            CreateVersionTable();

            if (!dbAppVersion.GetLastVersion(Assembly.GetName().Name))
            {
                UpdateDbVersion(assemblyVersion, dbAppVersion, new Version());
            }
            else if (new Version(dbAppVersion.Version) != assemblyVersion)
            {
                var dbVersion = new Version(dbAppVersion.Version);
                //Verifica se a ultima versão é menor que a versão corrente;
                //Se for chama a a atualizaçõa do banco de dados
                if (dbVersion < assemblyVersion)
                    UpdateDbVersion(assemblyVersion, dbAppVersion, dbVersion);
                else if (!NotCheckVersion)
                    throw new Exception("A versão do banco de dados [{0}] não é compátivel com a versão atual do sistema [{1}]!".Fmt(
                        dbVersion.ToString(), assemblyVersion.ToString()));
            }
        }

        private void CheckIfReadCommitedSnapshotEnabled()
        {
            if (NotCheckIsoationLevel)
                return;

            var query = string.Format(
                "SELECT is_read_committed_snapshot_on FROM sys.databases WHERE name= '{0}'", DataBaseName);

            var isReadCommited = Connection.Instance.SqlExecuteScalar<int>(query);

            if (isReadCommited == 1)
                return;

            var message = string.Format(
                "O Banco de Dados está com uma configuração não apropriada, você deve alterar a configuração de transações para READ_COMMIT_SNAPSHOT para maiores informações acesse: {0}.",
                @"http://docs.inventsoftware.info/GeneralDocs/BancoDados.html#configuracao-do-controle-de-transacoes");

            throw new Exception(message);
        }

        protected bool NotCheckIsoationLevel { get; set; }


        /// <summary>
        /// Atualiza a versão do banco de dasdos
        /// </summary>
        /// <param name="assemblyVersion">Versão do Assembly</param>
        /// <param name="dbAppVersion">Objeto Table de Versão do Banco</param>
        /// <param name="dbVersion">Versão do Banco  de dados</param>
        private void UpdateDbVersion(Version assemblyVersion, AppVersion dbAppVersion, Version dbVersion)
        {
            Connection.Instance.ConnectionParameter.Database = DataBaseName;
            Connection.Instance.Connect();

            if (OnBeforeUpdate != null)
                OnBeforeUpdate(this,
                    new DBEventArgs { OldVersion = dbVersion, NewVersion = assemblyVersion });

            LoadObjects();

            CreateTableLogIfExists();

            //Verifica se alterou alguma cosia na tabela
            var infosSchema = new InformationSchemaColumn { DBName = DataBaseName }.GetAll();

            //Pegar todas as tabelas que existem no banco e não existem nos objetos
            var tableNoExist = (from table in Tables
                                where !infosSchema.Exists(myInfo => table.TableName == myInfo.TableName)
                                select table).ToList();

            CreateTables(tableNoExist);

            //Para todos as tabelas que não existem verifcar se as colunas das tabelas existem ou não
            var tableExists = (from table in Tables
                               where infosSchema.Exists(info => String.Equals(table.TableName, info.TableName, StringComparison.CurrentCultureIgnoreCase))
                               select table).ToList();

            foreach (var table in tableExists)
            {
                var fields = (from column in table.Collumns
                              where !infosSchema.Exists(
                                infoSchema => String.Equals(table.TableName, infoSchema.TableName, StringComparison.CurrentCultureIgnoreCase)
                                           && String.Equals(infoSchema.ColumName, column.Name, StringComparison.CurrentCultureIgnoreCase))
                              select column).ToList();

                if (fields.IsEmpty())
                    continue;

                AlterTable(table, fields);
            }

            foreach (var item in new Stack<StoredProcedure>(StoredProcedures))
                item.Drop();

            CreateProcedures(StoredProcedures);

            AddVersionToDb(assemblyVersion, dbAppVersion);
            UpdateInitialValues();

            if (OnAfterUpdate != null)
                OnAfterUpdate(this,
                    new DBEventArgs { OldVersion = dbVersion, NewVersion = assemblyVersion });
        }

        private void CreateTableLogIfExists()
        {
            foreach (var tableAdapter in Tables)
            {
                if (tableAdapter.TableAdapterLog != null)
                    tableAdapter.TableAdapterLog.CreateTableIfNoExist();
            }
        }

        /// <summary>
        /// Atualiza os valores de tabelas de moninio
        /// </summary>
        private void UpdateInitialValues()
        {
            foreach (var item in Tables.Where(c => c.InicialValue))
                item.UpdateValues();
        }

        /// <summary>
        /// Adiciona versão do Assembly ao banco de dados
        /// </summary>
        /// <param name="pAssemblyVersion">A versão do Assembly</param>
        /// <param name="pVersion">Objeto de Versao</param>
        private void AddVersionToDb(Version pAssemblyVersion, AppVersion pVersion)
        {
            pVersion.Version = pAssemblyVersion.ToString();
            pVersion.UserName = Connection.Instance.ConnectionParameter.UserName;
            pVersion.AssemblyName = Assembly.GetName().Name;
            pVersion.CreateDate = DateTime.Now;
            pVersion.Add();
        }

        /// <summary>
        /// Cria a tabela de versão do banco de dados, caso não exista.
        /// </summary>
        private void CreateVersionTable()
        {
            var info = new InformationSchemaColumn { DBName = DataBaseName };
            var version = new AppVersion { DBName = DataBaseName };

            if (!info.GetByKey(version.TableName, AppVersion.FieldsName.ID))
                version.Create();

            //Verifica se existe a coluna AssemlyName
            //Se não existir cria a coluna cria
            if (!info.GetByKey(version.TableName, AppVersion.FieldsName.AssemblyName))
                AlterTable(version,
                    new List<TableAdapterField> { version.Collumns[AppVersion.FieldsName.AssemblyName] });
        }

        /// <summary>
        /// Instancia um objeto de negócio
        /// </summary>
        public TT CreateObject<TT>()
        {
            return CreateObject<TT>(null);
        }

        /// <summary>
        /// Instancia um objeto de negócio
        /// </summary>
        /// <typeparam name="TT">Tipo do Objeto</typeparam>
        /// <param name="pConnection">Conec'~ao</param>
        /// <returns>Um novo objeto t Instanciado</returns>
        public TT CreateObject<TT>(Connection pConnection)
        {
            var myType = typeof(TT);
            return (TT)GetInstanceObject(pConnection, myType);
        }

        /// <summary>
        /// Pega uma instancia de um objeto que herda de DataObjet
        /// </summary>
        /// <param name="pConnection">Conexão</param>
        /// <param name="pType">Tipo do Objeto</param>
        /// <returns>Um objeto dataobjet instanciado</returns>
        internal object GetInstanceObject(Connection pConnection, Type pType)
        {
            var instance = Assembly.CreateInstance(pType.ToString()) as DataObject;

            if (instance == null)
                throw new Exception(string.Format(" O Objeto [{0}] não é um objeto que herda de DataObject ", pType));

            if (pConnection == null)
                pConnection = Connection.Instance;

            instance.SetConnection(pConnection);
            instance.DBName = DataBaseName;

            return instance;
        }

        /// <summary>
        /// Realiza conexao com o banco de dados
        /// </summary>
        /// <param name="pParam">Objeto detentor dos parametros de conexao.</param> 
        /// <returns>Retorna o valor verdadeiro se a conexao for realizada com sucesso.</returns> 
        public virtual bool Start(ConnectionParameter pParam)
        {
            Connection.Instance.ConnectionParameter = pParam;

            pParam.Database = DataBaseName;
            pParam.ApplicationName = Assembly.GetCallingAssembly().GetName().Name;

            if (Exists())
                CheckUpdateDb();
            else
                Create();

            return true;

        }

        /// <summary>
        /// Verfica se deve ou não checkar a versão do banco de dados
        /// </summary>
        public bool NotCheckVersion { get; set; }

        /// <summary>
        /// Pega a data do Servidor
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerDate()
        {
            return Connection.Instance.SqlExecuteScalar<DateTime>("Select GetDate()");
        }
    }
}
