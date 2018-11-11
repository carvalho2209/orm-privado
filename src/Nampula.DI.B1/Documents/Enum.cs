using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI.B1.BusinessPartners;

namespace Nampula.DI.B1.Documents
{

    /// <summary>
    /// Enum de Tipos de Objetos
    /// </summary>
    public enum eDocumentObjectType
    {
        oNone = 0,
        oInvoices = 13,
        oInvoicesReserve = -13,
        /// <summary>
        /// 
        /// </summary>
        oCreditNotes = 14,
        /// <summary>
        /// sales credit note document. 
        /// </summary
        oDeliveryNotes = 15,
        /// <summary>
        /// sales delivery note document. 
        /// </summary>
        oReturns = 16,
        /// <summary>
        /// sales return document. 
        /// </summary>
        oOrders = 17,
        /// <summary>
        ///  sales order document. 
        /// </summary>
        oPurchaseInvoices = 18,
        /// <summary>
        /// purchase invoice document. (Nota fiscal de entrada)
        /// </summary>
        oPurchaseInvoicesReserve = -18,
        /// <summary>
        /// 
        /// </summary>
        oPurchaseCreditNotes = 19,
        // purchase credit note document. 
        oPurchaseDeliveryNotes = 20,
        // purchase delivery note document. 
        oPurchaseReturns = 21,
        //Documents 'bject that represents a draft of a purchase return document. 
        oPurchaseOrders = 22,
        // purchase order document. 
        oQuotations = 23,
        //Documents 'object that represents a draft of sales quotation document. 
        oInventoryGenEntry = 59,
        //Documents object that is used to enter general items to the inventory. 
        oInventoryGenExit = 60,
        //Documents object that is used to exit general items from inventory. 
        oDrafts = 112,
        //Documents object that represents a draft document (see Creating a draft document sample). 
        oCorrectionPurchaseInvoice = 163,
        //Documents object that represents a draft of purchase invoice correction document. 
        oCorrectionPurchaseInvoiceReversal = 164,
        //Documents object that represents a draft of reverse purchase invoice correction document. 
        oCorrectionARInvoice = 165,
        //Documents object that represents a draft of correction invoice document. 
        oCorrectionInvoiceReversal = 166,
        //Documents object that represents a draft of reverse invoice correction document. 
        oDownPayments = 203,
        //Documents object. 
        oPurchaseDownPayments = 204,
        //Documents object. 
        oCorrectionInvoice = 132,
        //Documents object. 
        oStockUpdate = 58,
        //Documents object. 
        oWorkInstructions = 68,
        //InventoryTransfer
        oInventoryTransfers = 67,
        //InventoryTransfer
        oInventoryRevaluation = 162,
        //InventoryTransfer
        oLandedCosts = 69,
        //Oferta de Compra
        oPurchaseQuotations = 540000006
    }



    /// <summary>
    /// Tipos de Docuemntos de Marketing
    /// </summary>
    public static class DocumentObjectType
    {

        public struct FieldsName
        {
            public static readonly string ObjectCode = "ObjectCode";
            public static readonly string ObjectName = "ObjectName";
            public static readonly string TableNameSuffix = "TableNameSuffix";
        }

        public struct Description
        {
            public static readonly string ObjectCode = "Código";
            public static readonly string ObjectName = "Nome";
            public static readonly string TableNameSuffix = "Sufixo Tabela";
        }

