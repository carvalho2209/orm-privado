using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.FinancialTemplates
{
    public class FinancialReportTemplate : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OFRT";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string AbsID = "AbsID";
            public static readonly string Name = "Name";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string AbsID = "Código";
            public static readonly string Name = "Descrição";
        }
        

        

        TableAdapterField m_AbsID = new TableAdapterField( FieldsName.AbsID, FieldsDescription.AbsID, DbType.Int32, 11, 0, true, false );
        TableAdapterField m_Name = new TableAdapterField( FieldsName.Name, FieldsDescription.Name, 100 );

        

        

        

        public FinancialReportTemplate ( )
            : base( Definition.TableName )
        {
        }

        public FinancialReportTemplate ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public FinancialReportTemplate ( FinancialReportTemplate pFinancialReportTemplate )
            : this( )
        {
            this.CopyBy( pFinancialReportTemplate );
        }

        

        

        public int AbsID
        {
            get { return m_AbsID.GetInt32( ); }
            set { m_AbsID.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString( ); }
            set { m_Name.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pAbsID )
        {
            this.AbsID = pAbsID;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de FinancialReportTemplate.</returns>
        public List<FinancialReportTemplate> GetAll ( )
        {
            return FillCollection<FinancialReportTemplate>( this.GetData( ).Rows );
        }
        

        
    }
}
