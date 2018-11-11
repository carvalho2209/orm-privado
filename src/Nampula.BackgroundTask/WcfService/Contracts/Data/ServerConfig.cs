using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Nampula.BackgroundTask.WcfService.Contracts.Data
{
    [DataContract]
    public class ServerConfig
    {
        [DataMember]
        public string DBName { get; set; }
        [DataMember]
        public string DBUser { get; set; }
        [DataMember]
        public string DBPassword { get; set; }
        [DataMember]
        public string ServerName { get; set; }
        [DataMember]
        public string InstanceName { get; set; }
        [DataMember]
        public string LicenseServer { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int DBServerType { get; set; }
    }
}
