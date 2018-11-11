using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.Framework;

namespace Nampula.DI.B1.Opportunity
{
    /// <summary>
    ///     Tabela de Competitors
    /// </summary>
    public class Competitors : TableAdapter
    {
        /// <summary>
        ///     Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "Competitors";
        }

        public struct FieldsName
        {
            public static readonly string CompetId = "CompetId";
            public static readonly string Name = "Name";
            public static readonly string ThreatLevl = "ThreatLevl";
            public static readonly string Memo = "Memo";
            public static readonly string UserSign = "UserSign";
        }

        public struct Description
        {
            public static readonly string CompetId = "Nº";
            public static readonly string Name = "Nome";
            public static readonly string ThreatLevl = "Grau de ameaça";
            public static readonly string Memo = "Detalhes";
            public static readonly string UserSign = "Usuário";
        }

        private readonly TableAdapterField _competId = new TableAdapterField(FieldsName.CompetId,
            Description.CompetId,
            DbType.Int32,
            11,
            0,
            true,
            false);
        private readonly TableAdapterField _name = new TableAdapterField(FieldsName.Name, Description.Name, 100);
        
        private readonly TableAdapterField _threatLevl = new TableAdapterField(FieldsName.ThreatLevl,
            Description.ThreatLevl,
            DbType.Int16);

        private readonly TableAdapterField _memo = new TableAdapterField(FieldsName.Memo,
            Description.Memo,
            50);

        private readonly TableAdapterField _userSign = new TableAdapterField(FieldsName.UserSign,
            Description.UserSign,
            DbType.Int16);
        
        public Competitors()
            : base("OCMT")
        {
        }

        public Competitors(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public Competitors(Competitors pCompetitors)
            : this()
        {
            CopyBy(pCompetitors);
        }

        public int CompetId
        {
            get { return _competId.GetInt32(); }
            set { _competId.Value = value; }
        }

        public string Name
        {
            get { return _name.GetString(); }
            set { _name.Value = value; }
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

        public short UserSign
        {
            get { return _userSign.GetInt16(); }
            set { _userSign.Value = value; }
        }
        
        public bool GetByKey(int pCompetId)
        {
            CompetId = pCompetId;
            return base.GetByKey();
        }

        public List<Competitors> GetAll()
        {
            return FillCollection<Competitors>();
        }
        
        public Competitors GetByNum(int pCompetId)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(_competId, pCompetId));
            return FillCollection<Competitors>(GetData(tableQuery).Rows).FirstOrDefault(); 
        }

        public Competitors GetBy(int pCompetId,int pThreatLevl,string pName)
        {
            var tableQuery = new TableQuery(this);
            if (pCompetId > 0)
                tableQuery.Where.Add(new QueryParam(_competId, pCompetId));

            if (pThreatLevl > 0)
                tableQuery.Where.Add(new QueryParam(_threatLevl, pThreatLevl));

            if (pName != string.Empty)
                tableQuery.Where.Add(new QueryParam(_name, pName));

            return FillCollection<Competitors>(GetData(tableQuery).Rows).FirstOrDefault(); 
        }
    }
}

