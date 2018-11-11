using System.Collections.Generic;

namespace Nampula.DI
{

    /// <summary>
    /// Lista de COndições para pesquisas
    /// </summary>
    public class WhereCollection : List<QueryParam>
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public WhereCollection()
        {
            Relation = eRelationship.erAnd;
        }

        /// <summary>
        /// Construtor com QueryParam
        /// </summary>
        /// <param name="pQueryParam"></param>
        public WhereCollection(QueryParam pQueryParam)
            : this()
        {
            Add(pQueryParam);
        }

        /// <summary>
        /// Clonar a collection
        /// </summary>
        /// <param name="pWhereCollection">Query a ser collection</param>
        public WhereCollection(WhereCollection pWhereCollection)
            : this()
        {

            foreach (var myItem in pWhereCollection)
            {
                Add(new QueryParam(myItem));
            }

            Relation = pWhereCollection.Relation;
        }

        /// <summary>
        /// Relacção entre as wheres
        /// </summary>
        public eRelationship Relation { get; set; }

    }

}
