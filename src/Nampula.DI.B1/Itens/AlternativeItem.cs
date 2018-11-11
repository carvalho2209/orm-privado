using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.Itens
{
    /// <summary>
    /// Gerencia a tabela de itens alternativis
    /// </summary>
    public class AlternativeItem : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OALI";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string OrigItem = "OrigItem";
            public static readonly string AltItem = "AltItem";
            public static readonly string Match = "Match";
            public static readonly string Remarks = "Remarks";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string OrigItem = "N. do Item";
            public static readonly string AltItem = "N. do Item";
            public static readonly string Match = "Fator";
            public static readonly string Remarks = "Observações";
        }
        

        

        TableAdapterField m_OrigItem = new TableAdapterField( FieldsName.OrigItem, FieldsDescription.OrigItem, DbType.String, 40, 0, true, false );
        TableAdapterField m_AltItem = new TableAdapterField( FieldsName.AltItem, FieldsDescription.AltItem, DbType.String, 40, 0, true, false );
        TableAdapterField m_Match = new TableAdapterField( FieldsName.Match, FieldsDescription.Match, DbType.Decimal );
        TableAdapterField m_Remarks = new TableAdapterField( FieldsName.Remarks, FieldsDescription.Remarks, 50 );

        

        

        

        public AlternativeItem ( )
            : base( Definition.TableName )
        {
        }

        public AlternativeItem ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public AlternativeItem ( AlternativeItem pAlternativeItem )
            : this( )
        {
            this.CopyBy( pAlternativeItem );
        }

        

        

        public string OrigItem
        {
            get { return m_OrigItem.GetString( ); }
            set { m_OrigItem.Value = value; }
        }

        public string AltItem
        {
            get { return m_AltItem.GetString( ); }
            set { m_AltItem.Value = value; }
        }

        public Decimal Match
        {
            get { return m_Match.GetDecimal( ); }
            set { m_Match.Value = value; }
        }

        public string Remarks
        {
            get { return m_Remarks.GetString( ); }
            set { m_Remarks.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( string pOrigItem, string pAltItem )
        {
            this.OrigItem = pOrigItem;
            this.AltItem = pAltItem;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de AlternativeItem.</returns>
        public List<AlternativeItem> GetAll ( )
        {
            return FillCollection<AlternativeItem>( this.GetData( ).Rows );
        }
        

        
    }
}
