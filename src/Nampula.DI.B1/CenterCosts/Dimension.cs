using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.CenterCosts
{
    /// <summary>
    /// Classe para gerenciamento da tabela de dimensioes
    /// </summary>
    public class Dimension : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ODIM";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DimCode = "DimCode";
            public static readonly string DimName = "DimName";
            public static readonly string DimActive = "DimActive";
            public static readonly string DimDesc = "DimDesc";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DimCode = "Código";
            public static readonly string DimName = "Nome";
            public static readonly string DimActive = "Ativo";
            public static readonly string DimDesc = "Descrição";
        }
        

        

        TableAdapterField m_DimCode = new TableAdapterField( FieldsName.DimCode, FieldsDescription.DimCode, DbType.Int16, 11, 0, true, false );
        TableAdapterField m_DimName = new TableAdapterField( FieldsName.DimName, FieldsDescription.DimName, 30 );
        TableAdapterField m_DimActive = new TableAdapterField( FieldsName.DimActive, FieldsDescription.DimActive, 1 );
        TableAdapterField m_DimDesc = new TableAdapterField( FieldsName.DimDesc, FieldsDescription.DimDesc, 100 );

        

        

        

        public Dimension ( )
            : base( Definition.TableName )
        {
        }

        public Dimension ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public Dimension ( Dimension pDimension )
            : this( )
        {
            this.CopyBy( pDimension );
        }

        

        

        public Int16 DimCode
        {
            get { return m_DimCode.GetInt16( ); }
            set { m_DimCode.Value = value; }
        }

        public string DimName
        {
            get { return m_DimName.GetString( ); }
            set { m_DimName.Value = value; }
        }

        public eYesNo DimActive
        {
            get { return m_DimActive.GetString( ).ToYesNoEnum( ); }
            set { m_DimActive.Value = value.ToYesNoString( ); }
        }

        public string DimDesc
        {
            get { return m_DimDesc.GetString( ); }
            set { m_DimDesc.Value = value; }
        }
        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( Int16 pDimCode )
        {
            this.DimCode = pDimCode;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de Dimension.</returns>
        public List<Dimension> GetAll ( )
        {
            return FillCollection<Dimension>( this.GetData( ).Rows );
        }
        

        
    }
}
