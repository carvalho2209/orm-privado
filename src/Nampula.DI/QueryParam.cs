using System.Data;


namespace Nampula.DI
{

    /// <summary>
    /// Parametro de consulta do TableQuery
    /// </summary>
    public class QueryParam
    {


        /// <summary>
        /// Apelido da Tabela
        /// </summary>
        public string AliasTableName { get; set; }
        /// <summary>
        /// Nome do Campo
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Apelido do Banco
        /// </summary>
        public string AliasName { get; set; }
        /// <summary>
        /// Condição
        /// </summary>
        public eCondition Condition { get; set; }
        /// <summary>
        /// Relacionamento Lógico
        /// </summary>
        public eRelationship Relationship { get; set; }
        /// <summary>
        /// Primeiro valor avaliado
        /// </summary>
        public object Value1 { get; set; }
        /// <summary>
        /// Sedundo valor avaliado
        /// </summary>
        public object Value2 { get; set; }
        /// <summary>
        /// Tipo do Campo
        /// </summary>
        public DbType DbType { get; set; }
        /// <summary>
        /// Primeiro valor avaliado para outro campo
        /// </summary>
        public QueryParam Value1Column { get; set; }
        /// <summary>
        /// Segundo valor avaliado para o outtro campo
        /// </summary>
        public QueryParam Value2Column { get; set; }


        /// <summary>
        /// Construtor padrão
        /// </summary>
        public QueryParam()
        {

            AliasTableName = string.Empty;
            FieldName = string.Empty;
            AliasName = string.Empty;
            Condition = eCondition.ecNone;
            Relationship = eRelationship.erAnd;
            Value1 = null;
            Value2 = null;
            DbType = DbType.String;
            Value1Column = null;
            Value2Column = null;
        }

        /// <summary>
        /// Insancia o classe apartir de um objeto 
        /// </summary>
        /// <param name="pQueryParam">Objeto de Origem</param>
        public QueryParam(QueryParam pQueryParam)
            : this()
        {

            AliasTableName = pQueryParam.AliasTableName;
            FieldName = pQueryParam.FieldName;
            AliasName = pQueryParam.AliasName;
            Condition = pQueryParam.Condition;
            Relationship = pQueryParam.Relationship;
            Value1 = pQueryParam.Value1;
            Value2 = pQueryParam.Value2;
            DbType = pQueryParam.DbType;

            if (pQueryParam.Value1Column != null)
                Value1Column = new QueryParam(pQueryParam.Value1Column);

            if (pQueryParam.Value2Column != null)
                Value2Column = new QueryParam(pQueryParam.Value2Column);

        }

        /// <summary>
        /// Instancia a classe atrav;es de um tableField
        /// </summary>
        /// <param name="field">Um TableAdapterField</param>
        public QueryParam(TableAdapterField field)
            : this()
        {
            AliasTableName = field.TableAlias;
            AliasName = field.Alias;
            FieldName = field.Name;
            DbType = field.DbType;
            Condition = eCondition.ecEqual;
            Value1 = field.Value;
        }

        /// <summary>
        /// Instancia a classe e atribui a condiciona de igual ao campo valor
        /// </summary>
        /// <param name="field">Um tableFiel</param>
        /// <param name="pValue1">Um valor</param>
        public QueryParam(TableAdapterField field, object pValue1)
            : this(field)
        {
            Value1 = pValue1;
        }

        /// <summary>
        ///Instancia a classe e atribui a condiciona de Between
        /// </summary>
        /// <param name="pField">Um TableAdaterField</param>
        /// <param name="pValue1">Primeiro valor, de</param>
        /// <param name="pValue2">Segundo valor, até.</param>
        public QueryParam(TableAdapterField pField, object pValue1, object pValue2)
            : this(pField, pValue1)
        {

            Value2 = pValue2;
            SetConditionValue(pValue1, pValue2);

        }

        /// <summary>
        /// Instancia a classe através do objeto TableField e atribui uma condicional que não exige valor.
        /// </summary>
        /// <param name="pField">Um TableAdaterField</param>
        /// <param name="pCondition">Uma condição</param>
        public QueryParam(TableAdapterField pField, eCondition pCondition)
            : this(pField)
        {
            Condition = pCondition;
        }

