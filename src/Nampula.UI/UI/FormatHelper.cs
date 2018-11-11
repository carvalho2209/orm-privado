using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI {

    public class FormatHelper {

        public BoDataType DataType { get; set; }
        public int DecimalPlaces { get; set; }
        public char DecimalSeparator { get; set; }
        public char ThousandSeparator { get; set; }

        public FormatHelper () {
            this.DataType = BoDataType.dt_SHORT_TEXT;
        }

        public FormatHelper ( BoDataType pBoDataType )
            : this ( ) {
            this.DataType = pBoDataType;
        }

        public FormatHelper ( BoDataType pBoDataType, int pDecimalPlaces )
            : this ( pBoDataType ) {
            this.DecimalPlaces = pDecimalPlaces;
        }

        internal void SetDysplatFormat ( DevExpress.Utils.FormatInfo pFormatInfo ) {

            switch ( this.DataType ) {
                case BoDataType.dt_LONG_NUMBER:
                case BoDataType.dt_SHORT_NUMBER:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "f0";
                    //pFormatInfo.Format =
                    break;
                case BoDataType.dt_QUANTITY:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_PRICE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_RATE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_MEASURE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_SUM:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_PERCENT:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_LONG_TEXT:
                    break;
                case BoDataType.dt_SHORT_TEXT:
                    break;
                case BoDataType.dt_DATE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.DateTime;
                    pFormatInfo.FormatString = "d";
                    break;
                default:
                    break;
            }

        }

        internal void SetEditFormat ( DevExpress.Utils.FormatInfo pFormatInfo ) {

            switch ( this.DataType ) {
                case BoDataType.dt_LONG_NUMBER:
                case BoDataType.dt_SHORT_NUMBER:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "f0";
                    break;
                case BoDataType.dt_QUANTITY:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_PRICE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_RATE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_MEASURE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_SUM:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_PERCENT:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.Numeric;
                    pFormatInfo.FormatString = "n" + this.DecimalPlaces.ToString ( );
                    break;
                case BoDataType.dt_LONG_TEXT:
                    break;
                case BoDataType.dt_SHORT_TEXT:
                    break;
                case BoDataType.dt_DATE:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.DateTime;
                    pFormatInfo.FormatString = "d";
                    break;
                default:
                    pFormatInfo.FormatType = DevExpress.Utils.FormatType.None;
                    pFormatInfo.FormatString = String.Empty;
                    break;
            }

        }

        internal void SetTexAlign ( DevExpress.Utils.AppearanceObject pAppearanceObject ) {

            switch ( this.DataType ) {
                case BoDataType.dt_LONG_NUMBER:
                case BoDataType.dt_SHORT_NUMBER:
                case BoDataType.dt_QUANTITY:
                case BoDataType.dt_PRICE:
                case BoDataType.dt_RATE:
                case BoDataType.dt_MEASURE:
                case BoDataType.dt_SUM:
                case BoDataType.dt_PERCENT:
                    pAppearanceObject.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case BoDataType.dt_LONG_TEXT:
                case BoDataType.dt_SHORT_TEXT:
                case BoDataType.dt_DATE:
                default:
                    pAppearanceObject.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
            }

        }

        internal void SetMaskEdit ( DevExpress.XtraEditors.Mask.MaskProperties pMaskEdit ) {

            switch ( this.DataType ) {
                case BoDataType.dt_LONG_NUMBER:
                case BoDataType.dt_SHORT_NUMBER:
                    pMaskEdit.EditMask = "f0";
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    pMaskEdit.UseMaskAsDisplayFormat = false;
                    break;
                case BoDataType.dt_QUANTITY:
                    pMaskEdit.EditMask = "n" + this.DecimalPlaces.ToString ( );
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    break;
                case BoDataType.dt_PRICE:
                    pMaskEdit.EditMask = "n" + this.DecimalPlaces.ToString ( );
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    break;
                case BoDataType.dt_RATE:
                    pMaskEdit.EditMask = "n" + this.DecimalPlaces.ToString ( );
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    break;
                case BoDataType.dt_MEASURE:
                    pMaskEdit.EditMask = "n" + this.DecimalPlaces.ToString ( );
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    break;
                case BoDataType.dt_SUM:
                    pMaskEdit.EditMask = "n" + this.DecimalPlaces.ToString ( );
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    break;
                case BoDataType.dt_PERCENT:
                    pMaskEdit.EditMask = "n" + this.DecimalPlaces.ToString ( );
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    break;
                case BoDataType.dt_LONG_TEXT:
                case BoDataType.dt_SHORT_TEXT:
                    pMaskEdit.EditMask = String.Empty;
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                    break;
                case BoDataType.dt_DATE:
                    pMaskEdit.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9]";
                    pMaskEdit.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    pMaskEdit.ShowPlaceHolders = false;
                    pMaskEdit.UseMaskAsDisplayFormat = true;
                    break;
                default:
                    break;
            }

        }
    }

}
