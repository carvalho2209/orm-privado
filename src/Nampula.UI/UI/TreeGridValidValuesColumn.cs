using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;

namespace Nampula.UI
{
    /// <summary>
    /// UMa coluna no estilo combobox de um treeviewe
    /// </summary>
    public class TreeGridValidValuesColumn : RepositoryItemLookUpEdit
    {
        /// <summary>
        /// Cria uma nova coluna do tipo RepositoryItemLookUpEdit
        /// </summary>
        /// <param name="pCollumn">Coluna que será aplicado o combo</param>
        public TreeGridValidValuesColumn(TreeListColumn pCollumn)
        {
            pCollumn.ColumnEdit = this;

            ValidValues = new ValidValues();
            ValidValues.OnAdd += new CollectionEventHandler(ValidValues_OnAdd);

            this.DataSource = new ValidValuesCollection();
            this.ValueMember = "Value";
            this.DisplayMember = "Description";
            this.ShowHeader = false;
        }

        void ValidValues_OnAdd(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            ((ValidValuesCollection)this.DataSource).Add(e.Item);
        }

        /// <summary>
        /// Valore válidos da coluna
        /// </summary>
        public ValidValues ValidValues { get; set; }

    }

}
