using System;
using System.Data;

namespace Nampula.UI.Helpers
{
    /// <summary>
    /// Evento que representa uma seleção
    /// </summary>
    /// <param name="sender">Objeto que disparou</param>
    /// <param name="e">Argumentos do Evento</param>
    public delegate void ChooseFromListHandler ( object sender, ChooseFromListEventArgs e );

    /// <summary>
    /// Argumentos do Evento da Lista
    /// </summary>
    public class ChooseFromListEventArgs : EventArgs
    {
        /// <summary>
        /// Lista de Registros Selecionados
        /// </summary>
        public DataRow[] Records { get; set; }
        
        /// <summary>
        /// Registro Selecionado
        /// </summary>
        public DataRow Record { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public object SearchBy { get; set; }

        /// <summary>
        /// Indica se foi cancelado
        /// </summary>
        public bool Cancel { get; set; }
    }
}
