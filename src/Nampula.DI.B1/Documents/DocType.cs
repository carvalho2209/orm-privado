using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents
{

    public enum eDocType
    {
        eNone,
        eItem,
        eService
    }

    public static class DocType
    {

        private const string strItem = "I";
        private const string strService = "S";

        public static eDocType ToDocTypeEnum(this string pDocType)
        {
            switch (pDocType)
            {
                case strItem:
                    return eDocType.eItem;
                case strService:
                    return eDocType.eService;
                default:
                    return eDocType.eNone;
            }
        }

        public static string ToDocTypeString(this eDocType pDocType)
        {
            switch (pDocType)
            {
                case eDocType.eItem:
                    return strItem;
                case eDocType.eService:
                    return strService;
                default:
                    return "";
            }
        }
    }

}