        public static string GetTableNameSufix(this eDocumentObjectType pObjectType)
        {

            string mResult = string.Empty;

            switch (pObjectType)
            {
                case eDocumentObjectType.oInvoices:
                case eDocumentObjectType.oCorrectionInvoice:
                case eDocumentObjectType.oCorrectionInvoiceReversal:
                case eDocumentObjectType.oInvoicesReserve:
                    // OINV 
                    mResult = "INV";

                    break;
                case eDocumentObjectType.oCreditNotes:
                    // ORIN 
                    mResult = "RIN";

                    break;
                case eDocumentObjectType.oDeliveryNotes:
                    // ODLN 
                    mResult = "DLN";

                    break;
                case eDocumentObjectType.oReturns:
                    // ORDN 
                    mResult = "RDN";

                    break;
                case eDocumentObjectType.oOrders:
                    // eDocumentObjectType.RDR 
                    mResult = "RDR";

                    break;
                case eDocumentObjectType.oQuotations:
                    // eDocumentObjectType.QUT 
                    mResult = "QUT";

                    break;
                case eDocumentObjectType.oPurchaseInvoices:
                case eDocumentObjectType.oCorrectionPurchaseInvoice:
                case eDocumentObjectType.oCorrectionPurchaseInvoiceReversal:
                case eDocumentObjectType.oPurchaseInvoicesReserve:
                    // eDocumentObjectType.PCH 
                    mResult = "PCH";

                    break;
                case eDocumentObjectType.oPurchaseCreditNotes:
                    // eDocumentObjectType.RPC 
                    mResult = "RPC";

                    break;
                case eDocumentObjectType.oPurchaseDeliveryNotes:
                    // eDocumentObjectType.PDN 
                    mResult = "PDN";

                    break;
                case eDocumentObjectType.oPurchaseReturns:
                    // eDocumentObjectType.RPD 
                    mResult = "RPD";

                    break;
                case eDocumentObjectType.oPurchaseOrders:
                    // eDocumentObjectType.POR 
                    mResult = "POR";

                    break;
                case eDocumentObjectType.oInventoryGenEntry:
                    // eDocumentObjectType.IGN 
                    mResult = "IGN";

                    break;
                case eDocumentObjectType.oInventoryGenExit:
                    // eDocumentObjectType.IGE 
                    mResult = "IGE";

                    break;
                case eDocumentObjectType.oDrafts:
                    // eDocumentObjectType.DRF 
                    mResult = "DRF";

                    break;
                case eDocumentObjectType.oPurchaseDownPayments:
                    // eDocumentObjectType.DPO 
                    mResult = "DPO";

                    break;
                case eDocumentObjectType.oDownPayments:
                    // eDocumentObjectType.DPI
                    mResult = "DPI";

                    break;
                case eDocumentObjectType.oStockUpdate:
                    mResult = "";
                    break;
                case eDocumentObjectType.oPurchaseQuotations:
                    mResult = "PQT";
                    break;
            }

            return mResult;

        }

        public static string GetTableNameMaster(this eDocumentObjectType pObjectType, string pCompanyDB)
        {
            return "[" + pCompanyDB + "].." + pObjectType.GetTableNameMaster();
        }

        public static string GetTableNameMaster(this eDocumentObjectType pObjectType)
        {
            return "[O" + GetTableNameSufix(pObjectType) + "]";
        }

        public static string GetTableNameLines(this eDocumentObjectType pObjectType, string pCompanyDB)
        {
            return "[" + pCompanyDB + "].." + pObjectType.GetTableNameLines();
        }

        public static string GetTableNameLines(this eDocumentObjectType pObjectType)
        {
            return "[" + GetTableNameSufix(pObjectType) + "1]";
        }

        public static eTransactionType GetDocTransactionType(this eDocumentObjectType pObjectType)
        {

            var transType = eTransactionType.oCopy;

            switch (pObjectType)
            {
                case eDocumentObjectType.oInvoices:
                case eDocumentObjectType.oCorrectionInvoice:
                case eDocumentObjectType.oCorrectionInvoiceReversal:
                case eDocumentObjectType.oInvoicesReserve:
                    transType = eTransactionType.oOut;

                    break;
                case eDocumentObjectType.oCreditNotes:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oDeliveryNotes:
                    transType = eTransactionType.oOut;

                    break;
                case eDocumentObjectType.oReturns:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oOrders:
                    transType = eTransactionType.oOut;

                    break;
                case eDocumentObjectType.oPurchaseInvoices:
                case eDocumentObjectType.oCorrectionPurchaseInvoice:
                case eDocumentObjectType.oCorrectionPurchaseInvoiceReversal:
                case eDocumentObjectType.oPurchaseInvoicesReserve:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oPurchaseCreditNotes:
                    transType = eTransactionType.oOut;

                    break;
                case eDocumentObjectType.oPurchaseDeliveryNotes:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oPurchaseReturns:
                    transType = eTransactionType.oOut;
                    break;

                case eDocumentObjectType.oPurchaseQuotations:
                    transType = eTransactionType.oOut;
                    break;
                case eDocumentObjectType.oPurchaseOrders:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oQuotations:
                    transType = eTransactionType.oOut;

                    break;
                case eDocumentObjectType.oInventoryGenEntry:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oInventoryGenExit:
                    transType = eTransactionType.oIn;

                    break;
                case eDocumentObjectType.oDrafts:
                    transType = eTransactionType.oCopy;

                    break;
                case eDocumentObjectType.oDownPayments:
                    transType = eTransactionType.oOut;

                    break;
                case eDocumentObjectType.oPurchaseDownPayments:
                    transType = eTransactionType.oIn;

                    break;
            }

            return transType;

        }

