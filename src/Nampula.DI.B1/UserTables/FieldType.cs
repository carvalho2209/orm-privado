using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.Framework;

namespace Nampula.DI.B1.UserTables
{
    public static class FieldType
    {
        const string alphaEnum = "A";
        const string memoEnum = "M";
        const string numericEnum = "N";
        const string dateEnum = "D";
        const string floatEnum = "B";

        /// <summary>
        /// Converto o enum tipo de campos uma string enum
        /// </summary>
        /// <param name="pEnum">Valor do enum</param>
        /// <returns>string do enum referente ao valor passado</returns>
        public static string ToStrEnum(this FieldTypeEnum pEnum)
        {
            switch (pEnum)
            {
                case FieldTypeEnum.Memo:
                    return memoEnum;
                case FieldTypeEnum.Numeric:
                    return numericEnum;
                case FieldTypeEnum.Date:
                    return dateEnum;
                case FieldTypeEnum.Float:
                    return floatEnum;
                default:
                    return alphaEnum;
            }
        }

        /// <summary>
        /// Converte uma string enum em um valor de enum
        /// </summary>
        /// <param name="pEnum">Sring de Enum</param>
        /// <returns>Um enum</returns>
        public static FieldTypeEnum ToFldTypeEnum(this string pEnum)
        {
            switch (pEnum)
            {
                case memoEnum:
                    return FieldTypeEnum.Memo;
                case numericEnum:
                    return FieldTypeEnum.Numeric;
                case dateEnum:
                    return FieldTypeEnum.Date;
                case floatEnum:
                    return FieldTypeEnum.Float;
                case alphaEnum:
                    return FieldTypeEnum.Alpha;
                default:
                    throw new NotSupportedException(string.Format(
                        "Valor não encontrado no enum {0}", pEnum));
            }
        }
    }
}
