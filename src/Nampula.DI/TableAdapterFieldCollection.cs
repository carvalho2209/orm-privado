using System.Collections.Generic;
using System.Linq;


namespace Nampula.DI
{
    /// <summary>
    /// Lista de Campos do tableAdapterField
    /// </summary>
    public class TableAdapterFieldCollection : List<TableAdapterField>
    {

        public TableAdapterFieldCollection() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTableAdapterFieldCollection"></param>
        public TableAdapterFieldCollection(TableAdapterFieldCollection pTableAdapterFieldCollection)
        {
            AllFields = pTableAdapterFieldCollection.AllFields;

            foreach (var myItem in pTableAdapterFieldCollection)
                Add(new TableAdapterField(myItem));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pTableAlias"></param>
        public void Add(TableAdapterField item, string pTableAlias)
        {
            item.TableAlias = pTableAlias;
            Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <param name="pTableAlias"></param>
        public void Insert(int index, TableAdapterField item, string pTableAlias)
        {
            item.TableAlias = pTableAlias;
            Insert(index, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pTableAlias"></param>
        /// <param name="pAlias"></param>
        public void Add(TableAdapterField item, string pTableAlias, string pAlias)
        {
            item.Alias = pAlias;
            Add(item, pTableAlias);
        }

        /// <summary>
        /// Todos os campos
        /// </summary>
        public bool AllFields { get; set; }

        /// <summary>
        /// Indice
        /// </summary>
        /// <param name="pColumName"></param>
        public TableAdapterField this[string pColumName]
        {
            get { return this.FirstOrDefault(d => d.Name == pColumName); }
        }
    }
}
