using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.Framework
{
    public static class ValidationExtention
    {
        /// <summary>
        /// Dispara uma exceção caso o valor não for um percentual válido
        /// </summary>
        /// <param name="pValue">Novo Valor</param>
        public static void ThowExceptionIfNotPercentValue(this decimal pValue)
        {
            if (pValue < Decimal.Zero | pValue > 100)
                throw new NotValidPercentException();
        }

        /// <summary>
        /// Dispara uma excceção caso o valor não for maior que zero
        /// </summary>
        /// <param name="pValue">Um valor qualquer</param>
        public static void ThowExceptionIfLessOrEqualZero(this decimal pValue)
        {
            if (pValue <= Decimal.Zero)
                throw new LessOrEqualZeroException();
        }
    }
}
