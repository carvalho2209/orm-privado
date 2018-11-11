using System.Reflection;
using Nampula.DI;

namespace NampulaDemo.DI.Factory
{
    /// <summary>
    /// Gerenciamento do banco de dados e fabrica de classes de todos os objetos envolvidos
    /// </summary>
    public class DBTeste : DataBaseAdapter
    {
        /// <summary>
        /// Construtor da classe que instancia o evento
        /// </summary>
        public DBTeste()
        {
            DataBaseName = Properties.Resources.DataBaseName;
            Assembly = Assembly.GetExecutingAssembly();
        }

        public new static t CreateObject<t>()
        {
            return CreateObject<t>(null);
        }

        public new static t CreateObject<t>(Connection pConnection)
        {
            return new DBTeste().CreateBaseObject<t>(pConnection);
        }

        private t CreateBaseObject<t>(Connection pConnection)
        {
            return base.CreateObject<t>(pConnection);
        }
        
    }
}
