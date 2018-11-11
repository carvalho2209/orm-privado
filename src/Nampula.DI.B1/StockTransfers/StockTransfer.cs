using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;
using Nampula.DI.B1.Helpers;

namespace Nampula.DI.B1.StockTransfers
{

    /// <summary>
    /// Classe para gerenciamento da tabela do SAP : OWTR
    /// </summary>
    public class StockTransfer : TableAdapter
    {
        
        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OWTR";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>ss
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string CardCode = "CardCode";
            public static readonly string Filler = "Filler";
            public static readonly string Comments = "Comments";
            public static readonly string Ref1 = "Ref1";
            public static readonly string Ref2 = "Ref2";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "N. Doc";
            public static readonly string CardCode = "Código Parceiro";
            public static readonly string Filler = "Depósito Origem";
            public static readonly string Comments = "Observações";
            public static readonly string Ref1 = "Referência 1";
            public static readonly string Ref2 = "Referência 2";
        }
        

        

        TableAdapterField m_DocEntry = new TableAdapterField( FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, true );
        TableAdapterField m_CardCode = new TableAdapterField( FieldsName.CardCode, FieldsDescription.CardCode, 15 );
        TableAdapterField m_Filler = new TableAdapterField( FieldsName.Filler, FieldsDescription.Filler, 8 );
        TableAdapterField m_Comments = new TableAdapterField( FieldsName.Comments, FieldsDescription.Comments, 254 );
        TableAdapterField m_Ref1 = new TableAdapterField( FieldsName.Ref1, FieldsDescription.Ref1, 11 );
        TableAdapterField m_Ref2 = new TableAdapterField( FieldsName.Ref2, FieldsDescription.Ref2, 11 );

        
        

        

        public StockTransfer ( )
            : base( Definition.TableName )
        {
            Lines = new List<StockTransferLine>( );
            OnAfterSelect += new TableAdapterEventHandler( StockTransfer_OnAfterSelect );
        }

        public StockTransfer ( string pCompanyDb )
            : this( )
        {
            DBName = pCompanyDb;
        }

        public StockTransfer ( StockTransfer pStockTransfer )
            : this( )
        {
            this.CopyBy( pStockTransfer );
        }

        void StockTransfer_OnAfterSelect ( object Sender, TableAdapterEventArgs e )
        {
            StockTransferLine line = new StockTransferLine( DBName );
            TableQuery query = new TableQuery( );

            query.Where.Add(
                new QueryParam(
                    line.Collumns[StockTransferLine.FieldsName.DocEntry],
                    this.DocEntry ) );

            Lines = line.FillCollection<StockTransferLine>( query );
        }

        

        

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32( ); }
            set { m_DocEntry.Value = value; }
        }

        public string CardCode
        {
            get { return m_CardCode.GetString( ); }
            set { m_CardCode.Value = value; }
        }

        public string Filler
        {
            get { return m_Filler.GetString( ); }
            set { m_Filler.Value = value; }
        }

        public string Comments
        {
            get { return m_Comments.GetString( ); }
            set { m_Comments.Value = value; }
        }

        public string Ref1
        {
            get { return m_Ref1.GetString( ); }
            set { m_Ref1.Value = value; }
        }

        public string Ref2
        {
            get { return m_Ref2.GetString( ); }
            set { m_Ref2.Value = value; }
        }

        public List<StockTransferLine> Lines { get; set; }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pDocEntry )
        {
            this.DocEntry = pDocEntry;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de StockTransfer.</returns>
        public List<StockTransfer> GetAll ( )
        {
            return FillCollection<StockTransfer>( this.GetData( ).Rows );
        }
        

        
    }

}
