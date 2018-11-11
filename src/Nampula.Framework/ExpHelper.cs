using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.Framework
{
    /// <summary>
    /// Classe de Utilidades sobre exceções
    /// </summary>
    public static class ExpHelper
    {
        /// <summary>
        /// Verifica se um argumento de uma propriedade é nula se for dispara uma exeção
        /// </summary>
        /// <param name="pArgument">Valor do Argumento</param>        
        public static void CheckForArgumentNull<t>(this t pArgument, string pParamName) where t : class
        {
            if (pArgument == null)
                throw new ArgumentNullException(pParamName);
        }
        
    }
}
