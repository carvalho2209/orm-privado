using System;
using System.Data;
using Nampula.DI.B1.Documents;
using Nampula.Framework;

namespace Nampula.DI.B1.BatchNumbers
{

    public class BatchNumberTrans : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "IBT1";
        }

        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string ItemCode = "ItemCode";
            public static readonly string BatchNum = "BatchNum";
            public static readonly string WhsCode = "WhsCode";
            public static readonly string Quantity = "Quantity";
            public static readonly string BaseType = "BaseType";
            public static readonly string BaseEntry = "BaseEntry";
            public static readonly string BaseNum = "BaseNum";
            public static readonly string BaseLinNum = "BaseLinNum";
            public static readonly string Direction = "Direction";
        }

        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string ItemCode = "Código do Item";
            public static readonly string BatchNum = "Nº do Lote";
            public static readonly string WhsCode = "Deposito";
            public static readonly string Quantity = "Quantidade";
            public static readonly string BaseType = "Doc. de Origem";
            public static readonly string BaseEntry = "Nº Int. do Documento";
            public static readonly string BaseNum = "Nº do Documento";
            public static readonly string BaseLinNum = "Linha do Documento";
            public static readonly string Direction = "Direção";
        }

        TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, DbType.String, 20, 0, true, false);
        TableAdapterField m_BatchNum = new TableAdapterField(FieldsName.BatchNum, FieldsDescription.BatchNum, DbType.String, 32, 0, true, false);
        TableAdapterField m_WhsCode = new TableAdapterField(FieldsName.WhsCode, FieldsDescription.WhsCode, DbType.String, 8, 0, true, false);
        TableAdapterField m_Quantity = new TableAdapterField(FieldsName.Quantity, FieldsDescription.Quantity, DbType.Decimal);
        TableAdapterField m_BaseType = new TableAdapterField(FieldsName.BaseType, FieldsDescription.BaseType, DbType.Int32);
        TableAdapterField m_BaseEntry = new TableAdapterField(FieldsName.BaseEntry, FieldsDescription.BaseEntry, DbType.Int32);
        TableAdapterField m_BaseNum = new TableAdapterField(FieldsName.BaseNum, FieldsDescription.BaseNum, DbType.Int32);
        TableAdapterField m_BaseLinNum = new TableAdapterField(FieldsName.BaseLinNum, FieldsDescription.BaseLinNum, DbType.Int32);
        TableAdapterField m_Direction = new TableAdapterField(FieldsName.Direction, FieldsDescription.Direction, DbType.Int32);

        public BatchNumberTrans()
            : base(Definition.TableName)
        {
        }

        public BatchNumberTrans(string companyDb)
            : this()
        {
            DBName = companyDb;
        }

        public BatchNumberTrans(BatchNumberTrans pBatchNumberForItem)
            : this()
        {
            CopyBy(pBatchNumberForItem);
        }
        
        public string ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public string BatchNum
        {
            get { return m_BatchNum.GetString(); }
            set { m_BatchNum.Value = value; }
        }

        public string WhsCode
        {
            get { return m_WhsCode.GetString(); }
            set { m_WhsCode.Value = value; }
        }

        public decimal Quantity
        {
            get { return m_Quantity.GetDecimal(); }
            set { m_Quantity.Value = value; }
        }

        public eDocumentObjectType BaseType
        {
            get { return m_BaseType.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_BaseType.Value = value.ToInt32(); }
        }

        public int BaseEntry
        {
            get { return m_BaseEntry.GetInt32(); }
            set { m_BaseEntry.Value = value; }
        }

        public string BaseNum
        {
            get { return m_BaseNum.GetString(); }
            set { m_BaseNum.Value = value; }
        }

        public string BaseLinNum
        {
            get { return m_BaseLinNum.GetString(); }
            set { m_BaseLinNum.Value = value; }
        }

        public BatchNumberDirectionType Direction
        {
            get { return (BatchNumberDirectionType)m_Direction.GetInt32(); }
            set { m_Direction.Value = value.To<Int32>(); }
        }


    }
}
