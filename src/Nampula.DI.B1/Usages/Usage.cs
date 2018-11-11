using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;
using Nampula.DI.B1;
using Nampula.DI.B1.Documents;

namespace Nampula.DI.B1.Usages {

    public class Usage : TableAdapter {

        public struct FieldsName {
            public static readonly  string ID = "ID";
            public static readonly  string Usage = "Usage";
            public static readonly  string TaxOnly = "TaxOnly";
        }

        public struct Description {
            public static readonly  string ID = "Utilização";
            public static readonly  string Usage = "Descrição";
            public static readonly  string TaxOnly = "Somente Imposto";
        }

        TableAdapterField m_ID = new TableAdapterField ( FieldsName.ID, Description.ID, DbType.Int32, 11, null, true, false );
        TableAdapterField m_Usage = new TableAdapterField ( FieldsName.Usage, Description.Usage, 40 );
        TableAdapterField m_TaxOnly = new TableAdapterField ( FieldsName.TaxOnly, Description.TaxOnly, 1 );

        public Usage ()
            : base ( "OUSG" ) {
        }

        public Usage ( string pCompanyDb )
            : this ( ) {
            this.DBName = pCompanyDb;
        }

        public Usage ( Usage pUsage )
            : this ( pUsage.DBName ) {

            this.CopyBy ( pUsage );

        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public int ID {
            get { return m_ID.GetInt32 ( ); }
            set { m_ID.Value = value; }
        }

        public string UsageName {
            get { return m_Usage.GetString ( ); }
            set { m_Usage.Value = value; }
        }

        public eYesNo TaxOnly {
            get { return m_TaxOnly.GetString ( ).ToYesNoEnum ( ); }
            set { m_TaxOnly.Value = value.ToYesNoString(); }
        }

        public List<Usage> GetAll () {
            return FillCollection<Usage> ( );
        }

        public bool GetByKey ( int pID ) {
            this.ID = pID;
            return base.GetByKey ( );
        }

        //public IEnumerable<Usage> GetByTrans ( eTransactionType eTransactionType ) {

        //    TableQuery myQuery = new TableQuery ( this );


        //}
    }
}
