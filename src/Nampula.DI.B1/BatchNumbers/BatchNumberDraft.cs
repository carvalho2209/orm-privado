namespace Nampula.DI.B1.BatchNumbers
{
    public class BatchNumberDraft : BatchNumberBase
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ODBN";
        }
        
        public BatchNumberDraft()
        {
            TableName = Definition.TableName;
        }

        public BatchNumberDraft(string companyDb)
            : this()
        {
            DBName = companyDb;
        }

        public BatchNumberDraft(BatchNumberDraft pBatchNumberForItem)
            : this()
        {
            CopyBy(pBatchNumberForItem);
        }

        /// <summary>
        /// Código Que Identifica o objeto em questão
        /// </summary>
        public const int ObjectId = 10000068;
    }
}
