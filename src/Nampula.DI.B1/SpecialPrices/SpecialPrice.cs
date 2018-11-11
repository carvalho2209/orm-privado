using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.SpecialPrices
{
    /// <summary>
    /// Classe que gerencia a tabela de preços especiais
    /// </summary>
    public class SpecialPrice : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OSPP";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";
            public static readonly string CardCode = "CardCode";
            public static readonly string Price = "Price";
            public static readonly string Currency = "Currency";
            public static readonly string Discount = "Discount";
            public static readonly string ListNum = "ListNum";
            public static readonly string AutoUpdt = "AutoUpdt";
            public static readonly string Expand = "Expand";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ItemCode = "Item";
            public static readonly string CardCode = "Parceiro";
            public static readonly string Price = "Preço";
            public static readonly string Currency = "Moeda";
            public static readonly string Discount = "% Disconto";
            public static readonly string ListNum = "Lista de Preço";
            public static readonly string AutoUpdt = "Auto Atualizar";
            public static readonly string Expand = "Expandir";
        }
        

        

        TableAdapterField m_ItemCode = new TableAdapterField( FieldsName.ItemCode, FieldsDescription.ItemCode, DbType.String, 40, 0, true, false );
        TableAdapterField m_CardCode = new TableAdapterField( FieldsName.CardCode, FieldsDescription.CardCode, DbType.String, 15, 0, true, false );
        TableAdapterField m_ListNum = new TableAdapterField( FieldsName.ListNum, FieldsDescription.ListNum, DbType.Int16 );
        TableAdapterField m_Price = new TableAdapterField( FieldsName.Price, FieldsDescription.Price, DbType.Decimal );
        TableAdapterField m_Currency = new TableAdapterField( FieldsName.Currency, FieldsDescription.Currency, 3 );
        TableAdapterField m_Discount = new TableAdapterField( FieldsName.Discount, FieldsDescription.Discount, DbType.Decimal );
        TableAdapterField m_AutoUpdt = new TableAdapterField( FieldsName.AutoUpdt, FieldsDescription.AutoUpdt, 1 );
        TableAdapterField m_Expand = new TableAdapterField( FieldsName.Expand, FieldsDescription.Expand, 1 );

        

        

        

        public SpecialPrice ( )
            : base( Definition.TableName )
        {
        }

        public SpecialPrice ( string pCompanyDb )
            : this(  )
        {
            this.DBName = pCompanyDb;
        }

        public SpecialPrice ( SpecialPrice pSpecialPrice )
            : this( )
        {
            this.CopyBy( pSpecialPrice );
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

        public Int16 ListNum
        {
            get { return m_ListNum.GetInt16( ); }
            set { m_ListNum.Value = value; }
        }

        public eYesNo AutoUpdt
        {
            get { return m_AutoUpdt.GetString( ).ToYesNoEnum( ); }
            set { m_AutoUpdt.Value = value.ToYesNoString( ); }
        }

        public eYesNo Expand
        {
            get { return m_Expand.GetString( ).ToYesNoEnum( ); }
            set { m_Expand.Value = value.ToYesNoString( ); }
        }
        

        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( string pCardCode, string pItemCode )
        {
            this.CardCode = pCardCode;
            this.ItemCode = pItemCode;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de SpecialPrice.</returns>
        public List<SpecialPrice> GetAll ( )
        {
            return FillCollection<SpecialPrice>( this.GetData( ).Rows );
        }
        

        
    }
}
