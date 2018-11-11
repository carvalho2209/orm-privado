using System;

namespace Nampula.DI
{
    
    /// <summary>
    /// Delegate para eventos de TableAdapters
    /// </summary>
    /// <param name="sender">Objeto que disprou</param>
    /// <param name="e">Argumentos do Evento</param>
    public delegate void TableAdapterEventHandler(Object sender, TableAdapterEventArgs e); 
    
    /// <summary>
    /// Artgumentos do Evento do TableAdapter
    /// </summary>
    public class TableAdapterEventArgs : EventArgs
    {
        public TableAdapterFieldCollection Keys;
        public TableAdapterField Field;
    } 
    
}
