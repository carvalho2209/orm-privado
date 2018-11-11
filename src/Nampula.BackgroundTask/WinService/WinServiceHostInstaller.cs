using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;

namespace Nampula.BackgroundTask.WinService
{
    public class WinServiceHostInstaller : Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        protected WinServiceHostInstaller()
        {

        }

        public WinServiceHostInstaller ( string pServiceName, string pDysplayName, string pDescription )
        {
            process = new ServiceProcessInstaller( );
            process.Account = ServiceAccount.LocalSystem;

            service = new ServiceInstaller( );
            service.Description = pDescription;
            service.ServiceName = pServiceName;
            service.DisplayName = pDysplayName;

            base.Installers.Add( process );
            base.Installers.Add( service );
        }
    }
}
