using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nampula.DI.B1.BusinessPartners;
using Nampula.UI.Helpers.Extentions;
using Nampula.UI.Helpers;
using NampulaDemo.DI;

namespace NampulaDemo
{
    public partial class GridViewEditorDemo : Nampula.UI.Form
    {

        GridViewEditable<SampleGri> _editGridMaster;
        GridViewEditable<BusinessPartnerContact> _editGridChield;

        public GridViewEditorDemo()
        {
            InitializeComponent();

            ForamtGrid();
        }

        private void ForamtGrid()
        {
            _editGridMaster = new GridViewEditable<SampleGri>(gridView1, new List<SampleGri>());

            gridView1.SetEditable(new List<string>{
                SampleGri.FieldsName.Campo1,
                SampleGri.FieldsName.Campo2,
                SampleGri.FieldsName.Campo3
            }, true);

            _editGridChield = new GridViewEditable<BusinessPartnerContact>(gridView2, new List<BusinessPartnerContact>());

            gridView2.SetAllEditable(true);

            gridView1.FocusedRowChanged +=gridView1_FocusedRowChanged;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (!gridView1.IsValidRowHandle(e.FocusedRowHandle))
                    return;

                FillChields();
            }
            catch (Exception ex)
            {
                ShowMessageError(ex);
            }
        }

        private void FillChields()
        {
            //var current = gridView1.GetSelected<BusinessPartnerContact>();

            //_editGridChield.Lines = current.Samples;
            //_editGridChield.FillAll();
        }
    }
}
