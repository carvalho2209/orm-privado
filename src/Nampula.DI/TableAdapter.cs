using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Nampula.DI.Logs;
using Nampula.DI.ScriptWizard;
using Nampula.Framework;
using System.ComponentModel;

namespace Nampula.DI
{
    /// <summary>
    /// Classe para gerencimento de tabelas do banco de dados.
    /// </summary>
    [Serializable]
    public class TableAdapter : DataObject, INotifyPropertyChanged, INotifyPropertyChanging
    {


        /// <summary>
        /// Evento Disparado Depois de adicionar o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnAfterAdd;
        /// <summary>
        /// Evento de Disparado Depois de atualizar o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnAfterUpdate;
        /// <summary>
        /// Evento Disparado Depois de remover o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnAfterRemove;
        /// <summary>
        /// Evento Disparado Depois de buscar o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnAfterSelect;
        /// <summary>
        /// Evento de Disparado Depois de criar a tabela
        /// </summary>
        public event TableAdapterEventHandler OnAfterCreate;
        /// <summary>
        /// Evento Disparado Depois de ler valores iniciais
        /// </summary>
        public event TableAdapterEventHandler OnAfterLoadValues;
        /// <summary>
        /// Evento Disparado Depois de alterar a tabela
        /// </summary>
        public event TableAdapterEventHandler OnAfterAlterTable;

        /// <summary>
        /// Evento Disparado Antes de adicionar registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnBeforeAdd;
        /// <summary>
        /// Evento Disparado Antes de atualizar o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnBeforeUpdate;
        /// <summary>
        /// Evento Disparado Antes de remover o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnBeforeRemove;
        /// <summary>
        /// Evento Disparado Antes de selecionar o registro no banco
        /// </summary>
        public event TableAdapterEventHandler OnBeforeSelect;
        /// <summary>
        /// Evento Disparado Antes de Criar a tabela
        /// </summary>
        public event TableAdapterEventHandler OnBeforeCreate;
        /// <summary>
        /// Evento de Disparado Antes de ler registro inciais
        /// </summary>
        public event TableAdapterEventHandler OnBeforeLoadValues;


        /// <summary>
        /// Instancia um objeto TableAdapter
        /// </summary>
        public TableAdapter()
        {
            Collumns = new TableAdapterFieldCollection();
            KeyFields = new TableAdapterFieldCollection();
            InicialValues = new List<TableAdapter>();
            PropertyChangedNotify = new List<string>();
            PropertyChangingNotify = new List<string>();
            LogCollection = new List<Log>();

            FillCollumns();
        }

        /// <summary>
        /// Innstancia um objeto TableAdapter
        /// </summary>
        /// <param name="pTableName">Nome da Tabela</param>
        /// <param name="autoLog">Geração automatica de log</param>
        public TableAdapter(string pTableName, Boolean autoLog = false)
            : this()
        {
            TableName = pTableName;
            SetAutoLog(autoLog);
        }

        /// <summary>
        /// Instancia um objeto TableAdapter
        /// </summary>
        /// <param name="pDbName">Nome do Banco de dados</param>
        /// <param name="pTableName">Nome da Tabela</param>
        public TableAdapter(string pDbName, string pTableName)
            : this(pTableName)
        {
            DBName = pDbName;
        }

        /// <summary>
        /// Log gerado dentro de um execução dos commando Add,Update,Delete,Create
        /// </summary>
        public List<Log> LogCollection { get; set; }

        /// <summary>
        /// Avento disparado enquanto atualiza o algum campo
        /// </summary>
        public event ChangeStateEventHandler OnStateRecordChanging;
        /// <summary>
        /// Avento disparado depois de atualizado algum campo
        /// </summary>
        public event ChangeStateEventHandler OnStateRecordChanged;

        /// <summary>
        /// Sem a Hint (NO LOCK)
        /// </summary>
        public bool WithoutNotLock { get; set; }

        private eState _stateRecord;

