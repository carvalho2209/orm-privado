using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.Framework;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Categoria de documentos
    /// </summary>
    public enum WTCategoryEnum
    {
        Payment,
        Invoice
    }

    public static class WTCategory
    {
        public const string payment = "P";
        public const string invoice = "I";

        /// <summary>
        /// Converte para string um enum de categoria do imposto retido na fonte
        /// </summary>
        /// <param name="pCat">Enum da Categoria do imposto</param>
        /// <returns>Um string de enum válido para categoria</returns>
        public static string ToCatString(this WTCategoryEnum pCat)
        {
            return pCat == WTCategoryEnum.Invoice ? invoice : payment;
        }

        /// <summary>
        // Converte uma string para um enum de categoria do imposto retido na fonte
        /// </summary>
        /// <param name="pCat">String válido para o enum</param>
        /// <returns>O Enum correspondente ao valor da categoria</returns>
        public static WTCategoryEnum ToCatEnum(this string pCat)
        {
            pCat.CheckForArgumentNull("pCat");

            switch (pCat)
            {
                case payment:
                    return WTCategoryEnum.Payment;
                case invoice:
                    return WTCategoryEnum.Invoice;
                default:
                    throw new NotSupportedException();
            }
        }
    }

}
