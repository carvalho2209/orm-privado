using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Nampula.Framework;

namespace Nampula.BackgroundTask.Configuration
{
    public class ServiceSection : ConfigurationSection
    {
        #region Variáveis
        private const string connectionParam = "ConnectionParam";
        #endregion

        #region Server
        /// <summary>
        /// Gets or sets the ConnectionParam element.
        /// </summary>
        [ConfigurationProperty(connectionParam, IsRequired = true)]
        public ConnectionParamElement ConnectionParam
        {
            get
            {
                return this[connectionParam] as ConnectionParamElement;
            }
            set { this[connectionParam] = value; }
        }
        #endregion
    }

    public class ConnectionParamElement : ConfigurationElement
    {
        #region Variáveis
        private const string dbName = "dbName";
        private const string dbUser = "dbUser";
        private const string dbPassword = "dbPassword";
        private const string name = "serverName";
        private const string instance = "instanceName";
        private const string licenseServer = "licenseServer";
        private const string username = "username";
        private const string password = "password";
        private const string dbServerType = "dbServerType";
        #endregion

        #region DBName
        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        [ConfigurationProperty(dbName, IsRequired = true)]
        public string DBName
        {
            get
            {
                return this[dbName] as string;
            }
            set { this[dbName] = value; }
        }
        #endregion

        #region DBUser
        /// <summary>
        /// Gets or sets the database user name.
        /// </summary>
        [ConfigurationProperty(dbUser, DefaultValue = "ontime", IsRequired = false)]
        public string DBUser
        {
            get
            {
                return this[dbUser] as string;
            }
            set { this[dbUser] = value; }
        }
        #endregion

        #region DBPassword
        /// <summary>
        /// Gets or sets the database user password.
        /// </summary>
        [ConfigurationProperty(dbPassword, DefaultValue = "timeon", IsRequired = false)]
        public string DBPassword
        {
            get
            {
                return this[dbPassword] as string;
            }
            set { this[dbPassword] = value; }
        }
        #endregion

        #region Name
        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        [ConfigurationProperty(name, DefaultValue = "localhost", IsRequired = false)]
        public string Name
        {
            get
            {
                return this[name] as string;
            }
            set { this[name] = value; }
        }
        #endregion

        #region InstanceName
        /// <summary>
        /// Gets or sets the server name.
        /// </summary>
        [ConfigurationProperty(instance, DefaultValue = "sqlexpress", IsRequired = false)]
        public string InstanceName
        {
            get
            {
                return this[instance] as string;
            }
            set { this[instance] = value; }
        }
        #endregion

        #region LicenseServer
        /// <summary>
        /// Gets or sets the license server.
        /// </summary>
        [ConfigurationProperty(licenseServer, DefaultValue = "localhost:30000", IsRequired = false)]
        public string LicenseServer
        {
            get
            {
                return this[licenseServer] as string;
            }
            set { this[licenseServer] = value; }
        }
        #endregion

        #region Username
        /// <summary>
        /// Gets or sets the sbo user name.
        /// </summary>
        [ConfigurationProperty(username, DefaultValue = "manager", IsRequired = false)]
        public string Username
        {
            get
            {
                return this[username] as string;
            }
            set { this[username] = value; }
        }
        #endregion

        #region Password
        /// <summary>
        /// Gets or sets the sbo user password.
        /// </summary>
        [ConfigurationProperty(password, DefaultValue = "manager", IsRequired = false)]
        public string Password
        {
            get
            {
                return this[password] as string;
            }
            set { this[password] = value; }
        }
        #endregion

        #region DBServerType
        /// <summary>
        /// Gets or sets the database server type.
        /// </summary>
        [ConfigurationProperty(dbServerType, DefaultValue = "6", IsRequired = false)]
        public int DBServerType
        {
            get
            {
                return this[dbServerType].To<int>();
            }
            set { this[dbServerType] = value; }
        }
        #endregion
    }
}
