using System;

namespace Nampula.DI
{
    /// <summary>
    /// Delegate para evento de alteração de estado do table adapter
    /// </summary>
    /// <param name="sender">Objeto que disprou</param>
    /// <param name="e">Argumentos do Evento</param>
    public delegate void ChangeStateEventHandler(Object sender, ChangeStateEventArgs e);
    
    /// <summary>
    /// Artgumentos do Evento de Alteração de Statado
    /// </summary>
    public class ChangeStateEventArgs : EventArgs
    {
        public eState StateOld { get; set; }
        public eState StateNew { get; set; }
    } 
}
