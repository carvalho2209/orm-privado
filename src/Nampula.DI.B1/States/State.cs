using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;


namespace Nampula.DI.B1.States {

    /// <summary>
    /// Estados
    /// </summary>
    public class State : TableAdapter {

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName {
            public static readonly  string Code = "Code";
            public static readonly  string Country = "Country";
            public static readonly  string Name = "Name";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description {
            public static readonly  string Code = "Código";
            public static readonly  string Country = "País";
            public static readonly  string Name = "Nome";
        }


        /// <summary>
        /// Definição da Tabela
        /// </summary>
        public struct Definition {
            public static readonly  string TableName = "OCST";
        }


        TableAdapterField m_Code = new TableAdapterField ( FieldsName.Code, Description.Code, System.Data.DbType.String, 3, null, true, false );
        TableAdapterField m_Country = new TableAdapterField ( FieldsName.Country, Description.Country, System.Data.DbType.String, 3, null, true, false );
        TableAdapterField m_Name = new TableAdapterField ( FieldsName.Name, Description.Name, 100 );

        public State ()
            : base ( Definition.TableName ) {
        }

        public State ( string pCompanyDb )
            : this ( ) {
            this.DBName = pCompanyDb;
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string Code {
            get { return m_Code.GetString ( ); }
            set { m_Code.Value = value; }
        }

        public string Country {
            get { return m_Country.GetString ( ); }
            set { m_Country.Value = value; }
        }

        public string Name {
            get { return m_Name.GetString ( ); }
            set { m_Name.Value = value; }
        }

        public bool GetByKey ( string Code, string Country ) {
            this.Code = Code;
            this.Country = Country;
            return this.GetByKey ( );
        }

        public List<State> GetAll () {
            return FillCollection<State> ( );
        }

        public List<State> GetByCountry ( string pCountry ) {

            TableQuery myTableQuery = new TableQuery ( this );
            QueryParam myQueryParam = new QueryParam ( m_Country, pCountry );

            myTableQuery.Where.Add ( myQueryParam );

            return FillCollection<State> ( myTableQuery );

        }

    }

}
