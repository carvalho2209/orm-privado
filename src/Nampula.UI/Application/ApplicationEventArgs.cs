using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{

    public class ApplicationEventArgs : EventArgs
    {
        public bool BubbleEvent { get; set; }
        public BoLanguages BoLanguage { get; set; }
        public BoFormTypes BoFormType { get; set; }
        public int FormCounts { get; set; }
        public MenuEventArgs MenuEvent { get; set; }
        public ItemEventArgs ItemEvent { get; set; }
        public BoAppEventTypes BoAppEventTypes { get; set; }

    }

    public delegate void ApplicationEventHandler ( object sender, ApplicationEventArgs e );

}
