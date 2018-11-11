using System;
using System.Collections.Generic;
using System.Text;
using Nampula.DI;
using System.Data;

namespace IntegrationBank.DI.General {
    public class PaymentMethods : TableAdapter {
        public struct FieldsName {
            public static readonly  string PayMethCod = "PayMethCod";
            public static readonly  string Descript = "Descript";
            public static readonly  string Type = "Type";
            public static readonly  string BankTransf = "BankTransf";
            public static readonly  string Address = "Address";
            public static readonly  string BankDet = "BankDet";
            public static readonly  string CllctAutor = "CllctAutor";
            public static readonly  string BnkDflt = "BnkDflt";
            public static readonly  string DflAccount = "DflAccount";
            public static readonly  string Branch = "Branch";
            //...
        }

        TableAdapterField m_PayMethCod = new TableAdapterField ( 0, FieldsName.PayMethCod, null, DbType.String, 15, null, true, false );
        TableAdapterField m_Descript = new TableAdapterField ( 0, FieldsName.Descript, null, 100 );
        TableAdapterField m_Type = new TableAdapterField ( 0, FieldsName.Type, null, 1 );
        TableAdapterField m_BankTransf = new TableAdapterField ( 0, FieldsName.BankTransf, null, 1 );
        TableAdapterField m_Address = new TableAdapterField ( 0, FieldsName.Address, null, 1 );
        TableAdapterField m_BankDet = new TableAdapterField ( 0, FieldsName.BankDet, null, 1 );
        TableAdapterField m_CllctAutor = new TableAdapterField ( 0, FieldsName.CllctAutor, null, 1 );
        TableAdapterField m_BnkDflt = new TableAdapterField ( 0, FieldsName.BnkDflt, null, 30 );
        TableAdapterField m_DflAccount = new TableAdapterField ( 0, FieldsName.DflAccount, null, 30 );
        TableAdapterField m_Branch = new TableAdapterField ( 0, FieldsName.Branch, null, 50 );

        public PaymentMethods ()
            : base ( "OPYM" ) {

        }

        public string PayMethCode {
            get { return m_PayMethCod.GetString ( ); }
            set { m_PayMethCod.Value = value; }
        }

        public string Descript {
            get { return m_Descript.GetString ( ); }
            set { m_Descript.Value = value; }
        }

        public string Type {
            get { return m_Type.GetString ( ); }
            set { m_Type.Value = value; }
        }

        public string BankTransf {
            get { return m_BankTransf.GetString ( ); }
            set { m_BankTransf.Value = value; }
        }

        public string Address {
            get { return m_Address.GetString ( ); }
            set { m_Address.Value = value; }
        }

        public string CllctAutor {
            get { return m_CllctAutor.GetString ( ); }
            set { m_CllctAutor.Value = value; }
        }

        /// <summary>
        /// Código do Banco
        /// </summary>
        public string BnkDflt {
            get { return m_BnkDflt.GetString ( ); }
            set { m_BnkDflt.Value = value; }
        }

        /// <summary>
        /// Conta corrente
        /// </summary>
        /// <param name="pID"></param>        
        public string DflAccount {
            get { return m_DflAccount.GetString ( ); }
            set { m_DflAccount.Value = value; }
        }

        /// <summary>
        /// Agência
        /// </summary>
        /// <param name="Agência"></param>
        /// <returns>Código da agência</returns>
        public string Branch {
            get { return m_Branch.GetString ( ); }
            set { m_Branch.Value = value; }
        }

        public bool GetByKey ( string pID ) {
            this.PayMethCode = pID;
            return GetByKey ( );
        }

        public override bool Add () {
            return false;
        }

        public override bool Update () {
            return false;
        }
    }
}
