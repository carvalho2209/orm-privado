using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Nampula.Framework;

namespace Nampula.DI.ScriptWizard
{
    /// <summary>
    /// Classe para gerenciamento de scripts do banco de dados Sql
    /// </summary>
    public partial class SqlServerScriptWizard
    {


        /// <summary>
        /// Construtores
        /// </summary>
        public SqlServerScriptWizard()
        {
            Parameters = new WhereCollection();
        }

        /// <summary>
        /// Instancia o objeto através da classe taleQuery
        /// </summary>
        /// <param name="pTableAdapter"></param>
        public SqlServerScriptWizard(TableQuery pTableAdapter)
            : this()
        {
            TableQuery = pTableAdapter;
        }



        /// <summary>
        /// Query utilizado para o script
        /// </summary>
        public TableQuery TableQuery { get; set; }

        /// <summary>
        /// Lista de Parametros da Query
        /// </summary>
        private WhereCollection Parameters { get; set; }


        /// <summary>
        /// Limira a quantidade de registro que irá retornar em uma consulta
        /// </summary>
        /// <param name="pQuery">Query a ser executada</param>
        /// <param name="pPageIdName">Código para o campo de contagem</param>
        /// <param name="pStart">Linha Inicial</param>
        /// <param name="pEnd">Linha Final</param>
        /// <param name="pField">Campo de Ordenação</param>
        /// <param name="pOrder">Direção da Ordenação</param>
        /// <returns>Comando com a query a ser execudata</returns>
        public Tuple<string, List<TableAdapterField>> GetSelectStatment(TableQuery pQuery, string pPageIdName, int pStart, int pEnd, string pField, eOrder pOrder)
        {
            //Select COUNT(T0.CardCode) From OCRD T0

            //SELECT
            //    Limit.LimitId,
            //    Limit.CardCode,
            //    Limit.CardName
            //FROM (
            //    SELECT
            //        ROW_NUMBER() OVER (ORDER BY T0.CardCode ASC) AS LimitId,
            //        T0.CardCode,
            //        T0.CardName
            //    FROM OCRD T0
            //    ) AS Limit
            //WHERE Limit.LimitId BETWEEN 1 AND 50
            //ORDER BY Limit.LimitId ASC

            var sortField = GetOrderBy(
                new List<OrderBy>{ 
                    new OrderBy( new QueryParam(pQuery.Fields.First(c => c.Name == pField)) ,  pOrder)});

            pQuery.Fields.Add(new TableAdapterField
                {
                    Name = pPageIdName,
                    FieldType = eFieldType.eValueField,
                    Value = string.Format("ROW_NUMBER() OVER ({0})", sortField)
                });

            const string query = @"SELECT T0Limit.* FROM ( {0} ) AS T0Limit
                          WHERE {1} BETWEEN {2} AND {3} ORDER BY {1} ASC";

            var querySqlFormated = String.Format(query,
                GetSelectComplexStatmentInternal(pQuery),
                pPageIdName, pStart, pEnd);

            var parameters = Parameters.Select(GetDataParameter).ToList();

            return new Tuple<string, List<TableAdapterField>>(
                querySqlFormated,
                parameters
            );
        }

        /// <summary>
        /// Pega o comando da Query
        /// </summary>
        /// <returns>Um comando</returns>
        public Tuple<string, List<TableAdapterField>> GetSelectStatment()
        {
            return GetSelectComplexStatment(TableQuery);
        }

        /// <summary>
        /// Pega somente o Select da Query
        /// </summary>
        /// <param name="pTableQuery">tablQuery</param>
        /// <returns>Um comando</returns>
        public Tuple<string, List<TableAdapterField>> GetSelectComplexStatment(TableQuery pTableQuery)
        {
            var query = GetSelectComplexStatmentInternal(pTableQuery).ToString();

            var parameters = Parameters.Select(GetDataParameter).ToList();

            return new Tuple<string, List<TableAdapterField>>(query, parameters);
        }

        private StringBuilder GetSelectComplexStatmentInternal(TableQuery pTableQuery)
        {

            SetAliasName(pTableQuery);

            var mySql = new StringBuilder();

            mySql.AppendLine(GetSelectStringBuilder(pTableQuery).ToString());

            return mySql;
        }

