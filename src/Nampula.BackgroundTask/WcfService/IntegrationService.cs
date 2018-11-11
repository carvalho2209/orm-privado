using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Nampula.BackgroundTask.WcfService.Contracts.Data;
using Nampula.BackgroundTask.TaskService;
using Nampula.BackgroundTask.WcfService.Contracts.Service;

namespace Nampula.BackgroundTask.WcfService
{
    [ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
    public class IntegrationService : IIntegrationService
    {
        public void SetConfig ( ServerConfig pServerConfig )
        {
            ServiceConfig.DBName = pServerConfig.DBName;
            ServiceConfig.DBUser = pServerConfig.DBUser;
            ServiceConfig.DBPassword = pServerConfig.DBPassword;
            ServiceConfig.ServerName = pServerConfig.ServerName;
            ServiceConfig.InstanceName = pServerConfig.InstanceName;
            ServiceConfig.LicenseServer = pServerConfig.LicenseServer;
            ServiceConfig.Username = pServerConfig.Username;
            ServiceConfig.Password = pServerConfig.Password;
            ServiceConfig.DBServerType = pServerConfig.DBServerType;
            ServiceConfig.Save( );
        }

        public ServerConfig GetConfig ( )
        {
            ServerConfig serverConfig = new ServerConfig( );

            if ( ServiceConfig.HasConfiguration( ) )
            {
                serverConfig.DBName = ServiceConfig.DBName;
                serverConfig.DBUser = ServiceConfig.DBUser;
                serverConfig.DBPassword = ServiceConfig.DBPassword;
                serverConfig.ServerName = ServiceConfig.ServerName;
                serverConfig.InstanceName = ServiceConfig.InstanceName;
                serverConfig.LicenseServer = ServiceConfig.LicenseServer;
                serverConfig.Username = ServiceConfig.Username;
                serverConfig.Password = ServiceConfig.Password;
                serverConfig.DBServerType = ServiceConfig.DBServerType;
            }

            return serverConfig;
        }

        public void StopAllTasks ( )
        {
            TaskManager.Instance.Stop( );
        }

        public void ResumeAllTasks ( )
        {
            TaskManager.Instance.Start( );
        }

        public bool IsServiceRunning ( )
        {
            return TaskManager.Instance.IsServiceRunning;
        }
    }
}
