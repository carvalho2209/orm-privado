using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.Manufacturers
{
    /// <summary>
    /// Classe para gerenciamento de fabricantes
    /// </summary>
    public class Manufacturer : TableAdapter
    {
        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OMRC";
        }

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string FirmCode = "FirmCode";
            public static readonly string FirmName = "FirmName";
        }
        
        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string FirmCode = "Código";
            public static readonly string FirmName = "Fabricante";
        }

        TableAdapterField m_FirmCode = new TableAdapterField( FieldsName.FirmCode, FieldsDescription.FirmCode, DbType.Int32, 6, 0, true, false );
        TableAdapterField m_FirmName = new TableAdapterField( FieldsName.FirmName, FieldsDescription.FirmName, 32 );


        public Manufacturer ( )
            : base( Definition.TableName  )
        {
        }

        public Manufacturer ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public Manufacturer ( Manufacturer pManufacturer )
            : this( pManufacturer.DBName )
        {
            this.CopyBy( pManufacturer );
        }

        public int FirmCode
        {
            get { return m_FirmCode.GetInt32( ); }
            set { m_FirmCode.Value = value; }
        }
        public string FirmName
        {
            get { return m_FirmName.GetString( ); }
            set { m_FirmName.Value = value; }
        }

        public bool GetByKey ( int pFirmCode )
        {
            this.FirmCode = pFirmCode;
            return base.GetByKey( );
        }

        public List<Manufacturer> GetAll ( )
        {
            TableQuery myQuery = new TableQuery( this );
            return FillCollection<Manufacturer>( GetData( myQuery ).Rows );
        }
    }
}
