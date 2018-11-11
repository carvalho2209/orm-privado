using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Nampula.UI
{
    public class EditTextCalc: DevExpress.XtraEditors.CalcEdit
    {
        private BoDataType m_DataType;
        private int m_DecimalPlaces;

        public EditTextCalc()
        {
            Nampula.UI.VisualStyles.SetStyle(this);
            this.DecimalPlaces = 2;
            this.DataType = BoDataType.dt_SHORT_TEXT;
        }

        protected override void OnResize(EventArgs e)
        {
            VisualStyles.SetStyle(this);
            base.OnResize(e);
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

        /// <summary>
        /// Informações da fonte de dados
        /// </summary>
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
    }
}
