using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Documents {
    /// <summary>
    /// Tipos de parceiros de negócios
    /// </summary>
    public enum eDocStatus {
        None,
        Open,
        Closed
    }

    /// <summary>
    /// Conversão de tipos de tabelas de negócios
    /// </summary>
    public static class DocStatus {

        private const string strOpen = "O";
        private const string strClosed = "C";

        public static string GetDocStatusName ( this eDocStatus pDocStatus ) {
            switch ( pDocStatus ) {
                case eDocStatus.Open:
                    return "Em Aberto";
                case eDocStatus.Closed:
                    return "Fechado";
                default:
                    return string.Empty;
            }
        }

        public static string ToDocStatusString ( this eDocStatus pDocStatus ) {
            switch ( pDocStatus ) {
                case eDocStatus.Open:
                    return strOpen;
                case eDocStatus.Closed:
                    return strClosed;
                default:
                    return string.Empty;
            }
        }

        public static eDocStatus ToDocStatusEnum ( this string pDocStatus ) {
            switch ( pDocStatus ) {
                case strOpen:
                    return eDocStatus.Open;
                case strClosed:
                    return eDocStatus.Closed;
                default:
                    return eDocStatus.None;
            }
        }

    }
}