        /// <summary>
        /// Estado do Registro
        /// </summary>
        public eState StateRecord
        {
            get { return _stateRecord; }
            set
            {
                RaiseStateChanging(_stateRecord, value);
                var old = _stateRecord;
                _stateRecord = value;
                RaiseStateChanged(old, _stateRecord);
            }
        }

        private void RaiseStateChanged(eState stateOld, eState stateNew)
        {
            if (OnStateRecordChanged == null)
                return;

            var state = new ChangeStateEventArgs
            {
                StateNew = stateNew,
                StateOld = stateOld
            };

            OnStateRecordChanged(this, state);
        }

        private void RaiseStateChanging(eState stateOld, eState stateNew)
        {
            if (OnStateRecordChanging == null)
                return;

            var state = new ChangeStateEventArgs
            {
                StateNew = stateNew,
                StateOld = stateOld
            };

            OnStateRecordChanging(this, state);
        }

        /// <summary>
        /// O DataRow que representa o objeto
        /// </summary>
        public DataRow DataRow { get; set; }

        /// <summary>
        /// Lista de Coluns da Tabela
        /// </summary>
        public TableAdapterFieldCollection Collumns { get; private set; }

        /// <summary>
        /// Campos chave da tabela
        /// </summary>
        public TableAdapterFieldCollection KeyFields { get; private set; }

        /// <summary>
        /// Representa uma tabela de schema do banco
        /// </summary>
        public bool SchemaTable { get; set; }

        /// <summary>
        /// Nome da Tabela
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// PReenche as colunms da atbela de acordo com as Campos TableAdapterFields
        /// Instanciano na classe base
        /// </summary>
        private void FillCollumns()
        {
            Collumns = TableAdapterColumns.GetCollumns(this);

            foreach (var item in Collumns.Where(c => c.Key))
                KeyFields.Add(item);

            StateRecord = eState.eAdd;
        }


        /// <summary>
        /// Evento tisparado quando alguma proriedade está sendo alterada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void col_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (LockNotify || (PropertyChanging == null || PropertyChangingNotify.All(c => c != e.PropertyName)))
                return;

            try
            {
                LockNotify = true;
                PropertyChanging(sender, e);
            }
            finally
            {
                LockNotify = false;
            }
        }

        /// <summary>
        /// Evento tisparado quando alguma proriedade eh alterada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void col_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (LockNotify || (PropertyChanged == null || PropertyChangedNotify.All(c => c != e.PropertyName)))
                return;

