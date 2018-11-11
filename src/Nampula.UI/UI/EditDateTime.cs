using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
namespace Nampula.UI {

    public class EditDateTime : DevExpress.XtraEditors.DateEdit {

        public EditDateTime () {
            if ( !this.DesignMode ) {
                SetDateTimeFormat ( );
            }
        }

        private void SetDateTimeFormat () {
            
            FormatHelper myFormatHelper = new FormatHelper ( BoDataType.dt_DATE );

            myFormatHelper.SetDysplatFormat ( this.Properties.DisplayFormat );
            myFormatHelper.SetEditFormat ( this.Properties.EditFormat );
            myFormatHelper.SetMaskEdit ( this.Properties.Mask );

            myFormatHelper.SetTexAlign ( this.Properties.Appearance );
            myFormatHelper.SetTexAlign ( this.Properties.AppearanceDisabled );
            myFormatHelper.SetTexAlign ( this.Properties.AppearanceFocused );
            myFormatHelper.SetTexAlign ( this.Properties.AppearanceReadOnly );

        }

        /// <summary>
        /// Informações da fonte de dados
        /// </summary>
        public string DataSourceInformation { get; set; }
    }

}
