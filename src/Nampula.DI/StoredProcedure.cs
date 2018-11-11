using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;


namespace Nampula.DI
{
    /// <summary>
    /// Classe para gerenciamento de procedures
    /// </summary>
    public abstract class StoredProcedure : DataObject
    {
        /// <summary>
        /// Evento disparado antes de criar a procedure no banco
        /// </summary>
        public event EventHandler<StoredProcedureEventArgs> OnBeforeCreateProcedure;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        protected StoredProcedure()
        {
            Collumns = new TableAdapterFieldCollection();
            LogCollection = new List<Log>();
            Files = new List<string>();
            ProcedureName = string.Empty;
            Result = new DataTable();
            Collumns = TableAdapterColumns.GetCollumns(this);
        }

        /// <summary>
        /// Construtor da StoredProceudre que definio o nome e os arquivos
        /// </summary>
        /// <param name="pProcedureName">Nome da Procedure</param>
        /// <param name="pFiles">Arquivos no assemlbly da procedure</param>
        protected StoredProcedure(string pProcedureName, params string[] pFiles)
            : this()
        {
            ProcedureName = pProcedureName;
            FileNames = pFiles.ToList();
        }

        /// <summary>
        /// Executa a procedure no banco de dados
        /// </summary>
        /// <returns>true se for executado com sucesso.</returns>
        public virtual bool Execute(bool withResult = true)
        {
            var query = new StringBuilder();
            var queryParams = new StringBuilder();
            var paramters = new List<TableAdapterField>();

            foreach (var column in Collumns)
            {
                queryParams.Append(queryParams.Length > 0 ? " , " : " ");

                queryParams.AppendLine(" @" + column.Name + " = @_" + column.Name + " ");

                var dataParameter = new TableAdapterField
                {
                    Name = "@_" + column.Name,
                    DbType = column.DbType,
                    Value = column.Value ?? DBNull.Value
                };

                paramters.Add(dataParameter);
            }

            query.AppendLine("EXEC " + MakeFullTableName(DBName, ProcedureName));
            query.AppendLine(queryParams.ToString());

            using (var trans = TransManager.GetTrans(withTransaction:false))
            {
                if (withResult)
                    Result = Connection.SqlServerQuery(query.ToString(), paramters);
                else
                    Connection.SqlServerExecute(query.ToString(), paramters);
   
                trans.Complete();
            }            

            return true;
        }

        /// <summary>
        /// Logs 
        /// </summary>
        public List<Log> LogCollection { get; set; }
        /// <summary>
        /// Arquivos com o corpo da procedure
        /// </summary>
        public List<string> Files { get; set; }
        /// <summary>
        /// Nome da Procedure no banco de dados
        /// </summary>
        public string ProcedureName { get; set; }
        /// <summary>
        /// Resulta da Procedure
        /// </summary>
        public DataTable Result { get; set; }
        /// <summary>
        /// Lista de Parametros da Procedure
        /// </summary>
        public TableAdapterFieldCollection Collumns { get; set; }
        /// <summary>
        /// Lista de Nome de Arquivos
        /// </summary>
        public List<string> FileNames { get; set; }
        /// <summary>
        /// Somente cria a procedure se ele não existir
        /// </summary>
        public bool OnlyCreate { get; set; }

        /// <summary>
        /// Cria a procedure no banco de dados
        /// </summary>
        /// <returns>True se for criado com sucesso.</returns>
        public bool Create()
        {
            var args = new StoredProcedureEventArgs();

            if (OnBeforeCreateProcedure != null)
                OnBeforeCreateProcedure(this, args);

            if (args.Cancel)
                return false;

            if (Exists())
                return true;

            foreach (var file in Files)
                Connection.SqlServerExecute(file);

            return true;
        }

        /// <summary>
        /// Verifica se existe a procedure no banco de dados
        /// </summary>
        /// <returns></returns>
        private bool Exists()
        {
            var query = string.Format("SELECT count(*) FROM {0}.sys.objects WHERE object_id = OBJECT_ID(N'{1}') AND type in (N'P', N'PC')",
                   DBName, MakeFullTableName(DBName, ProcedureName));

            return Connection.SqlExecuteScalar<int>(query) > 0;
        }

        /// <summary>
        /// Adiciona um arquivo de acordo com a procedure
        /// </summary>
        /// <param name="pAssemblyName">Nome do Assemly</param>
        /// <param name="pProcedureName">Nome da proceure</param>
        /// <returns>True se for adicionado com sucesso</returns>
        public bool AddFile(string pAssemblyName, string pProcedureName)
        {
            var thisExe = Assembly.Load(pAssemblyName);
            return AddFile(thisExe, pProcedureName);
        }

        /// <summary>
        /// Adiciona um arquivo de acordo com a procedure
        /// </summary>
        /// <param name="pAssemblyName">Assembly</param>
        /// <param name="procedureName">Nome da proceure</param>
        /// <returns>True se for adicionado com sucesso</returns>
        public bool AddFile(Assembly pAssemblyName, string procedureName)
        {
            var resourceFileName = pAssemblyName.GetManifestResourceNames().FirstOrDefault(
                p => p.Contains(procedureName));

            if (string.IsNullOrEmpty(resourceFileName))
                return false;

            var resourceStream = pAssemblyName.GetManifestResourceStream(resourceFileName);
            Debug.Assert(resourceStream != null, "resourceStream != null");
            var streamReader = new StreamReader(resourceStream);

            Files.Add(streamReader.ReadToEnd());

            return true;
        }

        /// <summary>
        /// Le os arquivos das procedures no assemlbly
        /// </summary>
        /// <param name="pAssembly">Assembly onde a procedure está localizada</param>
        public void LoadFiles(Assembly pAssembly)
        {
            foreach (var item in FileNames)
                if (!AddFile(pAssembly, item))
                    throw new Exception(string.Format("Não encontrado o arquivo no assembly com o nome {0}", item));
        }

        /// <summary>
        /// Exclui a procedure no banco
        /// </summary>
        /// <returns></returns>
        public void Drop()
        {
            if (OnlyCreate) return;

            var dropQuery = new StringBuilder();
            var myProcName = MakeFullTableName(DBName, ProcedureName);

            dropQuery.AppendFormat("USE {0};", DBName);
            dropQuery.AppendFormat("IF  EXISTS (SELECT * FROM {0}.sys.objects WHERE object_id = OBJECT_ID(N'{1}')",
                                   DBName, myProcName);

            dropQuery.AppendLine("AND type in (N'P', N'PC'))");
            dropQuery.AppendFormat("DROP PROCEDURE {0};", ProcedureName);

            dropQuery.AppendFormat("IF  EXISTS (SELECT * FROM {0}.sys.objects WHERE object_id = OBJECT_ID(N'{1}')",
                                   DBName, myProcName);

            dropQuery.AppendLine("AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))");
            dropQuery.AppendFormat("DROP FUNCTION {0};", ProcedureName);

            Connection.SqlServerExecute(dropQuery.ToString());
        }

    }
}
