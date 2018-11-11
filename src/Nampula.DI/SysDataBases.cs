namespace Nampula.DI
{

    /// <summary>
    /// Recupera todos os banco de dados da instancia atual
    /// </summary>
    public class DataBases : StoredProcedure
    {
        /// <summary>
        /// Nome dos campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DATABASE_NAME = "DATABASE_NAME";
            public static readonly string DATABASE_SIZE = "DATABASE_SIZE";
            public static readonly string REMARKS = "REMARKS";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {
            public static readonly string DATABASE_NAME = "Nome do Banco de dados";
            public static readonly string DATABASE_SIZE = "Tamanho";
            public static readonly string REMARKS = "Observações";
        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public DataBases() :
            base("sp_databases")
        {
        }

    }

}
