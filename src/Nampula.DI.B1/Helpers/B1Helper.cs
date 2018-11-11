using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.DI.B1.BillOfExchanges;
using Nampula.DI.B1.Itens;
using Nampula.DI.B1.BusinessPartners;
using Nampula.DI.B1.Administrations;
using Nampula.DI.B1.PaymentMethods;
using Nampula.DI.B1.PaymentTerms;
using Nampula.DI.B1.PriceLists;
using Nampula.DI.B1.Warehouses;
using Nampula.DI.B1.BatchNumbers;
using Nampula.Framework;
using Nampula.DI.B1.Employees;
using Nampula.DI.B1.Users;
using Nampula.DI.B1.MeasuresUnits;
using Nampula.DI.B1.ChartOfAccounts;
using Nampula.DI.B1.Documents;
using Nampula.DI.B1.Counties;
using Nampula.DI.B1.Territories;
using Nampula.DI.B1.UserTables;
using Nampula.DI.B1.Countries;
using Nampula.DI.B1.Usages;
using Nampula.DI.B1.WithholdingTaxes;

namespace Nampula.DI.B1.Helpers
{
    /// <summary>
    /// Classe estática para facilitar criação de objetos através das chaves
    /// </summary>
    public static class B1Helper
    {


        /// <summary>
        /// Constantes para exibir textos nas mensagens
        /// segue a seguinte lógica [Nome do Objeto] : [Chave do chamada]
        /// </summary>
        private static readonly string DontFindText1Key = "Não encontrado {0} com o código [{1}]";
        private static readonly string DontFindText2Key = "Não encontrado {0} com o código [{1}], [{2}] : [{3}]";
        private static readonly string DontFindText3Key = "Não encontrado {0} com o código [{1}], [{2}] : [{3}], [{4}] : [{5}]";

        private static readonly string ItemObjectName = "Item";
        private static readonly string ItemPriceListObjectName = "Preço do Item";
        private static readonly string ItemWarehouseObjectName = "Depósito do Item";
        private static readonly string BusinessPartnerObjectName = "Parceiro de Negócios";
        private static readonly string BusinessPartnerAddressObjectName = "Endereço do Parceiro de Negócios";
        private static readonly string BusinessPartnerFiescalIDObjectName = "ID Fiscal do Parceiro de Negócios";
        private static readonly string AdministrationObjectName = "Administração";
        private static readonly string PaymentTermObjectName = "Condições de Pgto";
        private static readonly string PriceListObjectName = "Lista de Preço";
        private static readonly string WarehouseObjectName = "Depósitos";
        private static readonly string BatchNumberObjectName = "Lote";
        private static readonly string EmployeeObjectName = "Empregado";
        private static readonly string UserObjectName = "Usuário";
        private static readonly string LengthMeasureName = "Unidade de Medida";
        private static readonly string ChartOfAccountName = "Conta Contábil";


        /// <summary>
        /// Pega um item pelo código
        /// </summary>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static Item GetItem(string pItemCode, string pCompanyDb)
        {
            pItemCode.CheckForArgumentNull("pItemCode");
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var item = new Item(pCompanyDb);

            if (!item.GetByKey(pItemCode))
                throw new Exception(
                    string.Format(DontFindText1Key, ItemObjectName, pItemCode));

            return item;
        }

        /// <summary>
        /// Pega um item pelo código
        /// </summary>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pPriceList">Lista de Preço</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static ItemPrice GetItemPrice(string pItemCode, int pPriceList, string pCompanyDb)
        {
            pItemCode.CheckForArgumentNull("pItemCode");
            //pPriceList.CheckForArgumentNull( "pPriceList" );
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var item = new ItemPrice(pCompanyDb);

            if (!item.GetByKey(pItemCode, pPriceList))
                throw new Exception(
                    string.Format(DontFindText2Key, ItemPriceListObjectName, pPriceList, ItemObjectName, pItemCode));

            return item;
        }

