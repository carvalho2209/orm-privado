using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.DI.B1.Version;

namespace Nampula.DI.B1.Documents
{
    /// <summary>
    /// Documento de markenting do SAP (OPRQ, OPOR, ORPD, ODPO, ORPC, ORDR, OPCH, ORIN...)
    /// </summary>
    public class Document : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string Handwrtten = "Handwrtten";
            public static readonly string DocNum = "DocNum";
            public static readonly string DocStatus = "DocStatus";
            public static readonly string DocType = "DocType";
            public static readonly string CANCELED = "CANCELED";
            public static readonly string Printed = "Printed";
            public static readonly string ObjType = "ObjType";

            public static readonly string DocDate = "DocDate";
            public static readonly string DocTime = "DocTime";
            public static readonly string ReqDate = "ReqDate";
            public static readonly string TaxDate = "TaxDate";
            public static readonly string DocDueDate = "DocDueDate";
            public static readonly string Confirmed = "Confirmed";
            public static readonly string CancelDate = "CancelDate";
            public static readonly string Reserve = "Reserve";

            public static readonly string CardCode = "CardCode";
            public static readonly string CardName = "CardName";

            public static readonly string ShipToCode = "ShipToCode";
            public static readonly string PayToCode = "PayToCode";
            public static readonly string NumAtCard = "NumAtCard";

            public static readonly string SlpCode = "SlpCode";
            public static readonly string Indicator = "Indicator";

            public static readonly string GroupNum = "GroupNum";
            public static readonly string PeyMethod = "PeyMethod";
            public static readonly string Project = "Project";
            public static readonly string AgentCode = "AgentCode";
            public static readonly string Installmnt = "Installmnt";

            public static readonly string Header = "Header";
            public static readonly string Footer = "Footer";
            public static readonly string OwnerCode = "OwnerCode";
            public static readonly string SeqCode = "SeqCode";
            public static readonly string Serial = "Serial";
            public static readonly string SeriesStr = "SeriesStr";
            public static readonly string SubStr = "SubStr";
            public static readonly string Model = "Model";

            public static readonly string Comments = "Comments";

            public static readonly string TotalExpns = "TotalExpns";
            public static readonly string DiscPrcnt = "DiscPrcnt";
            public static readonly string DiscSum = "DiscSum";
            public static readonly string Rounding = "Rounding";
            public static readonly string PaidToDate = "PaidToDate";
            public static readonly string DocTotal = "DocTotal";
            public static readonly string DocTotalFC = "DocTotalFC";
            public static readonly string DocTotalSy = "DocTotalSy";

            // Adiantamento            
            public static readonly string PaidSum = "PaidSum";
            public static readonly string DpmAppl = "DpmAppl";
            public static readonly string CntctCode = "CntctCode";
            public static readonly string PartSupply = "PartSupply";
            public static readonly string CurSource = "CurSource";
            public static readonly string DocCur = "DocCur";
            public static readonly string DocRate = "DocRate";
            public static readonly string TrnspCode = "TrnspCode";
            public static readonly string ImportEnt = "ImportEnt";
            public static readonly string JrnlMemo = "JrnlMemo";
            public static readonly string BPLId = "BPLId";

