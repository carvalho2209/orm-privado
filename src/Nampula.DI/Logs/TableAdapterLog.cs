using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nampula.Framework;

namespace Nampula.DI.Logs
{
    /// <summary>
    /// Tabela de tratamento de log de alterações
    /// </summary>
    public class TableAdapterLog
    {
        /// <summary>
        /// Nomes dos Campos da Tabela de Log
        /// </summary>
        public struct FieldsName
        {
            public static readonly string InstanceLog = "InstanceLog";
            public static readonly string DateAddLog = "DateAddLog";
            public static readonly string UserNameLog = "UserNameLog";
            public static readonly string MachineLog = "MachineLog";
            public static readonly string BaseIdLog = "BaseIdLog";
            public static readonly string WasDeletedLog = "WasDeletedLog";
        }

        /// <summary>
        /// Nome dos campos da tabela de log
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string Id = "Código";
            public static readonly string InstanceLog = "Instância";
            public static readonly string DateAddLog = "Data";
            public static readonly string UserNameLog = "Usuário";
            public static readonly string MachineLog = "Máquina";
            public static readonly string BaseIdLog = "Código da Origem";
            public static readonly string WasDeletedLog = "Foi Excluído";
        }

        readonly TableAdapterField m_InstanceLog = new TableAdapterField(FieldsName.InstanceLog, FieldsDescription.InstanceLog, DbType.Int32, 11, null, true, false);
        readonly TableAdapterField m_BaseIdLog = new TableAdapterField(FieldsName.BaseIdLog, FieldsDescription.BaseIdLog, DbType.String, 200, null, true, false);
        readonly TableAdapterField m_MachineLog = new TableAdapterField(FieldsName.MachineLog, FieldsDescription.MachineLog, 200);
        readonly TableAdapterField m_DateAddLog = new TableAdapterField(FieldsName.DateAddLog, FieldsDescription.DateAddLog, DbType.DateTime);
        readonly TableAdapterField m_UserNameLog = new TableAdapterField(FieldsName.UserNameLog, FieldsDescription.UserNameLog, 200);
        readonly TableAdapterField m_WasDeletedLog = new TableAdapterField(FieldsName.WasDeletedLog, FieldsDescription.WasDeletedLog, DbType.Boolean);

        private readonly TableAdapter _tableLog = new TableAdapter();
        private readonly TableAdapter _tableLogBase;

        /// <summary>
        /// Instanciar o TableLog
        /// </summary>
        /// <param name="tableAdapter">Tabela Base de Criação de Log</param>
        public TableAdapterLog(TableAdapter tableAdapter)
        {
            CheckIfOnlyOneKey(tableAdapter);

            CopyFields(tableAdapter);
            AddLogFields();

            _tableLogBase = tableAdapter;
            _tableLogBase.OnAfterAdd += tableAdpterBaser_OnAfterAdd;
            _tableLogBase.OnAfterUpdate += tableAdpterBase_OnAfterUpdate;
            _tableLogBase.OnAfterCreate += tableAdpterBase_OnAfterCreate;
            _tableLogBase.OnAfterAlterTable += tableAdpterBase_OnAfterAlterTable;
        }

        private static void CheckIfOnlyOneKey(TableAdapter tableAdapter)
        {
            if (!tableAdapter.KeyFields.Any())
            {
                throw new Exception(
                    "Para habilitar o autoLog deve haver ao menos uma chave: Tabela [{0}.{1}]"
                    .Fmt(tableAdapter.DBName, tableAdapter.TableName));
            }

        }

        /// <summary>
        /// Chaves do registro de origem
        /// </summary>
        public String BaseIdLog
        {
            get { return m_BaseIdLog.GetString(); }
            set { m_BaseIdLog.Value = value; }
        }

        /// <summary>
        /// Id da instancia de atualização
        /// </summary>
        public Int32 InstanceLog
        {
            get { return m_InstanceLog.GetInt32(); }
            set { m_InstanceLog.Value = value; }
        }

        /// <summary>
        /// Lista dos campos da tabela de log
        /// </summary>
        /// <returns></returns>
        public List<TableAdapterField> GetColumns()
        {
            return _tableLog.Collumns;
        }