        /// <summary>
        /// Pega um item pelo código
        /// </summary>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pWhsCode">Código do Deposito</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>UmWarehouse item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static ItemWareHouse GetItemWarehouse(string pItemCode, string pWhsCode, string pCompanyDb)
        {
            pItemCode.CheckForArgumentNull("pItemCode");
            pWhsCode.CheckForArgumentNull("pWhsCode");
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var item = new ItemWareHouse(pCompanyDb);
            if (!item.GetByKey(pItemCode, pWhsCode))
                throw new Exception(
                    string.Format(DontFindText2Key, ItemWarehouseObjectName, pWhsCode, ItemObjectName, pItemCode));

            return item;
        }




        /// <summary>
        /// Pega um parceiro de negócio pelo código
        /// </summary>
        /// <param name="pCardCode">Código do Cliente</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static BusinessPartner GetBusinessPartner(string pCardCode, string pCompanyDb)
        {
            pCardCode.CheckForArgumentNull("pCardCode");
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new BusinessPartner(pCompanyDb);
            if (!bp.GetByKey(pCardCode))
                throw new Exception(
                    string.Format(DontFindText1Key, BusinessPartnerObjectName, pCardCode));

            return bp;
        }

        /// <summary>
        /// Pega um parceiro de negócio pelo código
        /// </summary>
        /// <param name="pCardCode">Código do Item</param>
        /// <param name="pName">Nome do Contato</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static BusinessPartnerContact GetContactByName(string pCardCode, string pName, string pCompanyDb)
        {
            pCardCode.CheckForArgumentNull("pCardCode");
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new BusinessPartnerContact(pCompanyDb);
            var query = new TableQuery(bp);

            query.Where.Add(new QueryParam(bp.Collumns[BusinessPartnerContact.FieldsName.CardCode], pCardCode));
            query.Where.Add(new QueryParam(bp.Collumns[BusinessPartnerContact.FieldsName.Name], pName));

            var contact = bp.FillCollection<BusinessPartnerContact>(query).SingleOrDefault();

            if (contact == null)
                throw new Exception(string.Format(DontFindText2Key, "Contato", pCardCode, pName));

            return contact;
        }

        /// <summary>
        /// Pega um parceiro de negócio pelo código
        /// </summary>
        /// <param name="pCode">Código do Contato</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static BusinessPartnerContact GetContact(int pCode, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new BusinessPartnerContact(pCompanyDb);

            if (!bp.GetByKey(pCode))
                throw new Exception(string.Format(DontFindText1Key, "Contato", pCode));

            return bp;
        }

        /// <summary>
        /// Pega um endereço do parceiro de negócio pelo código
        /// </summary>
        /// <param name="pCardCode">Código do Parceiro</param>
        /// <param name="pAddressName">Nome do Endereço</param>
        /// <param name="pAddressType">Tipo do Endrereço</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um endereço preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado por qualquer parametros</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static BusinessPartnerAddress GetBusinessPartnerAddress(string pCardCode, string pAddressName, eAdresType pAddressType, string pCompanyDb)
        {
            pCardCode.CheckForArgumentNull("pCardCode");
            pAddressName.CheckForArgumentNull("pAddressName");
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new BusinessPartnerAddress(pCompanyDb);

            if (!bp.GetByKey(pCardCode, pAddressName, pAddressType))
                throw new Exception(
                    DontFindText3Key.Fmt(
                        BusinessPartnerAddressObjectName, pAddressName,
                        BusinessPartnerObjectName, pCardCode,
                        "Tipo de Endereço",
                        pAddressType.ToString()));

            return bp;
        }



