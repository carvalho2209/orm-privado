using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.ChartOfAccounts {

    public class ChartOfAccount : TableAdapter {

        public struct FieldsName {
            public static readonly string AcctCode  = "AcctCode";
            public static readonly string AcctName  = "AcctName";
            public static readonly string Postable  = "Postable";
            public static readonly string Finanse  = "Finanse";
            public static readonly string CurrTotal  = "CurrTotal";
            public static readonly string AccntntCod = "AccntntCod";
            public static readonly string LocManTran = "LocManTran";
            public static readonly string BPLId = "BPLId";
        }

        public struct Description {
            public static readonly string AcctCode  = "Conta Contábil";
            public static readonly string AcctName  = "Nome";
            public static readonly string Postable  = "Conta ativa";
            public static readonly string Finanse  = "Conta Caixa";
            public static readonly string CurrTotal  = "Saldo";
            public static readonly string AccntntCod = "Código Externo";
            public static readonly string LocManTran = "Conta controle";
            public static readonly string BPLId = "BPLId";
        }

        public struct Definition {
            public static readonly string TableName  = "OACT";
        }

        TableAdapterField m_AcctCode = new TableAdapterField (FieldsName.AcctCode, Description.AcctCode, DbType.String, 15, null, true, false );
        TableAdapterField m_AcctName = new TableAdapterField (FieldsName.AcctName, Description.AcctName, 100 );
        TableAdapterField m_Postable = new TableAdapterField (FieldsName.Postable, Description.Postable, 1 );
        TableAdapterField m_Finanse = new TableAdapterField (FieldsName.Finanse, Description.Finanse, 1 );
        TableAdapterField m_CurrTotal = new TableAdapterField (FieldsName.CurrTotal, Description.CurrTotal, 1 );
        TableAdapterField m_AccntntCod = new TableAdapterField(FieldsName.AccntntCod, Description.AccntntCod, 12);
        TableAdapterField m_LocManTran = new TableAdapterField(FieldsName.LocManTran, Description.LocManTran, 1);
        TableAdapterField m_BPLId = new TableAdapterField(FieldsName.BPLId, Description.BPLId, DbType.Int32);

        public ChartOfAccount ()
            : base ( Definition.TableName ) { }

        public ChartOfAccount ( string pCompanyDb )
            : this ( ) {
            this.DBName = pCompanyDb;
        }

        public string AcctCode {
            get { return m_AcctCode.GetString ( ); }
            set { m_AcctCode.Value = value; }
        }

        public string AcctName {
            get { return m_AcctName.GetString ( ); }
            set { m_AcctName.Value = value; }
        }

        public eYesNo Postable {
            get { return m_Postable.GetString ( ).ToYesNoEnum ( ); }
            set { m_Postable.Value = value.ToYesNoString ( ); }
        }

        public eYesNo LocManTran
        {
            get { return m_LocManTran.GetString().ToYesNoEnum(); }
            set { m_LocManTran.Value = value.ToYesNoString(); }
        }

        public Int32 BPLId
        {
            get { return m_BPLId.GetInt32(); }
            set { m_BPLId.Value = value; }
        }

        public eYesNo Finanse {
            get { return m_Finanse.GetString ( ).ToYesNoEnum ( ); }
            set { m_Finanse.Value = value.ToYesNoString ( ); }
        }

        public Decimal CurrTotal {
            get { return m_CurrTotal.GetDecimal ( ); }
            set { m_CurrTotal.Value = value; }
        }

        public String AccntntCod
        {
            get { return m_AccntntCod.GetString(); }
            set { m_AccntntCod.Value = value; }
        }


        public bool GetByKey ( string pAcctCode ) {
            this.AcctCode = pAcctCode;
            return base.GetByKey ( );
        }

    }

}