        /// <summary>
        /// Obetem as diferenças entre o último log até o log passado
        /// </summary>
        /// <param name="logDataRow">Log Inicial</param>
        /// <returns>Uma lista de diferenças entre os registros</returns>
        public List<LogDifferences> GetDiffStartBy(DataRow logDataRow)
        {
            var logs = GetByBaseId();

            var logsGratherThanInstanceLog = logs.AsEnumerable()
                .Where(c => c[FieldsName.InstanceLog].To<int>() >= logDataRow[FieldsName.InstanceLog].To<int>())
                .ToArray();

            var diffs = new List<LogDifferences>();

            for (var i = 0; i < logsGratherThanInstanceLog.Length - 1; i++)
            {
                var currentLog = logsGratherThanInstanceLog[i];
                var nextLog = logsGratherThanInstanceLog[i + 1];

                var diff = GetDiff(logs, currentLog, nextLog);

                diffs.AddRange(diff);
            }

            return diffs;
        }

        /// <summary>
        /// Pega a diferença entre os 2 registros
        /// </summary>
        /// <param name="dataTable">Tabela de log na memória</param>
        /// <param name="from">Comparar de</param>
        /// <param name="to">Comparar com</param>
        /// <returns>Lista de Campos que estão diferentes</returns>
        public List<LogDifferences> GetDiff(DataTable dataTable, DataRow from, DataRow to)
        {
            var logDifferences = new List<LogDifferences>();

            for (var i = 1; i < from.ItemArray.Length; i++)
            {
                var firstValue = from[i].To<String>();
                var secondValue = to[i].To<String>();

                if (IsFieldOfTableLog(dataTable.Columns[i].ColumnName) || firstValue == secondValue)
                    continue;

                var logDifferenceItem = new LogDifferences
                                            {
                                                Instance = to.Field<int>(FieldsName.InstanceLog),
                                                Date = to.Field<DateTime>(FieldsName.DateAddLog),
                                                FieldName = _tableLog.Collumns[i].Name,
                                                FieldDescription = _tableLog.Collumns[i].Description,
                                                NewValue = secondValue,
                                                OldValue = firstValue,
                                                UserName = to.Field<string>(FieldsName.UserNameLog),
                                                MachineName = to.Field<string>(FieldsName.MachineLog)
                                            };


                logDifferences.Add(logDifferenceItem);
            }

            return logDifferences;
        }

        /// <summary>
        /// Obtem os nomes dos campos somento do log e não da tabela base
        /// </summary>
        /// <returns>Lista de Campos</returns>
        public List<TableAdapterField> GetLogFields()
        {
            return new List<TableAdapterField>
                       {
                           m_InstanceLog,
                           m_MachineLog,
                           m_UserNameLog,
                           m_DateAddLog,
                           m_BaseIdLog,
                           m_WasDeletedLog
                       };
        }

        /// <summary>
        /// Obtem a lista de log apartir de um id
        /// </summary>
        /// <returns></returns>
        public DataTable GetByBaseId()
        {
            if (string.IsNullOrWhiteSpace(_tableLog.TableName))
                SetTableAndDbNameLogFor(_tableLogBase);

            var query = new TableQuery(_tableLog);

            var baseId = GetBaseId();

            query.Where.Add(new QueryParam(_tableLog.Collumns[FieldsName.BaseIdLog], baseId));

            query.OrderBy.Add(new OrderBy(
                new QueryParam(_tableLog.Collumns[FieldsName.InstanceLog]),
                eOrder.eoASC));

            return _tableLog.GetData(query);
        }

        void tableAdpterBase_OnAfterAlterTable(object sender, TableAdapterEventArgs e)
        {
            SetTableAndDbNameLogFor(sender as TableAdapter);
            AddFieldsIfNoExistsOnTable();
        }

        void tableAdpterBase_OnAfterCreate(object Sender, TableAdapterEventArgs e)
        {
            SetTableAndDbNameLogFor(Sender as TableAdapter);
            CreateTableIfNoExist();
        }

        void tableAdpterBaser_OnAfterAdd(object Sender, TableAdapterEventArgs e)
        {
            SetTableAndDbNameLogFor(Sender as TableAdapter);

            _tableLog.Collumns[FieldsName.DateAddLog].Value = DataBaseAdapter.GetServerDate();
            _tableLog.Collumns[FieldsName.MachineLog].Value = Environment.MachineName;
            _tableLog.Collumns[FieldsName.UserNameLog].Value = Connection.Instance.ConnectionParameter.UserName;
            _tableLog.Collumns[FieldsName.BaseIdLog].Value = GetBaseId();
            _tableLog.Collumns[FieldsName.InstanceLog].Value = GetNextSeqInstanceLog();

            foreach (var collumn in _tableLogBase.Collumns)
                _tableLog.Collumns[collumn.Name].Value = collumn.Value;

            _tableLog.Add();
        }

