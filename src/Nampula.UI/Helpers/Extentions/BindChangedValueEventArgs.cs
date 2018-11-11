using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nampula.UI.Helpers.Extentions
{
    public class BindChangedValueEventArgs : EventArgs
    {
        public Exception Ex { get; set; }
        public bool Continue { get; set; }
        public KeyValuePair<string, Control> Bind { get; set; }
        public object Value { get; set; }
    }
}
