using System.Collections.Generic;
using System.Data;


namespace Nampula.DI.B1.Counties {


    /// <summary>
    /// Municipios 
    /// </summary>
    public class County : TableAdapter {

        /// <summary>
        /// Nome dos campos 
        /// </summary>
        public struct FieldsName {

            public static readonly  string AbsId = "AbsId";

            public static readonly  string Code = "Code";
            public static readonly  string Country = "Country";
            public static readonly  string State = "State";
            public static readonly  string Name = "Name";
            public static readonly  string TaxZone = "TaxZone";
            public static readonly  string IbgeCode = "IbgeCode";
            public static readonly  string GiaCode = "GiaCode";

        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description {

            public static readonly string AbsId = "Código Interno";

            public static readonly string Code = "Código";
            public static readonly string Country = "País";
            public static readonly string State = "Estado";
            public static readonly string Name = "Município";
            public static readonly string TaxZone = "Zona France de Manaus";
            public static readonly string IbgeCode = "Código IBGE";
            public static readonly string GiaCode = "GiaCode";

        }

        /// <summary>
        /// Definição das Tabelas
        /// </summary>
        public struct Definition {

            public static readonly  string TableName = "OCNT";

        }

        TableAdapterField m_AbsID = new TableAdapterField ( FieldsName.AbsId, Description.AbsId, DbType.Int32, 11, null, true, false );
        TableAdapterField m_Code = new TableAdapterField ( FieldsName.Code, Description.Code, 100 );
        TableAdapterField m_Country = new TableAdapterField ( FieldsName.Country, Description.Country, 3 );
        TableAdapterField m_State = new TableAdapterField ( FieldsName.State, Description.State, 3 );
        TableAdapterField m_Name = new TableAdapterField ( FieldsName.Name, Description.Name, 32 );
        TableAdapterField m_TaxZone = new TableAdapterField ( FieldsName.TaxZone, Description.TaxZone, 1 );
        TableAdapterField m_IbgeCode = new TableAdapterField ( FieldsName.IbgeCode, Description.IbgeCode, 20 );
        TableAdapterField m_GiaCode = new TableAdapterField ( FieldsName.GiaCode, Description.GiaCode, 20 );

        public County ()
            : base ( Definition.TableName ) {
        }

        /// <summary>
        /// Administração
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public County ( string pCompanyDb )
            : this ( ) {

            this.DBName = pCompanyDb;
        }

        public County ( County pCounty )
            : this ( ) {

            this.CopyBy ( pCounty );
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }


        public int AbsID {
            get { return m_AbsID.GetInt32 ( ); }
            set { m_AbsID.Value = value; }
        }

        public string Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }


        public string Country {
            get { return m_Country.GetString ( ); }
            set { m_Country.Value = value; }
        }

        public string State {
            get { return m_State.GetString ( ); }
            set { m_State.Value = value; }
        }

        public string Name {
            get { return m_Name.GetString ( ); }
            set { m_Name.Value = value; }
        }

        public bool TaxZone {
            get { return m_TaxZone.GetString ( ) == "Y"; }
            set { m_TaxZone.Value = value ? "Y" : "N"; }
        }

        public string IbgeCode {
            get { return m_IbgeCode.GetString ( ); }
            set { m_IbgeCode.Value = value; }
        }

        public string GiaCode {
            get { return m_GiaCode.GetString ( ); }
            set { m_GiaCode.Value = value; }
        }

        public bool GetByKey ( int AbsID ) {
            this.AbsID = AbsID;
            return this.GetByKey ( );
        }

        //public bool GetByKey(Int32 AbsID) {
        //    TableQueryCollection myTableQueryCollection = new TableQueryCollection();
        //    TableQuery myTableQuery = new TableQuery();
        //    QueryParam myAbsID = new QueryParam();

        //    myAbsID.FieldName = m_AbsID.Name;
        //    myAbsID.DbType = m_AbsID.SqlType;
        //    myAbsID.Condition = QueryParam.eCondition.ecEqual;
        //    myAbsID.Value1 = AbsID;

        //    myTableQuery.TableName = this.TableName;
        //    myTableQuery.FieldName = m_AbsID.Name;
        //    myTableQuery.Add(myAbsID);

        //    myTableQueryCollection.Add(myTableQuery);

        //    System.Data.DataTable myData = this.GetData(myTableQueryCollection);
        //    CountryCollection myCollection = new CountryCollection();

        //    if (myData.Rows.Count > 0) {
        //        this.FillFields(myData.Rows[0]);
        //        return true;
        //    }
        //    else {
        //        return false;
        //    }
        //}

        public List<County> GetByState ( string pCountry, string pState ) {

            TableQuery myTableQuery = new TableQuery ( this );
            myTableQuery.Where.Add ( new QueryParam ( m_Country, pCountry ) );
            myTableQuery.Where.Add ( new QueryParam ( m_State, pState ) );

            return FillCollection<County> ( myTableQuery );
        }

        public List<County> GetAll () {
            return FillCollection<County> ( );
        }


        public bool GetByIBGECode ( string pIbgeCode ) {

            TableQuery myTableQuery = new TableQuery ( this );
            myTableQuery.Where.Add ( new QueryParam ( m_IbgeCode, pIbgeCode ) );

            DataTable myData = GetData ( myTableQuery );

            if ( myData.Rows.Count > 0 ) {
                this.FillFields ( myData.Rows[0] );
                return true;
            }
            else {
                return false;
            }
        }
    }

}
