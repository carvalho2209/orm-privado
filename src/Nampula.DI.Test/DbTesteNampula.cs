using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nampula.DI.Test
{
    /// <summary>
    /// Gerenciamento do banco de dados e fabrica de classes de todos os objetos envolvidos
    /// </summary>
    public class DbTesteNampula : DataBaseAdapter
    {
        /// <summary>
        /// Construtor da classe que instancia o evento
        /// </summary>
        public DbTesteNampula()
        {
            DataBaseName = "DbTesteNampula";
            Assembly = Assembly.GetExecutingAssembly();
        }

        public new static t CreateObject<t>()
        {
            return new DbTesteNampula().CreateObject<t>(null);
        }

    }
}
