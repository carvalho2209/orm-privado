using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using System.Drawing;

namespace Nampula.UI.Helpers
{
    public class FormatConditionChoose
    {
        public FormatConditionChoose(FormatConditionEnum pCondition, string pColName, object pVal1, object pVal2, bool pApplyToRow)
        {
            this.FormatConditionEnum = pCondition;
            this.ColumnName = pColName;
            this.val1 = pVal1;
            this.val2 = pVal2;
            this.applyToRow = pApplyToRow;
        }
        
        public FormatConditionEnum FormatConditionEnum { get; set; }
        public string ColumnName { get; set; }
        public object val1 { get; set; }
        public object val2 { get; set; }
        public bool  applyToRow{get;set;}
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
    }
}