        public static eCardType GetCardTypeBy(this eDocumentObjectType pObjectType)
        {
            switch (pObjectType)
            {
                case eDocumentObjectType.oInvoices:
                case eDocumentObjectType.oCorrectionInvoice:
                case eDocumentObjectType.oCorrectionInvoiceReversal:
                case eDocumentObjectType.oInvoicesReserve:
                case eDocumentObjectType.oCreditNotes:
                case eDocumentObjectType.oDeliveryNotes:
                case eDocumentObjectType.oReturns:
                case eDocumentObjectType.oOrders:
                case eDocumentObjectType.oQuotations:
                    return eCardType.Customer;

                case eDocumentObjectType.oPurchaseInvoices:
                case eDocumentObjectType.oCorrectionPurchaseInvoice:
                case eDocumentObjectType.oCorrectionPurchaseInvoiceReversal:
                case eDocumentObjectType.oPurchaseInvoicesReserve:
                case eDocumentObjectType.oPurchaseCreditNotes:
                case eDocumentObjectType.oPurchaseDeliveryNotes:
                case eDocumentObjectType.oPurchaseReturns:
                case eDocumentObjectType.oPurchaseOrders:
                case eDocumentObjectType.oPurchaseDownPayments:
                case eDocumentObjectType.oDownPayments:
                case eDocumentObjectType.oPurchaseQuotations:
                    return eCardType.Vendor;

                default:
                    return eCardType.None;
            }

        }

        public static string GetName(this eDocumentObjectType pObjectType)
        {
            string mResult = null;

            switch (pObjectType)
            {
                case eDocumentObjectType.oInvoices:
                    mResult = "Nota Fiscal de Saída";
                    break;
                case eDocumentObjectType.oCorrectionInvoice:
                    mResult = "";
                    break;
                case eDocumentObjectType.oCorrectionInvoiceReversal:
                    mResult = "";
                    break;
                case eDocumentObjectType.oInvoicesReserve:
                    mResult = "Nota Fiscal Saída ( Reserva / Futura )";

                    break;

                case eDocumentObjectType.oCreditNotes:
                    mResult = "Nota Fiscal de Saída ( Devolução )";

                    break;
                case eDocumentObjectType.oDeliveryNotes:
                    mResult = "Entrega de Mercadoria";

                    break;
                case eDocumentObjectType.oReturns:
                    mResult = "Devolução de Entrega de Mercadoria";

                    break;
                case eDocumentObjectType.oOrders:
                    mResult = "Pedido de Venda";

                    break;
                case eDocumentObjectType.oPurchaseInvoices:
                    mResult = "Nota Fiscal de Entrada";
                    break;
                case eDocumentObjectType.oPurchaseInvoicesReserve:
                    mResult = "Nota Fiscal de Entrada ( Reserva / Futura )";
                    break;
                case eDocumentObjectType.oCorrectionPurchaseInvoice:
                    mResult = "";
                    break;
                case eDocumentObjectType.oCorrectionPurchaseInvoiceReversal:
                    mResult = "";

                    break;
                case eDocumentObjectType.oPurchaseCreditNotes:
                    mResult = "Nota Fiscal de Entrada (Devolução)";
                    break;

                case eDocumentObjectType.oPurchaseDeliveryNotes:
                    mResult = "Recebimento de Mercadoria";
                    break;

                case eDocumentObjectType.oPurchaseReturns:
                    mResult = "Devolução de Mercadorias";
                    break;

                case eDocumentObjectType.oPurchaseOrders:
                    mResult = "Pedido de Compra";
                    break;

                case eDocumentObjectType.oPurchaseQuotations:
                    mResult = "Oferta de Compra";
                    break;

                case eDocumentObjectType.oQuotations:
                    mResult = "Cotação";

                    break;
                case eDocumentObjectType.oInventoryGenEntry:
                    mResult = "Entrada de Mercadoria";

                    break;
                case eDocumentObjectType.oInventoryGenExit:
                    mResult = "Saída de Mercadoria";

                    break;
                case eDocumentObjectType.oDrafts:
                    mResult = "Esboço de Documentos";

                    break;
                case eDocumentObjectType.oDownPayments:
                    mResult = "Adiantamento a Cliente";

                    break;
                case eDocumentObjectType.oPurchaseDownPayments:
                    mResult = "Adiantamento para Fornecedor";

                    break;
                default:
                    mResult = "Não selecionado";
                    break;
            }

            return mResult;
        }

