using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.Framework;

namespace Nampula.DI
{
    public static class TableAdapterExtetions
    {
        /// <summary>
        /// Altera o estado da coleção
        /// </summary>
        /// <typeparam name="TT">O Tipo do TableAdapter</typeparam>
        /// <param name="pColection">UMa ista de tableadpaters</param>
        /// <param name="pNewState">O Novo estado</param>
        public static void SetState<TT>(this IEnumerable<TT> pColection, eState pNewState) where TT : TableAdapter
        {
            foreach (var item in pColection)
                item.StateRecord = pNewState;
        }




        /// <summary>
        /// Converte a lista para um dataTable
        /// </summary>
        /// <typeparam name="TT">O tipo do TableAdapte</typeparam>
        /// <param name="pCollection">Uma Lista de TableAdapters</param>
        /// <returns>Um DataTable</returns>
        public static DataTable ToDataTable<TT>(this IEnumerable<TT> pCollection) where TT : TableAdapter, new()
        {
            var listOfColections = pCollection.ToList();

            var columns = listOfColections.IsEmpty() 
                ? new TT().Collumns
                : listOfColections.First().Collumns;

            var data = new DataTable();

            foreach (var column in columns)
                data.Columns.Add(column.Name, column.GetDbType());

            foreach (var item in listOfColections)
            {
                var pDataRow = data.Rows.Add();

                foreach (var column in item.Collumns)
                    pDataRow[column.Name] = column.Value ?? DBNull.Value;
            }

            return data;
        }


    }
}
