using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.TransactionLog
{

    /// <summary>
    /// Tabela de Transação de Inventário (OITL)
    /// </summary>
    public class InventoryTransactionsLog : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OITL";
        }

        public struct FieldsName
        {
            public static readonly string LogEntry = "LogEntry";
            public static readonly string TransId = "TransId";
            public static readonly string ApplyEntry = "ApplyEntry";
            public static readonly string ApplyLine = "ApplyLine";
            public static readonly string ApplyType = "ApplyType";
            public static readonly string StockEff = "StockEff";

        }

        public struct FieldsDescription
        {
            public static readonly string LogEntry = "Nº";
            public static readonly string TransId = "Nº da Transação";
            public static readonly string ApplyEntry = "Nº do Documento";
            public static readonly string ApplyLine = "Nº da Linha Documento";
            public static readonly string ApplyType = "Tipo do Objeto";
            public static readonly string StockEff = "Tipo de Estoque";
        }

        readonly TableAdapterField m_LogEntry = new TableAdapterField(FieldsName.LogEntry, FieldsDescription.LogEntry, DbType.Int32, 11, 0, true, false);
        readonly TableAdapterField m_TransId = new TableAdapterField(FieldsName.TransId, FieldsDescription.TransId, DbType.Int32);
        readonly TableAdapterField m_ApplyEntry = new TableAdapterField(FieldsName.ApplyEntry, FieldsDescription.ApplyEntry, DbType.Int32);
        readonly TableAdapterField m_ApplyLine = new TableAdapterField(FieldsName.ApplyLine, FieldsDescription.ApplyLine, DbType.Int32);
        readonly TableAdapterField m_ApplyType = new TableAdapterField(FieldsName.ApplyType, FieldsDescription.ApplyType, DbType.Int32);
        readonly TableAdapterField m_StockEff = new TableAdapterField(FieldsName.StockEff, FieldsDescription.StockEff, DbType.Int32);

        public InventoryTransactionsLog()
            : base(Definition.TableName)
        {
        }

        public InventoryTransactionsLog(string companyDb)
            : base(companyDb, Definition.TableName)
        {
        }

        public InventoryTransactionsLog(InventoryTransactionsLog pInventoryTransactionsLog)
        {
            CopyBy(pInventoryTransactionsLog);
        }

        public int LogEntry
        {
            get { return m_LogEntry.GetInt32(); }
            set { m_LogEntry.Value = value; }
        }

        public Int32 TransId
        {
            get { return m_TransId.GetInt32(); }
            set { m_TransId.Value = value; }
        }

        public Int32 ApplyEntry
        {
            get { return m_ApplyEntry.GetInt32(); }
            set { m_ApplyEntry.Value = value; }
        }

        public Int32 ApplyLine
        {
            get { return m_ApplyLine.GetInt32(); }
            set { m_ApplyLine.Value = value; }
        }

        public Int32 ApplyType
        {
            get { return m_ApplyType.GetInt32(); }
            set { m_ApplyType.Value = value; }
        }

        public Int32 StockEff
        {
            get { return m_StockEff.GetInt32(); }
            set { m_StockEff.Value = value; }
        }

        public List<InventoryTransactionsLogDetail> Details { get; set; }

    }
}
