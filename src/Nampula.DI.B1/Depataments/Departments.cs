using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.Departments
{
    public class Department : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
        }

        public struct Description
        {
            public static readonly string Code = "Code";
            public static readonly string Name = "Name";
        }

        public struct Definition
        {
            public static readonly string TableName = "OUDP";
        }

        private TableAdapterField m_Code = new TableAdapterField( FieldsName.Code, null, DbType.Int16, 10, null, true, false );
        private TableAdapterField m_Name = new TableAdapterField( FieldsName.Name, null, 20 );

        public Department ( )
            : base( Definition.TableName )
        {
        }

        /// <summary>
        /// Administração
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public Department ( string pCompanyDb )
            : this( )
        {

            this.DBName = pCompanyDb;
        }

        public Department ( Department pDepartments )
            : this( )
        {

            this.CopyBy( pDepartments );
        }

        public short Code
        {
            get { return m_Code.GetInt16( ); }
            set { m_Code.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString( ); }
            set { m_Name.Value = value; }
        }

        public bool GetByKey ( short Code )
        {
            this.Code = Code;
            return base.GetByKey( );
        }

    }
}
