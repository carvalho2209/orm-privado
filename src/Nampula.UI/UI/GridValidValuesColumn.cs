using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace Nampula.UI
{
    /// <summary>
    /// UMa coluna no estilo combobox de um treeviewe
    /// </summary>
    public class GridValidValuesColumn : GridColumn
    {
        /// <summary>
        /// Cria uma nova coluna do tipo RepositoryItemLookUpEdit
        /// </summary>
        public GridValidValuesColumn()
        {
            var myComboEdit = new RepositoryItemLookUpEdit();

            this.ColumnEdit = myComboEdit;
            myComboEdit.ShowHeader = false;
            myComboEdit.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            ValidValues = new ValidValues();
            ValidValues.OnAdd += new CollectionEventHandler(ValidValues_OnAdd);
            ValidValues.OnClear += new CollectionEventHandler(ValidValues_OnClear);
            ValidValues.OnRemove += new CollectionEventHandler(ValidValues_OnRemove);

            myComboEdit.DataSource = new ValidValuesCollection();
            myComboEdit.ValueMember = "Value";
            myComboEdit.DisplayMember = "Description";
        }

        void ValidValues_OnRemove(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            ((ValidValuesCollection)((RepositoryItemLookUpEdit)this.ColumnEdit).DataSource).Remove(e.Item);
        }

        void ValidValues_OnClear(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            ((ValidValuesCollection)((RepositoryItemLookUpEdit)this.ColumnEdit).DataSource).Clear();
        }

        void myComboEdit_Popup(object sender, EventArgs e)
        {
            ((RepositoryItemLookUpEdit)sender).BestFit();
        }

        void ValidValues_OnAdd(object sender, ManagerCollectionEventHargs<ValidValue> e)
        {
            ((ValidValuesCollection)((RepositoryItemLookUpEdit)this.ColumnEdit).DataSource).Add(e.Item);
        }

        /// <summary>
        /// Valore válidos da coluna
        /// </summary>
        public ValidValues ValidValues { get; set; }

    }
}
