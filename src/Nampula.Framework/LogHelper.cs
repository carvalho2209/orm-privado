using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.Framework
{
    /// <summary>
    /// Classe para ativação de logging em aplicações
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Habilita o log4net na aplicação
        /// </summary>
        /// <param name="pFielName">Nome do arquivo</param>
        public static void EnableLog ( string pFielName )
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(
                new System.IO.FileInfo( pFielName ) );
        }

        /// <summary>
        /// Hablita o log4net na aplicação através do arquivo padrão Log4net.config
        /// </summary>
        public static void EnableLog ( )
        {
            EnableLog( "Log4net.config" );
        }
    }
}
