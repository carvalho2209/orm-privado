using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1
{
    public class CompanyDb : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string dbName = "dbName";
            public static readonly string cmpName = "cmpName";
        }

        public struct Description
        {
            public static readonly string dbName = "Banco de Dados";
            public static readonly string cmpName = "Nome da empresa";
        }

        private TableAdapterField m_dbName = new TableAdapterField( FieldsName.dbName, Description.dbName, DbType.String, 100, "", true, false );
        private TableAdapterField m_cmpName = new TableAdapterField( FieldsName.cmpName, Description.cmpName, 100 );

        public CompanyDb ( string pCompanyDb )
            : base( "SBO-COMMON", "SRGC" )
        {
            Connection.SqlServerExecute( "[SBO-COMMON]..[TmSp_GetCompList]" );
            dbName = pCompanyDb;
        }

        public CompanyDb ( )
            : base( "SBO-COMMON", "SRGC" )
        {
            Connection.SqlServerExecute( "[SBO-COMMON]..[TmSp_GetCompList]" );
        }

        public CompanyDb ( bool pNoUpdate )
            : base( "SBO-COMMON", "SRGC" )
        {
        }

        public string dbName
        {
            get { return m_dbName.GetString( ); }
            private set { m_dbName.Value = value; }
        }

        public string cmpName
        {
            get { return m_cmpName.GetString( ); }
        }

        public bool GetByKey ( string dbName )
        {
            this.dbName = dbName;
            return this.GetByKey( );
        }


        //public CompanyDbCollection GetCompanies () {
        //    return new CompanyDbCollection ( GetData ( ) );
        //}

        public List<CompanyDb> GetAll ( )
        {
            return FillCollection<CompanyDb>( new TableQuery( this ) );
        }

    }
}
