namespace Nampula.DI
{

    /// <summary>
    /// Direção da Ordenação
    /// </summary>
    public enum eOrder
    {
        eoNone = 0,
        eoASC,
        eoDESC
    }

    /// <summary>
    /// Tipo de Relacionamento do Join
    /// </summary>
    public enum eJoinRelationShip
    {
        ejrNone = 0,
        ejrInnerJoin,
        ejrLeftJoin,
        ejrOuterJoin
    }

    /// <summary>
    /// Tipo de Union
    /// </summary>
    public enum eUnionType
    {
        eutNone = 0,
        eutAll
    }

    /// <summary>
    /// Tipo de Condição 
    /// </summary>
    public enum eCondition
    {

        /// <summary>
        /// Não incializado
        /// </summary>
        ecNone = 0,
        /// <summary>
        /// Igual a ( = )
        /// </summary>
        ecEqual,
        /// <summary>
        /// Maior que ( > )
        /// </summary>
        ecGraterThan,
        /// <summary>
        /// Menor que (<)
        /// </summary>
        ecLessThan,
        /// <summary>
        /// Maior ou Igual (>=)
        /// </summary>
        ecGraterEqual,
        /// <summary>
        /// Menor ou Igual (<=)
        /// </summary>
        ecLessEqual,
        /// <summary>
        /// Diferente (<>)
        /// </summary>
        ecNotEqual,
        /// <summary>
        /// Que contenha ( Like ) .
        /// </summary>
        ecLike,
        /// <summary>
        /// Não contenha ( Not Like ).
        /// </summary>
        ecNotLike,
        /// <summary>
        /// Inicia com ( Like ...%).
        /// </summary>
        ecLikeStart,
        /// <summary>
        /// Termina com (Like %...).
        /// </summary>
        ecLikeEnd,
        /// <summary>
        /// Entre (A1...An).
        /// </summary>
        ecBetween,
        /// <summary>
        /// Não esta entre (A1...An).
        /// </summary>
        ecNotBetween,
        /// <summary>
        /// É nulo.
        /// </summary>
        ecIsNull,
        /// <summary>
        /// Não é nulo.
        /// </summary>
        ecNotNull,
        /// <summary>
        /// Está na lista.
        /// </summary>
        ecIn,
        /// <summary>
        /// Não está na lista
        /// </summary>
        ecNotIn
    }

    /// <summary>
    /// Operador de Relacionamento
    /// </summary>
    public enum eRelationship
    {
        /// <summary>
        /// Não inicializado
        /// </summary>
        erNone = 0,
        /// <summary>
        /// Operador Lógico AND (&&) 
        /// </summary>
        erAnd,

        /// <summary>
        /// Operador Lógico OR (||) 
        /// </summary>
        erOr

    }

    /// <summary>
    /// Tipo do Servidor
    /// </summary>
    public enum eDataServerType
    {
        None = 0,
        SqlServer2005 = 4,
        SqlServer2008 = 6
    }

    ///// <summary>
    ///// Tipo de Objeto de banco de dados
    ///// </summary>
    //public enum DatatObjectList
    //{
    //    DbConnection = -1000,
    //    DbDataAdapter,

    //    Connection,
    //    Navigation,

    //    DataBaseAdapter,

    //    TableQueryCollection,
    //    TableQuery,
    //    QueryParam,

    //    TableAdapter,
    //    TableAdapterField,
    //    TableAdapterFieldCollection,

    //    Log,
    //    LogCollection,
    //}

    /// <summary>
    /// Movimentação da Tabela
    /// </summary>
    public enum eMoveCommand
    {
        MoveFirst,
        MoveNext,
        MovePrevious,
        MoveLast,
        MoveTo,
        Rows
    }

    /// <summary>
    /// Resultado do registro
    /// </summary>
    public struct eMoveResult
    {
        public const int iNoCurrent = -1;
    }

    /// <summary>
    /// Tipo de Finalização de transação
    /// </summary>
    public enum eEndTrans
    {
        eRollBack,
        eCommit
    }

    /// <summary>
    /// Estado do Registro no Banco de dados
    /// </summary>
    public enum eState
    {
        eDatabase,
        eAdd,
        eUpdate,
        eRemove
    }

}
