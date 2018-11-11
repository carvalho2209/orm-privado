using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI
{
    /// <summary>
    /// Argumentos do s Eventos do Banco de dados
    /// </summary>
    public class DBEventArgs : EventArgs
    {
        public TableAdapter TableAdapter { get; set; }
        public StoredProcedure StoredProcedure { get; set; }
        public int Value { get; set; }
        public Version OldVersion { get; set; }
        public Version NewVersion { get; set; }
    }

}
