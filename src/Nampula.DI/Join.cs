namespace Nampula.DI
{
    /// <summary>
    /// Classe para tratamento de clausula join
    /// </summary>
    public class Join
    {
        /// <summary>
        /// Tipo de Relacionamento
        /// </summary>
        public eJoinRelationShip RelationShip { get; set; }
        /// <summary>
        /// Um TableQuery
        /// </summary>
        public TableQuery TableQuery { get; set; }
        /// <summary>
        /// Nome do parametro de relacionamento mais a esquerda
        /// </summary>
        public QueryParam FieldName { get; set; }
        /// <summary>
        /// Clausla On
        /// </summary>
        public WhereCollection On { get; set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Join() { }

        /// <summary>
        /// Instancia um objeto
        /// </summary>
        /// <param name="pTableQuery">Um objeto TableQuery de origem</param>
        /// <param name="pOn">Clausula on</param>
        public Join(TableQuery pTableQuery, WhereCollection pOn)
            : this()
        {

            this.TableQuery = pTableQuery;
            this.RelationShip = eJoinRelationShip.ejrInnerJoin;
            this.On = pOn;

        }

        /// <summary>
        /// Clona o objeto
        /// </summary>
        /// <param name="pJoin">Objeto de Origem</param>
        public Join(Join pJoin)
            : this()
        {

            this.RelationShip = pJoin.RelationShip;
            this.TableQuery = new TableQuery(pJoin.TableQuery);
            //this.FieldName = new QueryParam ( pJoin.FieldName );
            this.On = new WhereCollection(pJoin.On);

        }

    }
}
