using System;

namespace Nampula.DI
{
    /// <summary>
    /// Parametros de conex�o
    /// </summary>
    public class ConnectionParameter
    {

        /// <summary>
        /// Construtor padr�o
        /// </summary>
        public ConnectionParameter()
        {
            Server = string.Empty;
            ServerPort = 0;
            ApplicationName = string.Empty;
            DbServerType = eDataServerType.None;
            Database = "master";
            LicenseServer = String.Empty;
            DBPassword = "timeon";
            DBUser = "ontime";
            Password = string.Empty;
            ConnectionTimeout = 15;
        }



        /// <summary>
        /// Instancia a classe e copia os dados apartir de um objeto
        /// </summary>
        /// <param name="pConnection">Objeto de c�pia</param>
        public ConnectionParameter(ConnectionParameter pConnection)
            : this()
        {

            ApplicationName = pConnection.ApplicationName;
            Database = pConnection.Database;
            DbServerType = pConnection.DbServerType;
            DBUser = pConnection.DBUser;
            DBPassword = pConnection.DBPassword;
            LicenseServer = pConnection.LicenseServer;
            Server = pConnection.Server;
            ServerPort = pConnection.ServerPort;
            CompanyDb = pConnection.CompanyDb;
            UserName = pConnection.UserName;
            Password = pConnection.Password;
            IsHostedEnvironment = pConnection.IsHostedEnvironment;
            ConnectionTimeout = pConnection.ConnectionTimeout;
        }



        /// <summary>
        /// Seridor do banco de dados
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Porta TCP do Servidor
        /// </summary>
        public int ServerPort { get; set; }
        /// <summary>
        /// Servidor de Licen�a
        /// </summary>
        public string LicenseServer { get; set; }
        /// <summary>
        /// Usu�rio do banco de dados
        /// </summary>
        public string DBUser { get; set; }
        /// <summary>
        /// Senha do banco de dados
        /// </summary>
        public string DBPassword { get; set; }
        /// <summary>
        /// Banco de dados
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// Nome da Aplica��o
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// Tipo do Servidor
        /// </summary>
        public eDataServerType DbServerType { get; set; }
        /// <summary>
        /// Banco de dados da Empresa do SAP
        /// </summary>
        public string CompanyDb { get; set; }
        /// <summary>
        /// Usu�rio do SAP
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Senha do usu�rio do SAP
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Identifica se est� rodando dentro de um Hosted Company
        /// </summary>
        public bool IsHostedEnvironment { get; set; }

        const int CONNECTION_TIMEOUT_DEFAULT = 15;

        /// <summary>
        /// Timeout de conex�o
        /// </summary>
        public int ConnectionTimeout { get; set; } = CONNECTION_TIMEOUT_DEFAULT;

        public bool TrustedConnection { get; set; }
    }
}
