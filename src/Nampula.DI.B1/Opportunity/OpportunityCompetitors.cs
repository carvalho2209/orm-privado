using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.Framework;

namespace Nampula.DI.B1.Opportunity
{
    /// <summary>
    ///     Tabela de OpportunityCompetitors
    /// </summary>
    public class OpportunityCompetitors : TableAdapter
    {
        /// <summary>
        ///     Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OpportunityCompetitors";
        }

        public struct FieldsName
        {
            public static readonly string Line = "Line";
            public static readonly string OpportId = "OpportId";
            public static readonly string CompetId = "CompetId";
            public static readonly string Won = "Won";
            public static readonly string ThreatLevl = "ThreatLevl";
            public static readonly string Memo = "Memo";
        }

        public struct Description
        {
            public static readonly string Line = "Linha";
            public static readonly string OpportId = "Nº da Oportunidade";
            public static readonly string CompetId = "Concorrente";
            public static readonly string Won = "Venceu";
            public static readonly string ThreatLevl = "Grau de ameaça";
            public static readonly string Memo = "Detalhes";
        }

        readonly TableAdapterField _line = new TableAdapterField(FieldsName.Line, Description.Line, DbType.Int16, 11, 0, true, true);
        readonly TableAdapterField _opportId = new TableAdapterField(FieldsName.OpportId, Description.OpportId, DbType.Int32, 11, 0, true, true);
        
        private readonly TableAdapterField _competId = new TableAdapterField(FieldsName.CompetId,
            Description.CompetId,
            DbType.Int32,
            11,
            0,
            true,
            false);
        private readonly TableAdapterField _won = new TableAdapterField(FieldsName.Won, Description.Won, 100);
        
        private readonly TableAdapterField _threatLevl = new TableAdapterField(FieldsName.ThreatLevl,
            Description.ThreatLevl,
            DbType.Int16);

        private readonly TableAdapterField _memo = new TableAdapterField(FieldsName.Memo,
            Description.Memo,
            50);
        
        public OpportunityCompetitors()
            : base("OPR3")
        {
        }

        public OpportunityCompetitors(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public OpportunityCompetitors(OpportunityCompetitors pOpportunityCompetitors)
            : this()
        {
            CopyBy(pOpportunityCompetitors);
        }

        
        public short Line
        {
            get { return _line.GetInt16(); }
            set { _line.Value = value; }
        }
        
        public int OpportId
        {
            get { return _opportId.GetInt32(); }
            set { _opportId.Value = value; }
        }

        public int CompetId
        {
            get { return _competId.GetInt32(); }
            set { _competId.Value = value; }
        }

        public string Won
        {
            get { return _won.GetString(); }
            set { _won.Value = value; }
        }
        
        public eYesNo WonEnum
        {
            get { return (eYesNo) _won.GetChar(); }
            set { _won.Value = value.To<char>(); }
        }

        public short ThreatLevl
        {
            get { return _threatLevl.GetInt16(); }
            set { _threatLevl.Value = value; }
        }

        public ThreatLevlEnum ThreatLevlEnum
        {
            get { return (ThreatLevlEnum) _threatLevl.GetChar(); }
            set { _threatLevl.Value = value.To<char>(); }
        }
        
        public string Memo
        {
            get { return _memo.GetString(); }
            set { _memo.Value = value; }
        }
        
        public bool GetByKey(int pCompetId)
        {
            CompetId = pCompetId;
            return base.GetByKey();
        }

        public List<OpportunityCompetitors> GetAll()
        {
            return FillCollection<OpportunityCompetitors>();
        }
        
        public OpportunityCompetitors GetByCompetId(int pCompetId)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(_competId, pCompetId));
            return FillCollection<OpportunityCompetitors>(GetData(tableQuery).Rows).FirstOrDefault(); 
        }
        
        public List<OpportunityCompetitors> GetByOpportId(int pOpportId)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(_opportId, pOpportId));
            return FillCollection<OpportunityCompetitors>(GetData(tableQuery).Rows); 
        }

        public OpportunityCompetitors GetBy(int pCompetId,int pThreatLevl,string pWon)
        {
            var tableQuery = new TableQuery(this);
            if (pCompetId > 0)
                tableQuery.Where.Add(new QueryParam(_competId, pCompetId));

            if (pThreatLevl > 0)
                tableQuery.Where.Add(new QueryParam(_threatLevl, pThreatLevl));

            if (pWon != string.Empty)
                tableQuery.Where.Add(new QueryParam(_won, _won));

            return FillCollection<OpportunityCompetitors>(GetData(tableQuery).Rows).FirstOrDefault(); 
        }
    }
}

