using System;
using System.Collections.Generic;
using System.Data;
using Nampula.Framework;

namespace Nampula.DI.B1.Opportunity
{
        /// <summary>
    /// Tabela de OpportunityRows
    /// </summary>
    public class OpportunityRows : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OpportunityRows";
        }

        public struct FieldsName
        {
            public static readonly string Line = "Line";
            public static readonly string OpprId = "OpprId";
            public static readonly string SlpCode = "SlpCode";
            public static readonly string CntctCode = "CntctCode";
            public static readonly string OpenDate = "OpenDate";
            public static readonly string CloseDate = "CloseDate";
            public static readonly string Step_Id = "Step_Id";
            public static readonly string ClosePrcnt = "ClosePrcnt";
            public static readonly string MaxSumLoc = "MaxSumLoc";
            public static readonly string MaxSumSys = "MaxSumSys";
            public static readonly string Memo = "Memo";
            public static readonly string DocId = "DocId";
            public static readonly string ObjType = "ObjType";
            public static readonly string Status = "Status";
            public static readonly string Linked = "Linked";
            public static readonly string WtSumLoc = "WtSumLoc";
            public static readonly string WtSumSys = "WtSumSys";
            public static readonly string UserSign = "UserSign";
            public static readonly string ChnCrdCode = "ChnCrdCode";
            public static readonly string ChnCrdName = "ChnCrdName";
            public static readonly string ChnCrdCon = "ChnCrdCon";
            public static readonly string DocChkbox = "DocChkbox";
            public static readonly string Owner = "Owner";
            public static readonly string DocNumber = "DocNumber";
        }

        public struct Description
        {
            public static readonly string Line = "Linha";
            public static readonly string OpprId = "Nº da Sequência";
            public static readonly string SlpCode = "Vendedor";
            public static readonly string CntctCode = "Pessoa de Contato";
            public static readonly string OpenDate = "Data de Abertura";
            public static readonly string CloseDate = "Data de Fechamento";
            public static readonly string Step_Id = "Etapa";
            public static readonly string ClosePrcnt = "%";
            public static readonly string MaxSumLoc = "Valor potencial";
            public static readonly string MaxSumSys = "Valor potencial Sistema";
            public static readonly string Memo = "Observações";
            public static readonly string DocId = "Nº Entrada vinculado";
            public static readonly string ObjType = "Tipo do Documento";
            public static readonly string Status = "Status";
            public static readonly string Linked = "Atividade";
            public static readonly string WtSumLoc = "Valor ponderado";
            public static readonly string WtSumSys = "Valor ponderado Sistema";
            public static readonly string UserSign = "Usuário";
            public static readonly string ChnCrdCode = "Código Canal BP";
            public static readonly string ChnCrdName = "Nome Canal BP";
            public static readonly string ChnCrdCon = "Contato Canal BP";
            public static readonly string DocChkbox = "Existe Doc. Vinculado";
            public static readonly string Owner = "Proprietário";
            public static readonly string DocNumber = "Nº documento vinculado";
        }

        readonly TableAdapterField _line = new TableAdapterField(FieldsName.Line, Description.Line, DbType.Int16, 11, 0, true, true);
        readonly TableAdapterField _opprId = new TableAdapterField(FieldsName.OpprId, Description.OpprId, DbType.Int32, 11, 0, true, true);
        readonly TableAdapterField _slpCode = new TableAdapterField(FieldsName.SlpCode, Description.SlpCode, DbType.Int32);
        readonly TableAdapterField _cntctCode = new TableAdapterField(FieldsName.CntctCode, Description.CntctCode, DbType.Int32);
        readonly TableAdapterField _openDate = new TableAdapterField(FieldsName.OpenDate, Description.OpenDate, DbType.DateTime);
        readonly TableAdapterField _closeDate = new TableAdapterField(FieldsName.CloseDate, Description.CloseDate, DbType.DateTime);
        readonly TableAdapterField _step_Id = new TableAdapterField(FieldsName.Step_Id, Description.Step_Id, DbType.Int32);
        readonly TableAdapterField _closePrcnt = new TableAdapterField(FieldsName.ClosePrcnt, Description.ClosePrcnt, DbType.Decimal);
        readonly TableAdapterField _maxSumLoc = new TableAdapterField(FieldsName.MaxSumLoc, Description.MaxSumLoc, DbType.Decimal);
        readonly TableAdapterField _maxSumSys = new TableAdapterField(FieldsName.MaxSumSys, Description.MaxSumSys, DbType.Decimal);
        readonly TableAdapterField _memo = new TableAdapterField(FieldsName.Memo, Description.Memo, 16);
        readonly TableAdapterField _docId = new TableAdapterField(FieldsName.DocId, Description.DocId, DbType.Int32);
        readonly TableAdapterField _objType = new TableAdapterField(FieldsName.ObjType, Description.ObjType, 9);
        readonly TableAdapterField _status = new TableAdapterField(FieldsName.Status, Description.Status, 1);
        readonly TableAdapterField _linked = new TableAdapterField(FieldsName.Linked, Description.Linked, 1);
        readonly TableAdapterField _wtSumLoc = new TableAdapterField(FieldsName.WtSumLoc, Description.WtSumLoc, DbType.Decimal);
        readonly TableAdapterField _wtSumSys = new TableAdapterField(FieldsName.WtSumSys, Description.WtSumSys, DbType.Decimal);
        readonly TableAdapterField _userSign = new TableAdapterField(FieldsName.UserSign, Description.UserSign, DbType.Int16);
        readonly TableAdapterField _chnCrdCode = new TableAdapterField(FieldsName.ChnCrdCode, Description.ChnCrdCode, 15);
        readonly TableAdapterField _chnCrdName = new TableAdapterField(FieldsName.ChnCrdName, Description.ChnCrdName, 100);
        readonly TableAdapterField _chnCrdCon = new TableAdapterField(FieldsName.ChnCrdCon, Description.ChnCrdCon, DbType.Int32);
        readonly TableAdapterField _docChkbox = new TableAdapterField(FieldsName.DocChkbox, Description.DocChkbox, 1);
        readonly TableAdapterField _owner = new TableAdapterField(FieldsName.Owner, Description.Owner, DbType.Int32);
        readonly TableAdapterField _docNumber = new TableAdapterField(FieldsName.DocNumber, Description.DocNumber, DbType.Int32);

        public OpportunityRows()
            : base("OPR1")
        {
        }

        public OpportunityRows(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public OpportunityRows(OpportunityRows pOpportunityRows)
            :this()
        {
            CopyBy(pOpportunityRows);
        }

        public short Line
        {
            get { return _line.GetInt16(); }
            set { _line.Value = value; }
        }

        public int OpprId
        {
            get { return _opprId.GetInt32(); }
            set { _opprId.Value = value; }
        }

        public int CntctCode
        {
            get { return _cntctCode.GetInt32(); }
            set { _cntctCode.Value = value; }
        }
        
        public int SlpCode
        {
            get { return _slpCode.GetInt32(); }
            set { _slpCode.Value = value; }
        }
        public DateTime OpenDate
        {
            get { return _openDate.GetDateTime(); }
            set { _openDate.Value = value; }
        }

        public DateTime CloseDate
        {
            get { return _closeDate.GetDateTime(); }
            set { _closeDate.Value = value; }
        }
        
        public short Step_Id
        {
            get { return _step_Id.GetInt16(); }
            set { _step_Id.Value = value; }
        }
        
        public decimal ClosePrcnt
        {
            get { return _closePrcnt.GetDecimal(); }
            set { _closePrcnt.Value = value; }
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
        
        public string Memo
        {
            get { return _memo.GetString(); }
            set { _memo.Value = value; }
        }
        
        public int DocId
        {
            get { return _docId.GetInt32(); }
            set { _docId.Value = value; }
        }
        
        public string ObjType
        {
            get { return _objType.GetString(); }
            set { _objType.Value = value; }
        }
        
        public DocTypeEnum ObjTypeEnum
        {
            get { return (DocTypeEnum)_objType.GetInt32(); }
            set { _objType.Value = value.To<int>(); }
        }

        public string Status
        {
            get { return _status.GetString(); }
            set { _status.Value = value; }
        }
        
        public OpportunityStatusEnum OpportunityStatusEnum
        {
            get { return (OpportunityStatusEnum)_status.GetChar(); }
            set { _status.Value = value.To<char>(); }
        }

        public string Linked
        {
            get { return _linked.GetString(); }
            set { _linked.Value = value; }
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

        public short UserSign
        {
            get { return _userSign.GetInt16(); }
            set { _userSign.Value = value; }
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

        public int ChnCrdCon
        {
            get { return _chnCrdCon.GetInt32(); }
            set { _chnCrdCon.Value = value; }
        }
        
        public string DocChkbox
        {
            get { return _docChkbox.GetString(); }
            set { _docChkbox.Value = value; }
        }
        
        public eYesNo DocChkboxEnum
        {
            get { return (eYesNo) _docChkbox.GetChar(); }
            set { _docChkbox.Value = value.To<char>(); }
        }

        public int Owner
        {
            get { return _owner.GetInt32(); }
            set { _owner.Value = value; }
        }

        public int DocNumber
        {
            get { return _docNumber.GetInt32(); }
            set { _docNumber.Value = value; }
        }

        public List<OpportunityRows> GetByOpprId(int pOpprId)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(_opprId, pOpprId));
            return FillCollection<OpportunityRows>(GetData(tableQuery).Rows); 
        }
    }
}
