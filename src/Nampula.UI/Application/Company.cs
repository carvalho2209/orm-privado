using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;

namespace Nampula.UI
{

    public class Company
    {
        public int CurrentPeriod { get; set; }
        public string DatabaseName { get; set; }
        public string InstallationId { get; set; }
        public string Localization { get; set; }
        public string Name { get; set; }
        public string ServerDate { get; set; }
        public string ServerName { get; set; }
        public string ServerTime { get; set; }
        public string SystemId { get; set; }
        public string UserName { get; set; }
    }

}
