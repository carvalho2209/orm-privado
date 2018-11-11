using System;

namespace Nampula.DI
{
    /// <summary>
    /// Argumentos dos eventos da procedure
    /// </summary>
    public class StoredProcedureEventArgs : EventArgs
    {
        /// <summary>
        /// Canelar o procedimento
        /// </summary>
        public bool Cancel { get; set; }
    }

}
