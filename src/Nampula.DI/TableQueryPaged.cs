using System.Data;

namespace Nampula.DI
{
    /// <summary>
    /// Consulta páginada
    /// </summary>
    public class TableQueryPaged
    {
        /// <summary>
        /// Pagina atual
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Número de Página
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Linha por página
        /// </summary>
        public int RowsByPage { get; set; }
        /// <summary>
        /// Quantidade de registros
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Ordernar pelo campo
        /// </summary>
        public int SortFieldName { get; set; }
        /// <summary>
        /// Direção da ordenação
        /// </summary>
        public eOrder SortFieldDirection { get; set; }
        /// <summary>
        /// Consulta
        /// </summary>
        public TableQuery Query { get; set; }
        /// <summary>
        /// DataTable
        /// </summary>
        public DataTable Data { get; set; }
    }
}