            try
            {
                LockNotify = true;
                PropertyChanged(sender, e);
            }
            finally
            {
                LockNotify = false;
            }
        }


        /// <summary>
        /// Pega o comando de inserção
        /// </summary>
        /// <returns>Um Db command preenchiodo</returns>
        protected Tuple<string, List<TableAdapterField>> GetInsertCommand()
        {
            var fields = new StringBuilder();
            var values = new StringBuilder();

            var columns = Collumns.Where(p => !p.Identity && p.Value != null).ToList();

            foreach (var column in columns)
            {
                if (fields.Length > 0)
                {
                    fields.Append("   , ");
                    values.Append("   , ");
                }
                else
                {
                    fields.Append("     ");
                    values.Append("     ");
                }

                fields.AppendLine(SetQuote(column.Name));
                values.AppendFormat("@{0}", column.Name);
            }

            if (fields.Length == 0)
                throw new Exception(string.Format("Não há campos definidos para o objeto [{0}]", this));

            var query = new StringBuilder();
            query.AppendLine(" INSERT INTO  " + MakeFullTableName(DBName, TableName) + " ( ");
            query.AppendLine(fields.ToString());
            query.AppendLine(") VALUES (");
            query.AppendLine(values.ToString());
            query.AppendLine(") ");

            var parameters = GetParameters(columns);

            return new Tuple<string, List<TableAdapterField>>(
                query.ToString(),
                parameters);
        }



        /// <summary>
        /// Pega o comando de atualização
        /// </summary>
        /// <returns>Um DbCOmmand</returns>
        protected Tuple<string, List<TableAdapterField>> GetUpdateCommand()
        {
            var fields = new StringBuilder();

            foreach (var column in Collumns.Where(p => !p.Key))
            {
                fields.Append(fields.Length > 0 ? "   , " : "     ");

                fields.AppendLine("" + SetQuote(column.Name) + " = @" + column.Name + "");
            }

            if (fields.Length == 0)
                return null;

            var query = new StringBuilder();
            query.AppendLine(" Update " + MakeFullTableName(DBName, TableName) + " SET  ");
            query.AppendLine(fields.ToString());
            query.AppendLine("  ");
            query.AppendLine(GetWhereCommand());

            return new Tuple<string, List<TableAdapterField>>(
                query.ToString(),
                GetParameters(Collumns)
                );

        }



        /// <summary>
        /// Pega um comando de criação de tabaela
        /// </summary>
        /// <returns>Um comando</returns>
        protected Tuple<string, List<TableAdapterField>> GetCreateCommand()
        {
            var fields = new StringBuilder();
            var constrant = new StringBuilder();

            foreach (TableAdapterField colum in Collumns)
            {

                if (fields.Length > 0)
                {
                    fields.AppendLine();
                    fields.Append("   , ");
                }
                else
                {
                    fields.Append("     ");
                }

                fields.Append(SetQuote(colum.Name));
                fields.Append(GetCreateFieldType(colum));

                if (colum.Key)
                {
                    //Adiconar constraint
                    if (constrant.Length > 0)
                    {
                        constrant.Append(", ");
                    }

                    constrant.Append(SetQuote(colum.Name));

                    constrant.Append("\n");

                    if (colum.Identity)
                    {
                        fields.Append(" IDENTITY(1,1) ");
                    }
                }
                else
                {
                    if (colum.Value != null)
                    {
                        string tableName = TableName.RemoveCharacter("[]..", "_");
                        fields.Append(" CONSTRAINT [DF_" + tableName + "_" + colum.Name + "]  DEFAULT (('" + colum.Value + "'))");
                    }
                }

            }

            if (fields.Length == 0)
                throw new Exception("Quantidade campo para o comando Create não foi informado");

            var query = new StringBuilder();
            query.AppendLine(" Create Table " + MakeFullTableName(DBName, TableName) + "");
            query.AppendLine(" (  ");
            query.AppendLine(fields.ToString());

            if (constrant.Length > 0)
            {
                var tableName = TableName.RemoveCharacter("[]..", "_");
                query.AppendLine(", CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED ");
                query.AppendLine("(");
                query.AppendLine(constrant.ToString());
                query.AppendLine(")");
            }

            query.AppendLine(" ) ");

            return new Tuple<string, List<TableAdapterField>>(
                query.ToString(), null);

        }



        /// <summary>
        /// Pega uma string com o tipo do SQL Server de Criação
        /// </summary>
        /// <param name="tableAdapterField">o campo</param>
        /// <returns></returns>
        private string GetCreateFieldType(TableAdapterField tableAdapterField)
        {
            string fieldType = null;

            switch (tableAdapterField.DbType)
            {
                case DbType.AnsiString:
                    fieldType = " VARCHAR (" + tableAdapterField.Size + ")";
                    break;
                case DbType.AnsiStringFixedLength:
                    fieldType = " CHAR (" + tableAdapterField.Size + ")";
                    break;
                case DbType.String:
                    fieldType = " NVARCHAR (" + tableAdapterField.Size + ")";
                    break;
                case DbType.StringFixedLength:
                    fieldType = " Char (" + tableAdapterField.Size + ")";
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
                    fieldType = " MONEY (" + tableAdapterField.Precision + ", " + tableAdapterField.Scale + ")";
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
                    fieldType = " DECIMAL (" + tableAdapterField.Precision + ", " + tableAdapterField.Scale + ")";
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
                    fieldType = " DECIMAL (" + tableAdapterField.Precision + ", " + tableAdapterField.Scale + ")";
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



        /// <summary>
        /// Pega um string com clausula Where
        /// </summary>
        /// <returns>Uma string com o comando</returns>
        private string GetWhereCommand()
        {
            var whereCommand = new StringBuilder();

            for (int i = 0; i <= KeyFields.Count - 1; i++)
            {
                whereCommand.Append(whereCommand.Length > 0 ? "   AND " : "     ");

                whereCommand.AppendLine("(" + SetQuote(KeyFields[i].Name) + " = @" + KeyFields[i].Name + ")");
            }

            whereCommand.Insert(0, " Where \n");

            return whereCommand.ToString();
        }



        /// <summary>
        /// Pega o camando delete
        /// </summary>
        /// <returns>Um DbComando com o camando para excluir</returns>
        protected Tuple<string, List<TableAdapterField>> GetDeleteCommand()
        {
            var columns = Collumns.Where(p => p.Key).ToList();

            var query = new StringBuilder();
            query.AppendLine(" DELETE FROM " + MakeFullTableName(DBName, TableName) + " ");
            query.AppendLine(GetWhereCommand());

            return new Tuple<string, List<TableAdapterField>>(
                query.ToString(),
                GetParameters(columns));
        }



        /// <summary>
        /// Atribui parametros ao comando
        /// </summary>
        /// <param name="columns">Lista de Colunas</param>
        private List<TableAdapterField> GetParameters(IEnumerable<TableAdapterField> columns)
        {
            var parameters = new List<TableAdapterField>();

            foreach (var column in columns)
            {
                var param = new TableAdapterField
                {
                    Name = column.Name,
                    DbType = column.DbType,
                    Value = column.Value ?? DBNull.Value
                };

                parameters.Add(param);
            }

            return parameters;
        }



        /// <summary>
        /// Pega o camando de Seleção de Registros
        /// </summary>
        /// <returns>Um comando com o select</returns>
        private Tuple<string, List<TableAdapterField>> GetSelectCommand()
        {
            var script = new SqlServerScriptWizard
            {
                TableQuery = new TableQuery(this, true)
            };

            return script.GetSelectStatment();
        }

        /// <summary>
        /// Atribui os valores das chaves autoincremental
        /// </summary>
        protected void SetIdentityValue(long value)
        {
            var keyIdentiyField = KeyFields.SingleOrDefault(f => f.Identity);

            if (keyIdentiyField != null)
                keyIdentiyField.Value = value;
        }



        /// <summary>
        /// Adiciona um registro no banco de dados
        /// </summary>
        /// <returns>true se adicionar</returns>
        public virtual void Add()
        {
            using (var trans = TransManager.GetTrans())
            {
                var eventArgs = new TableAdapterEventArgs();

                if (OnBeforeAdd != null)
                    OnBeforeAdd(this, eventArgs);

                var inserdCommand = GetInsertCommand();

                var lastInsertedId = Connection.SqlServerExecuteAndGetLastInsertId(inserdCommand.Item1, inserdCommand.Item2);

                SetIdentityValue(lastInsertedId);

                eventArgs.Keys = KeyFields;
                eventArgs = new TableAdapterEventArgs();

                if (OnAfterAdd != null)
                    OnAfterAdd(this, eventArgs);

                trans.Complete();
            }
        }



        /// <summary>
        /// Remove o registro do banco de acordo com a chave
        /// </summary>
        /// <returns>True se remover</returns>
        public virtual void Remove()
        {
            using (var trans = TransManager.GetTrans())
            {
                var eventArgs = new TableAdapterEventArgs();

                if (OnBeforeRemove != null)
                    OnBeforeRemove(this, eventArgs);

                var command = GetDeleteCommand();

                Connection.SqlServerExecute(command.Item1, command.Item2);

                if (OnAfterRemove != null)
                {
                    eventArgs.Keys = KeyFields;
                    OnAfterRemove(this, eventArgs);
                }

                trans.Complete();
            }
        }



        /// <summary>
        /// Atualiza o registro no banco de dados
        /// </summary>
        /// <returns>True se atualizar</returns>
        public virtual void Update()
        {
            using (var trans = TransManager.GetTrans())
            {
                var eventArgs = new TableAdapterEventArgs();

                if (OnBeforeUpdate != null)
                    OnBeforeUpdate(this, eventArgs);

                var command = GetUpdateCommand();

                Connection.SqlServerExecute(command.Item1, command.Item2);

                eventArgs = new TableAdapterEventArgs();

                if (OnAfterUpdate != null)
                {
                    eventArgs.Keys = KeyFields;
                    OnAfterUpdate(this, eventArgs);
                }

                trans.Complete();
            }

        }



        /// <summary>
        /// Pega o registro pelas chaves
        /// </summary>
        /// <returns>True se encontrar</returns>
        public virtual bool GetByKey()
        {
            using (var trans = TransManager.GetTrans())
            {
                var eventArgs = new TableAdapterEventArgs();

                if (OnBeforeSelect != null)
                    OnBeforeSelect(this, eventArgs);

                var command = GetSelectCommand();

                var data = Connection.SqlServerQuery(command.Item1, command.Item2);

                var foundRecord = data.Rows.Count > 0;

                if (foundRecord)
                {
                    eventArgs = new TableAdapterEventArgs
                    {
                        Keys = KeyFields
                    };

                    FillFields(data.Rows[0], true);
                    StateRecord = eState.eDatabase;

                    if (OnAfterSelect != null)
                        OnAfterSelect(this, eventArgs);
                }

                trans.Complete();

                return foundRecord;
            }

        }



        /// <summary>
        /// Pega um dataTabloe de Acordo com uma Consulta TableQuery 
        /// </summary>
        /// <param name="pTableQuery">Um TableQuery</param>
        /// <returns>Um DataTable</returns>
        public DataTable GetData(TableQuery pTableQuery)
        {
            if (pTableQuery == null)
                pTableQuery = new TableQuery(this);

            var query = new SqlServerScriptWizard(pTableQuery);

            var selectCommand = query.GetSelectStatment();

            return Connection.SqlServerQuery(selectCommand.Item1, selectCommand.Item2);
        }

        /// <summary>
        /// Pega um dataTable todos os registros da tabela
        /// </summary>
        /// <returns>Um DataTable</returns>
        public DataTable GetData()
        {
            //BeforeExecute();
            return GetData(null);
        }


        /// <summary>
        /// Preenche os Columns de acordo com o dataRow
        /// </summary>
        /// <param name="pRow">Um datarow</param>
        /// <param name="pLockNotify">Bloquei notificações</param>
        /// <returns>True se preencher</returns>
        public void FillFields(DataRow pRow, bool pLockNotify = false)
        {
            foreach (var column in Collumns)
            {
                if (!(pRow.IsNull(column.Name)))
                {
                    var savedLockotify = column.LockNotify;
                    try
                    {
                        column.LockNotify = pLockNotify;
                        column.Value = pRow[column.Name];
                    }
                    finally
                    {
                        column.LockNotify = savedLockotify;
                    }
                }
            }
        }



        /// <summary>
        /// Criar a tabela no banco de dados
        /// </summary>
        /// <returns>true se criar</returns>
        public virtual void Create()
        {
            try
            {
                using (var trans = TransManager.GetTrans())
                {

                    var eventArgs = new TableAdapterEventArgs();

                    if (OnBeforeCreate != null)
                        OnBeforeCreate(this, eventArgs);

                    var command = GetCreateCommand();

                    Connection.SqlServerExecute(command.Item1, command.Item2);

                    eventArgs = new TableAdapterEventArgs();

                    if (OnAfterCreate != null)
                        OnAfterCreate(this, eventArgs);

                    trans.Complete();
                }

            }
            catch (Exception ex)
            {
                var message = string.Format("Erro ao criar a tabela [{0}..{1}]", DBName, TableName);
                throw new Exception(message, ex);
            }
        }

        /// <summary>
        /// Pega um campo pelo nome ou retorna null
        /// </summary>
        /// <param name="pFieldName">Nome do campo</param>
        /// <returns>Um TableAdapterField</returns>
        public TableAdapterField GetTableField(string pFieldName)
        {
            return Collumns.FirstOrDefault(p => p.Name == pFieldName);
        }

        /// <summary>
        /// Adiciona um novo log ao LogCollection
        /// </summary>
        /// <param name="pMessage">Mensagem</param>
        public void AddLog(string pMessage)
        {
            LogCollection.Add(new Log
            {
                Message = pMessage
            });
        }

        /// <summary>
        /// Pega o nome da tabela completo
        /// </summary>
        /// <returns>Um string com o nome da tabela</returns>
        public string FullTableName()
        {
            return MakeFullTableName(DBName, TableName);
        }

        /// <summary>
        /// Preenche p tableadapter com um dataRow
        /// </summary>
        /// <param name="dataRow">Um DataRow</param>
        /// <returns>True se preencher</returns>
        public bool FillDataRow(DataRow dataRow)
        {
            if (dataRow == null) 
                throw new ArgumentNullException("dataRow");

            dataRow = DataRow;

            foreach (var column in Collumns)
            {
                if (dataRow.Table.Columns.IndexOf(column.Name) < 0)
                    dataRow.Table.Columns.Add(new DataColumn(column.Name, column.GetDbType()));

                dataRow[column.Name] = column.Value ?? DBNull.Value;
            }

            return true;
        }

        /// <summary>
        /// Copia através os dados de um tableadapter
        /// </summary>
        /// <param name="pTableAdapter">Um TableAdapter</param>
        /// <returns>True se copiar</returns>
        public void CopyBy<TT>(TT pTableAdapter) where TT : TableAdapter
        {
            //BeforeExecute();

            DBName = pTableAdapter.DBName;
            TableName = pTableAdapter.TableName;
            SetConnection(pTableAdapter.Connection);
            StateRecord = pTableAdapter.StateRecord;

            foreach (var item in Collumns)
            {
                if (pTableAdapter.Collumns.All(c => c.Name != item.Name))
                    continue;

                try
                {
                    item.LockNotify = true;
                    item.Value = pTableAdapter.Collumns[item.Name].Value;
                }
                finally
                {
                    item.LockNotify = false;
                }
            }
        }

        /// <summary>
        /// Prrenche uma coleção através de uma lista de DataRows
        /// </summary>
        /// <typeparam name="TObject">O tipo de destino</typeparam>
        /// <param name="pRows">Lista de ROwsa</param>
        /// <returns>Uma lista de <see cref="TObject "/></returns>
        public List<TObject> FillCollection<TObject>(DataRowCollection pRows)
            where TObject : TableAdapter, new()
        {

            var list = new List<TObject>();

            foreach (DataRow myRow in pRows)
            {
                var item = new TObject
                {
                    DBName = DBName,
                    Connection = Connection,
                    StateRecord = eState.eDatabase
                };

                item.FillFields(myRow, true);
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Prrenche uma coleção através de uma lista de DataRows
        /// </summary>
        /// <typeparam name="TObject">O tipo de destino</typeparam>
        /// <param name="pRows">Lista de ROwsa</param>
        /// <returns>Uma lista de <see cref="TObject "/></returns>
        public List<TObject> FillCollection<TObject>(DataRow[] pRows)
            where TObject : TableAdapter, new()
        {

            var list = new List<TObject>();

            foreach (var row in pRows)
            {
                var item = new TObject
                               {
                                   DBName = DBName,
                                   Connection = Connection,
                                   StateRecord = eState.eDatabase
                               };

                item.FillFields(row, true);
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Executa uma consulta no banco e retorna uma coleção de T
        /// </summary>
        /// <typeparam name="TObject">O tipo do TableAdapter</typeparam>
        /// <param name="pTableQuery">Uma query</param>
        /// <returns>Uma lista de T</returns>
        public List<TObject> FillCollection<TObject>(TableQuery pTableQuery) where TObject : TableAdapter, new()
        {
            return FillCollection<TObject>(GetData(pTableQuery).Rows);
        }

        /// <summary>
        /// Retorna todos os objetos da tabela
        /// </summary>
        /// <typeparam name="TObject">O tipo do TableAdapter</typeparam>
        /// <returns>Uma lista de T</returns>
        public List<TObject> FillCollection<TObject>() where TObject : TableAdapter, new()
        {
            return FillCollection<TObject>(new TableQuery(this));
        }

        /// <summary>
        /// Salva a coleção
        /// </summary>
        /// <typeparam name="TT">O tipo do TableAdapter</typeparam>
        /// <param name="tableAdaptes">Uma lista de Coleções</param>
        /// <returns>true se salvar</returns>
        public void SaveLines<TT>(IEnumerable<TT> tableAdaptes) where TT : TableAdapter
        {
            if (tableAdaptes == null)
                throw new ArgumentNullException("tableAdaptes");

            using (var trans = TransManager.GetTrans())
            {
                foreach (var tableAdpter in tableAdaptes)
                {
                    tableAdpter.SetConnection(Connection);

                    if (string.IsNullOrEmpty(tableAdpter.DBName))
                        tableAdpter.DBName = DBName;

                    switch (tableAdpter.StateRecord)
                    {
                        case eState.eAdd:                            
                            tableAdpter.Add();

                            break;
                        case eState.eUpdate:
                            
                            tableAdpter.Update();

                            break;
                        case eState.eRemove:
                            tableAdpter.Remove();
                            break;
                    }
                }

                trans.Complete();
            }

        }

        /// <summary>
        /// Valores validos para a tebela
        /// </summary>
        /// <remarks>
        /// Esse valor é usado para prenchimento da tabela no 
        /// momento da criação dela e na atualização
        /// </remarks>
        public List<TableAdapter> InicialValues { get; set; }


        /// <summary>
        /// Indica se a tabela tem valores padrões.
        /// </summary>
        public bool InicialValue { get; set; }
        /// <summary>
        /// Qual o campo para identificar registros no banco de dados
        /// </summary>
        public string InicialFieldName { get; set; }

        /// <summary>
        /// Atualiza a lista de valores iniciais
        /// </summary>
        public void UpdateValues()
        {
            RaiseBeforeLoadValues();

            var fieldName = InicialFieldName ?? KeyFields.First().Name;

            CheckForNewsAditionalValues(fieldName);

            CheckForUpdateAditionalValues(fieldName);

            RaiseAfterLoadValues();
        }

        private void CheckForUpdateAditionalValues(string keyFieldName)
        {
            var dblist = GetData();

            var newList = new List<TableAdapter>();

            foreach (var item in InicialValues)
            {
                var dataItem = dblist.AsEnumerable().FirstOrDefault(
                    c => c[keyFieldName].Equals(item.Collumns[keyFieldName].Value));

                if (dataItem == null)
                    continue;

                foreach (var column in item.Collumns.Where(c => c.Name != keyFieldName))
                {
                    if (EqualityComparer<object>.Default.Equals(column.Value, dataItem[column.Name]))
                        continue;

                    newList.Add(item);

                    break;
                }
            }

            newList.SetState(eState.eUpdate);

            SaveLines(newList);
        }

        private void CheckForNewsAditionalValues(string fieldName)
        {
            var dblist = from obj in GetData().AsEnumerable()
                         select new { Id = obj[fieldName].To(obj[fieldName].GetType()) };

            var newList = InicialValues
                .Where(item => !dblist.Any(c => c.Id.Equals(item.Collumns[fieldName].Value)))
                .ToList();

            newList.SetState(eState.eAdd);

            SaveLines(newList.ToArray());
        }



        /// <summary>
        /// Dispara o evento OnBeforeLoadValues
        /// </summary>
        protected internal void RaiseBeforeLoadValues()
        {
            if (OnBeforeLoadValues != null)
                OnBeforeLoadValues(this, new TableAdapterEventArgs());
        }

        /// <summary>
        /// Dispara o evento OnAfterLoadValues
        /// </summary>
        protected internal void RaiseAfterLoadValues()
        {
            if (OnAfterLoadValues != null)
                OnAfterLoadValues(this, new TableAdapterEventArgs());
        }

        /// <summary>
        /// Atribui as alterações ocorridas aos eventos
        /// </summary>
        void SetPropertyChangedEvents()
        {
            foreach (var col in Collumns)
            {
                col.PropertyChanged -= col_PropertyChanged;
                col.PropertyChanging -= col_PropertyChanging;

                if (PropertyChangedNotify.Any(c => c == col.Name))
                    col.PropertyChanged += col_PropertyChanged;

                if (PropertyChangingNotify.Any(c => c == col.Name))
                    col.PropertyChanging += col_PropertyChanging;
            }
        }

        /// <summary>
        /// Bloquei notificações de alteração
        /// </summary>
        public Boolean LockNotify { get; set; }

        /// <summary>
        /// Evento disparado quando alguma atualização é realizada
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Evento disparado quando alguma atualização está sendo realizada
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Variável que da apoio a propriedades
        /// </summary>
        List<string> _propertyChangedNotify = new List<string>();

        /// <summary>
        /// Propriedades que devem ser notificadas quando ocorrer uma atualização
        /// </summary>
        public List<String> PropertyChangedNotify
        {
            get { return _propertyChangedNotify; }
            set
            {
                _propertyChangedNotify = value;
                SetPropertyChangedEvents();
            }
        }

        /// <summary>
        /// Variável que da apoio a propriedades
        /// </summary>
        List<string> _propertyChangingNotify = new List<string>();
        /// <summary>
        /// Propriedades que devem ser notificadas quando estiver ocorrendo uma atualização.
        /// </summary>
        public List<String> PropertyChangingNotify
        {
            get { return _propertyChangingNotify; }
            set
            {
                _propertyChangingNotify = value;
                SetPropertyChangedEvents();
            }
        }

        /// <summary>
        /// Atribui o estado de update caso for banco de dados
        /// </summary>
        public void SetModifyState()
        {
            if (!IsModifyState())
                StateRecord = StateRecord == eState.eDatabase ? eState.eUpdate : eState.eAdd;
        }

        /// <summary>
        /// Atribui o estado de update caso for banco de dados
        /// </summary>
        public bool IsModifyState()
        {
            return StateRecord == eState.eAdd || StateRecord == eState.eUpdate;
        }

        internal void RaiseAfeterAlterTable(TableAdapter tableAdapterForAlter)
        {
            if (OnAfterAlterTable != null)
                OnAfterAlterTable(tableAdapterForAlter, new TableAdapterEventArgs());
        }

        /// <summary>
        /// Tabela de Log
        /// </summary>
        public TableAdapterLog TableAdapterLog { get; set; }
        /// <summary>
        /// Identifica se a instância de objeto da entidade controla log
        /// </summary>
        public bool AutoLog { get; private set; }

        /// <summary>
        /// Hablita Log automático no tableAdapter
        /// </summary>
        public void SetAutoLog(bool autoLog = true)
        {
            if (autoLog)
            {
                TableAdapterLog = new TableAdapterLog(this);
                this.AutoLog = autoLog;
            }
            else if (TableAdapterLog != null)
            {
                TableAdapterLog.Detach();
                TableAdapterLog = null;
            }
        }


    }
}