        /// <summary>
        /// Pega todos os endereço de um parceiro pelo tipo
        /// </summary>
        /// <param name="pCardCode">Código do Parceiro</param>
        /// <param name="pAdresType">Endereço</param>
        /// <param name="pCompanyDb">Banco de Dados de Empresa</param>
        /// <returns></returns>
        public static List<BusinessPartnerAddress> GetBusinessPartnerAddress(string pCardCode, eAdresType pAdresType, string pCompanyDb)
        {
            var bp = new BusinessPartnerAddress(pCompanyDb);

            var query = new TableQuery(bp);

            query.Where.Add(
                new QueryParam(bp.Collumns[BusinessPartnerAddress.FieldsName.CardCode], pCardCode));

            query.Where.Add(
                new QueryParam(
                    bp.Collumns[BusinessPartnerAddress.FieldsName.AdresType],
                    AdresTypeClass.ToString(pAdresType)));

            return bp.FillCollection<BusinessPartnerAddress>(query);

        }



        /// <summary>
        /// Pega um endereço do parceiro de negócio pelo código
        /// </summary>
        /// <param name="pCardCode">Código do Parceiro</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um endereço preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado por qualquer parametros</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static BusinessPartnerFiscalID GetBusinessPartnerFiscalId(string pCardCode, string pCompanyDb)
        {
            pCardCode.CheckForArgumentNull("pCardCode");

            var bp = new BusinessPartnerFiscalID(pCompanyDb);

            if (!bp.GetByKey(pCardCode, String.Empty, eAdresType.Shipto))
                throw new Exception(
                    DontFindText1Key.Fmt(BusinessPartnerFiescalIDObjectName, pCardCode));

            return bp;
        }



        /// <summary>
        /// Pega um objeto Administration
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static Administration GetAdministration(string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new Administration(pCompanyDb);

            if (!bp.GetByKey())
                throw new Exception(
                    string.Format(DontFindText1Key, AdministrationObjectName, "1"));

            return bp;
        }

        public static List<BussinessPartnerPaymentMethod> GetBusinessPartnerPayMethod(string pCardCode, string pCompanyDb)
        {
            var payMethod = new BussinessPartnerPaymentMethod(pCompanyDb);
            var query = new TableQuery(payMethod);

            query.Where.Add(new QueryParam(
                payMethod.Collumns[BussinessPartnerPaymentMethod.FieldsName.CardCode], pCardCode));

            return payMethod.FillCollection<BussinessPartnerPaymentMethod>(query);
        }

        /// <summary>
        /// Pega um objeto Administration Extention
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static AdministrationExtension GetAdministrationExtension(string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new AdministrationExtension(pCompanyDb);
            if (!bp.GetByKey())
                throw new Exception(
                    string.Format(DontFindText1Key, AdministrationObjectName, "1"));

            return bp;
        }



        /// <summary>
        /// Pega um código CNAE através do Id Interno
        /// </summary>
        /// <param name="pAbsId">Id Interno</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static CNAE GetCnaeCode(int pAbsId, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new CNAE(pCompanyDb);

            if (!bp.GetByKey(pAbsId))
                throw new Exception(
                    string.Format(DontFindText1Key, "", "1"));

