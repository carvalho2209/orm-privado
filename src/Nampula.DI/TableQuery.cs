using System.Collections.Generic;


namespace Nampula.DI
{
    /// <summary>
    /// Construtor de Consultas no banco de dados
    /// </summary>
    public class TableQuery
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public TableQuery()
        {
            Fields = new TableAdapterFieldCollection();
            Wheres = new List<WhereCollection>();
            OrderBy = new List<OrderBy>();
            Union = eUnionType.eutAll;
            InternalQuery = new List<TableQuery>();
            Joins = new List<Join>();
            Top = -1;
        }

        /// <summary>
        /// Instancie o objeto e clona
        /// </summary>
        /// <param name="pTableQuery">Objeto table query</param>
        public TableQuery(TableQuery pTableQuery)
            : this()
        {

            DbName = pTableQuery.DbName;
            TableName = pTableQuery.TableName;
            FieldName = pTableQuery.FieldName;
            Alias = pTableQuery.Alias;
            SchemaTable = pTableQuery.SchemaTable;
            Top = pTableQuery.Top;
            Distinct = pTableQuery.Distinct;

            Fields = new TableAdapterFieldCollection(pTableQuery.Fields);

            foreach (OrderBy myItem in pTableQuery.OrderBy)
                OrderBy.Add(new OrderBy(myItem));

            pTableQuery.Wheres.ForEach(
                w => Wheres.Add(new WhereCollection(w)));

            if (pTableQuery.Joins != null)
                pTableQuery.Joins.ForEach(
                    j => Joins.Add(new Join(j)));

            if (pTableQuery.Union != eUnionType.eutNone)
                pTableQuery.InternalQuery.ForEach(
                    c => InternalQuery.Add(new TableQuery(c)));

        }


        /// <summary>
        /// Instancia um objeto e atribui as chaves como compos de condição 
        /// </summary>
        /// <param name="pTableAdapter">Um table adapter</param>
        /// <param name="pKeysAsWhere"></param>
        public TableQuery(TableAdapter pTableAdapter, bool pKeysAsWhere = false)
            : this()
        {
            Fields.AddRange(pTableAdapter.Collumns);
            DbName = pTableAdapter.DBName;
            TableName = pTableAdapter.TableName;
            SchemaTable = pTableAdapter.SchemaTable;
            WithoutNotLock = pTableAdapter.WithoutNotLock;

            if(!pKeysAsWhere)
                return;

            foreach (var myItem in pTableAdapter.KeyFields)
                Where.Add(new QueryParam(myItem));
        }

        /// <summary>
        /// Instancia um objeto e atribui um alias para uma pesquisa mais complexa.
        /// </summary>
        /// <param name="pTableAdapter">Um TableAdpter</param>
        /// <param name="pWithFields">Chaves como clásula where</param>
        /// <param name="pAlias">Alias da tabela</param>
        public TableQuery(TableAdapter pTableAdapter, bool pWithFields, string pAlias)
            : this(pTableAdapter, false)
        {

            if (!pWithFields)
                Fields = new TableAdapterFieldCollection();

            foreach (var item in pTableAdapter.Collumns)
                item.TableAlias = pAlias;

            Alias = pAlias;
        }

        /// <summary>
        /// Nome do Banco de dados
        /// </summary>
        public string DbName { get; set; }
        /// <summary>
        /// Nome da Tabela
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Nome do Campo Chave
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Alias da Tabela
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Tabela de Schema do banco de dados
        /// </summary>
        public bool SchemaTable { get; set; }

        /// <summary>
        /// NÃO incluir wiht(nolock)
        /// </summary>
        public bool WithoutNotLock { get; set; }

        /// <summary>
        /// Lista de Campos
        /// </summary>
        public TableAdapterFieldCollection Fields { get; set; }
        /// <summary>
        /// Lista de Ordenação
        /// </summary>
        public List<OrderBy> OrderBy { get; set; }
        /// <summary>
        /// Lista de Joins
        /// </summary>
        public List<Join> Joins { get; set; }
        /// <summary>
        /// Tipo de Union
        /// </summary>
        public eUnionType Union { get; set; }
        /// <summary>
        /// Lista de Table Querys alinhados
        /// </summary>
        public List<TableQuery> InternalQuery { get; set; }
        /// <summary>
        /// Adicionar a clausula Disctinct a query
        /// </summary>
        public bool Distinct { get; set; }
        /// <summary>
        /// Número máximo de registros de retorno.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Primeira condição da clausula where
        /// </summary>
        public WhereCollection Where
        {
            get
            {
                if (Wheres.Count == 0)
                    Wheres.Add(new WhereCollection());
                return Wheres[0];
            }
            set
            {
                if (Wheres.Count == 0)
                    Wheres.Add(new WhereCollection());
                Wheres[0] = value;
            }
        }

        /// <summary>
        /// Lista de clauslas where
        /// </summary>
        public List<WhereCollection> Wheres { get; set; }


    }
}


