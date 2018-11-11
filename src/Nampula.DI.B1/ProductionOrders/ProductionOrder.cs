using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.ProductionOrders
{
    public class ProductionOrder : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OWOR";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string DocNum = "DocNum";
            public static readonly string Series = "Series";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string Status = "Status";
            public static readonly string Type = "Type";
            public static readonly string PlannedQty = "PlannedQty";
            public static readonly string CmpltQty = "CmpltQty";
            public static readonly string RjctQty = "RjctQty";
            public static readonly string PostDate = "PostDate";
            public static readonly string DueDate = "DueDate";
            public static readonly string OriginAbs = "OriginAbs";
            public static readonly string OriginNum = "OriginNum";
            public static readonly string OriginType = "OriginType";
            public static readonly string Comments = "Comments";
            public static readonly string CardCode = "CardCode";
            public static readonly string Warehouse = "Warehouse";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Número";
            public static readonly string DocNum = "Número manual";
            public static readonly string Series = "Série";
            public static readonly string ItemCode = "Nº do Produto";
            public static readonly string Status = "Status";
            public static readonly string Type = "Tipo";
            public static readonly string PlannedQty = "Qtd. planejada";
            public static readonly string CmpltQty = "Qtd. completa";
            public static readonly string RjctQty = "Qtd. rejeitada";
            public static readonly string PostDate = "Data do pedido";
            public static readonly string DueDate = "Data de vencimento";
            public static readonly string OriginAbs = "Pedido de venda";
            public static readonly string OriginNum = "Pedido de venda";
            public static readonly string Comments = "Observações";
            public static readonly string CardCode = "Cliente";
            public static readonly string Warehouse = "Depósito";
        }
        

        

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_DocNum = new TableAdapterField(FieldsName.DocNum, FieldsDescription.DocNum, DbType.Int32);
        TableAdapterField m_Series = new TableAdapterField(FieldsName.Series, FieldsDescription.Series, DbType.Int32);
        TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, 20);
        TableAdapterField m_Status = new TableAdapterField(FieldsName.Status, FieldsDescription.Status, 1);
        TableAdapterField m_Type = new TableAdapterField(FieldsName.Type, FieldsDescription.Type, 1);
        TableAdapterField m_PlannedQty = new TableAdapterField(FieldsName.PlannedQty, FieldsDescription.PlannedQty, DbType.Decimal);
        TableAdapterField m_CmpltQty = new TableAdapterField(FieldsName.CmpltQty, FieldsDescription.CmpltQty, DbType.Decimal);
        TableAdapterField m_RjctQty = new TableAdapterField(FieldsName.RjctQty, FieldsDescription.RjctQty, DbType.Decimal);
        TableAdapterField m_PostDate = new TableAdapterField(FieldsName.PostDate, FieldsDescription.PostDate, DbType.DateTime);
        TableAdapterField m_DueDate = new TableAdapterField(FieldsName.DueDate, FieldsDescription.DueDate, DbType.DateTime);
        TableAdapterField m_OriginAbs = new TableAdapterField(FieldsName.OriginAbs, FieldsDescription.OriginAbs, DbType.Int32);
        TableAdapterField m_OriginNum = new TableAdapterField(FieldsName.OriginNum, FieldsDescription.OriginNum, DbType.Int32);
        TableAdapterField m_Comments = new TableAdapterField(FieldsName.Comments, FieldsDescription.Comments, 254);
        TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, FieldsDescription.CardCode, 15);
        TableAdapterField m_Warehouse = new TableAdapterField(FieldsName.Warehouse, FieldsDescription.Warehouse, 8);

        

        

        

        public ProductionOrder()
            : base(Definition.TableName)
        {
            Lines = new List<ProductionOrderLine>();
            OnAfterSelect += new TableAdapterEventHandler(ProductionOrder_OnAfterSelect);
        }

        public ProductionOrder(string pCompanyDb)
            : this( )
        {
            DBName = pCompanyDb;
        }

        public ProductionOrder(ProductionOrder pProductionOrder)
            : this()
        {
            this.CopyBy(pProductionOrder);
        }

        

        

        private void ProductionOrder_OnAfterSelect(object Sender, TableAdapterEventArgs e)
        {
            var line = new ProductionOrderLine(DBName);
            TableQuery query = new TableQuery(line);

            query.Where.Add(
                new QueryParam(
                    line.Collumns[ProductionOrderLine.FieldsName.DocEntry],
                    this.DocEntry));

            Lines = line.FillCollection<ProductionOrderLine>(query);
        }

        

        

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int DocNum
        {
            get { return m_DocNum.GetInt32(); }
            set { m_DocNum.Value = value; }
        }

        public int Series
        {
            get { return m_Series.GetInt32(); }
            set { m_Series.Value = value; }
        }

        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public ProductionOrderStatusType Status
        {
            get { return ProductionOrderStatusClass.ToEnum(m_Status.GetString()); }
            set { m_Status.Value = value.ToStringEnum(); }
        }

        public ProductionOrderType Type
        {
            get { return ProductionOrderClass.ToEnum(m_Type.GetString()); }
            set { m_Type.Value = value.ToStringEnum(); }
        }

        public decimal PlannedQty
        {
            get { return m_PlannedQty.GetDecimal(); }
            set { m_PlannedQty.Value = value; }
        }

        public decimal CmpltQty
        {
            get { return m_CmpltQty.GetDecimal(); }
            set { m_CmpltQty.Value = value; }
        }

        public decimal RjctQty
        {
            get { return m_RjctQty.GetDecimal(); }
            set { m_RjctQty.Value = value; }
        }

        public DateTime PostDate
        {
            get { return m_PostDate.GetDateTime(); }
            set { m_PostDate.Value = value; }
        }

        public DateTime DueDate
        {
            get { return m_DueDate.GetDateTime(); }
            set { m_DueDate.Value = value; }
        }

        public int OriginAbs
        {
            get { return m_OriginAbs.GetInt32(); }
            set { m_OriginAbs.Value = value; }
        }

        public int OriginNum
        {
            get { return m_OriginNum.GetInt32(); }
            set { m_OriginNum.Value = value; }
        }

        public string Comments
        {
            get { return m_Comments.GetString(); }
            set { m_Comments.Value = value; }
        }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public string Warehouse
        {
            get { return m_Warehouse.GetString(); }
            set { m_Warehouse.Value = value; }
        }

        public List<ProductionOrderLine> Lines { get; set; }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(int pDocEntry)
        {
            this.DocEntry = pDocEntry;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de ProductionOrder.</returns>
        public List<ProductionOrder> GetAll()
        {
            return FillCollection<ProductionOrder>(this.GetData().Rows);
        }
        

        
    }
}
