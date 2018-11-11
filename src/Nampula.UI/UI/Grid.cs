using System;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using Nampula.UI.Helpers.Extentions;

namespace Nampula.UI
{

    /// <summary>
    /// Data grid
    /// </summary>
    public class DataGrid : DevExpress.XtraGrid.GridControl
    {

        /// <summary>
        /// Data Grid
        /// </summary>
        public DataGrid()
        {
            VisualStyles.SetStyle(this);

            DataSourceChanged += DataGrid_DataSourceChanged;
            Load += DataGrid_Load;
        }


        public Boolean DontSavePosition { get; set; }

        /// <summary>
        /// método do evento disparado ao carregar um grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGrid_Load(object sender, EventArgs e)
        {
            var view = MainView as GridView;

            if (view != null)
                view.ColumnPositionChanged += view_ColumnPositionChanged;
        }



        /// <summary>
        /// Pega o caminho do registro para ser salvo o layout
        /// </summary>
        /// <param name="pView">Uma View</param>
        /// <returns>Uma string com o caminho do registro</returns>
        private string GetRegistry(GridView pView)
        {
            string path = string.Format("HKEY_LOCAL_MACHINE\\SOFTWARE\\{0}\\{1}\\{2}"
                , Assembly.GetEntryAssembly().GetName().Name, FindForm().Name, pView.Name);

            return path;
        }

        void DataGrid_DataSourceChanged(object sender, EventArgs e)
        {
            if (DontSavePosition)
                return;

            var view = MainView as GridView;
            if (view != null)
                view.RestoreLayoutFromRegistry(GetRegistry(view));
        }

        void view_ColumnPositionChanged(object sender, EventArgs e)
        {
            if (DontSavePosition)
                return;

            try
            {
                var view = (sender as GridColumn).View as GridView;
                if (view != null)
                    view.SaveLayoutToRegistry(GetRegistry(view));
            }
            catch (Exception ex)
            {
                var form = FindForm() as Form;
                if (form != null)
                    form.SetTextOnStatusBar(ex.Message, BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
        }

        /// <summary>
        /// Formata a coluna da grid de acordo com um tipo
        /// </summary>
        /// <param name="pCollumn">Uma coluna</param>
        /// <param name="pDataType">tipo da coluna</param>
        public void SetGridFormat(GridColumn pCollumn, BoDataType pDataType)
        {
            SetGridFormat(pCollumn, pDataType, 2);
        }



        /// <summary>
        /// Formata a coluna da grid de acordo com um tipo
        /// </summary>
        /// <param name="pCollumn">Uma coluna</param>
        /// <param name="pDataType">Tipo de Coluna</param>
        /// <param name="pDecimalPlaces">Casas decimais</param>
        public void SetGridFormat(GridColumn pCollumn, BoDataType pDataType, int pDecimalPlaces)
        {
            var myHellper = new FormatHelper(pDataType, pDecimalPlaces);

            myHellper.SetDysplatFormat(pCollumn.DisplayFormat);
            myHellper.SetTexAlign(pCollumn.AppearanceCell);

            pCollumn.View.ShowingEditor += View_ShowingEditor;
        }



        void View_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var view = sender as GridView;
            var edit = view.FocusedColumn.RealColumnEdit as RepositoryItemDateEdit;

            if (edit != null)
                new FormatHelper(BoDataType.dt_DATE).SetMaskEdit(edit.Mask);

        }


    }

}
