using System;
using System.Collections.Generic;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI.B1.Opportunity
{
    /// <summary>
    ///     Tabela de Opportunity
    /// </summary>
    public class Opportunity : TableAdapter
    {
        /// <summary>
        ///     Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "Opportunity";
        }

        public struct FieldsName
        {
            public static readonly string OpprId = "OpprId";
            public static readonly string CardCode = "CardCode";
            public static readonly string SlpCode = "SlpCode";
            public static readonly string CprCode = "CprCode";
            public static readonly string Source = "Source";
            public static readonly string IntCat1 = "IntCat1";
            public static readonly string IntCat2 = "IntCat2";
            public static readonly string IntCat3 = "IntCat3";
            public static readonly string IntRate = "IntRate";
            public static readonly string OpenDate = "OpenDate";
            public static readonly string DifType = "DifType";
            public static readonly string PredDate = "PredDate";
            public static readonly string MaxSumLoc = "MaxSumLoc";
            public static readonly string MaxSumSys = "MaxSumSys";
            public static readonly string WtSumLoc = "WtSumLoc";
            public static readonly string WtSumSys = "WtSumSys";
            public static readonly string PrcnProf = "PrcnProf";
            public static readonly string SumProfL = "SumProfL";
            public static readonly string SumProfS = "SumProfS";
            public static readonly string Memo = "Memo";
            public static readonly string Status = "Status";
            public static readonly string StatusRem = "StatusRem";
            public static readonly string Reason = "Reason";
            public static readonly string RealSumLoc = "RealSumLoc";
            public static readonly string RealSumSys = "RealSumSys";
            public static readonly string RealProfL = "RealProfL";
            public static readonly string RealProfS = "RealProfS";
            public static readonly string CloPrcnt = "CloPrcnt";
            public static readonly string StepLast = "StepLast";
            public static readonly string UserSign = "UserSign";
            public static readonly string Transfered = "Transfered";
            public static readonly string Instance = "Instance";
            public static readonly string CardName = "CardName";
            public static readonly string CloseDate = "CloseDate";
            public static readonly string LastSlp = "LastSlp";
            public static readonly string Name = "Name";
            public static readonly string Territory = "Territory";
            public static readonly string Industry = "Industry";
            public static readonly string ChnCrdCode = "ChnCrdCode";
            public static readonly string ChnCrdName = "ChnCrdName";
            public static readonly string PrjCode = "PrjCode";
            public static readonly string CardGroup = "CardGroup";
            public static readonly string ChnCrdCon = "ChnCrdCon";
            public static readonly string Owner = "Owner";
            public static readonly string Attachment = "attachment";
            public static readonly string DocType = "DocType";
            public static readonly string DocNum = "DocNum";
            public static readonly string DocEntry = "DocEntry";
            public static readonly string DocChkbox = "DocChkbox";
            public static readonly string AtcEntry = "AtcEntry";
            public static readonly string LogInstanc = "LogInstanc";
            public static readonly string UserSign2 = "UserSign2";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string OpprType = "OpprType";
        }

        public struct Description
        {
            public static readonly string OpprId = "Nº";
            public static readonly string CardCode = "Cód.parceiro negócios";
            public static readonly string SlpCode = "Vendedor";
            public static readonly string CprCode = "Pessoa de Contato";
            public static readonly string Source = "Fonte de informação";
            public static readonly string IntCat1 = "IntCat1";
            public static readonly string IntCat2 = "IntCat2";
            public static readonly string IntCat3 = "IntCat3";
            public static readonly string IntRate = "Nível de interesse";
            public static readonly string OpenDate = "Data de início";
            public static readonly string DifType = "Tipo Encerramento previsto";
            public static readonly string PredDate = "Data de Encerramento Projetada";
            public static readonly string MaxSumLoc = "Valor potencial";
            public static readonly string MaxSumSys = "Valor potencial Sistema";
            public static readonly string WtSumLoc = "Valor ponderado";
            public static readonly string WtSumSys = "Valor ponderado Sistema";
            public static readonly string PrcnProf = "% de lucro bruto";
            public static readonly string SumProfL = "Valor Ponderado (LC) - Documento";
            public static readonly string SumProfS = "Total do lucro bruto";
            public static readonly string Memo = "Observações";
            public static readonly string Status = "Status";
            public static readonly string StatusRem = "Observações de status";
            public static readonly string Reason = "Motivo do Encerramento";
            public static readonly string RealSumLoc = "Valor Total - Local";
            public static readonly string RealSumSys = "Valor Total - Sistema";
            public static readonly string RealProfL = "Fechando Lucro Bruto - Local";
            public static readonly string RealProfS = "Fechando Lucro Bruto - Sistema";
            public static readonly string CloPrcnt = "Percentual de Fechamento";
            public static readonly string StepLast = "Estágio atual";
            public static readonly string UserSign = "Usuário";
            public static readonly string Transfered = "Transferido para o próximo ano";
            public static readonly string Instance = "Instancia";
            public static readonly string CardName = "Nome do parceiro de negócios";
            public static readonly string CloseDate = "Data de encerramento";
            public static readonly string LastSlp = "Último Vendedor";
            public static readonly string Name = "Nome da oportunidade";
            public static readonly string Territory = "Território do PN";
            public static readonly string Industry = "Setor industrial";
            public static readonly string ChnCrdCode = "Código canal PN";
            public static readonly string ChnCrdName = "Nome canal PN";
            public static readonly string PrjCode = "Projeto PN";
            public static readonly string CardGroup = "CardGroup";
            public static readonly string ChnCrdCon = "Contato canal PN";
            public static readonly string Owner = "Proprietário";
            public static readonly string Attachment = "Anexos";
            public static readonly string DocType = "Tipo de documento";
            public static readonly string DocNum = "Nº documento vinculado";
            public static readonly string DocEntry = "Nº Entrada vinculado";
            public static readonly string DocChkbox = "Existe Doc. Vinculado";
            public static readonly string AtcEntry = "Nº Entrada anexo";
            public static readonly string LogInstanc = "LogInstanc";
            public static readonly string UserSign2 = "Usuário 2";
            public static readonly string UpdateDate = "Data de atualização";
            public static readonly string OpprType = "Tipo de oportunidade";
        }

        private readonly TableAdapterField _opprId = new TableAdapterField(FieldsName.OpprId,
            Description.OpprId,
            DbType.Int32,
            11,
            0,
            true,
            false);

        private readonly TableAdapterField _cardCode = new TableAdapterField(FieldsName.CardCode,
            Description.CardCode,
            15);

        private readonly TableAdapterField _slpCode = new TableAdapterField(FieldsName.SlpCode,
            Description.SlpCode,
            DbType.Int32);

        private readonly TableAdapterField _cprCode = new TableAdapterField(FieldsName.CprCode,
            Description.CprCode,
            DbType.Int32);

        private readonly TableAdapterField _source = new TableAdapterField(FieldsName.Source,
            Description.Source,
            DbType.Int32);

        private readonly TableAdapterField _intCat1 = new TableAdapterField(FieldsName.IntCat1,
            Description.IntCat1,
            DbType.Int32);

        private readonly TableAdapterField _intCat2 = new TableAdapterField(FieldsName.IntCat2,
            Description.IntCat2,
            DbType.Int32);

        private readonly TableAdapterField _intCat3 = new TableAdapterField(FieldsName.IntCat3,
            Description.IntCat3,
            DbType.Int32);

        private readonly TableAdapterField _intRate = new TableAdapterField(FieldsName.IntRate,
            Description.IntRate,
            DbType.Int32);

        private readonly TableAdapterField _openDate = new TableAdapterField(FieldsName.OpenDate,
            Description.OpenDate,
            DbType.DateTime);

        private readonly TableAdapterField _difType = new TableAdapterField(FieldsName.DifType, Description.DifType, 1);

        private readonly TableAdapterField _predDate = new TableAdapterField(FieldsName.PredDate,
            Description.PredDate,
            DbType.DateTime);

        private readonly TableAdapterField _maxSumLoc = new TableAdapterField(FieldsName.MaxSumLoc,
            Description.MaxSumLoc,
            DbType.Decimal);

        private readonly TableAdapterField _maxSumSys = new TableAdapterField(FieldsName.MaxSumSys,
            Description.MaxSumSys,
            DbType.Decimal);

        private readonly TableAdapterField _wtSumLoc = new TableAdapterField(FieldsName.WtSumLoc,
            Description.WtSumLoc,
            DbType.Decimal);

        private readonly TableAdapterField _wtSumSys = new TableAdapterField(FieldsName.WtSumSys,
            Description.WtSumSys,
            DbType.Decimal);

        private readonly TableAdapterField _prcnProf = new TableAdapterField(FieldsName.PrcnProf,
            Description.PrcnProf,
            DbType.Decimal);

        private readonly TableAdapterField _sumProfL = new TableAdapterField(FieldsName.SumProfL,
            Description.SumProfL,
            DbType.Decimal);

        private readonly TableAdapterField _sumProfS = new TableAdapterField(FieldsName.SumProfS,
            Description.SumProfS,
            DbType.Decimal);

        private readonly TableAdapterField _memo = new TableAdapterField(FieldsName.Memo, Description.Memo, 16);
        private readonly TableAdapterField _status = new TableAdapterField(FieldsName.Status, Description.Status, 1);

        private readonly TableAdapterField _statusRem = new TableAdapterField(FieldsName.StatusRem,
            Description.StatusRem,
            30);

        private readonly TableAdapterField _reason = new TableAdapterField(FieldsName.Reason,
            Description.Reason,
            DbType.Int32);

        private readonly TableAdapterField _realSumLoc = new TableAdapterField(FieldsName.RealSumLoc,
            Description.RealSumLoc,
            DbType.Decimal);

        private readonly TableAdapterField _realSumSys = new TableAdapterField(FieldsName.RealSumSys,
            Description.RealSumSys,
            DbType.Decimal);

        private readonly TableAdapterField _realProfL = new TableAdapterField(FieldsName.RealProfL,
            Description.RealProfL,
            DbType.Decimal);

        private readonly TableAdapterField _realProfS = new TableAdapterField(FieldsName.RealProfS,
            Description.RealProfS,
            DbType.Decimal);

        private readonly TableAdapterField _cloPrcnt = new TableAdapterField(FieldsName.CloPrcnt,
            Description.CloPrcnt,
            DbType.Decimal);

        private readonly TableAdapterField _stepLast = new TableAdapterField(FieldsName.StepLast,
            Description.StepLast,
            DbType.Int16);

        private readonly TableAdapterField _userSign = new TableAdapterField(FieldsName.UserSign,
            Description.UserSign,
            DbType.Int16);

        private readonly TableAdapterField _transfered = new TableAdapterField(FieldsName.Transfered,
            Description.Transfered,
            1);

        private readonly TableAdapterField _instance = new TableAdapterField(FieldsName.Instance,
            Description.Instance,
            DbType.Int16);

        private readonly TableAdapterField _cardName = new TableAdapterField(FieldsName.CardName,
            Description.CardName,
            100);

        private readonly TableAdapterField _closeDate = new TableAdapterField(FieldsName.CloseDate,
            Description.CloseDate,
            DbType.DateTime);

        private readonly TableAdapterField _lastSlp = new TableAdapterField(FieldsName.LastSlp,
            Description.LastSlp,
            DbType.Int32);

        private readonly TableAdapterField _name = new TableAdapterField(FieldsName.Name, Description.Name, 100);

        private readonly TableAdapterField _territory = new TableAdapterField(FieldsName.Territory,
            Description.Territory,
            DbType.Int32);

        private readonly TableAdapterField _industry = new TableAdapterField(FieldsName.Industry,
            Description.Industry,
            DbType.Int32);

        private readonly TableAdapterField _chnCrdCode = new TableAdapterField(FieldsName.ChnCrdCode,
            Description.ChnCrdCode,
            15);

        private readonly TableAdapterField _chnCrdName = new TableAdapterField(FieldsName.ChnCrdName,
            Description.ChnCrdName,
            100);

        private readonly TableAdapterField _prjCode = new TableAdapterField(FieldsName.PrjCode, Description.PrjCode, 20);

        private readonly TableAdapterField _cardGroup = new TableAdapterField(FieldsName.CardGroup,
            Description.CardGroup,
            DbType.Int16);

        private readonly TableAdapterField _chnCrdCon = new TableAdapterField(FieldsName.ChnCrdCon,
            Description.ChnCrdCon,
            DbType.Int32);

        private readonly TableAdapterField _owner = new TableAdapterField(FieldsName.Owner,
            Description.Owner,
            DbType.Int32);

        private readonly TableAdapterField _attachment = new TableAdapterField(FieldsName.Attachment,
            Description.Attachment,
            1);

        private readonly TableAdapterField _docType = new TableAdapterField(FieldsName.DocType, Description.DocType, 9);

        private readonly TableAdapterField _docNum = new TableAdapterField(FieldsName.DocNum,
            Description.DocNum,
            DbType.Int32);

        private readonly TableAdapterField _docEntry = new TableAdapterField(FieldsName.DocEntry,
            Description.DocEntry,
            DbType.Int32);

        private readonly TableAdapterField _docChkbox = new TableAdapterField(FieldsName.DocChkbox,
            Description.DocChkbox,
            1);

        private readonly TableAdapterField _atcEntry = new TableAdapterField(FieldsName.AtcEntry,
            Description.AtcEntry,
            DbType.Int32);

        private readonly TableAdapterField _logInstanc = new TableAdapterField(FieldsName.LogInstanc,
            Description.LogInstanc,
            DbType.Int32);

        private readonly TableAdapterField _userSign2 = new TableAdapterField(FieldsName.UserSign2,
            Description.UserSign2,
            DbType.Int16);

        private readonly TableAdapterField _updateDate = new TableAdapterField(FieldsName.UpdateDate,
            Description.UpdateDate,
            DbType.DateTime);

        private readonly TableAdapterField _opprType = new TableAdapterField(FieldsName.OpprType,
            Description.OpprType,
            1);

        public Opportunity()
            : base("OOPR")
        {
        }

        public Opportunity(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public Opportunity(Opportunity pOpportunity)
            : this()
        {
            CopyBy(pOpportunity);

            pOpportunity.OpportunityRows.ForEach(
                l => OpportunityRows.Add(new OpportunityRows(l)));

            pOpportunity.OpportunityCompetitors.ForEach(
                l => OpportunityCompetitors.Add(new OpportunityCompetitors(l)));
        }

        public int OpprId
        {
            get { return _opprId.GetInt32(); }
            set { _opprId.Value = value; }
        }

        public string CardCode
        {
            get { return _cardCode.GetString(); }
            set { _cardCode.Value = value; }
        }

        public int SlpCode
        {
            get { return _slpCode.GetInt32(); }
            set { _slpCode.Value = value; }
        }

        public int CprCode
        {
            get { return _cprCode.GetInt32(); }
            set { _cprCode.Value = value; }
        }

        public int Source
        {
            get { return _source.GetInt32(); }
            set { _source.Value = value; }
        }

        public int IntCat1
        {
            get { return _intCat1.GetInt32(); }
            set { _intCat1.Value = value; }
        }

        public int IntCat2
        {
            get { return _intCat2.GetInt32(); }
            set { _intCat2.Value = value; }
        }

        public int IntCat3
        {
            get { return _intCat3.GetInt32(); }
            set { _intCat3.Value = value; }
        }

        public int IntRate
        {
            get { return _intRate.GetInt32(); }
            set { _intRate.Value = value; }
        }

        public DateTime OpenDate
        {
            get { return _openDate.GetDateTime(); }
            set { _openDate.Value = value; }
        }

        public string DifType
        {
            get { return _difType.GetString(); }
            set { _difType.Value = value; }
        }

        public DifTypeEnum DifTypeEnum
        {
            get { return (DifTypeEnum) _difType.GetChar(); }
            set { _difType.Value = value.To<char>(); }
        }

        public DateTime PredDate
        {
            get { return _predDate.GetDateTime(); }
            set { _predDate.Value = value; }
        }

        public decimal MaxSumLoc
        {
            get { return _maxSumLoc.GetDecimal(); }
            set { _maxSumLoc.Value = value; }
        }

        public decimal MaxSumSys
        {
            get { return _maxSumSys.GetDecimal(); }
            set { _maxSumSys.Value = value; }
        }

        public decimal WtSumLoc
        {
            get { return _wtSumLoc.GetDecimal(); }
            set { _wtSumLoc.Value = value; }
        }

        public decimal WtSumSys
        {
            get { return _wtSumSys.GetDecimal(); }
            set { _wtSumSys.Value = value; }
        }

        public decimal PrcnProf
        {
            get { return _prcnProf.GetDecimal(); }
            set { _prcnProf.Value = value; }
        }

        public decimal SumProfL
        {
            get { return _sumProfL.GetDecimal(); }
            set { _sumProfL.Value = value; }
        }

        public decimal SumProfS
        {
            get { return _sumProfS.GetDecimal(); }
            set { _sumProfS.Value = value; }
        }

        public string Memo
        {
            get { return _memo.GetString(); }
            set { _memo.Value = value; }
        }

        public string Status
        {
            get { return _status.GetString(); }
            set { _status.Value = value; }
        }

        public OpportunityStatusEnum OpportunityStatusEnum
        {
            get { return (OpportunityStatusEnum) _status.GetChar(); }
            set { _status.Value = value.To<char>(); }
        }
        
        public string StatusRem
        {
            get { return _statusRem.GetString(); }
            set { _statusRem.Value = value; }
        }

        public int Reason
        {
            get { return _reason.GetInt32(); }
            set { _reason.Value = value; }
        }

        public decimal RealSumLoc
        {
            get { return _realSumLoc.GetDecimal(); }
            set { _realSumLoc.Value = value; }
        }

        public decimal RealSumSys
        {
            get { return _realSumSys.GetDecimal(); }
            set { _realSumSys.Value = value; }
        }

        public decimal RealProfL
        {
            get { return _realProfL.GetDecimal(); }
            set { _realProfL.Value = value; }
        }

        public decimal RealProfS
        {
            get { return _realProfS.GetDecimal(); }
            set { _realProfS.Value = value; }
        }

        public decimal CloPrcnt
        {
            get { return _cloPrcnt.GetDecimal(); }
            set { _cloPrcnt.Value = value; }
        }

        public short StepLast
        {
            get { return _stepLast.GetInt16(); }
            set { _stepLast.Value = value; }
        }

        public short UserSign
        {
            get { return _userSign.GetInt16(); }
            set { _userSign.Value = value; }
        }

        public string Transfered
        {
            get { return _transfered.GetString(); }
            set { _transfered.Value = value; }
        }

        public short Instance
        {
            get { return _instance.GetInt16(); }
            set { _instance.Value = value; }
        }

        public string CardName
        {
            get { return _cardName.GetString(); }
            set { _cardName.Value = value; }
        }

        public DateTime CloseDate
        {
            get { return _closeDate.GetDateTime(); }
            set { _closeDate.Value = value; }
        }

        public int LastSlp
        {
            get { return _lastSlp.GetInt32(); }
            set { _lastSlp.Value = value; }
        }

        public string Name
        {
            get { return _name.GetString(); }
            set { _name.Value = value; }
        }

        public int Territory
        {
            get { return _territory.GetInt32(); }
            set { _territory.Value = value; }
        }

        public int Industry
        {
            get { return _industry.GetInt32(); }
            set { _industry.Value = value; }
        }

        public string ChnCrdCode
        {
            get { return _chnCrdCode.GetString(); }
            set { _chnCrdCode.Value = value; }
        }

        public string ChnCrdName
        {
            get { return _chnCrdName.GetString(); }
            set { _chnCrdName.Value = value; }
        }

        public string PrjCode
        {
            get { return _prjCode.GetString(); }
            set { _prjCode.Value = value; }
        }

        public short CardGroup
        {
            get { return _cardGroup.GetInt16(); }
            set { _cardGroup.Value = value; }
        }

        public int ChnCrdCon
        {
            get { return _chnCrdCon.GetInt32(); }
            set { _chnCrdCon.Value = value; }
        }

        public int Owner
        {
            get { return _owner.GetInt32(); }
            set { _owner.Value = value; }
        }

        public string Attachment
        {
            get { return _attachment.GetString(); }
            set { _attachment.Value = value; }
        }

        public string DocType
        {
            get { return _docType.GetString(); }
            set { _docType.Value = value; }
        }

        public DocTypeEnum DocTypeEnum
        {
            get { return (DocTypeEnum) _docType.GetInt32(); }
            set { _docType.Value = value.To<int>(); }
        }

        public int DocNum
        {
            get { return _docNum.GetInt32(); }
            set { _docNum.Value = value; }
        }

        public int DocEntry
        {
            get { return _docEntry.GetInt32(); }
            set { _docEntry.Value = value; }
        }

        public string DocChkbox
        {
            get { return _docChkbox.GetString(); }
            set { _docChkbox.Value = value; }
        }

        public int AtcEntry
        {
            get { return _atcEntry.GetInt32(); }
            set { _atcEntry.Value = value; }
        }

        public int LogInstanc
        {
            get { return _logInstanc.GetInt32(); }
            set { _logInstanc.Value = value; }
        }

        public short UserSign2
        {
            get { return _userSign2.GetInt16(); }
            set { _userSign2.Value = value; }
        }

        public DateTime UpdateDate
        {
            get { return _updateDate.GetDateTime(); }
            set { _updateDate.Value = value; }
        }

        public string OpprType
        {
            get { return _opprType.GetString(); }
            set { _opprType.Value = value; }
        }

        public OpprTypeEnum OpprTypeEnum
        {
            get { return (OpprTypeEnum) _opprType.GetChar(); }
            set { _opprType.Value = value.To<char>(); }
        }

        public List<OpportunityRows> OpportunityRows { get; set; }

        public List<OpportunityCompetitors> OpportunityCompetitors { get; set; }


        public bool GetByKey(int pOpprId)
        {
            OpprId = pOpprId;
            return base.GetByKey();
        }

        public List<Opportunity> GetAll()
        {
            return FillCollection<Opportunity>();
        }

        private List<OpportunityRows> GetRows() 
        {
            var line = new OpportunityRows(DBName);

            var lines = line.GetByOpprId(DocEntry);

            foreach (var line1 in lines)
            {
                line1.TableName = line.TableName;
                line1.DBName = line.DBName;
            }

            return lines;
        }

        private List<OpportunityCompetitors> GetCompetitors() 
        {
            var competitors = new OpportunityCompetitors(DBName);

            var lines = competitors.GetByOpportId(DocEntry);

            foreach (var line1 in lines)
            {
                line1.TableName = competitors.TableName;
                line1.DBName = competitors.DBName;
            }

            return lines;
        }

        public void FillLines() 
        {

            OpportunityRows = GetRows();

            OpportunityCompetitors = GetCompetitors();
        }
    }
}
