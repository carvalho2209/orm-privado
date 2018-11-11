namespace Nampula.DI
{
    /// <summary>
    /// Classe para gerenciamento de Ordenação da Query
    /// </summary>
    public class OrderBy
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public OrderBy()
        {
        }

        /// <summary>
        /// Instancia e clona o onketo
        /// </summary>
        /// <param name="pOrderBy">Um objeto OrderBy</param>
        public OrderBy(OrderBy pOrderBy)
            : this()
        {
            Field = new QueryParam(pOrderBy.Field);
            Order = pOrderBy.Order;
        }

        /// <summary>
        /// Ordena de forma ascendente apartir do objeto
        /// </summary>
        /// <param name="pField">Um QueryParam</param>
        public OrderBy(QueryParam pField)
        {
            Field = pField;
            Order = eOrder.eoASC;
        }

        /// <summary>
        /// Instancia e o objeto e define o campoe a ordenação
        /// </summary>
        /// <param name="pField">Campo de Ordenação</param>
        /// <param name="pOrder">Tipo de Ordenação</param>
        public OrderBy(QueryParam pField, eOrder pOrder)
        {
            Field = pField;
            Order = pOrder;
        }

        /// <summary>
        /// Campo de ordenação
        /// </summary>
        public QueryParam Field { get; set; }
        /// <summary>
        /// Tipo de Ordenação
        /// </summary>
        public eOrder Order { get; set; }

    }

}
