using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI {

    public class MenuEventArgs {

        internal MenuEventArgs ( MenuEvent pMenuEvent ) {
            this.BeforeAction = pMenuEvent.BeforeAction;
            this.InnerEvent = pMenuEvent.InnerEvent;
            this.MenuUID = pMenuEvent.MenuUID;
        }
        public bool BeforeAction { get; set; }
        public bool InnerEvent { get; set; }
        public string MenuUID { get; set; }

    }

    public delegate void MenuEventHandler ( object sender, MenuEventArgs e );

}
