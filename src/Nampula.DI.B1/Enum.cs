using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1
{

    /// <summary>
    /// Tipos de parceiros de negócios
    /// </summary>
    public enum eYesNo
    {
        None,
        Yes,
        No
    }

    /// <summary>
    /// Conversão de tipos de tabelas de negócios
    /// </summary>
    public static class YesNoClass
    {

        private const string strYes = "Y";
        private const string strNo = "N";

        public static string GetYesNoName(this eYesNo pYesNo)
        {
            switch (pYesNo)
            {
                case eYesNo.Yes:
                    return "Sim";
                case eYesNo.No:
                    return "Não";
                default:
                    return string.Empty;
            }
        }

        public static string ToYesNoString(this eYesNo pYesNo)
        {
            switch (pYesNo)
            {
                case eYesNo.Yes:
                    return strYes;
                case eYesNo.No:
                    return strNo;
                default:
                    return string.Empty;
            }
        }

        public static string ToYesNoString(bool pYesNo)
        {
            switch (pYesNo)
            {
                case true:
                    return strYes;
                case false:
                    return strNo;
                default:
                    return string.Empty;
            }
        }

        public static eYesNo ToYesNoEnum(this string pYesNo)
        {
            switch (pYesNo)
            {
                case strYes:
                    return eYesNo.Yes;
                case strNo:
                    return eYesNo.No;
                default:
                    return eYesNo.None;
            }
        }

        public static eYesNo ToYesNoEnum(bool pYesNo)
        {
            switch (pYesNo)
            {
                case true:
                    return eYesNo.Yes;
                case false:
                    return eYesNo.No;
                default:
                    return eYesNo.None;
            }
        }

        public static bool IsYes(this string pSboYesNoString)
        {
            CheckValidateYesNo(pSboYesNoString);
            return pSboYesNoString == "Y";
        }

        public static bool IsNo(this string pSboYesNoString)
        {
            CheckValidateYesNo(pSboYesNoString);
            return pSboYesNoString == "N";
        }

        private static void CheckValidateYesNo(string pSboYesNoString)
        {
            if (string.IsNullOrWhiteSpace(pSboYesNoString))
                throw new Exception("String do Booleana do SAP inválida (Nula ou Vazia)");

            if (pSboYesNoString.Length == 1)
                throw new Exception("String do Booleana do SAP inválida (Tamanho diferente de 1)");

            if (!pSboYesNoString.Any(c => c == 'Y' | c == 'N'))
                throw new Exception("String do Booleana do SAP inválida (Deve conter somente 'Y' ou 'N')");
        }
    }

    public enum eDBServerType
    {
        SqlServer2005 = 4,
        SqlServer2008 = 6,
        SqlServer2012 = 7
    }

    public static class DBServerTypeClass
    {

        public static string GetDbServerTypeName(this eDBServerType eDBServerType)
        {

            switch (eDBServerType)
            {
                case eDBServerType.SqlServer2005:
                    return "MS Sql Server 2005";
                case eDBServerType.SqlServer2008:
                    return "MS Sql Server 2008";
                case eDBServerType.SqlServer2012:
                    return "MS Sql Server 2012";
                default:
                    return "";
            }

        }

        public static eDBServerType ToDBServerTypeEnum(this int pDBServerType)
        {
            return (eDBServerType)pDBServerType;
        }

        public static string ToDBServerTypeString(this eDBServerType pDBServerType)
        {
            return pDBServerType.ToDBServerTypeInt().ToString(CultureInfo.InvariantCulture);
        }

        public static int ToDBServerTypeInt(this eDBServerType pDBServerType)
        {
            return Convert.ToInt32(pDBServerType);
        }

    }




}
