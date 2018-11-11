using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.PaymentMethods {

    public enum ePayType { 
        eNone,
        eOutgoing,
        eIncoming
    }

    public static class PayType {

        private  const string strOutgoing = "O";
        private const string strIncoming = "I";

        public static string GetName ( this ePayType pPayType ) {
            switch ( pPayType ) {
                case ePayType.eOutgoing:
                    return "Transação de Compra";
                case ePayType.eIncoming:
                    return "Transação de Venda";
                default:
                    return string.Empty;
            }
        }

        public static string ToPayTypeString ( this ePayType pPayType ) {
            switch ( pPayType ) {
                case ePayType.eOutgoing:
                    return strOutgoing;
                case ePayType.eIncoming:
                    return strIncoming;
                default:
                    return string.Empty;
            }
        }

        public static ePayType ToPayTypeEnum ( this string pPayType ) {
            switch ( pPayType ) {
                case strOutgoing:
                    return ePayType.eOutgoing;
                case strIncoming:
                    return ePayType.eIncoming;
                default:
                    return ePayType.eNone;
            }
        }

    }


    public enum eBankTransf {
        eNone,
        eCheck,
        eBankTransfer,
        eBillOfExchange,
    }

    public static class BankTransf {

        private const  string strCheck = "C";
        private const string strBankTransfer = "T";
        private const string strBillOfExchange = "B";

        public static string GetName ( this eBankTransf pBankTransf ) {
            switch ( pBankTransf ) {
                case eBankTransf.eCheck:
                    return "Cheque";
                case eBankTransf.eBankTransfer:
                    return "Transferência Bancária";
                case eBankTransf.eBillOfExchange :
                    return "Boleto";
                default:
                    return string.Empty;
            }
        }

        public static string ToBankTransfString ( this eBankTransf pBankTransf ) {
            switch ( pBankTransf ) {
                case eBankTransf.eBankTransfer:
                    return strCheck;
                case eBankTransf.eBillOfExchange:
                    return strBillOfExchange;
                case eBankTransf.eCheck:
                    return strCheck;
                default:
                    return string.Empty;
            }
        }

        public static eBankTransf ToBankTransfEnum ( this string pBankTransf ) {
            switch ( pBankTransf ) {
                case strBankTransfer:
                    return eBankTransf.eBankTransfer;
                case strCheck:
                    return eBankTransf.eCheck;
                case strBillOfExchange:
                    return eBankTransf.eBillOfExchange;
                default:
                    return eBankTransf.eNone;
            }
        }

    }

}
