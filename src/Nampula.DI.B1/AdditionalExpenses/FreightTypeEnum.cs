using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.Framework;

namespace Nampula.DI.B1.AdditionalExpenses
{
    /// <summary>
    /// Tipo de despesas adicional do frete.
    /// </summary>
    public enum ExpensesFreightTypeEnum
    {
        None = 0,
        Shipping = 1,
        Insurance = 2,
        Other = 3,
        Special = 4
    }

    /// <summary>
    /// Tipo de despesas adicional do frete.
    /// </summary>
    public static class ExpensesFreightType
    {

        
        /// <summary>
        /// Convery a string para um enum
        /// </summary>
        /// <param name="pEnum">String Enum de tipo de frete</param>
        /// <returns>O Valor do Enum ExpensesFreightTypeEnum</returns>
        public static ExpensesFreightTypeEnum ToFreightEnum(this string pEnum)
        {
            return (ExpensesFreightTypeEnum)Enum.Parse(typeof(ExpensesFreightTypeEnum), pEnum);
        }
        

        
        /// <summary>
        /// Convery a string para um enum
        /// </summary>
        /// <param name="pEnum">Enum de tipo de frete</param>
        /// <returns>O Valor do Enum ExpensesFreightTypeEnum</returns>
        public static string ToFreightString(this ExpensesFreightTypeEnum pEnum)
        {
            return pEnum.To<int>().ToString();
        }
        

    }
}
