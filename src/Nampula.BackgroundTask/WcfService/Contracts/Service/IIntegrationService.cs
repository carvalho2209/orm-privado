using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Nampula.BackgroundTask.WcfService.Contracts.Data;

namespace Nampula.BackgroundTask.WcfService.Contracts.Service
{
    [ServiceContract]
    public interface IIntegrationService
    {
        [OperationContract]
        void SetConfig(ServerConfig pServerConfig);

        [OperationContract]
        ServerConfig GetConfig();

        [OperationContract]
        void StopAllTasks();

        [OperationContract]
        void ResumeAllTasks();

        [OperationContract]
        bool IsServiceRunning();
    }
}
