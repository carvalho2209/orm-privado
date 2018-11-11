using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents {

    public enum eInstallmentStatus {
        eNone = 0,
        eOpen,
        eClosed
    }

    public static class InstallmentStatus {

        private const string strOpen = "O";
        private const string strClosed = "C";

        public static string GetName ( this eInstallmentStatus pInstallmentStatus ) {
            switch ( pInstallmentStatus ) {
                case eInstallmentStatus.eOpen:
                    return "Aberto";
                case eInstallmentStatus.eClosed:
                    return "Fechado";
                default:
                    return "Nenhum";
            }
        }

        public static string ToEnumString ( this eInstallmentStatus pInstallmentStatus ) {
            switch ( pInstallmentStatus ) {
                case eInstallmentStatus.eOpen:
                    return strOpen;
                case eInstallmentStatus.eClosed:
                    return strClosed;
                default:
                    return String.Empty;
            }
        }

        public static eInstallmentStatus ToEnum ( this string pInstallmentStatus ) {
            switch ( pInstallmentStatus ) {
                case strOpen:
                    return eInstallmentStatus.eOpen;
                case strClosed:
                    return eInstallmentStatus.eClosed;
                default:
                    return eInstallmentStatus.eNone;
            }
        }

    }
}
