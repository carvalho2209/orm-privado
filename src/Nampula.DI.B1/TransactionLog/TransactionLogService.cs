using System.Collections.Generic;
using System.Linq;
using Nampula.DI.B1.Documents;

namespace Nampula.DI.B1.TransactionLog
{
    public class TransactionLogService
    {
        private readonly string _companyDb;
        private readonly int _docEntry;
        private readonly int _docType;

        public TransactionLogService(string companyDb, int docEntry, int docType)
        {
            _companyDb = companyDb;
            _docEntry = docEntry;
            _docType = docType;
        }

        public InventoryTransactionsLog GetByLine(int lineId)
        {
            var transLog = new InventoryTransactionsLog(_companyDb);
            var tableQuery = new TableQuery(transLog);

            tableQuery.Where.Add(
                new QueryParam(
                    transLog.Collumns[InventoryTransactionsLog.FieldsName.ApplyEntry], _docEntry));

            tableQuery.Where.Add(
                new QueryParam(
                    transLog.Collumns[InventoryTransactionsLog.FieldsName.ApplyType], _docType));

            tableQuery.Where.Add(
                new QueryParam(
                    transLog.Collumns[InventoryTransactionsLog.FieldsName.ApplyLine], lineId));

            var transType = DocumentObjectType.GetDocTransactionType((eDocumentObjectType)_docType);
            var accumOnHand = 1;
            var accumCommited = 2;
            var stockEff = transType == eTransactionType.oIn ? accumCommited : accumOnHand;

            tableQuery.Where.Add(
                new QueryParam(
                    transLog.Collumns[InventoryTransactionsLog.FieldsName.StockEff], eCondition.ecEqual, stockEff));

            var transLogs = transLog
                .FillCollection<InventoryTransactionsLog>(tableQuery)
                .FirstOrDefault() ?? new InventoryTransactionsLog(_companyDb);

            transLogs.Details = GetDetails(transLogs.LogEntry);

            return transLogs;
        }

        private List<InventoryTransactionsLogDetail> GetDetails(int logEntry)
        {
            var transLog = new InventoryTransactionsLogDetail(_companyDb);
            var tableQuery = new TableQuery(transLog);

            tableQuery.Where.Add(
                new QueryParam(
                    transLog.Collumns[InventoryTransactionsLogDetail.FieldsName.LogEntry],
                    logEntry));

            return transLog.FillCollection<InventoryTransactionsLogDetail>(tableQuery);
        }

    }
}