            return bp;
        }



        /// <summary>
        /// Pega uma Condição de Pagamento
        /// </summary>
        /// <param name="pGroupNum">Código do Grupo</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Uma forma preenchida</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static PaymentTerm GetPaymentTerm(Int32 pGroupNum, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new PaymentTerm(pCompanyDb);

            if (!bp.GetByKey(pGroupNum))
                throw new Exception(
                    string.Format(DontFindText1Key, PaymentTermObjectName, pGroupNum));

            return bp;
        }

        public static List<PaymentTermsLine> GetPaymentTermLines(Int32 pGroupNum, string companyDb)
        {
            companyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new PaymentTermsLine(companyDb);
            var query = new TableQuery(bp);

            query.Where.Add(new QueryParam(bp.Collumns[PaymentTermsLine.FieldsName.CTGCode], pGroupNum));

            query.OrderBy.Add(new OrderBy(new QueryParam(bp.Collumns[PaymentTermsLine.FieldsName.IntsNo])));

            return bp.FillCollection<PaymentTermsLine>(query);
        }

        /// <summary>
        /// Pega uma Forma de Pagamento
        /// </summary>
        /// <param name="pPayMethodCode">Código do Grupo</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Uma forma preenchida</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static PaymentMethod GetPayMethod(string pPayMethodCode, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");
            pPayMethodCode.CheckForArgumentNull("pPayMethodCode");

            var bp = new PaymentMethod(pCompanyDb);

            if (!bp.GetByKey(pPayMethodCode))
                throw new Exception(
                    string.Format(DontFindText1Key, "Meio de Pagamento", pPayMethodCode));

            return bp;
        }

        /// <summary>
        /// Pega uma lista de preço pelo código
        /// </summary>
        /// <param name="pPriceList">Código do Lista de Preço</param>
        /// <param name="companyDb">Banco de Dados</param>
        /// <returns>Uma lista de preço preenchida</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static PriceList GetPriceList(short pPriceList, string companyDb)
        {
            companyDb.CheckForArgumentNull("pCompanyDb");

            var bp = new PriceList(companyDb);

            if (!bp.GetByKey(pPriceList))
                throw new Exception(
                    string.Format(DontFindText1Key, PriceListObjectName, pPriceList));

            return bp;
        }



        /// <summary>
        /// Pega um depósito
        /// </summary>
        /// <param name="pWhsCode">Código do Depósito</param>
        /// <param name="companyDb">Banco de Dados</param>
        /// <returns>um depósito preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com parametro</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static Warehouse GetWarehouse(string pWhsCode, string companyDb)
        {
            companyDb.CheckForArgumentNull("pCompanyDb");
            pWhsCode.CheckForArgumentNull("pWhsCode");

            var bp = new Warehouse(companyDb);

            if (!bp.GetByKey(pWhsCode))
                throw new Exception(
                    string.Format(DontFindText1Key, WarehouseObjectName, pWhsCode));

            return bp;
        }


        public static WithholdingTax GetWitholdingTax(string pWtCode, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");
            pWtCode.CheckForArgumentNull("pWtCode");

            var wtTax = new WithholdingTax(pCompanyDb) { WTCode = pWtCode };

            if (!wtTax.GetByKey())
                throw new Exception(
                    string.Format(DontFindText1Key, "Imposto Retido na Fonte", pWtCode));

            return wtTax;
        }

        /// <summary>
        /// Pega um território pelo código
        /// </summary>
        /// <param name="pTerritoryId">Código do Território</param>
        /// <param name="companyDb">Banco de Dados</param>
        /// <returns>um território preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com parametro</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static Territory GetTerritory(int pTerritoryId, string companyDb)
        {
            companyDb.CheckForArgumentNull("pCompanyDb");

            var territory = new Territory(companyDb);

            if (!territory.GetByKey(pTerritoryId))
                throw new Exception(DontFindText1Key.Fmt("Território", pTerritoryId));

            return territory;
        }



        /// <summary>
        /// Pega uma linha de um documenot
        /// </summary>
        /// <param name="docType">Tipo de Objeto</param>
        /// <param name="pDocEntry">Código do Documento</param>
        /// <param name="pLineNum">Linha do Documento</param>
        /// <param name="pCompanyDB">Banco de Dados</param>
        /// <returns>um território preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com parametro</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static Line GetLine(eDocumentObjectType docType, int pDocEntry, int pLineNum, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            var line = new Line(pCompanyDB, docType);

            if (!line.GetByKey(pDocEntry, pLineNum))
                throw new Exception((
                    DontFindText2Key.Fmt(
                        "Linha do {0}".Fmt(docType.GetName()),
                        pDocEntry, "Linha", pLineNum)));

            return line;
        }



        /// <summary>
        /// Pega uma conta contábil do plano de contas
        /// </summary>
        /// <param name="pWhsCode">Código do Conta</param>
        /// <param name="pCompanyDB">Banco de Dados</param>
        /// <returns>uma conta contábil preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com parametro</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static ChartOfAccount GetAccount(string pAccountCode, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");
            pAccountCode.CheckForArgumentNull("pAccountCode");

            ChartOfAccount bp = new ChartOfAccount(pCompanyDB);
            if (!bp.GetByKey(pAccountCode))
                throw new Exception(
                    string.Format(DontFindText1Key, ChartOfAccountName, pAccountCode));

            return bp;
        }



        /// <summary>
        /// Pega um lote
        /// </summary>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pWhsCode">Código do Depósito</param>
        /// <param name="pBatchNumber">Código do Lote</param>
        /// <param name="pCompanyDB">Empresa</param>
        /// <returns></returns>
        public static BatchNumber GetBatchNumber(string pItemCode, string pWhsCode, string pBatchNumber, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");
            pWhsCode.CheckForArgumentNull("pWhsCode");
            pItemCode.CheckForArgumentNull("pItemCode");
            pBatchNumber.CheckForArgumentNull("pItemCode");

            BatchNumber batch = new BatchNumber(pCompanyDB);
            if (!batch.GetByKey(pItemCode, pWhsCode, pBatchNumber))
                throw new Exception(
                    string.Format(
                    DontFindText3Key, BatchNumberObjectName, pBatchNumber,
                    ItemObjectName, pItemCode,
                    WarehouseObjectName, pWhsCode));

            return batch;
        }



        /// <summary>
        /// Pega um empregado pelo código
        /// </summary>
        /// <param name="pEmpID">Código do Empregado</param>
        /// <param name="pCompanyDB">Banco da Empresa</param>
        /// <returns></returns>
        public static Employee GetEmployee(Int32 pEmpID, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            Employee empl = new Employee(pCompanyDB);
            if (!empl.GetByKey(pEmpID))
                throw new Exception(
                    string.Format(
                    DontFindText1Key, EmployeeObjectName, pEmpID));

            return empl;
        }



        /// <summary>
        /// Pega um usuário pelo código 
        /// </summary>
        /// <param name="pUserCode">Código do Usuário</param>
        /// <param name="pCompanyDb">Banco da Empresa</param>
        /// <returns></returns>
        public static User GetUser(string pUserCode, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");
            pUserCode.CheckForArgumentNull("pUserCode");

            var user = new User(pCompanyDb);

            if (!user.GetByKey(pUserCode))
                throw new Exception(string.Format(DontFindText1Key, UserObjectName, pUserCode));

            return user;
        }

        /// <summary>
        /// Pega um usuário pelo código 
        /// </summary>
        /// <param name="pInternalK">Código do Usuário</param>
        /// <param name="pCompanyDb">Banco da Empresa</param>
        /// <returns></returns>
        public static User GetUser(int pInternalK, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var user = new User(pCompanyDb);

            if (!user.GetByKey(pInternalK))
                throw new Exception(string.Format(DontFindText1Key, UserObjectName, pInternalK));

            return user;
        }

        /// <summary>
        /// Pega o municipio
        /// </summary>
        /// <param name="pCode">Código do Municipo</param>
        /// <param name="pCompanyDB">Banco da Empresa</param>
        /// <returns></returns>
        public static County GetCounty(int pCode, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            var empl = new County(pCompanyDB);
            if (!empl.GetByKey(pCode))
                throw new Exception(
                    string.Format(
                    DontFindText1Key, "Municipio", pCode));

            return empl;
        }



        /// <summary>
        /// Pega uma unidade de medida pelo código
        /// </summary>
        /// <param name="pMeasureID">Código da unidade</param>
        /// <param name="pCompanyDB">Banco da Empresa</param>
        /// <returns></returns>
        public static LengthUnit GetLengthMeasure(Int16 pMeasureID, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            LengthUnit lenght = new LengthUnit(pCompanyDB);
            if (!lenght.GetByKey(pMeasureID))
                throw new Exception(
                    string.Format(
                    DontFindText1Key, LengthMeasureName, pMeasureID));

            return lenght;
        }



        /// <summary>
        /// Pega um documento de marketing
        /// </summary>
        /// <param name="pDocEntry">Código do Docuemnto</param>
        /// <param name="pDocType">Tipo do Documento</param>
        /// <param name="pCompanyDB">Empresa</param>
        /// <returns>Um documento de marketing</returns>
        public static Document GetDocument(Int32 pDocEntry, eDocumentObjectType pDocType, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            var doc = new Document(pCompanyDB, pDocType);

            if (doc.GetByKey(pDocEntry))
                return doc;

            var message = string.Format(DontFindText1Key, pDocType.GetName(), pDocEntry);
            throw new Exception(message);
        }


        /// <summary>
        /// Pega os lotes de uma linha do documento
        /// </summary>
        /// <param name="pCompanyb">Nome do Banco de Dados</param>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pWhsCode">Depósito</param>
        /// <param name="pDocEntry">Número do Documento</param>
        /// <param name="pLineNum">Linha do docuemnto</param>
        /// <param name="pDocType">Tipo do Documento</param>
        /// <param name="ignoreStock">Ignorar movimento de estoque</param>
        /// <returns>Retorna uma lista de documentos</returns>
        public static List<BatchNumberTrans> GetBatchNumbers(
            string pCompanyb,
            string pItemCode,
            string pWhsCode,
            int pDocEntry,
            int pLineNum,
            eDocumentObjectType pDocType,
            bool ignoreStock = false)
        {

            var query = @"
                SELECT		
                        MIN(b.LogEntry)		as LogEntry,
		                MIN(b.ItemCode)		as [ItemCode],
		                MIN(c.DistNumber)	as [BatchNum],
		                MIN(b.LocCode)		as [WhsCode],
		                MIN(b.ItemName)		as [ItemName],
		                MIN(b.ApplyType)	as [BaseType],      
		                MIN(b.ApplyEntry)	as [BaseEntry],
		                MIN(b.AppDocNum)	as [BaseNum],
		                MIN(b.ApplyLine)	as [BaseLinNum],
		                MIN(b.DocDate)		as [DocDate],
		                (								 
			                CASE WHEN ABS(SUM(a.Quantity)) = 0 THEN SUM(a.AllocQty)
			                ELSE ABS(SUM(a.Quantity)) END
		                )					as [Quantity],
		                MIN(b.CardCode)		as [CardCode],
		                MIN(b.CardName)		as [CardName],
		                (
			                CASE WHEN  SUM(a.Quantity) > 0 THEN 0
			                WHEN SUM(a.Quantity) < 0 THEN 1
			                ELSE 2 END
		                )					as [Direction],
		                MIN(b.CreateDate)	as [CreateDate],
		                MIN(b.BaseType)		as [BsDocType],
		                MIN(b.BaseEntry)	as [BsDocEntry],
		                MIN(b.BaseLine)		as [BsDocLine],
		                'N'				as [DataSource],
		                NULL				as [UserSign]
                FROM		[{0}]..ITL1 a
                INNER JOIN	[{0}]..OITL b ON a.LogEntry = b.LogEntry
                INNER JOIN	[{0}]..OBTN c ON a.ItemCode = c.ItemCode and a.SysNumber = c.SysNumber
                Where b.ApplyEntry = {1} And b.ApplyType = {2} And b.ApplyLine = {3} And b.ItemCode = '{4}' And b.LocCode = '{5}'
                  {6} -- Selecionar somente transacao que baixa do estoque, eliminando no caso, o pedido de venda
                GROUP BY	b.ItemCode, a.SysNumber, b.ApplyType, b.ApplyEntry, b.ApplyLine, b.LocCode, b.StockEff
                having		(SUM(b.DocQty) <> 0)		-- To exclude those document lines with batch numbers that have been totally deallocated.
                OR			(SUM(b.DefinedQty) <> 0)	-- For the case: batch is on release only and use complete operation to define batch.
                OR			(SUM(b.DocQty) = 0 and b.StockEff = 2 
                and		min(b.BaseType) <> 17 and min(b.BaseType) <> 13 ) -- for the case DLN/INV based on sales order with allocated batch.";

            query = String.Format(query, pCompanyb, pDocEntry, pDocType.To<int>(), pLineNum, pItemCode, pWhsCode,
                ignoreStock ? "" : "And b.StockEff = 1");

            var data = Connection.Instance.SqlServerQuery(query);

            var batches = new List<BatchNumberTrans>();

            foreach (DataRow dataRow in data.Rows)
            {
                var batch = new BatchNumberTrans(pCompanyb);

                batch.FillFields(dataRow, true);

                batches.Add(batch);
            }

            return batches;
        }



        /// <summary>
        /// Pega um NCM pelo código interno
        /// </summary>
        /// <param name="pNCMCode">Código do NCM</param>
        /// <param name="pCompanyDB">Banco de Dados</param>
        /// <returns>um NCMCode preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com parametro</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static NCMCode GetNCMCode(int pAbsEntry, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            var list = B1Helper.GetAll<NCMCode>(pCompanyDB,
                new KeyValuePair<string, object>(NCMCode.FieldsName.AbsEntry, pAbsEntry));

            if (list.IsEmpty())
                throw new Exception(DontFindText1Key.Fmt( "NCMCode", pAbsEntry));

            return list.Single();
        }


        /// <summary>
        /// Pega todos os registros da tabela onde o campo Fieldname for igual ao ID passado
        /// </summary>
        /// <typeparam name="TT">Objeto Table Adapter</typeparam>
        /// <param name="pCompanyDb">Empresa do banco de dados</param>
        /// <param name="pValues">Nomes dos Campos</param>
        /// <returns>Lista de </returns>
        /// <t>Table Adapter Object</t>
        public static List<TT> GetAll<TT>(string pCompanyDb, params KeyValuePair<string, Object>[] pValues) where TT : TableAdapter, new()
        {
            var obj = new TT { DBName = pCompanyDb };
            var query = new TableQuery(obj);

            foreach (var item in pValues)
            {
                query.Where.Add(new QueryParam(
                       obj.Collumns[item.Key], item.Value));
            }

            return obj.FillCollection<TT>(query);
        }




        /// <summary>
        /// Pega os dados do campo de usuário 
        /// </summary>
        /// <param name="pTableName">Nome da tabela</param>
        /// <param name="pUserField">Nome do campo</param>
        /// <param name="pCompanyDb">Nome da Empresa</param>
        /// '<exception cref="Exception">Não encontrado o registro</exception>
        /// <returns>Um campo de usuário</returns>        
        public static UserField GetUserField(string pTableName, string pUserField, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");
            pTableName.CheckForArgumentNull("pTableName");
            pUserField.CheckForArgumentNull("pUserField");

            var userField = new UserField(pCompanyDb);
            var query = new TableQuery(userField);

            query.Where.Add(new QueryParam(userField.Collumns[UserField.FieldsName.TableID], pTableName));
            query.Where.Add(new QueryParam(userField.Collumns[UserField.FieldsName.AliasID], pUserField));

            var field = userField.FillCollection<UserField>(query).FirstOrDefault();

            if (field == null)
                throw new Exception(
                    "Não encontrado campo de usuário na empresa [{0}] com o código [{1}-{2}]"
                    .Fmt(pCompanyDb, pTableName, pUserField));

            return field;
        }



        /// <summary>
        /// Pega os dados do código do CFOP
        /// </summary>
        /// <param name="pCfopCode">Código do CFOP</param>
        /// <param name="pCompanyDb">Nome da Empresa</param>
        /// '<exception cref="Exception">Não encontrado o registro</exception>
        /// <returns>Um Nota Fiscal CFOP</returns>        
        public static NotaFiscalCFOP GetCFOP(string pCfopCode, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");
            pCfopCode.CheckForArgumentNull("pCfopCode");

            var nfCfop = new NotaFiscalCFOP(pCompanyDb);

            if (!nfCfop.GetByKey(pCfopCode))
                throw new Exception("Não encontrado na empresa [{0}] com o código [{1}]"
                    .Fmt(pCompanyDb, pCfopCode));

            return nfCfop;
        }



        /// <summary>
        /// Pega o pais
        /// </summary>
        /// <param name="pCode">Código do Pais</param>
        /// <param name="pCompanyDB">Banco da Empresa</param>
        /// <returns></returns>
        public static Country GetCountry(string pCode, string pCompanyDB)
        {
            pCode.CheckForArgumentNull("pCode");
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            var empl = new Country(pCompanyDB);

            if (!empl.GetByKey(pCode))
                throw new Exception(DontFindText1Key.Fmt("País", pCode));

            return empl;
        }



        /// <summary>
        /// Pega a utilização
        /// </summary>
        /// <param name="pUsageid">Código do Pais</param>
        /// <param name="pCompanyDB">Banco da Empresa</param>
        /// <returns></returns>
        public static Usage GetUsage(int pUsageid, string pCompanyDB)
        {
            pCompanyDB.CheckForArgumentNull("pCompanyDb");

            var empl = new Usage(pCompanyDB);

            if (!empl.GetByKey(pUsageid))
                throw new Exception(DontFindText1Key.Fmt("utilização", pUsageid));

            return empl;
        }


        /// <summary>
        /// Pega um boleto no SAP
        /// </summary>
        /// <param name="pBoeKey">Código do Boleto</param>
        /// <param name="pCompanyDb">Banco de Dados</param>
        /// <returns>Um item preenchido</returns>
        /// <exception cref="ArgumentNullException">Null passado com código</exception>
        /// <exception cref="Exception">Não encontro o registro</exception>
        public static BillOfExchange GetBoe(int pBoeKey, string pCompanyDb)
        {
            var boe = new BillOfExchange(pCompanyDb);
            if (!boe.GetByKey(pBoeKey))
                throw new Exception(
                    string.Format(DontFindText1Key, "Boleto", pBoeKey));

            return boe;
        }


        /// <summary>
        /// Pega um registro através do ID se Não encotrar gera uma exceção
        /// </summary>
        /// <typeparam name="TT">Um table adapter</typeparam>
        /// <param name="companyDb">Banco de Dados da empresa</param>
        /// <param name="key">Valor da CHAVE</param>
        /// <param name="pObjDescription">Nome do Ojeto: Explo: Parceiro de Negócios, Cliente, </param>        
        /// <returns>Objeto T</returns>
        /// <exception cref="Exception">Não encontrado objeto</exception>
        public static TT GetByKey<TT>(string companyDb, object key, string pObjDescription = null) where TT : TableAdapter, new()
        {
            var pTable = new TT { DBName = companyDb };

            if (pTable.KeyFields.Count > 1)
                throw new Exception("O Objeto {0} deve ter somente uma chave.".Fmt(pObjDescription));

            pTable.KeyFields.First().Value = key;

            var registry = pTable.GetByKey();

            if (!registry && !string.IsNullOrEmpty(pObjDescription))
                throw new Exception("Não encontrado [{0}] com o código [{1}]".Fmt(pObjDescription, key));

            if (!registry && string.IsNullOrEmpty(pObjDescription))
                return null;

            return pTable;
        }
    }
}