            public static readonly string isIns = "isIns";
            public static readonly string WeightUnit = "WeightUnit";
        }

        public struct Description
        {

            public static readonly string DocEntry = "Número";
            public static readonly string DocNum = "Número Manual";
            public static readonly string Handwrtten = "N° Manual";
            public static readonly string DocStatus = "Status";
            public static readonly string DocType = "Tipo";
            public static readonly string CANCELED = "Cancelado";
            public static readonly string Printed = "Impresso";
            public static readonly string ObjType = "Tipo de Documento";

            public static readonly string DocDate = "Data do Documento";
            public static readonly string DocTime = "Hora do Documento";
            public static readonly string ReqDate = "Data Necessária";
            public static readonly string TaxDate = "Data do Lançamento";
            public static readonly string DocDueDate = "Data de Vencimento";
            public static readonly string Confirmed = "Confirmado";
            public static readonly string CancelDate = "Data de Cancelamento";
            public static readonly string Reserve = "Reserva";

            public static readonly string CardCode = "Código";
            public static readonly string CardName = "Nome";

            public static readonly string ShipToCode = "Destinatário";
            public static readonly string PayToCode = "Cobrança";
            public static readonly string NumAtCard = "Numero do Cliente";

            public static readonly string SlpCode = "Vendedor";
            public static readonly string OwnerCode = "Titular";
            public static readonly string Indicator = "Indicador";

            public static readonly string GroupNum = "Condições de Pgto";
            public static readonly string PeyMethod = "Forma de Pagamento";
            public static readonly string Project = "Projeto";
            public static readonly string AgentCode = "Representante";
            public static readonly string Installmnt = "Installmnt";

            public static readonly string Header = "Comentários Iniciais";
            public static readonly string Footer = "Obs. de Nota Fiscal";
            public static readonly string SeqCode = "Sequência do Documento";
            public static readonly string Serial = "Serial do Documento";
            public static readonly string SeriesStr = "Serie";
            public static readonly string SubStr = "Sub Serie";
            public static readonly string Model = "Modelo";

            public static readonly string Comments = "Observações";

            public static readonly string TotalExpns = "Despesas Adicionais";
            public static readonly string DiscPrcnt = "% Desconto";
            public static readonly string DiscSum = "Total do Desconto";
            public static readonly string Rounding = "Arredondamento";
            public static readonly string PaidToDate = "Pago até a data";
            public static readonly string DocTotal = "Total do Documento";
            public static readonly string DocTotalFC = "Total do Documento (FC)";
            public static readonly string DocTotalSy = "Total do Documento (SC)";

            // Adiantamento
            public static readonly string PaidSum = "Total pago";
            public static readonly string DpmAppl = "Adiantamento aplicado";
            public static readonly string CntctCode = "Contato";
            public static readonly string PartSupply = "Entrega Parcial";
            public static readonly string CurSource = "Moeda Corrente";
            public static readonly string DocCur = "Moeda";
            public static readonly string DocRate = "Taxa moeda";
            public static readonly string TrnspCode = "Tipo de Envio";
            public static readonly string ImportEnt = "Nº do Pedido";
            public static readonly string JrnlMemo = "Observação do Diário";
            public static readonly string BPLId = "Filial";
            public static readonly string isIns = "Entrega Futura";
            public static readonly string WeightUnit = "Unidade de Peso";
        }

        readonly TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, Description.DocEntry, DbType.Int32, 11, null, true, false);
        readonly TableAdapterField m_DocNum = new TableAdapterField(FieldsName.DocNum, Description.DocNum, DbType.Int32);
        readonly TableAdapterField m_Handwrtten = new TableAdapterField(FieldsName.Handwrtten, Description.Handwrtten, 1);

        readonly TableAdapterField m_DocStatus = new TableAdapterField(FieldsName.DocStatus, Description.DocStatus, 1);
        readonly TableAdapterField m_DocType = new TableAdapterField(FieldsName.DocType, Description.DocType, 1);
        readonly TableAdapterField m_CANCELED = new TableAdapterField(FieldsName.CANCELED, Description.CANCELED, 1);
        readonly TableAdapterField m_Printed = new TableAdapterField(FieldsName.Printed, Description.Printed, 1);
        readonly TableAdapterField m_ObjType = new TableAdapterField(FieldsName.ObjType, Description.ObjType, DbType.Int32);
        readonly TableAdapterField m_CurSource = new TableAdapterField(FieldsName.CurSource, Description.CurSource, 1);
        readonly TableAdapterField m_DocCur = new TableAdapterField(FieldsName.DocCur, Description.DocCur, 3);
        readonly TableAdapterField m_DocRate = new TableAdapterField(FieldsName.DocRate, Description.DocRate, DbType.Decimal, 19, 6);

        readonly TableAdapterField m_DocDate = new TableAdapterField(FieldsName.DocDate, Description.DocDate, DbType.DateTime);
        readonly TableAdapterField m_DocTime = new TableAdapterField(FieldsName.DocTime, Description.DocTime, DbType.Int32);
        readonly TableAdapterField m_ReqDate = new TableAdapterField(FieldsName.ReqDate, Description.ReqDate, DbType.DateTime);
        readonly TableAdapterField m_TaxDate = new TableAdapterField(FieldsName.TaxDate, Description.TaxDate, DbType.DateTime);
        readonly TableAdapterField m_DocDueDate = new TableAdapterField(FieldsName.DocDueDate, Description.DocDueDate, DbType.DateTime);
        readonly TableAdapterField m_Confirmed = new TableAdapterField(FieldsName.Confirmed, Description.Confirmed, 1);
        readonly TableAdapterField m_CancelDate = new TableAdapterField(FieldsName.CancelDate, Description.CancelDate, DbType.DateTime);
        readonly TableAdapterField m_Reserve = new TableAdapterField(FieldsName.Reserve, Description.Reserve, 1);

        readonly TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, Description.CardCode, 15);
        readonly TableAdapterField m_CardName = new TableAdapterField(FieldsName.CardName, Description.CardName, 200);

        readonly TableAdapterField m_ShipToCode = new TableAdapterField(FieldsName.ShipToCode, Description.ShipToCode, 50);
        readonly TableAdapterField m_PayToCode = new TableAdapterField(FieldsName.PayToCode, Description.PayToCode, 50);
        readonly TableAdapterField m_NumAtCard = new TableAdapterField(FieldsName.NumAtCard, Description.NumAtCard, 100);

        readonly TableAdapterField m_PeyMethod = new TableAdapterField(FieldsName.PeyMethod, Description.PeyMethod, 15);
        readonly TableAdapterField m_Installmnt = new TableAdapterField(FieldsName.Installmnt, Description.Installmnt, DbType.Int32);

        readonly TableAdapterField m_SlpCode = new TableAdapterField(FieldsName.SlpCode, Description.SlpCode, DbType.Int16);
        readonly TableAdapterField m_Indicator = new TableAdapterField(FieldsName.Indicator, Description.Indicator, 2);
        readonly TableAdapterField m_GroupNum = new TableAdapterField(FieldsName.GroupNum, Description.GroupNum, DbType.Int32);

        readonly TableAdapterField m_Model = new TableAdapterField(FieldsName.Model, Description.Model, DbType.Int32);
        readonly TableAdapterField m_Serial = new TableAdapterField(FieldsName.Serial, Description.Serial, DbType.Int32);
        readonly TableAdapterField m_SeriesStr = new TableAdapterField(FieldsName.SeriesStr, Description.SeriesStr, 10);
        readonly TableAdapterField m_SubStr = new TableAdapterField(FieldsName.SubStr, Description.SubStr, 10);


        readonly TableAdapterField m_TotalExpns = new TableAdapterField(FieldsName.TotalExpns, Description.TotalExpns, DbType.Decimal);
        readonly TableAdapterField m_DiscPrcnt = new TableAdapterField(FieldsName.DiscPrcnt, Description.DiscPrcnt, DbType.Decimal);
        readonly TableAdapterField m_DiscSum = new TableAdapterField(FieldsName.DiscSum, Description.DiscSum, DbType.Decimal);
        readonly TableAdapterField m_Rounding = new TableAdapterField(FieldsName.Rounding, Description.Rounding, 1);
        readonly TableAdapterField m_PaidToDate = new TableAdapterField(FieldsName.PaidToDate, Description.PaidToDate, DbType.Decimal);
        readonly TableAdapterField m_DocTotal = new TableAdapterField(FieldsName.DocTotal, Description.DocTotal, DbType.Decimal);

        readonly TableAdapterField m_OwnerCode = new TableAdapterField(FieldsName.OwnerCode, Description.OwnerCode, DbType.Int32);
        readonly TableAdapterField m_Comments = new TableAdapterField(FieldsName.Comments, Description.Comments, 254);
        readonly TableAdapterField m_PaidSum = new TableAdapterField(FieldsName.PaidSum, Description.PaidSum, DbType.Decimal);
        readonly TableAdapterField m_DpmAppl = new TableAdapterField(FieldsName.DpmAppl, Description.DpmAppl, DbType.Decimal);
        readonly TableAdapterField m_CntctCode = new TableAdapterField(FieldsName.CntctCode, Description.CntctCode, DbType.Int32);

        readonly TableAdapterField m_Project = new TableAdapterField(FieldsName.Project, Description.Project, 8);
        readonly TableAdapterField m_PartSupply = new TableAdapterField(FieldsName.PartSupply, Description.PartSupply, 1);
        readonly TableAdapterField m_SeqCode = new TableAdapterField(FieldsName.SeqCode, Description.SeqCode, DbType.Int32);
        readonly TableAdapterField m_TrnspCode = new TableAdapterField(FieldsName.TrnspCode, Description.TrnspCode, DbType.Int32);

        readonly TableAdapterField m_Header = new TableAdapterField(FieldsName.Header, Description.Header, 200);
        readonly TableAdapterField m_Footer = new TableAdapterField(FieldsName.Footer, Description.Footer, 200);
        readonly TableAdapterField m_ImportEnt = new TableAdapterField(FieldsName.ImportEnt, Description.ImportEnt, DbType.Int32);
        readonly TableAdapterField m_AgentCode = new TableAdapterField(FieldsName.AgentCode, Description.AgentCode, 20);
        readonly TableAdapterField m_JrnlMemo = new TableAdapterField(FieldsName.JrnlMemo, Description.JrnlMemo, 50);
        readonly TableAdapterField m_BPLId = new TableAdapterField(FieldsName.BPLId, Description.BPLId, DbType.Int32);

        readonly TableAdapterField m_isIns = new TableAdapterField(FieldsName.isIns, Description.isIns, 1);
        readonly TableAdapterField m_WeightUnit = new TableAdapterField(FieldsName.WeightUnit, Description.WeightUnit, DbType.Int16);
        readonly TableAdapterField m_DocTotalFC = new TableAdapterField(FieldsName.DocTotalFC, Description.DocTotalFC, DbType.Decimal);
        readonly TableAdapterField m_DocTotalSy = new TableAdapterField(FieldsName.DocTotalSy, Description.DocTotalSy, DbType.Decimal);

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Document()
        {
            Expenses = new List<DocumentAdditionalExpenses>();
            DocumentRefenceList = new List<DocumentReferenceInformation>();
            Lines = new List<Line>();
            TaxExtension = new DocumentTaxExtension();
            DownPaymentsToDraw = new List<DocumentDownPaymentsToDraw>();
        }

        /// <summary>
        /// Instancia um novo documento
        /// </summary>
        /// <param name="pCompanyDb">Banco de dados da empresa</param>
        /// <param name="pDocumentObjectType">Tipo do Objeto</param>
        public Document(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, "O" + pDocumentObjectType.GetTableNameSufix())
        {
            Expenses = new List<DocumentAdditionalExpenses>();
            DocumentRefenceList = new List<DocumentReferenceInformation>();
            Lines = new List<Line>();
            TaxExtension = new DocumentTaxExtension(pCompanyDb, pDocumentObjectType);
            DownPaymentsToDraw = new List<DocumentDownPaymentsToDraw>();
        }

        /// <summary>
        /// Clona o objeto
        /// </summary>
        /// <param name="pDoc">Documento de Origem</param>
        public Document(Document pDoc)
            : this(pDoc.DBName, pDoc.ObjType)
        {

            CopyBy(pDoc);

            pDoc.Lines.ForEach(
                l => Lines.Add(new Line(l)));

            TaxExtension = new DocumentTaxExtension(pDoc.TaxExtension);

            pDoc.DownPaymentsToDraw.ForEach(
                l => DownPaymentsToDraw.Add(new DocumentDownPaymentsToDraw(l)));

            pDoc.Expenses.ForEach(
                l => this.Expenses.Add(new DocumentAdditionalExpenses(l)));

        }

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int DocNum
        {
            get { return m_DocNum.GetInt32(); }
            set { m_DocNum.Value = value; }
        }

        /// <summary>
        /// Permite definir número manualmente
        /// </summary>
        public eYesNo Handwrtten
        {
            get { return m_Handwrtten.GetString().ToYesNoEnum(); }
            set { m_Handwrtten.Value = value.ToYesNoString(); }
        }

        public eDocStatus DocStatus
        {
            get { return m_DocStatus.GetString().ToDocStatusEnum(); }
            set { m_DocStatus.Value = value.ToDocStatusString(); }
        }

        public DateTime DocDate
        {
            get { return m_DocDate.GetDateTime(); }
            set { m_DocDate.Value = value; }
        }

        public DateTime DocDueDate
        {
            get { return m_DocDueDate.GetDateTime(); }
            set { m_DocDueDate.Value = value; }
        }

        public DateTime ReqDate
        {
            get { return m_ReqDate.GetDateTime(); }
            set { m_ReqDate.Value = value; }
        }

        public DateTime TaxDate
        {
            get { return m_TaxDate.GetDateTime(); }
            set { m_TaxDate.Value = value; }
        }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public string CardName
        {
            get { return m_CardName.GetString(); }
            set { m_CardName.Value = value; }
        }

        public eDocumentModelID Model
        {
            get { return m_Model.GetInt32().ToDocumentModelIDEnum(); }
            set { m_Model.Value = value.ToInt32(); }
        }

        public eDocumentObjectType ObjType
        {
            get { return m_ObjType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_ObjType.Value = value.ToInt32(); }
        }

        public eYesNo Printed
        {
            get { return m_Printed.GetString().ToYesNoEnum(); }
            set { m_Printed.Value = value.ToYesNoString(); }
        }

        public string PeyMethod
        {
            get { return m_PeyMethod.GetString(); }
            set { m_PeyMethod.Value = value; }
        }

        public int Installmnt
        {
            get { return m_Installmnt.GetInt16(); }
            set { m_Installmnt.Value = value; }
        }

        public int Serial
        {
            get { return m_Serial.GetInt32(); }
            set { m_Serial.Value = value; }
        }

        public string SeriesStr
        {
            get { return m_SeriesStr.GetString(); }
            set { m_SeriesStr.Value = value; }
        }

        public string SubStr
        {
            get { return m_SubStr.GetString(); }
            set { m_SubStr.Value = value; }
        }

        public int SlpCode
        {
            get { return m_SlpCode.GetInt16(); }
            set { m_SlpCode.Value = value; }
        }

        public Decimal DocTotal
        {
            get { return m_DocTotal.GetDecimal(); }
            set { m_DocTotal.Value = value; }
        }

        public Decimal TotalExpns
        {
            get { return m_TotalExpns.GetDecimal(); }
            set { m_TotalExpns.Value = value; }
        }

        public string Comments
        {
            get { return m_Comments.GetString(); }
            set { m_Comments.Value = value; }
        }

        public Int32 GroupNum
        {
            get { return m_GroupNum.GetInt32(); }
            set { m_GroupNum.Value = value; }
        }

        public Int32 OwnerCode
        {
            get { return m_OwnerCode.GetInt32(); }
            set { m_OwnerCode.Value = value; }
        }

        public Decimal DiscPrcnt
        {
            get { return m_DiscPrcnt.GetDecimal(); }
            set { m_DiscPrcnt.Value = value; }
        }

        public Decimal DiscSum
        {
            get { return m_DiscSum.GetDecimal(); }
            set { m_DiscSum.Value = value; }
        }

        public Decimal PaidSum
        {
            get { return m_PaidSum.GetDecimal(); }
            set { m_PaidSum.Value = value; }
        }

        public Decimal DpmAppl
        {
            get { return m_DpmAppl.GetDecimal(); }
            set { m_DpmAppl.Value = value; }
        }

        public string NumAtCard
        {
            get { return m_NumAtCard.GetString(); }
            set { m_NumAtCard.Value = value; }
        }

        public Int32 CntctCode
        {
            get { return m_CntctCode.GetInt32(); }
            set { m_CntctCode.Value = value; }
        }

        public string Project
        {
            get { return m_Project.GetString(); }
            set { m_Project.Value = value; }
        }


        public eYesNo PartSupply
        {
            get { return m_PartSupply.GetString().ToYesNoEnum(); }
            set { m_PartSupply.Value = value.ToYesNoString(); }
        }

        public Int32 SeqCode
        {
            get { return m_SeqCode.GetInt32(); }
            set { m_SeqCode.Value = value; }
        }

        public Int32 TrnspCode
        {
            get { return m_TrnspCode.GetInt32(); }
            set { m_TrnspCode.Value = value; }
        }

        public Int32 ImportEnt
        {
            get { return m_ImportEnt.GetInt32(); }
            set { m_ImportEnt.Value = value; }
        }

        public string Header
        {
            get { return m_Header.GetString(); }
            set { m_Header.Value = value; }
        }

        public string Footer
        {
            get { return m_Footer.GetString(); }
            set { m_Footer.Value = value; }
        }

        public String ShipToCode
        {
            get { return m_ShipToCode.GetString(); }
            set { m_ShipToCode.Value = value; }
        }

        public String PayToCode
        {
            get { return m_PayToCode.GetString(); }
            set { m_PayToCode.Value = value; }
        }

        public Int16 DocTime
        {
            get { return m_DocTime.GetInt16(); }
            set { m_DocTime.Value = value; }
        }

        public String AgentCode
        {
            get { return m_AgentCode.GetString(); }
            set { m_AgentCode.Value = value; }
        }

        public String JrnlMemo
        {
            get { return m_JrnlMemo.GetString(); }
            set { m_JrnlMemo.Value = value; }
        }

        public Int32 BPLId
        {
            get { return m_BPLId.GetInt32(); }
            set { m_BPLId.Value = value; }
        }

        public eYesNo isIns
        {
            get { return m_isIns.GetString().ToYesNoEnum(); }
            set { m_isIns.Value = value.ToYesNoString(); }
        }

        /// <summary>
        /// Moeda corrente
        /// </summary>
        public String CurSource
        {
            get { return m_CurSource.GetString(); }
            set { m_CurSource.Value = value; }
        }

        /// <summary>
        /// Moeda do documento
        /// </summary>
        public String DocCur
        {
            get { return m_DocCur.GetString(); }
            set { m_DocCur.Value = value; }
        }

        /// <summary>
        /// Taxa de câmbio
        /// </summary>
        public Decimal DocRate
        {
            get { return m_DocRate.GetDecimal(); }
            set { m_DocRate.Value = value; }
        }

        /// <summary>
        /// Unidade de Peso
        /// </summary>
        public Int16 WeightUnit
        {
            get { return m_WeightUnit.GetInt16(); }
            set { m_WeightUnit.Value = value; }
        }

        public Decimal DocTotalFC
        {
            get { return m_DocTotalFC.GetDecimal(); }
            set { m_DocTotalFC.Value = value; }
        }

        public String SerieStr
        {
            get { return m_SeriesStr.GetString(); }
            set { m_SeriesStr.Value = value; }
        }

        public Decimal DocTotalSy
        {
            get { return m_DocTotalSy.GetDecimal(); }
            set { m_DocTotalSy.Value = value; }
        }

        public List<Line> Lines { get; set; }
        public List<Installment> Installments { get; set; }
        public DocumentTaxExtension TaxExtension { get; set; }
        public List<DocumentDownPaymentsToDraw> DownPaymentsToDraw { get; set; }
        /// <summary>
        /// Lista de Depesas adicionais
        /// </summary>
        public List<DocumentAdditionalExpenses> Expenses { get; set; }

        /// <summary>
        /// Lista de Documentos referenciados
        /// </summary>
        public List<DocumentReferenceInformation> DocumentRefenceList { get; set; }

        /// <summary>
        /// Pega o registro pela chave
        /// </summary>
        /// <param name="pDocEntry"></param>
        /// <returns></returns>
        public bool GetByKey(int pDocEntry)
        {
            DocEntry = pDocEntry;
            return base.GetByKey();
        }

        public void FillInstallments()
        {
            var myInstal = new Installment(DBName, ObjType);
            Installments = myInstal.GetInstallments(DocEntry);
        }

        public bool Draft
        {
            get { return IsDraft(); }
        }

        private bool IsDraft(eDocumentObjectType pDocumentObjectType = eDocumentObjectType.oNone)
        {
            return pDocumentObjectType == eDocumentObjectType.oDrafts
                   || (TableName != null && TableName.Contains("DRF"));
        }

        /// <summary>
        /// Prenche a lista e os lotes
        /// </summary>
        /// <param name="fillBathes">Prencher ou não os lotes e os números de séries</param>
        public void FillLines(bool fillBathes = true)
        {
            var lines = GetLines();

            if (fillBathes)
                FillBachesAndSerials(lines);

            Lines = lines;
        }

        private static void FillBachesAndSerials(IEnumerable<Line> lines)
        {
            foreach (var itemLine in lines)
            {
                itemLine.FillBatches();
                itemLine.FillSerialNumbers();
            }
        }

        private List<Line> GetLines()
        {
            var line = new Line(DBName, GetObjType());

            var lines = line.GetByDocEntry(DocEntry);

            foreach (var line1 in lines)
            {
                line1.TableName = line.TableName;
                line1.DBName = line.DBName;
            }

            return lines;
        }


        public void FillTaxExtension()
        {
            var docObjCode = GetObjType();

            TaxExtension = new DocumentTaxExtension(DBName, docObjCode)
            {
                DocEntry = DocEntry

            };

            TaxExtension.GetByKey();
        }

        private eDocumentObjectType GetObjType()
        {
            return IsDraft() ? eDocumentObjectType.oDrafts : ObjType;
        }


        public void FillDownPaymentsToDraw()
        {
            var docObjCode = GetObjType();

            var downPaymentsToDraw = new DocumentDownPaymentsToDraw(DBName, docObjCode);

            DownPaymentsToDraw = downPaymentsToDraw.GetByDocEntry(DocEntry);
        }


        /// <summary>
        /// Preenche as depesas adicionais
        /// </summary>
        public void FillExpenses()
        {
            var exp = new DocumentAdditionalExpenses(DBName, ObjType);
            Expenses = exp.GetByDocEntry(DocEntry);
        }

        /// <summary>
        /// Preenche os documentos referentes
        /// </summary>
        public void FillDocumentReferenceList()
        {
            if (!SboVersion.EqualOrMoreThenSap9P07()) return;

            var docs = new DocumentReferenceInformation(DBName, ObjType);
            DocumentRefenceList = docs.GetByDocEntry(DocEntry);
        }


        public bool GetBySerial(Int32 serial, eDocumentModelID documentModel)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(m_Serial, serial));
            tableQuery.Where.Add(new QueryParam(m_Model, documentModel.ToInt32()));

            var myData = GetData(tableQuery);

            if (myData.Rows.Count <= 0)
                return false;

            FillFields(myData.Rows[0]);

            return true;
        }

        public List<Document> GetByCardCode(string pCardCode)
        {
            var tableQuery = new TableQuery(this);
            tableQuery.Where.Add(new QueryParam(m_CardCode, pCardCode));

            return FillCollection<Document>(tableQuery);
        }
    }
}
