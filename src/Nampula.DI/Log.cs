using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Nampula.DI
{

    /// <summary>
    /// Uma mensagem de texto ou um erro que deseja gerar
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Usuário
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Memsagam
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Exceção
        /// </summary>
        public Exception Exception { get; set; }

    }
}