        private string GetBaseId()
        {
            var ids = new StringBuilder();

            foreach (var keyField in _tableLogBase.KeyFields)
            {
                if (ids.Length > 0)
                    ids.Append('\t');
                ids.Append(keyField.Value);
            }

            return ids.ToString();
        }

        void tableAdpterBase_OnAfterUpdate(object Sender, TableAdapterEventArgs pEvent)
        {
            tableAdpterBaser_OnAfterAdd(Sender, pEvent);
        }

        private void CopyFields(TableAdapter tableLog)
        {
            foreach (var collumn in tableLog.Collumns)
                _tableLog.Collumns.Add(CloneTableField(collumn));
        }

        private void AddFieldsIfNoExistsOnTable()
        {
            var fields = GetNewFields();

            if (fields.IsEmpty())
                return;

            var tableLog = GetTableLogUsingThis(fields);

            AlterTable(tableLog);
        }

        private void AlterTable(TableAdapter tableLog)
        {
            var script = new ScriptWizard.SqlServerScriptWizard();
            var query = script.GetAlterTableCommand(tableLog);
            Connection.Instance.SqlServerExecute(query);
        }

        private TableAdapter GetTableLogUsingThis(IEnumerable<TableAdapterField> fields)
        {
            var tableLog = new TableAdapter();

            tableLog.CopyBy(_tableLog);
            tableLog.Collumns.Clear();
            tableLog.Collumns.AddRange(fields);

            return tableLog;
        }

        private List<TableAdapterField> GetNewFields()
        {
            var newFields = new List<TableAdapterField>();

            foreach (var field in _tableLogBase.Collumns)
            {
                if (!ExistField(field.Name))
                    newFields.Add(CloneTableField(field));
            }

            return newFields;
        }

        private Boolean ExistField(string field)
        {
            var infoTable = new InformationSchemaColumn();

            infoTable.SetConnection(Connection.Instance);
            infoTable.DBName = _tableLog.DBName;

            return infoTable.GetByKey(_tableLog.TableName, field);
        }

        private TableAdapterField CloneTableField(TableAdapterField field)
        {
            return new TableAdapterField(field) { Key = false, Identity = false };
        }

        private void SetTableAndDbNameLogFor(TableAdapter tableAdapterBase)
        {
            _tableLog.TableName = tableAdapterBase.TableName + "Log";
            _tableLog.DBName = tableAdapterBase.DBName;
        }

        internal void CreateTableIfNoExist()
        {
            if (!ExistTable())
                _tableLog.Create();
        }

        private bool ExistTable()
        {

            SetTableAndDbNameLogFor(_tableLogBase);

            var infoTable = new InformationSchemaColumn();

            infoTable.SetConnection(Connection.Instance);
            infoTable.DBName = _tableLog.DBName;

            var tableQuery = new TableQuery(infoTable);

            tableQuery.Where.Add(
                new QueryParam(infoTable.Collumns[InformationSchemaColumn.FieldsName.TableName],
                _tableLog.TableName));

            var list = infoTable.FillCollection<InformationSchemaColumn>(tableQuery);

            return !list.IsEmpty();
        }

        private void AddLogFields()
        {
            _tableLog.Collumns.AddRange(GetLogFields());
        }

        private int GetNextSeqInstanceLog()
        {
            var logs = GetByBaseId();

            if (logs.Rows.Count == 0)
                return 1;

            var lastRow = logs.Rows[logs.Rows.Count - 1];

            return lastRow.Field<int>(FieldsName.InstanceLog) + 1;
        }

        private bool IsFieldOfTableLog(string columnName)
        {
            var fieldsTableLog = new List<string>
                                     {
                                         FieldsName.BaseIdLog,
                                         FieldsName.DateAddLog,                                         
                                         FieldsName.InstanceLog,
                                         FieldsName.MachineLog,
                                         FieldsName.UserNameLog,
                                         FieldsName.WasDeletedLog
                                     };

            return fieldsTableLog.Contains(columnName);
        }

        /// <summary>
        /// Remover link de eventos
        /// </summary>
        public void Detach()
        {
            _tableLogBase.OnAfterCreate -= tableAdpterBase_OnAfterCreate;
            _tableLogBase.OnAfterAlterTable -= tableAdpterBase_OnAfterAlterTable;
            _tableLogBase.OnAfterAdd -= tableAdpterBaser_OnAfterAdd;
            _tableLogBase.OnAfterUpdate -= tableAdpterBase_OnAfterUpdate;
        }
    }
}