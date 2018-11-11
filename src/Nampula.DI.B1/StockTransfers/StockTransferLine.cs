using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.StockTransfers
{
    /// <summary>
    ///  Classe para gerenciamento da tabela do SAP : WTR1
    /// </summary>
    public class StockTransferLine : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "WTR1";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string Dscription = "Dscription";
            public static readonly string Quantity = "Quantity";
            public static readonly string WhsCode = "WhsCode";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "N. Doc";
            public static readonly string LineNum = "Linha";
            public static readonly string ItemCode = "Item";
            public static readonly string Dscription = "Descrição";
            public static readonly string Quantity = "Quantidade";
            public static readonly string WhsCode = "Depósito";
        }
        

        

        TableAdapterField m_DocEntry = new TableAdapterField( FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, false );
        TableAdapterField m_LineNum = new TableAdapterField( FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32, 11, 0, true, false );
        TableAdapterField m_ItemCode = new TableAdapterField( FieldsName.ItemCode, FieldsDescription.ItemCode, 40 );
        TableAdapterField m_Dscription = new TableAdapterField( FieldsName.Dscription, FieldsDescription.Dscription, 100 );
        TableAdapterField m_Quantity = new TableAdapterField( FieldsName.Quantity, FieldsDescription.Quantity, DbType.Decimal );
        TableAdapterField m_WhsCode = new TableAdapterField( FieldsName.WhsCode, FieldsDescription.WhsCode, 8 );

        

        

        

        public StockTransferLine ( )
            : base( Definition.TableName )
        {
        }

        public StockTransferLine ( string pCompanyDb )
            : this( )
        {
            DBName = pCompanyDb;
        }

        public StockTransferLine ( StockTransferLine pStockTransferLine )
            : this( )
        {
            this.CopyBy( pStockTransferLine );
        }

        

        

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32( ); }
            set { m_DocEntry.Value = value; }
        }

        public int LineNum
        {
            get { return m_LineNum.GetInt32( ); }
            set { m_LineNum.Value = value; }
        }

        public string ItemCode
        {
            get { return m_ItemCode.GetString( ); }
            set { m_ItemCode.Value = value; }
        }

        public string Dscription
        {
            get { return m_Dscription.GetString( ); }
            set { m_Dscription.Value = value; }
        }

        public decimal Quantity
        {
            get { return m_Quantity.GetDecimal( ); }
            set { m_Quantity.Value = value; }
        }

        public string WhsCode
        {
            get { return m_WhsCode.GetString( ); }
            set { m_WhsCode.Value = value; }
        }

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pDocEntry, int pLineNum )
        {
            this.DocEntry = pDocEntry;
            this.LineNum = pLineNum;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de StockTransferLine.</returns>
        public List<StockTransferLine> GetAll ( )
        {
            return FillCollection<StockTransferLine>( this.GetData( ).Rows );
        }
        

        
    }
}
