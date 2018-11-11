using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Columns;
using Nampula.UI.Helpers.Extentions;

namespace Nampula.UI
{

    public class DataGridTreeView : DevExpress.XtraTreeList.TreeList
    {

        public DataGridTreeView ( )
        {
            VisualStyles.SetStyle( this );
            this.SetColors();
            //this.View
            //    ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler ( DataGrid_ViewRegistered );

        }

        //void DataGrid_ViewRegistered ( object sender, DevExpress.XtraGrid.ViewOperationEventArgs e ) {

        //    ( (GridView)e.View ).GroupPanelText = "Arraste as colunas aqui para poder agrupa-las";
        //}

        public void SetGridFormat ( GridColumn pCollumn, BoDataType pDataType, int pDecimalPlaces )
        {

            FormatHelper myHellper = new FormatHelper( pDataType, pDecimalPlaces );

            myHellper.SetDysplatFormat( pCollumn.DisplayFormat );
            myHellper.SetTexAlign( pCollumn.AppearanceCell );

        }

    }
}