        /// <summary>
        /// Instancia a classe através do objeto TableField e atribui uma condicional que exige valor.
        /// </summary>
        /// <param name="pField">Um TableAdaterField</param>
        /// <param name="pCondition">Uma condição</param>
        /// <param name="pValue1">Um valor qualquer</param>
        public QueryParam(TableAdapterField pField, eCondition pCondition, object pValue1)
            : this(pField, pValue1)
        {
            Condition = pCondition;
            Value1 = pValue1;
        }

        /// <summary>
        /// Instancia a classe através do objeto TableField e atribui uma condicional que exige 2 valores.
        /// </summary>
        /// <param name="pField">Um TableAdaterField</param>
        /// <param name="pCondition">Uma condição</param>
        /// <param name="pValue1">Um valor qualquer</param>
        /// <param name="pValue2">Um segundo valor</param>
        public QueryParam(TableAdapterField pField, eCondition pCondition, object pValue1, object pValue2)
            : this(pField, pCondition, pValue1)
        {
            Value2 = pValue2;
        }

        /// <summary>
        /// Instancia um classe de acordo com os dados do nome do campo tipo e valor.
        /// </summary>
        /// <param name="pFieldName">Nome do Campo</param>
        /// <param name="pDbType">Tipo do Campo</param>
        /// <param name="pValue1">Valor do Campos</param>
        public QueryParam(string pFieldName, DbType pDbType, object pValue1)
            : this()
        {
            FieldName = pFieldName;
            DbType = pDbType;
            Value1 = pValue1;
            Condition = eCondition.ecEqual;

        }

        /// <summary>
        /// Instancia um classe de acordo com os dados do nome do campo tipo e dois valores.
        /// </summary>
        /// <param name="pFieldName">Nome do Campo</param>
        /// <param name="pDbType">Tipo do Campo</param>
        /// <param name="pValue1">Valor do Campo 1</param>
        /// <param name="pValue2">Valor do campo 2</param>
        public QueryParam(string pFieldName, DbType pDbType, object pValue1, object pValue2)
            : this(pFieldName, pDbType, pValue1)
        {

            Value2 = pValue2;

        }

        /// <summary>
        /// Instancia um classe de acordo com os dados do nome do campo tipo valor e condicional
        /// </summary>
        /// <param name="pFieldName">Nome do Campo</param>
        /// <param name="pDbType">Tipo do Campo</param>
        /// <param name="pValue1">Valor do Campo 1</param>
        /// <param name="pCondition">Condição</param>
        public QueryParam(string pFieldName, DbType pDbType, object pValue1, eCondition pCondition)
            : this(pFieldName, pDbType, pValue1)
        {

            Condition = pCondition;

        }

        /// <summary>
        /// Instancia um classe de acordo com os dados do nome do campo tipo valor e condicional
        /// </summary>
        /// <param name="pFieldName">Nome do Campo</param>
        /// <param name="pDbType">Tipo do Campo</param>
        /// <param name="pValue1">Valor do Campo 1</param>
        /// <param name="pValue2">Valor do campo 2</param>
        /// <param name="pCondition">Condição</param>
        public QueryParam(string pFieldName, DbType pDbType, object pValue1, object pValue2, eCondition pCondition)
            : this(pFieldName, pDbType, pValue1)
        {

            Value2 = pValue2;
            Condition = pCondition;

        }

        /// <summary>
        /// Atribui uma condição bettwen, Maior Que ou Meor e igual a, de acordo com os valores
        /// passados.. normalmente esse recurso é usado com datas.
        /// </summary>
        /// <param name="pValue1">Valor 1</param>
        /// <param name="pValue2">Valor 2</param>
        private void SetConditionValue(object pValue1, object pValue2)
        {

            if (pValue1 != null && pValue2 != null)
                Condition = eCondition.ecBetween;

            if (pValue1 != null && pValue2 == null)
                Condition = eCondition.ecGraterEqual;

            if (pValue1 != null || pValue2 == null) 
                return;

            Condition = eCondition.ecLessEqual;
            Value1 = pValue2;
            Value2 = null;
        }

    }
}
