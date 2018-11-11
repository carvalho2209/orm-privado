using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.PeriodsCategory {

    public class PeriodCategory : TableAdapter {

        public struct FieldsName {
            public static readonly string AbsEntry ="AbsEntry";
            public static readonly string PeriodCat ="PeriodCat";
            /// <summary>
            /// Checks Received
            /// </summary>
            public static readonly string LinkAct_2 ="LinkAct_2";
            /// <summary>
            /// Domestic Accounts Payable ( Bill )
            /// </summary>
            public static readonly string LinkAct_10 ="LinkAct_10";

            /// <summary>
            /// CardCode
            /// </summary>
            public static readonly string DfltCard = "DfltCard";
        }

        public struct Description {
            public static readonly string AbsEntry ="Código";
            public static readonly string PeriodCat ="Periodo";
            /// <summary>
            /// Checks Received
            /// </summary>
            public static readonly string LinkAct_2 ="Conta Contábi de Cheque";
            /// <summary>
            /// Domestic Accounts Payable ( Bill )
            /// </summary>
            public static readonly string LinkAct_10 ="Conta Contábi de Boleto";

            /// <summary>
            /// 
            /// </summary>
            public static readonly string DfltCard = "Cliente padrão para nota fiscal de saída";
        }

        public struct Defintion {
            public static readonly string TableName ="OACP";
        }

        TableAdapterField m_AbsEntry = new TableAdapterField (FieldsName.AbsEntry, Description.AbsEntry, DbType.Int32, 10, null, true, true );
        TableAdapterField m_PeriodCat= new TableAdapterField (FieldsName.PeriodCat, Description.PeriodCat, 10 );
        TableAdapterField m_LinkAct_2 = new TableAdapterField (FieldsName.LinkAct_2, Description.LinkAct_2, 15 );
        TableAdapterField m_LinkAct_10 = new TableAdapterField (FieldsName.LinkAct_10, Description.LinkAct_10, 15 );
        TableAdapterField m_DfltCard = new TableAdapterField(FieldsName.DfltCard, Description.DfltCard, 15);                
                

        public PeriodCategory ()
            : base ( Defintion.TableName ) {
        }

        public PeriodCategory ( string pCompanyDb )
            : this ( ) {
            this.DBName = pCompanyDb;
        }

        public int AbsEntry {
            get { return m_AbsEntry.GetInt32 ( ); }
            set { m_AbsEntry.Value = value; }
        }

        public string PeriodCat {
            get { return m_PeriodCat.GetString ( ); }
            set { m_PeriodCat.Value = value; }
        }

        /// <summary>
        /// Checks Received
        /// </summary>
        public string LinkAct_2 {
            get { return m_LinkAct_2.GetString ( ); }
            set { m_LinkAct_2.Value = value; }
        }

        /// <summary>
        /// Domestic Accounts Payable ( Bill )
        /// </summary>
        public string LinkAct_10 {
            get { return m_LinkAct_10.GetString ( ); }
            set { m_LinkAct_10.Value = value; }
        }

        public String DfltCard
        {
            get { return m_DfltCard.GetString(); }
            set { m_DfltCard.Value = value; }
        }

        public List<PeriodCategory> GetByPeriodCat(string pPeriodCat)
        {
            TableQuery myTableQuery = new TableQuery(this);
            myTableQuery.Where.Add(new QueryParam(m_PeriodCat, pPeriodCat));

            return FillCollection<PeriodCategory>(myTableQuery);
        }

        public bool GetByKey ( int pAbsEntry ) {
            this.AbsEntry = pAbsEntry;
            return base.GetByKey ( );
        }

        /// <summary>
        /// Somente exist um periodo para essa tabela
        /// </summary>
        /// <returns></returns>
        public bool GetCurrentPeriod () {
            return GetByKey ( 1 );
        }


    }

}
