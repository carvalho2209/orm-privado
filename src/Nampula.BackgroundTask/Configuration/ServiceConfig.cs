using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace Nampula.BackgroundTask.Configuration
{
    /// <summary>
    /// Classe para gerenciamento dos dados de conexão com o banco de dados.
    /// </summary>
    public static class ServiceConfig
    {
        #region Variáveis
        public static readonly string configurationSectionName = "ServiceSectionConfig";
        public static readonly string protectionProvider = "RsaProtectedConfigurationProvider";
        private static ServiceSection section;
        #endregion

        #region Construtores
        static ServiceConfig()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration( 
                    Environment.CurrentDirectory  + "\\" + Assembly.GetEntryAssembly().GetName().Name +  ".exe.Config" );
                section = config.GetSection( configurationSectionName ) as ServiceSection;

                // Encripta as configurações
                if ( section != null && !section.IsReadOnly( ) && !section.SectionInformation.IsProtected )
                {
                    section.SectionInformation.ProtectSection( protectionProvider );
                    section.SectionInformation.ForceSave = true;
                    config.Save( ConfigurationSaveMode.Full );

                    ConfigurationManager.RefreshSection( configurationSectionName );
                }
            }
            catch ( Exception ex  )
            {                
                throw ex;
            }
        }
        #endregion

        #region Propriedades

        public static string DBName
        {
            get { return section.ConnectionParam.DBName; }
            set { section.ConnectionParam.DBName = value; }
        }

        public static string DBUser
        {
            get { return section.ConnectionParam.DBUser; }
            set { section.ConnectionParam.DBUser = value; }
        }

        public static string DBPassword
        {
            get { return section.ConnectionParam.DBPassword; }
            set { section.ConnectionParam.DBPassword = value; }
        }

        public static string DBServerName
        {
            get 
            {
                var dbServerName = section.ConnectionParam.Name;

                if (section.ConnectionParam.InstanceName.Length > 0)
                    dbServerName += "\\" + section.ConnectionParam.InstanceName;

                return dbServerName; 
            }
        }

        public static string ServerName
        {
            get { return section.ConnectionParam.Name; }
            set { section.ConnectionParam.Name = value; }
        }

        public static string InstanceName
        {
            get { return section.ConnectionParam.InstanceName; }
            set { section.ConnectionParam.InstanceName = value; }
        }

        public static string LicenseServer
        {
            get { return section.ConnectionParam.LicenseServer; }
            set { section.ConnectionParam.LicenseServer = value; }
        }

        public static string Username
        {
            get { return section.ConnectionParam.Username; }
            set { section.ConnectionParam.Username = value; }
        }

        public static string Password
        {
            get { return section.ConnectionParam.Password; }
            set { section.ConnectionParam.Password = value; }
        }

        public static int DBServerType
        {
            get { return section.ConnectionParam.DBServerType; }
            set { section.ConnectionParam.DBServerType = value; }
        }

        #endregion

        #region Métodos

        #region HasConfiguration
        /// <summary>
        /// Verifica se existe configuração salva.
        /// </summary>
        /// <returns>True, caso exista. Caso contráio, False.</returns>
        public static bool HasConfiguration()
        {
            return section != null;
        }
        #endregion

        #region Save
        /// <summary>
        /// Salva no disco as configurações.
        /// </summary>
        public static void Save()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            section.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            ConfigurationManager.RefreshSection(configurationSectionName);
        }
        #endregion

        #endregion
    }
}
