using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.ProductionOrders
{
    public class ProductionOrderLine : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "WOR1";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string LineNum = "LineNum";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string BaseQty = "BaseQty";
            public static readonly string PlannedQty = "PlannedQty";
            public static readonly string IssuedQty = "IssuedQty";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Número";
            public static readonly string LineNum = "Linha";
            public static readonly string ItemCode = "Produto";
            public static readonly string BaseQty = "Qtd. base";
            public static readonly string PlannedQty = "Qtd. planejada";
            public static readonly string IssuedQty = "Qtd. emitida";
        }
        

        

        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_LineNum = new TableAdapterField(FieldsName.LineNum, FieldsDescription.LineNum, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, 20);
        TableAdapterField m_BaseQty = new TableAdapterField(FieldsName.BaseQty, FieldsDescription.BaseQty, DbType.Decimal);
        TableAdapterField m_PlannedQty = new TableAdapterField(FieldsName.PlannedQty, FieldsDescription.PlannedQty, DbType.Decimal);
        TableAdapterField m_IssuedQty = new TableAdapterField(FieldsName.IssuedQty, FieldsDescription.IssuedQty, DbType.Decimal);

        

        

        

        public ProductionOrderLine()
            : base(Definition.TableName)
        {
        }

        public ProductionOrderLine(string pCompanyDb)
            : this( )
        {
            DBName = pCompanyDb;
        }

        public ProductionOrderLine(ProductionOrderLine pProductionOrderLine)
            : this()
        {
            this.CopyBy(pProductionOrderLine);
        }

        

        

        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public int LineNum
        {
            get { return m_LineNum.GetInt32(); }
            set { m_LineNum.Value = value; }
        }

        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public decimal BaseQty
        {
            get { return m_BaseQty.GetDecimal(); }
            set { m_BaseQty.Value = value; }
        }

        public decimal PlannedQty
        {
            get { return m_PlannedQty.GetDecimal(); }
            set { m_PlannedQty.Value = value; }
        }

        public decimal IssuedQty
        {
            get { return m_IssuedQty.GetDecimal(); }
            set { m_IssuedQty.Value = value; }
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pID">Código.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(int pDocEntry, int pLineNum)
        {
            this.DocEntry = pDocEntry;
            this.LineNum = pLineNum;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de ProductionOrderLine.</returns>
        public List<ProductionOrderLine> GetAll()
        {
            return FillCollection<ProductionOrderLine>(this.GetData().Rows);
        }
        

        
    }
}
