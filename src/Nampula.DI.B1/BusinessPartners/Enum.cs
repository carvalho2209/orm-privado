using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.BusinessPartners
{

    /// <summary>
    /// Tipos de parceiros de negócios
    /// </summary>
    public enum eCardType
    {
        None,
        Customer,
        Vendor,
        Lead
    }

    /// <summary>
    /// Conversão de tipos de tabelas de negócios
    /// </summary>
    public static class CardTypeClass
    {

        private const string strCustomer = "C";
        private const string strVendor = "S";
        private const string strLead = "L";

        public static string GetName(this eCardType CardType)
        {
            switch (CardType)
            {
                case eCardType.Customer:
                    return "Cliente";
                case eCardType.Vendor:
                    return "Fornecedor";
                case eCardType.Lead:
                    return "Lead";
                default:
                    return string.Empty;
            }
        }

        public static string ToStringEnum(this eCardType CardType)
        {
            switch (CardType)
            {
                case eCardType.Customer:
                    return strCustomer;
                case eCardType.Vendor:
                    return strVendor;
                case eCardType.Lead:
                    return strLead;
                default:
                    return string.Empty;
            }
        }

        public static eCardType ToEnum(this string CardType)
        {
            switch (CardType)
            {
                case strCustomer:
                    return eCardType.Customer;
                case strVendor:
                    return eCardType.Vendor;
                case strLead:
                    return eCardType.Lead;
                default:
                    return eCardType.None;
            }
        }

    }


    /// <summary>
    /// Tipos de endereços parceiros de negócios
    /// </summary>
    public enum eAdresType
    {
        None,
        Shipto,
        Billto
    }

    /// <summary>
    /// Conversão de tipos de tabelas de negócios
    /// </summary>
    public class AdresTypeClass
    {

        private const string strShipTo = "S";
        private const string strBillTo = "B";

        public static string GetName(eAdresType AdresType)
        {
            switch (AdresType)
            {
                case eAdresType.Shipto:
                    return "Destinatário";
                case eAdresType.Billto:
                    return "Pagar a";
                default:
                    return string.Empty;
            }
        }

        public static string ToString(eAdresType AdresType)
        {
            switch (AdresType)
            {
                case eAdresType.Shipto:
                    return strShipTo;
                case eAdresType.Billto:
                    return strBillTo;
                default:
                    return string.Empty;
            }
        }

        public static eAdresType ToEnum(string AdresType)
        {
            switch (AdresType)
            {
                case strShipTo:
                    return eAdresType.Shipto;
                case strBillTo:
                    return eAdresType.Billto;
                default:
                    return eAdresType.None;
            }
        }        
    }

}
