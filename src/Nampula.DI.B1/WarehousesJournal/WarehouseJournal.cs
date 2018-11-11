using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.WarehousesJournal
{
    public class WarehouseJournal : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OINM";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string TransNum = "TransNum";
            public static readonly string TransType = "TransType";
            public static readonly string CreatedBy = "CreatedBy";
            public static readonly string BaseRef = "BASE_REF";
            public static readonly string DocLineNum = "DocLineNum";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string Price = "Price";
            public static readonly string CalcPrice = "CalcPrice";
            public static readonly string CardCode = "CardCode";
            public static readonly string InQty = "InQty";
            public static readonly string OutQty = "OutQty";
            public static readonly string DocDate = "DocDate";
            public static readonly string DocDueDate = "DocDueDate";
            public static readonly string Warehouse = "Warehouse";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string TransNum = "Transação";
            public static readonly string TransType = "Tipo de Transação";
            public static readonly string CreatedBy = "Criado Por";
            public static readonly string BaseRef = "Ref.";
            public static readonly string DocLineNum = "Linha";
            public static readonly string ItemCode = "Item";
            public static readonly string Price = "Preço";
            public static readonly string CalcPrice = "Preço Calculado";
            public static readonly string CardCode = "Parceiro";
            public static readonly string InQty = "Qtd Entrada";
            public static readonly string OutQty = "Qtd Saída";
            public static readonly string DocDate = "DocDate";
            public static readonly string DocDueDate = "DocDueDate";
            public static readonly string Warehouse = "Depósito";
        }
        

        

        TableAdapterField m_TransNum = new TableAdapterField( FieldsName.TransNum, FieldsDescription.TransNum, DbType.Int32, 11, 0, true, true );
        TableAdapterField m_TransType = new TableAdapterField( FieldsName.TransType, FieldsDescription.TransType, DbType.Int16 );
        TableAdapterField m_CreateBy = new TableAdapterField( FieldsName.CreatedBy, FieldsDescription.CreatedBy, DbType.Int16 );
        TableAdapterField m_BaseRef = new TableAdapterField( FieldsName.BaseRef, FieldsDescription.BaseRef, DbType.Int32 );
        TableAdapterField m_DocLineNum = new TableAdapterField( FieldsName.DocLineNum, FieldsDescription.DocLineNum, DbType.Int16 );
        TableAdapterField m_Price = new TableAdapterField( FieldsName.Price, FieldsDescription.Price, DbType.Decimal );
        TableAdapterField m_CalcPrice = new TableAdapterField(FieldsName.CalcPrice, FieldsDescription.CalcPrice, DbType.Decimal, 19, 6);
        TableAdapterField m_CardCode = new TableAdapterField( FieldsName.CardCode, FieldsDescription.CardCode, 15 );
        TableAdapterField m_ItemCode = new TableAdapterField( FieldsName.ItemCode, FieldsDescription.ItemCode, 40 );
        TableAdapterField m_InQty = new TableAdapterField( FieldsName.InQty, FieldsDescription.InQty, DbType.Decimal );
        TableAdapterField m_OutQty = new TableAdapterField( FieldsName.OutQty, FieldsDescription.OutQty, DbType.Decimal );
        TableAdapterField m_DocDate = new TableAdapterField( FieldsName.DocDate, FieldsDescription.DocDate, DbType.DateTime );
        TableAdapterField m_DocDueDate = new TableAdapterField( FieldsName.DocDueDate, FieldsDescription.DocDueDate, DbType.DateTime );
        TableAdapterField m_Warehouse = new TableAdapterField( FieldsName.Warehouse, FieldsDescription.Warehouse, 8 );
        
        public WarehouseJournal ( )
            : base( Definition.TableName )
        {
        }

        public WarehouseJournal ( string pCompanyDb )
            : this( )
        {
            DBName = pCompanyDb;
        }

        public WarehouseJournal ( WarehouseJournal pWarehouse )
            : this( )
        {
            CopyBy( pWarehouse );
        }
        
        public int TransNum
        {
            get { return m_TransNum.GetInt32( ); }
            set { m_TransNum.Value = value; }
        }

        public Int16 TransType
        {
            get { return m_TransType.GetInt16( ); }
            set { m_TransType.Value = value; }
        }

        public Int16 CreateBy
        {
            get { return m_CreateBy.GetInt16( ); }
            set { m_CreateBy.Value = value; }
        }

        public Int32 BaseRef
        {
            get { return m_BaseRef.GetInt32( ); }
            set { m_BaseRef.Value = value; }
        }

        public Int16 DocLineNum
        {
            get { return m_DocLineNum.GetInt16( ); }
            set { m_DocLineNum.Value = value; }
        }

        public string ItemCode
        {
            get { return m_ItemCode.GetString( ); }
            set { m_ItemCode.Value = value; }
        }

        public Decimal Price
        {
            get { return m_Price.GetDecimal( ); }
            set { m_Price.Value = value; }
        }

        public Decimal CalcPrice
        {
            get { return m_CalcPrice.GetDecimal(); }
            set { m_CalcPrice.Value = value; }
        }


        public string CardCode
        {
            get { return m_CardCode.GetString( ); }
            set { m_CardCode.Value = value; }
        }

        public Decimal InQty
        {
            get { return m_InQty.GetDecimal( ); }
            set { m_InQty.Value = value; }
        }

        public Decimal OutQty
        {
            get { return m_OutQty.GetDecimal( ); }
            set { m_OutQty.Value = value; }
        }

        public DateTime DocDate
        {
            get { return m_DocDate.GetDateTime( ); }
            set { m_DocDate.Value = value; }
        }

        public DateTime DocDueDate
        {
            get { return m_DocDueDate.GetDateTime( ); }
            set { m_DocDueDate.Value = value; }
        }

        public string Warehouse
        {
            get { return m_Warehouse.GetString( ); }
            set { m_Warehouse.Value = value; }
        }
        

        

        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey ( int pTransNum )
        {
            this.TransNum = pTransNum;
            return GetByKey( );
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de Warehouse.</returns>
        public List<WarehouseJournal> GetAll ( )
        {
            return FillCollection<WarehouseJournal>( this.GetData( ).Rows );
        }
        

        
    }
}
