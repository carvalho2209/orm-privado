using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Argumento dos eventos da GridViewEditable
    /// </summary>
    public class GridViewEditableEventArgs : EventArgs
    {
        /// <summary>
        /// Elemeto alterado.
        /// </summary>
        public object item { get; set; }
        /// <summary>
        /// Cancelar o processo.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
