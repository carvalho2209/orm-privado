using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{

    /// <summary>
    /// Atributo usado para marcar um método para receber um evento do SAP
    /// </summary>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public class FormSystemEventAttribute : System.Attribute
    {

        public FormSystemEventAttribute ( )
        {
            this.EventType = BoEventTypes.et_ALL_EVENTS;
            this.ItemID = string.Empty;
            this.BeforeAction = false;
        }

        public BoEventTypes EventType { get; set; }
        public string ItemID { get; set; }
        public Boolean BeforeAction { get; set; }
    }

}
