namespace Nampula.DI.B1.BatchNumbers
{
    public class BatchNumberMasterData : BatchNumberBase
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OBTN";
        }

        
        public BatchNumberMasterData()
        {
            TableName = Definition.TableName;
        }

        public BatchNumberMasterData(string companyDb)
            : this()
        {
            DBName = companyDb;
        }

        public BatchNumberMasterData(BatchNumberMasterData batchNumberMasterData)
            : this()
        {
            CopyBy(batchNumberMasterData);
        }

        /// <summary>
        /// Código Que Identifica o objeto em questão
        /// </summary>
        public const int ObjectId = 10000044;
    }
}
