using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI.ScriptWizard;

namespace Nampula.DI
{
    /// <summary>
    /// Consulta de dados no banco de dados
    /// </summary>
    public class CommandService
    {
        /// <summary>
        /// Nome do Campo que define o Id da Query
        /// </summary>
        public static readonly string PageIdFieldName = "PageId";

        /// <summary>
        /// Executa uma consulta páginaa no banco e retorna o resultado
        /// </summary>
        /// <param name="pQuery">Consulta</param>
        /// <param name="pPage">Página</param>
        /// <param name="pRowsByPage">Linhas por página</param>
        /// <param name="pSortFieldName">Campo para ordenação</param>
        /// <param name="pSortDirection">Direação da Ordenação</param>
        /// <returns>Um consulta com o resultado</returns>
        public TableQueryPaged SqlQuery(TableQuery pQuery, int pPage, int pRowsByPage, string pSortFieldName, eOrder pSortDirection)
        {
            var conn = Connection.Instance;
            var queryCount = new TableQuery(pQuery);
            var script = new SqlServerScriptWizard();
            var result = new TableQueryPaged();

            queryCount.Fields = new TableAdapterFieldCollection();

            var fieldSort = pQuery.Fields.First(c => c.Name == pSortFieldName);
            queryCount.Fields.Add(new TableAdapterField()
            {
                Name = "Records",
                FieldType = eFieldType.eValueField,
                Value = string.Format("Count ( isNull({0},'0') )",
                    script.GetFieldName(fieldSort.TableAlias, fieldSort.Name, string.Empty))
            });

            var selectCommandForCount = script.GetSelectComplexStatment(queryCount);

            result.Count = conn.SqlExecuteScalar<int>(selectCommandForCount.Item1, selectCommandForCount.Item2);
            result.RowsByPage = pRowsByPage == 0 ? 1 : pRowsByPage;
            result.PageCount = (int)Math.Ceiling(result.Count / (decimal)result.RowsByPage);
            result.Page = pPage < 1 ? 1 : pPage > result.PageCount ? result.PageCount : pPage;

            var start = (result.Page - 1) * result.RowsByPage;
            var end = start + result.RowsByPage;

            var selectCommand = script.GetSelectStatment(pQuery, PageIdFieldName, start, end, pSortFieldName, pSortDirection);
            result.Data = conn.SqlServerQuery(selectCommand.Item1, selectCommand.Item2);

            return result;
        }
    }
}
