using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.SalesTaxCode
{
    /// <summary>
    /// Classe para conversão do tipo TcdTypeEnum
    /// </summary>
    public static class TcdType
    {
        

        /// <summary>
        /// Convert de Enum para String Enumerada
        /// </summary>
        /// <param name="pTcdType">Tipo da Deteminação</param>
        /// <returns>Uma string com o valor do enum no formato de um string</returns>
        public static string ToStrEnum(this TcdTypeEnum pTcdType)
        {
            switch (pTcdType)
            {
                case TcdTypeEnum.ServiceItem:
                    return "SI";
                case TcdTypeEnum.ServiceDocument:
                    return "SD";
                case TcdTypeEnum.WithholdingTax:
                    return "WT";
                case TcdTypeEnum.MaterialItem:
                default:
                    return "MI";

            }
        }
        
    }
}
