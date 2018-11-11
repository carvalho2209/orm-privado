using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Nampula.DI;

namespace Nampula.DI.B1.Itens
{
    public class ItemPrice : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";      //String(20)
            public static readonly string PriceList = "PriceList";    //int
            public static readonly string Price = "Price";            //decimal
            public static readonly string Factor = "Factor";          //decimal
        }

        public struct FieldsDescription
        {
            public static readonly string ItemCode = "Código";      //String(20)
            public static readonly string PriceList = "Lista de Preço";    //int
            public static readonly string Price = "Preço Unitário";            //decimal
            public static readonly string Factor = "Fator";          //decimal
        }

        public struct Definition
        {
            public static readonly string TableName = "ITM1";          //decimal
        }

        TableAdapterField m_ItemCode = new TableAdapterField( FieldsName.ItemCode, FieldsDescription.ItemCode, DbType.String, 20, false, true, false );
        TableAdapterField m_PriceList = new TableAdapterField( FieldsName.PriceList, FieldsDescription.PriceList, DbType.Int32, 11, false, true, false );
        TableAdapterField m_Price = new TableAdapterField( FieldsName.Price, FieldsDescription.Price, DbType.Decimal );
        TableAdapterField m_Factor = new TableAdapterField( FieldsName.Factor, FieldsDescription.Factor, DbType.Decimal );

        public ItemPrice ( )
            : base( Definition.TableName )
        {
        }

        public ItemPrice ( String pCompanyDb )
            : this( )
        {
            this.DBName = pCompanyDb;
        }

        public ItemPrice ( ItemPrice pItemPrice )
            : this( pItemPrice.DBName )
        {
            this.CopyBy( pItemPrice );
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string ItemCode
        {
            get { return m_ItemCode.GetString( ); }
            set { m_ItemCode.Value = value; }
        }
        public int PriceList
        {
            get { return m_PriceList.GetInt32( ); }
            set { m_PriceList.Value = value; }
        }
        public decimal Price
        {
            get { return m_Price.GetDecimal( ); }
            set { m_Price.Value = value; }
        }
        //public string ManualPrice
        //{
        //    get { return m_ManualPrice.GetString();}
        //    set { m_ManualPrice.Value = value;}
        //}
        public decimal Factor
        {
            get { return m_Factor.GetDecimal( ); }
            set { m_Factor.Value = value; }
        }

        public bool GetByKey ( string pItemCode, int pPriceList )
        {
            this.ItemCode = pItemCode;
            this.PriceList = pPriceList;
            return base.GetByKey( );
        }

        public List<ItemPrice> GetAll ( )
        {
            return FillCollection<ItemPrice>( );
        }
  
    }
}
