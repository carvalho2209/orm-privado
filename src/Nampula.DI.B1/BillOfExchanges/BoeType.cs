using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.BillOfExchanges {

    public enum eBoeType {
        None,
        Incoming,
        Outgoing
    }

    public static class BoeType {

        public const string strIncoming = "I";
        public const string strOutgoing = "O";

        public static string GetName ( this eBoeType CardType ) {
            switch ( CardType ) {
                case eBoeType.Outgoing:
                    return "Transação de Saida";
                case eBoeType.Incoming:
                    return "Transação de Entrada";
                default:
                    return string.Empty;
            }
        }

        public static string ToStringEnum ( this eBoeType pBoeType ) {
            switch ( pBoeType ) {
                case eBoeType.Outgoing:
                    return strOutgoing;
                case eBoeType.Incoming:
                    return strIncoming;
                default:
                    return string.Empty;
            }
        }

        public static eBoeType ToEnum ( this string pBoeType ) {
            switch ( pBoeType ) {
                case strOutgoing:
                    return eBoeType.Outgoing;
                case strIncoming:
                    return eBoeType.Incoming;
                default:
                    return eBoeType.None;
            }
        }

    }

}
