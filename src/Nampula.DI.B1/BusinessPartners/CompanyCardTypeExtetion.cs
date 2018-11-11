using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.BusinessPartners
{
    public static class CompanyCardTypeExtetion
    {
        public static string ToCmpPrivateString(this CompanyCardTypeEnum pCompanyCardTypeEnum)
        {
            switch (pCompanyCardTypeEnum)
            {
                case CompanyCardTypeEnum.Company:
                    return "C";
                case CompanyCardTypeEnum.Private:
                    return "I";
                default:
                    throw new InvalidCastException("String não é um enum de Tipo de Pessoa, valore válidos são [C,I]");
            }
        }

        public static CompanyCardTypeEnum ToCmpPrivateEnum(this string pCompanyCardTypeEnum)
        {
            switch (pCompanyCardTypeEnum)
            {
                case "C":
                    return CompanyCardTypeEnum.Company;
                case "I":
                    return CompanyCardTypeEnum.Private;
                default:
                    throw new InvalidCastException("String não é um enum de Tipo de Pessoa, valore válidos são [C,I]");
            }
        }
    }

    public enum CompanyCardTypeEnum
    {
        Company = 0,
        Private = 1
    }
}
