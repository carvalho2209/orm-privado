using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
namespace Nampula.UI
{

    public class EditText : DevExpress.XtraEditors.TextEdit
    {

        private BoDataType m_DataType;
        private int m_DecimalPlaces;

        public EditText()
        {
            Nampula.UI.VisualStyles.SetStyle(this);
            this.DecimalPlaces = 2;
            this.DataType = BoDataType.dt_SHORT_TEXT;
        }

        [DefaultValue(BoDataType.dt_SHORT_TEXT)]
        public BoDataType DataType
        {
            get { return m_DataType; }
            set
            {
                m_DataType = value;
                OnChangeDataType();
            }
        }

        [DefaultValue(2)]
        public Int32 DecimalPlaces
        {
            get { return m_DecimalPlaces; }
            set
            {
                m_DecimalPlaces = value;
                OnChangeDataType();
            }
        }

        public string DataSourceInformation { get; set; }

        private void OnChangeDataType()
        {
            var myFormatHelper = new FormatHelper(this.DataType, this.DecimalPlaces);

            myFormatHelper.SetDysplatFormat(this.Properties.DisplayFormat);
            myFormatHelper.SetEditFormat(this.Properties.EditFormat);
            myFormatHelper.SetMaskEdit(this.Properties.Mask);

            myFormatHelper.SetTexAlign(this.Properties.Appearance);
            myFormatHelper.SetTexAlign(this.Properties.AppearanceDisabled);
            myFormatHelper.SetTexAlign(this.Properties.AppearanceFocused);
            myFormatHelper.SetTexAlign(this.Properties.AppearanceReadOnly);

        }

        protected override void OnResize(EventArgs e)
        {
            VisualStyles.SetStyle(this);
            base.OnResize(e);
        }

    }

}
