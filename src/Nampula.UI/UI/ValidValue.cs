using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{
    /// <summary>
    /// Classe elemento de uma coleção de valores para ser usando em um combo
    /// </summary>
    public class ValidValue
    {
        /// <summary>
        /// Instancia o elemento e atribu os valores ao mesmo
        /// </summary>
        /// <param name="pValue">Chave</param>
        /// <param name="pDescription">Descrição</param>
        public ValidValue(object pValue, string pDescription)
        {
            this.Value = pValue;
            this.Description = pDescription;
        }
        /// <summary>
        /// Valor do elemento
        /// </summary>
        public object Value { get; private set; }
        /// <summary>
        /// Descrição do elemento
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Converte para string
        /// </summary>
        /// <returns>UM string com o valor e a descrição</returns>
        public override string ToString()
        {
            return string.Format("[{0}] - [{1}] ", this.Value, this.Description);
        }
    }

}
