using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.PaymentMethods {

    public class PaymentMethod : TableAdapter {

        public struct FieldsName {
            public static readonly  string PayMethCod = "PayMethCod";
            public static readonly  string Descript = "Descript";
            public static readonly  string Type = "Type";
            public static readonly  string BankTransf = "BankTransf";
            public static readonly  string CllctAutor = "CllctAutor";

            public static readonly  string Address = "Address";
            public static readonly  string BankDet = "BankDet";
            public static readonly  string BnkDflt = "BnkDflt";
            public static readonly  string DflAccount = "DflAccount";
            public static readonly  string Branch = "Branch";
        }

        public struct Description {
            public static readonly  string PayMethCod = "PayMethCod";
            public static readonly  string Descript = "Descript";
            public static readonly  string Type = "Type";
            public static readonly  string BankTransf = "BankTransf";
            public static readonly  string CllctAutor = "CllctAutor";

            public static readonly  string Address = "Address";
            public static readonly  string BankDet = "BankDet";
            public static readonly  string BnkDflt = "BnkDflt";
            public static readonly  string DflAccount = "DflAccount";
            public static readonly  string Branch = "Branch";

        }

        public struct Definition {
            public static readonly  string TableName = "OPYM";
        }

        TableAdapterField m_PayMethCod = new TableAdapterField ( FieldsName.PayMethCod, Description.PayMethCod, DbType.String, 10, 0, true, false );
        TableAdapterField m_Descript = new TableAdapterField ( FieldsName.Descript, Description.Descript, 100 );
        TableAdapterField m_Type = new TableAdapterField ( FieldsName.Type, Description.Type, 1 );
        TableAdapterField m_BankTransf = new TableAdapterField ( FieldsName.BankTransf, Description.BankTransf, 1 );
        TableAdapterField m_CllctAutor = new TableAdapterField ( FieldsName.CllctAutor, Description.CllctAutor, 1 );
        TableAdapterField m_Address = new TableAdapterField ( FieldsName.Address, null, 1 );
        TableAdapterField m_BankDet = new TableAdapterField ( FieldsName.BankDet, null, 1 );
        TableAdapterField m_BnkDflt = new TableAdapterField ( FieldsName.BnkDflt, null, 30 );
        TableAdapterField m_DflAccount = new TableAdapterField ( FieldsName.DflAccount, null, 30 );
        TableAdapterField m_Branch = new TableAdapterField ( FieldsName.Branch, null, 50 );


        public PaymentMethod ( string pCompanyDb )
            : base ( pCompanyDb, Definition.TableName ) {
        }

        public PaymentMethod ()
            : base ( Definition.TableName ) {
        }

        public string PayMethCod {
            get { return m_PayMethCod.GetString ( ); }
            set { m_PayMethCod.Value = value; }
        }

        public string Descript {
            get { return m_Descript.GetString ( ); }
            set { m_Descript.Value = value; }
        }

        public ePayType Type {
            get { return m_Type.GetString ( ).ToPayTypeEnum ( ); }
            set { m_Type.Value = value.ToPayTypeString ( ); }
        }

        public eBankTransf BankTransf {
            get { return m_BankTransf.GetString ( ).ToBankTransfEnum ( ); }
            set { m_BankTransf.Value = value.ToBankTransfString ( ); }
        }

        public eYesNo CllctAutor {
            get { return m_CllctAutor.GetString ( ).ToYesNoEnum ( ); }
            set { m_CllctAutor.Value = value.ToYesNoString ( ); }
        }

        public string Address {
            get { return m_Address.GetString ( ); }
            set { m_Address.Value = value; }
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

        /// <summary>
        /// Pegar um registro pela chave
        /// </summary>
        /// <param name="pPayMethCod">Código do Meior de Pagamento</param>
        /// <returns>true se achar, false se não achar</returns>
        public bool GetByKey ( string pPayMethCod ) {
            this.PayMethCod = pPayMethCod;
            return base.GetByKey ( );
        }

        public List<PaymentMethod> GetAll () {
            return FillCollection<PaymentMethod> ( );
        }

        public List<PaymentMethod> GetByTransaction ( eBankTransf pBankTransf, ePayType pePayType ) {

            TableQuery myQuery = new TableQuery ( this );

            myQuery.Where.Add ( new QueryParam ( m_BankTransf, pBankTransf.ToBankTransfString ( ) ) );
            myQuery.Where.Add ( new QueryParam ( m_Type, pePayType.ToPayTypeString ( ) ) );

            return FillCollection<PaymentMethod> ( myQuery );
        }

        public List<PaymentMethod> GetByTransaction ( ePayType pePayType ) {

            TableQuery myQuery = new TableQuery ( this );

            myQuery.Where.Add ( new QueryParam ( m_Type, pePayType.ToPayTypeString ( ) ) );

            return FillCollection<PaymentMethod> ( GetData ( myQuery ).Rows );
        }

        public List<PaymentMethod> GetByTransaction ( string pPayMethCod, ePayType pePayType ) {

            TableQuery myQuery = new TableQuery ( this );

            myQuery.Where.Add ( new QueryParam ( m_Type, pePayType.ToPayTypeString ( ) ) );
            myQuery.Where.Add ( new QueryParam ( m_PayMethCod, pPayMethCod ) );

            return FillCollection<PaymentMethod> ( GetData ( myQuery ).Rows );
        }

    }
}