        public static bool IsDocumentReserve(eDocumentObjectType pObjectType)
        {
            switch (pObjectType)
            {
                case eDocumentObjectType.oInvoicesReserve:
                case eDocumentObjectType.oPurchaseInvoicesReserve:
                    return true;
                default:
                    return false;
            }
        }

        public static eDocumentObjectType ToDocumentObjectTypeEnum(this int pObjectType)
        {
            return (eDocumentObjectType)pObjectType;
        }

        public static int ToInt32(this eDocumentObjectType pObjectType)
        {
            return Convert.ToInt32(pObjectType);
        }

    }
    
    /// <summary>
    /// Enum de Modelos do Documento
    /// </summary>
    public enum eDocumentModelID
    {
        None = 0,
        Model_1 = 1,
        Model_1_A = 2,
        Model_2 = 3,
        Model_2_A = 4,
        Model_4 = 5,
        Model_6 = 6,
        Model_7 = 7,
        Model_8 = 8,
        Model_10 = 9,
        Model_11 = 10,
        Model_13 = 11,
        Model_14 = 12,
        Model_15 = 13,
        Model_16 = 14,
        Model_17 = 15,
        Model_18 = 16,
        Model_20 = 17,
        Model_21 = 18,
        Model_22 = 19,
        Model_25 = 20,
        Nota_Fiscal_Service = 21,
        NFFS = 22,
        RPA = 23,
        CF = 24,
        NFSS = 25,
        R = 26,
        EXTR = 27,
        FAT = 28,
        Model_1F = 29,
        Model_1AF = 30,
        Model_4F = 31,
        Model_7F = 32,
        Model_9 = 33,
        Model_21F = 34,
        Model_22F = 35,
        Model_24 = 36,
        Outros = 37,
        Nada = 38,
        NFe = 39,
        Mista = 40,
        Saida = 41,
        Model_26 = 42,
        Model_27 = 43,
        Model_CTe = 44,
        Model_57 = 45
    }

    /// <summary>
    /// Modelos de Documento
    /// </summary>
    public static class DocumentModelID
    {

        public static string GetName(this eDocumentModelID pObjectType)
        {
            return pObjectType.ToString();
        }

        public static eDocumentModelID ToDocumentModelIDEnum(this int pObjectType)
        {
            return (eDocumentModelID)pObjectType;
        }

        public static int ToInt32(this eDocumentModelID pObjectType)
        {
            return Convert.ToInt32(pObjectType);
        }

    }



    /// <summary>
    /// Tipo de transação
    /// </summary>
    public enum eTransactionType
    {
        oIn = 0,
        oOut = 1,
        // sales credit note document. 
        oCopy = 3
        // sales credit note document. 
    }

}
