using System;

namespace Nampula.DI
{
    /// <summary>
    /// Classe base para tratamento de objeto do banco de dados
    /// </summary>
    [Serializable]
    public class DataObject
    {
        
        /// <summary>
        /// Construtor padr�o
        /// </summary>
        public DataObject()
        {
            Connection = Connection.Instance;
        } 
        
        /// <summary>
        /// Dados de Conex�o com o banco de dados
        /// </summary>
        public Connection Connection { get; set; }
        /// <summary>
        /// Nome do banco de dados
        /// </summary>
        public string DBName { get; set; } 
        
        /// <summary>
        /// Atribui os limites da esquerda e direita no nome de um objeto do banco
        /// </summary>
        /// <param name="pName">Nome</param>
        /// <returns>Uma stringo com as chaves.</returns>
        public string SetQuote(string pName)
        {
            return string.Format("[{0}]", pName);
        } 
        

        
        /// <summary>
        /// Cria o caminho completo da tabela
        /// </summary>
        /// <param name="dbName">Nome do banco de dados</param>
        /// <param name="tableName">Nome da tabela</param>
        /// <returns>Uma string com o nome da tabela</returns>
        public string MakeFullTableName(string dbName, string tableName)
        {
            return String.IsNullOrEmpty(dbName) 
                ? SetQuote(tableName) 
                : string.Format("[{0}]..[{1}]", dbName, tableName);
        }

        /// <summary>
        /// Atribui uma conex�o ao objeto
        /// </summary>
        /// <param name="pConnection">Uma conex�o com o banco de dados</param>
        public void SetConnection(Connection pConnection)
        {
            Connection = pConnection;
        } 

    }
}

