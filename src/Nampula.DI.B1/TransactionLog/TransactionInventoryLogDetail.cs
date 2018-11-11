using System;
using System.Data;

namespace Nampula.DI.B1.TransactionLog
{
    
    /// <summary>
    /// Tabela de Detalhes de Transação de Log (ITL1)
    /// 
    /// </summary>
    public class InventoryTransactionsLogDetail : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ITL1";
        }

        public struct FieldsName
        {
            public static readonly string LogEntry = "LogEntry";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string SysNumber = "SysNumber";
        }

        public struct FieldsDescription
        {
            public static readonly string LogEntry = "LogEntry";
            public static readonly string ItemCode = "ItemCode";
            public static readonly string SysNumber = "SysNumber";
        }

        readonly TableAdapterField m_LogEntry = new TableAdapterField(FieldsName.LogEntry, FieldsDescription.LogEntry, DbType.Int32, 11, 0, true, false);
        readonly TableAdapterField m_ItemCode = new TableAdapterField(FieldsName.ItemCode, FieldsDescription.ItemCode, 40);
        readonly TableAdapterField m_SysNumber = new TableAdapterField(FieldsName.SysNumber, FieldsDescription.SysNumber, DbType.Int32);

        public InventoryTransactionsLogDetail()
            : base(Definition.TableName)
        {
        }

        public InventoryTransactionsLogDetail(string companyDb)
            : base(companyDb,Definition.TableName)
        {
        }

        public InventoryTransactionsLogDetail(InventoryTransactionsLogDetail pTransactionInventoryLogDetail)
            : this()
        {
            CopyBy(pTransactionInventoryLogDetail);
        }

        public int LogEntry
        {
            get { return m_LogEntry.GetInt32(); }
            set { m_LogEntry.Value = value; }
        }

        public String ItemCode
        {
            get { return m_ItemCode.GetString(); }
            set { m_ItemCode.Value = value; }
        }

        public Int32 SysNumber
        {
            get { return m_SysNumber.GetInt32(); }
            set { m_SysNumber.Value = value; }
        }


    }
}
