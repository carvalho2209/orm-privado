using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents
{
    public enum eRefType
    {
        None,
        SystemDocument,
        ExternalDocument
    }

    public static class DocumentReferenceTypes
    {
        private const string strSystemDoc = "S";
        private const string strExternalDoc = "E";

        public static string ToRefTypeString(this eRefType pRefType)
        {
            switch (pRefType)
            {
                case eRefType.SystemDocument:
                    return strSystemDoc;
                case eRefType.ExternalDocument:
                    return strExternalDoc;
                default:
                    return string.Empty;
            }
        }

        public static eRefType ToRefTypeEnum(this string pRefType)
        {
            switch (pRefType)
            {
                case strSystemDoc:
                    return eRefType.SystemDocument;
                case strExternalDoc:
                    return eRefType.ExternalDocument;
                default:
                    return eRefType.None;
            }
        }
    }
}
