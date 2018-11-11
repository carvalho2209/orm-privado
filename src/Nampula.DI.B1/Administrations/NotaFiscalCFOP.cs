using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.Administrations
{

    /// <summary>
    /// CFOP para Nota Fiscal
    /// </summary>
    public class NotaFiscalCFOP : TableAdapter
    {
        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCFP";
        }

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string Code = "Code";
            public static readonly string Descrip = "Descrip";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {
            public static readonly string Code = "Código de CFOP";
            public static readonly string Descrip = "Descrição";
        }

#pragma warning disable 649
        TableAdapterField m_Code = new TableAdapterField( FieldsName.Code, Description.Code, DbType.String, 6, null, true, false );
        TableAdapterField m_Descrip = new TableAdapterField( FieldsName.Descrip, Description.Descrip, 100 );
#pragma warning restore 649

        /// <summary>
        /// Paises
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public NotaFiscalCFOP ( )
            : base( Definition.TableName )
        {
        }

        /// <summary>
        /// Paises
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public NotaFiscalCFOP ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string Code
        {
            get { return m_Code.GetString( ); }
            set { m_Code.Value = value; }
        }

        public string Descrip
        {
            get { return m_Descrip.GetString( ); }
            set { m_Descrip.Value = value; }
        }

        public bool GetByKey ( string Code )
        {
            this.Code = Code;
            return this.GetByKey( );
        }

        public List<NotaFiscalCFOP> GetAll ( )
        {
            return FillCollection<NotaFiscalCFOP>( );
        }
    }
}
