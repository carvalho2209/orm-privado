using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.SpecialPrices
{
    public class SpecialPriceQuantityArea : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "SPP2";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";
            public static readonly string CardCode = "CardCode";
            public static readonly string SPP1LNum = "SPP1LNum";
            public static readonly string SPP2LNum = "SPP2LNum";
            public static readonly string Amount = "Amount";
            public static readonly string Price = "Price";
            public static readonly string Currency = "Currency";
            public static readonly string Discount = "Discount";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ItemCode = "Item";
            public static readonly string CardCode = "Parceiro";
            public static readonly string SPP1LNum = "LineNum1";
            public static readonly string SPP2LNum = "LineNUm2";
            public static readonly string Amount = "Amount";
            public static readonly string Price = "Preço";
            public static readonly string Currency = "Moeda";
            public static readonly string Discount = "% Disconto";
        }
        

        

        TableAdapterField m_ItemCode = new TableAdapterField( FieldsName.ItemCode, FieldsDescription.ItemCode, DbType.String, 40, 0, true, false );
        TableAdapterField m_CardCode = new TableAdapterField( FieldsName.CardCode, FieldsDescription.CardCode, DbType.String, 15, 0, true, false );
        TableAdapterField m_SPP1LNum = new TableAdapterField( FieldsName.SPP1LNum, FieldsDescription.SPP1LNum, DbType.Int16, 11, 0, true, false );
        TableAdapterField m_SPP2LNum = new TableAdapterField( FieldsName.SPP2LNum, FieldsDescription.SPP2LNum, DbType.Int16, 11, 0, true, false );
        TableAdapterField m_Amount = new TableAdapterField( FieldsName.Amount, FieldsDescription.Amount, DbType.Decimal );
        TableAdapterField m_Price = new TableAdapterField( FieldsName.Price, FieldsDescription.Price, DbType.Decimal );
        TableAdapterField m_Currency = new TableAdapterField( FieldsName.Currency, FieldsDescription.Currency, 3 );
        TableAdapterField m_Discount = new TableAdapterField( FieldsName.Discount, FieldsDescription.Discount, DbType.Decimal );

        

        

        

        public SpecialPriceQuantityArea ( )
            : base( Definition.TableName )
        {
        }

        public SpecialPriceQuantityArea ( string pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public SpecialPriceQuantityArea ( SpecialPriceQuantityArea pSpecialPriceQuantityArea )
            : this( )
        {
            this.CopyBy( pSpecialPriceQuantityArea );
        }

        

        

        public string ItemCode
        {
            get { return m_ItemCode.GetString( ); }
            set { m_ItemCode.Value = value; }
        }

        public string CardCode
        {
            get { return m_CardCode.GetString( ); }
            set { m_CardCode.Value = value; }
        }

        public Int16 SPP1Lnum
        {
            get { return m_SPP1LNum.GetInt16( ); }
            set { m_SPP1LNum.Value = value; }
        }

        public Int16 SPP2Lnum
        {
            get { return m_SPP2LNum.GetInt16( ); }
            set { m_SPP2LNum.Value = value; }
        }

        public decimal Amount
        {
            get { return m_Amount.GetDecimal( ); }
            set { m_Amount.Value = value; }
        }

        public decimal Price
        {
            get { return m_Price.GetDecimal( ); }
            set { m_Price.Value = value; }
        }

        public string Currency
        {
            get { return m_Currency.GetString( ); }
            set { m_Currency.Value = value; }
        }

        public decimal Discount
        {
            get { return m_Discount.GetDecimal( ); }
            set { m_Discount.Value = value; }
        }


        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( string pCardCode, string pItemCode, short pSPP1LNum, short pSPP2LNum )
        {
            this.CardCode = pCardCode;
            this.ItemCode = pItemCode;
            this.SPP1Lnum = pSPP1LNum;
            this.SPP2Lnum = pSPP2LNum;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de SpecialPriceQuantityArea.</returns>
        public List<SpecialPriceQuantityArea> GetAll ( )
        {
            return FillCollection<SpecialPriceQuantityArea>( this.GetData( ).Rows );
        }
        

        
    }
}