        private StringBuilder GetInternalQuery(IEnumerable<TableQuery> tableQueries)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in tableQueries)
            {

                if (stringBuilder.Length > 0)
                    stringBuilder.AppendLine(GetUnionType(item.Union));

                stringBuilder.AppendLine(GetSelectStringBuilder(item).ToString());
            }

            return stringBuilder;
        }

        private StringBuilder GetSelectStringBuilder(TableQuery pQuery)
        {

            var query = new StringBuilder();

            query.AppendLine("  SELECT ");

            if (pQuery.Distinct)
                query.AppendLine(" DISTINCT ");

            if (pQuery.Top >= 0)
                query.AppendFormat(" TOP {0} ", pQuery.Top);

            query.Append(GetFieldsResult(pQuery.Fields.ToList(), pQuery.Fields.AllFields));

            if (!string.IsNullOrEmpty(pQuery.TableName))
                query.AppendFormat("  FROM {0} ",
                    GetTableName(pQuery.DbName, pQuery.TableName, pQuery.Alias, pQuery.SchemaTable));
            else
                query.AppendLine("  FROM  ");

            if (pQuery.Joins != null && pQuery.Joins.Count > 0)
            {
                foreach (var item in pQuery.Joins)
                    query.Append(GetInnerJoin(item));
            }

            if (pQuery.InternalQuery != null && pQuery.InternalQuery.Count > 0)
            {
                query.Append(" ( ");
                query.AppendLine(GetInternalQuery(pQuery.InternalQuery).ToString());
                query.Append(" ) " + (String.IsNullOrEmpty(pQuery.Alias) ? "" : pQuery.Alias));
            }

            if (pQuery.Wheres.Count > 0)
                query.AppendLine(GetWhere(pQuery.Wheres).ToString());

            if (pQuery.OrderBy.Count > 0)
                query.AppendLine(GetOrderBy(pQuery.OrderBy).ToString());

            return query;

        }

        private StringBuilder GetWhere(IEnumerable<WhereCollection> pWhere)
        {

            var sbwhere = new StringBuilder();

            foreach (var where in pWhere.Where(w => !w.IsEmpty()))
            {
                if (sbwhere.Length > 0)
                    sbwhere.Append(GetRelationShip(where.Relation));

                var whereInternal = new StringBuilder();

                foreach (var item in where)
                {
                    if (whereInternal.Length > 0)
                        whereInternal.AppendFormat("\n\t{0}",
                            GetConditionFieldName(item, true, true));
                    else
                        whereInternal.AppendFormat("\t{0}",
                            GetConditionFieldName(item, false, true));
                }

                if (whereInternal.Length > 0)
                    sbwhere.AppendFormat("( {0} )", whereInternal);
            }

            if (sbwhere.Length > 0)
                sbwhere.Insert(0, " WHERE \n");

            return sbwhere;
        }

        private StringBuilder GetOrderBy(IEnumerable<OrderBy> pOrder)
        {
            var orderBy = new StringBuilder();

            foreach (OrderBy myItem in pOrder)
                orderBy.AppendFormat("\t{0} {1} {2}\n",
                    (orderBy.Length > 0 ? "," : ""),
                    GetFieldName(
                        myItem.Field.AliasTableName,
                        myItem.Field.FieldName,
                        string.Empty),
                    GetOrderDirection(myItem.Order));

            if (orderBy.Length > 0)
                orderBy.Insert(0, " ORDER BY \n");

            return orderBy;
        }

        private static string GetOrderDirection(eOrder peOrder)
        {
            switch (peOrder)
            {
                case eOrder.eoASC:
                    return " ASC ";
                case eOrder.eoDESC:
                    return " DESC ";
                default:
                    return string.Empty;
            }
        }

        private string GetUnionType(eUnionType eUnionType)
        {
            switch (eUnionType)
            {
                case eUnionType.eutAll:
                    return " UNION ALL ";
                default:
                    throw new NotSupportedException(eUnionType.ToString());
            }
        }

        private StringBuilder GetInnerJoin(Join pJoin)
        {
            var join = new StringBuilder();

            join.Append(GetJoinRelationShip(pJoin.RelationShip));

            if (pJoin.TableQuery.Fields.Count > 0)
                join.AppendFormat(
                    "( {0} ) {1}",
                    GetSelectStringBuilder(pJoin.TableQuery),
                    pJoin.TableQuery.Alias);
            else
                join.AppendFormat("{0} ",
                    GetTableName(pJoin.TableQuery.DbName, pJoin.TableQuery.TableName, pJoin.TableQuery.Alias,
                        pJoin.TableQuery.SchemaTable));

            join.Append(GetJoinOn(pJoin.On));

            return join;
        }

        private string GetJoinRelationShip(eJoinRelationShip peJoinRelationShip)
        {
            switch (peJoinRelationShip)
            {
                case eJoinRelationShip.ejrInnerJoin:
                    return " INNER JOIN ";
                case eJoinRelationShip.ejrLeftJoin:
                    return " LEFT JOIN ";
                case eJoinRelationShip.ejrOuterJoin:
                    return " OUTER JOIN ";
                default:
                    throw new NotSupportedException(peJoinRelationShip.ToString());
            }
        }

        private StringBuilder GetFieldsResult(List<TableAdapterField> pFields, bool allField)
        {

            var fields = new StringBuilder();

            //{,} [Nome do Campo] {= Valor}
            //{= Valor} Somente é adicionado se o campo for do tipo diferente de Resultado da Tablea

            foreach (TableAdapterField value in pFields)
                fields.AppendFormat("\t{0} {1} {2}\n",
                    fields.Length > 0 ? "," : "",
                    GetFieldName(value.TableAlias, value.Name, value.Alias),
                    (
                        value.FieldType == eFieldType.eResult ? string.Empty :
                            (!value.DbTypeIsNumeric() && value.FieldType != eFieldType.eValueField ?
                             string.Format("= '{0}'", value.Value) : string.Format("= {0}", value.Value))
                    )
                    );

            if (pFields.Count == 0 & allField)
                fields.AppendLine(" * ");

            return fields;
        }

        private void SetAliasName(TableQuery tableQuery)
        {
            foreach (var item in tableQuery.Fields)
                SetAliasNameForField(tableQuery, item);

            foreach (var item in tableQuery.Where)
                SetAliasNameForField(tableQuery, item);

            if (tableQuery.Joins != null && tableQuery.Joins.Count > 0)
                foreach (var item in tableQuery.Joins)
                    SetAliasName(item.TableQuery);

            if (tableQuery.InternalQuery != null && tableQuery.InternalQuery.Count > 0)
                foreach (var item in tableQuery.InternalQuery)
                    SetAliasName(item);
        }

        private void SetAliasNameForField(TableQuery tableQuery, QueryParam myOn)
        {
            if (String.IsNullOrEmpty(myOn.AliasTableName) && !String.IsNullOrEmpty(tableQuery.Alias))
                myOn.AliasTableName = tableQuery.Alias;
        }

        private static void SetAliasNameForField(TableQuery tableQuery, TableAdapterField item)
        {
            if (String.IsNullOrEmpty(item.TableAlias) && item.FieldType == eFieldType.eResult)
                item.TableAlias = tableQuery.Alias;
        }

        //private const string AspasCaracter = "'";
        //private const char SpaceCaracter = ' ';
        //private const char PointCaracter = '.';
        //private const char LeftQuoteCaracter = '[';
        //private const char RigthQuoteCaracter = ']';

        /// <summary>
        /// Pega o nome da tabela   
        /// </summary>
        /// <param name="pdbName">Nome do Banco</param>
        /// <param name="pTableName">Nome da Tabela</param>
        /// <param name="pAliasName">Nome do Slia</param>
        /// <param name="schemaTable">Owner</param>
        /// <returns></returns>
        public string GetTableName(string pdbName, string pTableName, string pAliasName, bool schemaTable)
        {
            string tableName;

            //"[Nome do Banco].Nome da Tabela Alias"
            if (schemaTable)
                tableName = string.Format("[{0}].{1} {2}",
                    pdbName,
                    pTableName,
                    pAliasName);
            else
                //"[Nome do Banco]..[Nome da Table] Alias"
                tableName = string.Format("[{0}]..[{1}] {2}",
                    pdbName,
                    pTableName.RemoveCharacter("[]", ""),
                    pAliasName);

            return tableName;
        }

        /// <summary>
        /// Nome do Campo de Dados
        /// </summary>
        /// <param name="pTableAlias">Apelido do Banco dados</param>
        /// <param name="pFieldName">Nome do Campo</param>
        /// <param name="pAlias">Apelido do Campo</param>
        /// <returns>Nome do Campo para ser consultado</returns>
        public string GetFieldName(string pTableAlias, string pFieldName, string pAlias)
        {
            //[TableAlias].[Nome do Campo] AS [Alias] 
            var field = string.Format("{0}[{1}] {2}",
                string.IsNullOrEmpty(pTableAlias) ? string.Empty : string.Format("[{0}].", pTableAlias),
                pFieldName,
                string.IsNullOrEmpty(pAlias) ? string.Empty : string.Format("AS {0}", pAlias));
            return field;
        }

        /// <summary>
        /// Captura o Join do Banco de dados
        /// </summary>
        /// <param name="pOn">Tabelas</param>
        /// <returns>Um string do Join</returns>
        public StringBuilder GetJoinOn(WhereCollection pOn)
        {
            var where = new StringBuilder();

            foreach (QueryParam myItem in pOn)
                where.AppendFormat("\t{0}\n",
                    GetConditionFieldName(myItem, where.Length > 0, true));

            if (where.Length > 0)
                where.Insert(0, " ON ");

            return where;
        }

        /// <summary>
        /// Adicione o parametro do banco de dados
        /// </summary>
        /// <param name="pQueryParam">Query</param>
        public TableAdapterField GetDataParameter(QueryParam pQueryParam)
        {
            switch (pQueryParam.Condition)
            {
                case eCondition.ecLikeStart:
                    return CreateDataParameter(pQueryParam.FieldName, pQueryParam.DbType, pQueryParam.Value1 + "%");

                case eCondition.ecLikeEnd:
                    return CreateDataParameter(pQueryParam.FieldName, pQueryParam.DbType, "%" + pQueryParam.Value1);

                case eCondition.ecLike:
                    return CreateDataParameter(pQueryParam.FieldName, pQueryParam.DbType, "%" + pQueryParam.Value1 + "%");

                case eCondition.ecBetween:
                case eCondition.ecNotBetween:
                    return CreateDataParameter(pQueryParam.FieldName, pQueryParam.DbType, pQueryParam.Value1);

                case eCondition.ecIsNull:
                case eCondition.ecNotNull:
                    break;
                default:
                    return CreateDataParameter(pQueryParam.FieldName, pQueryParam.DbType, pQueryParam.Value1);

            }

            throw new Exception("AddDataParameter: Parametros errados foram passados");

        }

        /// <summary>
        /// Cria um parametro do banco de dados
        /// </summary>
        /// <param name="pFieldName">Nome do Banco de dados</param>
        /// <param name="pDbTYpe">Tipo do Banco</param>
        /// <param name="pValue">Valor do Banco</param>
        /// <returns>Data Parameter</returns>
        public TableAdapterField CreateDataParameter(string pFieldName, DbType pDbTYpe, object pValue)
        {
            var dataParameter = new TableAdapterField
            {
                Name = pFieldName,
                DbType = pDbTYpe,
                Value = pValue
            };

            return dataParameter;

        }

        /// <summary>
        /// Pega a condição
        /// </summary>
        /// <param name="pQueryParam">Parametro do Query</param>
        /// <param name="pRelantionShip">Relacionado</param>
        /// <param name="pWithNameParam">Com os parametros</param>
        /// <returns>Nome do Campo para condição</returns>
        public string GetConditionFieldName(QueryParam pQueryParam, bool pRelantionShip, bool pWithNameParam)
        {
            var stringBuilder = new StringBuilder();

            if (pRelantionShip)
                stringBuilder.Append(GetRelationShip(pQueryParam.Relationship));

            stringBuilder.Append(
                GetFieldName(pQueryParam.AliasTableName, pQueryParam.FieldName, string.Empty));

            stringBuilder.Append(GetCondition(pQueryParam.Condition));

            stringBuilder.Append(GetConditionValue(pQueryParam, pWithNameParam));

            return stringBuilder.ToString();
        }

        //private const string SinlgeQuoteCaracter = "'";
        //private const string EqualCaracter = "=";
        //private const string TabCaracter = "\t";
        //private const string NameParamCaracter = "@";
        //private const string AnyCaracter = "%";
        //private const string FirstFieldCaracter = "1";
        //private const string SecondFieldCaracter = "2";

        /// <summary>
        /// Pega o nome do banco de dados
        /// </summary>
        /// <param name="pQueryParam">Parametros da query</param>
        /// <param name="pWithNameParam">Com parametros</param>
        /// <returns></returns>
        public string GetConditionValue(QueryParam pQueryParam, bool pWithNameParam)
        {

            if (pWithNameParam)
            {
                return pQueryParam.Value1Column != null
                    ? GetConditionValueByColumn(pQueryParam)
                    : GetConditionValueByParam(pQueryParam);
            }

            var value = string.Empty;

            switch (pQueryParam.Condition)
            {
                case eCondition.ecLikeStart:
                    value = string.Format("{0}%", pQueryParam.FieldName);
                    break;
                case eCondition.ecLikeEnd:
                    value = string.Format("%{0}", pQueryParam.FieldName);
                    break;
                case eCondition.ecBetween:
                case eCondition.ecNotBetween:
                    value = string.Format(
                        "{0}1 {1} {0}2",
                        pQueryParam.FieldName,
                        GetRelationShip(eRelationship.erAnd));
                    break;
                case eCondition.ecIsNull:
                case eCondition.ecNotNull:
                    break;
                case eCondition.ecIn:
                case eCondition.ecNotIn:
                    value = string.Format("({0})", pQueryParam.FieldName);
                    break;
                default:
                    value = string.Format(pQueryParam.FieldName);
                    break;
            }

            return value;
        }

        private String GetConditionValueByColumn(QueryParam pQueryParam)
        {
            var value = string.Empty;

            switch (pQueryParam.Condition)
            {
                case eCondition.ecBetween:
                case eCondition.ecNotBetween:
                    //{0} {relation} {1}
                    value = string.Format("{0} {1} {2}",
                        GetFieldName(
                            pQueryParam.Value1Column.AliasTableName, pQueryParam.Value1Column.FieldName, string.Empty),
                        GetRelationShip(eRelationship.erAnd),
                        GetFieldName(
                            pQueryParam.Value2Column.AliasTableName, pQueryParam.Value2Column.FieldName, string.Empty));
                    break;
                case eCondition.ecIsNull:
                case eCondition.ecNotNull:
                    break;
                default:
                    value = GetFieldName(
                        pQueryParam.Value1Column.AliasTableName,
                        pQueryParam.Value1Column.FieldName, string.Empty);
                    break;
            }

            return value;
        }

        private String GetConditionValueByParam(QueryParam pQueryParam)
        {

            var valueConditional = string.Empty;
            var nameParam = GetParamFieldName(pQueryParam.FieldName);

            switch (pQueryParam.Condition)
            {
                case eCondition.ecBetween:
                case eCondition.ecNotBetween:
                    // @FieldName1 And @FieldName2
                    valueConditional = string.Format("@{0}1 {1} @{0}2",
                        nameParam, GetRelationShip(eRelationship.erAnd));
                    AddNewParamToParameters(string.Format("{0}1", nameParam), pQueryParam, false);
                    AddNewParamToParameters(string.Format("{0}2", nameParam), pQueryParam, true);
                    break;
                case eCondition.ecIsNull:
                case eCondition.ecNotNull:
                    break;
                case eCondition.ecIn:
                case eCondition.ecNotIn:
                    
                    var valuesOfListOrEmpty = pQueryParam.Value1 as IEnumerable ?? new object[]{};
                    var paramValuesInArray = valuesOfListOrEmpty as object[] ?? valuesOfListOrEmpty.Cast<object>().ToArray();

                    if (!paramValuesInArray.Any())
                    {
                        valueConditional = "('')";
                        break;
                    }

                    var paramNames = new List<string>();                    

                    for (var i = 0; i < paramValuesInArray.Length; i++)
                    {
                        var nameOfParam = "@{0}{1}".Fmt(nameParam, i);

                        var queryParam = new QueryParam(pQueryParam)
                        {
                            FieldName = nameOfParam, 
                            Value1 = paramValuesInArray[i]
                        };

                        paramNames.Add(nameOfParam);
                        AddNewParamToParameters(nameOfParam, queryParam, false);   
                    }

                    valueConditional = string.Format("({0})".Fmt(string.Join(",", paramNames)));

                    break;
                default:
                    valueConditional = string.Format("@{0}", nameParam);
                    AddNewParamToParameters(nameParam, pQueryParam, false);
                    break;
            }

            return valueConditional;

        }

        private void AddNewParamToParameters(string pPramName, QueryParam pQueryParam, bool pValue2)
        {
            var queryParam = new QueryParam(pQueryParam) { FieldName = pPramName };

            if (pValue2)
            {
                queryParam.Value1 = queryParam.Value2;
            }

            Parameters.Add(queryParam);

        }

        private string GetParamFieldName(string pFieldName)
        {
            var countParams = Parameters.FindAll(
                    p => p.FieldName.StartsWith(pFieldName)).Count();

            return string.Format(
                "{0}{1}",
                pFieldName,
                countParams == 0 ? string.Empty : countParams.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Pega o operado da condição
        /// </summary>
        /// <param name="eCondition">Tipo da Condição</param>
        /// <returns>A string da condição</returns>
        public string GetCondition(eCondition eCondition)
        {
            String condictional = string.Empty;

            switch (eCondition)
            {
                case eCondition.ecEqual:
                    condictional = "=";
                    break;
                case eCondition.ecGraterThan:
                    condictional = ">";
                    break;
                case eCondition.ecLessThan:
                    condictional = "<";
                    break;
                case eCondition.ecGraterEqual:
                    condictional = ">=";
                    break;
                case eCondition.ecLessEqual:
                    condictional = "<=";
                    break;
                case eCondition.ecNotEqual:
                    condictional = "<>";
                    break;
                case eCondition.ecLike:
                case eCondition.ecLikeStart:
                case eCondition.ecLikeEnd:
                    condictional = " Like ";
                    break;
                case eCondition.ecNotLike:
                    condictional = " Not Like ";
                    break;
                case eCondition.ecBetween:
                    condictional = " Between ";
                    break;
                case eCondition.ecNotBetween:
                    condictional = " Not Between ";
                    break;
                case eCondition.ecIsNull:
                    condictional = " Is Null ";
                    break;
                case eCondition.ecNotNull:
                    condictional = " Is Not Null ";
                    break;
                case eCondition.ecIn:
                    condictional = " In ";
                    break;
                case eCondition.ecNotIn:
                    condictional = " Not In ";
                    break;
            }

            return condictional;
        }

        /// <summary>
        /// Pega o operado booleando
        /// </summary>
        /// <param name="pRelationship">Tipo da Relação</param>
        /// <returns></returns>
        public string GetRelationShip(eRelationship pRelationship)
        {
            switch (pRelationship)
            {
                case eRelationship.erAnd:
                    return " AND ";
                case eRelationship.erOr:
                    return " OR ";
                default:
                    return string.Empty;
            }
        }


        ///// <summary>
        ///// Pega a query montado dentro da string
        ///// </summary>
        ///// <returns></returns>
        //public StringBuilder GetStringBuilder()
        //{

        //    IDbCommand myDbCommand = Connection.Instance.GetDbConnection().CreateCommand();

        //    myDbCommand.CommandText = GetSelectComplexStatmentInternal(TableQuery).ToString();

        //    foreach (var item in Parameters)
        //        AddDataParameter(ref myDbCommand, item);

        //    var myQuery = new StringBuilder();
        //    var myParamType = new StringBuilder();
        //    var myParamValue = new StringBuilder();

        //    foreach (IDbDataParameter item in myDbCommand.Parameters)
        //    {
        //        if (myParamType.Length > 0)
        //        {
        //            myParamType.AppendLine();
        //            myParamType.Append(",");

        //            myParamValue.AppendLine();
        //            myParamValue.Append(",");

        //        }

        //        myParamType.Append("@" + item.ParameterName + " ");

        //        myParamType.Append(GetCreateFieldType(item.DbType, item.Size, item.Precision, item.Scale));
        //        myParamValue.Append("@" + item.ParameterName + " =  N'" + item.Value + "'");

        //    }

        //    myQuery.AppendLine("exec sp_executesql ");
        //    myQuery.AppendLine("N' ");
        //    myQuery.AppendLine(myDbCommand.CommandText);
        //    myQuery.AppendLine("'");

        //    if (myParamType.Length > 0)
        //    {
        //        //Os nomes e os tipos dos parametros
        //        myQuery.AppendLine(",N' ");
        //        myQuery.AppendLine(myParamType.ToString());
        //        myQuery.AppendLine("'");
        //        //',N'@CardType1 nvarchar(1)'

        //        myQuery.AppendLine(",");
        //        myQuery.AppendLine(myParamValue.ToString());
        //        myQuery.AppendLine("");

        //        //os valores dos parametros
        //        //,@CardType1=N'S'
        //    }

        //    return myQuery;
        //}
    }

}
