using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nampula.Framework;

namespace Nampula.DI.B1.Opportunity
{
    /// <summary>
    ///     Tabela de OpportunityStage
    /// </summary>
    public class OpportunityStage : TableAdapter
    {
        /// <summary>
        ///     Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OpportunityStage";
        }

        public struct FieldsName
        {
            public static readonly string Num = "Num";
            public static readonly string Descript = "Descript";
            public static readonly string StepId = "StepId";
            public static readonly string CloPrcnt = "CloPrcnt";
            public static readonly string Canceled = "Canceled";
            public static readonly string UserSign = "UserSign";
            public static readonly string SalesStage = "SalesStage";
            public static readonly string PurStage = "PurStage";
        }

        public struct Description
        {
            public static readonly string Num = "Num";
            public static readonly string Descript = "Nome";
            public static readonly string StepId = "Nº do Nível";
            public static readonly string CloPrcnt = "Porcentagem Final";
            public static readonly string Canceled = "Cancelado";
            public static readonly string UserSign = "Usuário";
            public static readonly string SalesStage = "Vendas";
            public static readonly string PurStage = "Compras";
        }

        private readonly TableAdapterField _num = new TableAdapterField(FieldsName.Num,
            Description.Num,
            DbType.Int32,
            11,
            0,
            true,
            false);
        private readonly TableAdapterField _descript = new TableAdapterField(FieldsName.Descript, Description.Descript, 100);
        
        private readonly TableAdapterField _stepId = new TableAdapterField(FieldsName.StepId,
            Description.StepId,
            DbType.Int16);

        private readonly TableAdapterField _cloPrcnt = new TableAdapterField(FieldsName.CloPrcnt,
            Description.CloPrcnt,
            DbType.Decimal);

        private readonly TableAdapterField _canceled = new TableAdapterField(FieldsName.Canceled,
            Description.Canceled,
            1);

        private readonly TableAdapterField _userSign = new TableAdapterField(FieldsName.UserSign,
            Description.UserSign,
            DbType.Int16);

        private readonly TableAdapterField _salesStage = new TableAdapterField(FieldsName.SalesStage,
            Description.SalesStage,
            1);

        private readonly TableAdapterField _purStage = new TableAdapterField(FieldsName.PurStage,
            Description.PurStage,
            1);

        public OpportunityStage()
            : base("OOST")
        {
        }

        public OpportunityStage(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public OpportunityStage(OpportunityStage pOpportunityStage)
            : this()
        {
            CopyBy(pOpportunityStage);
        }

        public int Num
        {
            get { return _num.GetInt32(); }
            set { _num.Value = value; }
        }

        public string Descript
        {
            get { return _descript.GetString(); }
            set { _descript.Value = value; }
        }

        public short StepId
        {
            get { return _stepId.GetInt16(); }
            set { _stepId.Value = value; }
        }


        public decimal CloPrcnt
        {
            get { return _cloPrcnt.GetDecimal(); }
            set { _cloPrcnt.Value = value; }
        }

        public string Canceled
        {
            get { return _canceled.GetString(); }
            set { _canceled.Value = value; }
        }
        
        public eYesNo CanceledEnum
        {
            get { return (eYesNo) _canceled.GetChar(); }
            set { _canceled.Value = value.To<char>(); }
        }

        public short UserSign
        {
            get { return _userSign.GetInt16(); }
            set { _userSign.Value = value; }
        }

        public string SalesStage
        {
            get { return _salesStage.GetString(); }
            set { _salesStage.Value = value; }
        }
        
        public eYesNo SalesStageEnum
        {
            get { return (eYesNo) _salesStage.GetChar(); }
            set { _salesStage.Value = value.To<char>(); }
        }

        public string PurStage
        {
            get { return _purStage.GetString(); }
            set { _purStage.Value = value; }
        }
        
        public eYesNo PurStageEnum
        {
            get { return (eYesNo) _purStage.GetChar(); }
            set { _purStage.Value = value.To<char>(); }
        }

        public bool GetByKey(int pNum)
        {
            Num = pNum;
            return base.GetByKey();
        }

        public List<OpportunityStage> GetAll()
        {
            return FillCollection<OpportunityStage>();
        }
        
        public OpportunityStage GetByNum(int pNum)
        {
            var tableQuery = new TableQuery(this);

            tableQuery.Where.Add(new QueryParam(_num, pNum));
            return FillCollection<OpportunityStage>(GetData(tableQuery).Rows).FirstOrDefault(); 
        }

        public OpportunityStage GetBy(int pNum,int pStepId,string pDescript)
        {
            var tableQuery = new TableQuery(this);
            if (pNum > 0)
                tableQuery.Where.Add(new QueryParam(_num, pNum));

            if (pStepId > 0)
                tableQuery.Where.Add(new QueryParam(_stepId, pStepId));

            if (pDescript != string.Empty)
                tableQuery.Where.Add(new QueryParam(_descript, pDescript));

            return FillCollection<OpportunityStage>(GetData(tableQuery).Rows).FirstOrDefault(); 
        }
    }
}

