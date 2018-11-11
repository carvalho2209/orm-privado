using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI.B1.Documents;
using System.Data;
using Nampula.DI.B1.Itens;
using Nampula.Framework;

namespace Nampula.DI.B1.SalesTaxCode
{
    /// <summary>
    /// Classe para tratamento de captura de código de imposto do SAP.
    /// </summary>
    public class TaxCodeDetermination
    {
        
        /// <summary>
        /// Instancia a classe de determinação de código de imposto
        /// </summary>
        /// <param name="pCompanyDB">Banco de dados da empresa</param>
        /// <param name="pTransType">Tipo de Transação</param>
        public TaxCodeDetermination(string pCompanyDB, eTransactionType pTransType)
        {
            this.CompanyDb = pCompanyDB;
            this.TransType = pTransType;
        }
        

        
        /// <summary>
        /// Utilização
        /// </summary>
        public int Usage { get; private set; }
        /// <summary>
        /// Código do Imposto
        /// </summary>
        public string TaxCode { get; private set; }
        /// <summary>
        /// Código do Imposto para Despesa adicional
        /// </summary>
        public string ExpenseTaxCode { get; private set; }
        /// <summary>
        /// Banco de dado da Empresa
        /// </summary>
        public string CompanyDb { get; private set; }
        /// <summary>
        /// Código do item
        /// </summary>
        public string ItemCode { get; private set; }
        /// <summary>
        /// Tipo de Transação
        /// </summary>
        public eTransactionType TransType { get; private set; }
        

        
        /// <summary>
        /// Pega o código de imposto conforme a determinação do SAP
        /// </summary>
        /// <param name="pUsage">Utilização</param>
        /// <param name="pCardCode">Código do Cliente</param>
        /// <param name="pItemCode">Código do item</param>
        /// <returns>True se encontrar a determinação</returns>
        public bool GetTaxCode(Int32 pUsage, string pCardCode, string pItemCode)
        {
            return GetTaxCode(pUsage, pCardCode, pItemCode, GetTcdType(this.CompanyDb, pItemCode));
        }
        

        
        /// <summary>
        /// Pega o código de imposto conforme a determinação do SAP
        /// </summary>
        /// <param name="pUsage">Utilização</param>
        /// <param name="pCardCode">Código do Cliente</param>
        /// <param name="pItemCode">Código do item</param>
        /// <param name="pTdcType">Tipo de Determinação de Código de Imposto</param>
        /// <returns>True se encontrar a determinação</returns>
        public bool GetTaxCode(Int32 pUsage, string pCardCode, string pItemCode, TcdTypeEnum pTdcType)
        {
            var conn = Connection.Instance;

            this.Usage = pUsage;
            this.ItemCode = pItemCode;

            var query = new StringBuilder();

            query.AppendLine(" Select");
            query.AppendLine("        T1.Priority,");
            query.AppendLine("        T1.AbsId,");
            query.AppendLine("        Keyfld_1 = IsNull(T1.Keyfld_1,0),");
            query.AppendLine("        Keyfld_2 = IsNull(T1.Keyfld_2,0),");
            query.AppendLine("        Keyfld_3 = IsNull(T1.Keyfld_3,0) ");
            query.AppendLine(" From ");
            query.AppendFormat("       [{0}]..OTCD T With (NOLOCK), ", this.CompanyDb);
            query.AppendFormat("       [{0}]..TCD1 T1 With (NOLOCK)", this.CompanyDb);
            query.AppendLine(" Where      ");
            query.AppendFormat("        T.TcdType = '{0}' \n", pTdcType.ToStrEnum());
            query.AppendLine("    And T1.TcdId=T.AbsId");
            query.AppendLine("        Order by T1.Priority");

            var keyFields = conn.SqlServerQuery(query.ToString());

            foreach (DataRow row in keyFields.Rows)
            {

                var keyField1 = GetKeyField(pCardCode, pItemCode, row.Field<Int32>("Keyfld_1"));
                var keyField2 = GetKeyField(pCardCode, pItemCode, row.Field<Int32>("Keyfld_2"));
                var keyField3 = GetKeyField(pCardCode, pItemCode, row.Field<Int32>("Keyfld_3"));

                query = new StringBuilder();
                query.AppendLine(" Select");
                query.AppendLine("      T2.AbsId");
                query.AppendLine(" From ");
                query.AppendFormat("       [{0}]..TCD2 T2 With (NOLOCK) \n", this.CompanyDb);
                query.AppendLine(" Where ");
                query.AppendFormat("       IsNull(T2.KeyFld_1_V,0)=IsNull('{0}',0)", keyField1);
                query.AppendFormat("   and IsNull(T2.KeyFld_2_V,0)=IsNull('{0}',0)", keyField2);
                query.AppendFormat("   and IsNull(T2.KeyFld_3_V,0)=IsNull('{0}',0)", keyField3);
                query.AppendFormat("   and T2.Tcd1Id = {0} ", row.Field<Int32>("AbsId"));

                var absID = conn.SqlExecuteScalar<Int32>(query.ToString());

                if (absID != 0)
                {
                    query = new StringBuilder();

                    switch (pTdcType)
                    {
                        case TcdTypeEnum.MaterialItem:
                            query.AppendLine(" Select");
                            query.AppendLine("        T5.TaxCode,");
                            query.AppendLine("        T5.ExpTaxCode ");
                            query.AppendLine(" From ");
                            query.AppendFormat("        [{0}]..TCD3 T3 With (NOLOCK),", this.CompanyDb);
                            query.AppendFormat("        [{0}]..TCD5 T5 With (NOLOCK)", this.CompanyDb);
                            query.AppendLine(" Where ");
                            query.AppendFormat("          T3.Tcd2Id = {0}", absID);
                            query.AppendLine("      and T5.Tcd3Id = T3.AbsId ");
                            query.AppendFormat("      and T5.UsageCode= {0}", pUsage);
                            query.AppendFormat("      and T3.EfctFrom in (Select T0.EfctFrom from [{0}]..TCD3 T0 Where T0.tcd2id={1} ",
                                this.CompanyDb, absID);
                            query.AppendLine(" And datediff(d,T0.EfctFrom,GetDate()) >= 0 ");
                            query.AppendLine(" And datediff(d,IsNull(T0.EfctTo,GetDate()),GetDate()) <= 0 )");

                            break;
                        case TcdTypeEnum.ServiceItem:
                            query.AppendLine(" Select");
                            query.AppendLine("        T0.TaxCode, ");
                            query.AppendLine("        ExpTaxCode = ''");
                            query.AppendLine(" From ");
                            query.AppendFormat("        [{0}]..TCD3 T0 With (NOLOCK) ", this.CompanyDb);
                            query.AppendLine(" Where ");
                            query.AppendFormat("            T0.Tcd2Id = {0}", absID);
                            query.AppendFormat("          And datediff(d,T0.EfctFrom,GetDate()) >= 0 ");
                            query.AppendFormat("          And datediff(d,IsNull(T0.EfctTo,GetDate()),GetDate()) <= 0");
                            break;
                        default:
                            throw new Exception("Tipo de Determinação não suportado.");
                    }

                    var taxCode = conn.SqlServerQuery(query.ToString()).AsEnumerable().SingleOrDefault();

                    if (taxCode != null)
                    {
                        this.TaxCode = taxCode.Field<String>("TaxCode");
                        this.ExpenseTaxCode = taxCode.Field<String>("ExpTaxCode");
                        return true;
                    }
                }
            }

            //Se não achou nenhum imposto pega o padrão
            query = new System.Text.StringBuilder();

            switch (pTdcType)
            {
                case TcdTypeEnum.MaterialItem:
                    query.AppendLine(" Select");
                    query.AppendLine("        T5.TaxCode,");
                    query.AppendLine("        T5.ExpTaxCode ");
                    query.AppendLine(" From ");
                    query.AppendFormat("        [{0}]..TCD5 T5 With (NOLOCK)\n", this.CompanyDb);
                    query.AppendLine(" Where ");
                    query.AppendLine("          T5.Tcd3Id Is Null ");
                    query.AppendFormat("      and T5.UsageCode = {0}\n", pUsage);
                    query.AppendFormat("      and Type = '{0}'",
                        this.TransType == eTransactionType.oIn ? "P" : "R");

                    var taxCodeDefault = conn.SqlServerQuery(query.ToString()).AsEnumerable().FirstOrDefault();

                    if (taxCodeDefault != null)
                    {
                        this.TaxCode = taxCodeDefault.Field<String>("TaxCode");
                        this.ExpenseTaxCode = taxCodeDefault.Field<String>("ExpTaxCode");
                        return true;
                    }

                    break;
                case TcdTypeEnum.ServiceItem:
                    query.AppendLine(" Select");
                    query.AppendLine("        T1.DftArCode,");
                    query.AppendLine("        T1.DftApCode");
                    query.AppendLine(" From ");
                    query.AppendFormat("       [{0}]..OTCD T1 With (NOLOCK) ", this.CompanyDb);
                    query.AppendLine(" Where      ");
                    query.AppendFormat("        T1.TcdType = '{0}' \n", pTdcType.ToStrEnum());

                    var taxCodeDefaults = conn.SqlServerQuery(query.ToString()).AsEnumerable().FirstOrDefault();

                    if (taxCodeDefaults != null)
                    { 
                        this.TaxCode = this.TransType == eTransactionType.oIn ?
                            taxCodeDefaults.Field<String>("DftApCode") : taxCodeDefaults.Field<String>("DftArCode");

                        return true;
                    }

                    break;
                default:
                    throw new Exception("Tipo de Determinação não suportado.");
            }

            return false;

        }
        

        
        /// <summary>
        /// Pega o valor do campo chave
        /// </summary>
        /// <param name="pCardCode">Código do Parceiro</param>
        /// <param name="pItemCode">Código do Item</param>
        /// <param name="pKeyField">Tipo do Campo Chave</param>
        /// <returns>Um string com o valor do campo chave</returns>
        private string GetKeyField(string pCardCode, string pItemCode, Int32 pKeyField)
        {
            var query = String.Empty;

            switch (pKeyField)
            {
                case 1:
                    //  1 - CardCode -Parceiro de Negocios
                    query = string.Format("Select CardCode from [{0}]..OCRD with (nolock) Where CardCode = '{1}'",
                        this.CompanyDb, pCardCode);
                    break;
                case 2:
                    //  2 - ItemCode -Item
                    query = string.Format("Select ItemCode from [{0}]..OITM with (nolock) Where ItemCode = '{1}'",
                            this.CompanyDb, pItemCode);
                    break;
                case 3:
                    //  3 - MatGroup -Grupo Material
                    query = string.Format("Select matgrp from [{0}]..OITM with (nolock) Where ItemCode = '{1}'",
                            this.CompanyDb, pItemCode);
                    break;
                case 5:
                    //  5 - Ncmcode  -Ncm
                    query = string.Format("Select Ncmcode from [{0}]..OITM with (nolock) Where ItemCode = '{1}'",
                            this.CompanyDb, pItemCode);
                    break;
                case 6:
                    //  6 - Estado
                    query = string.Format("Select State2 from [{0}]..OCRD with (nolock) Where CardCode = '{1}'",
                    this.CompanyDb, pCardCode);
                    break;
                case 9:
                    //  9 - Grupo de itens
                    query = string.Format("Select ItmsGrpCod from [{0}]..OITM with (nolock) Where ItemCode = '{1}'",
                    this.CompanyDb, pItemCode);
                    break;
                case 11:
                    // 11 - Grupo de cliente
                    query = string.Format("Select GroupCode from [{0}]..OCRD with (nolock) Where CardCode = '{1}'",
                    this.CompanyDb, pCardCode);
                    break;
                case 12:
                    // 12 - Grupo do Fornecedor
                    query = string.Format("Select GroupCode from [{0}]..OCRD with (nolock) Where CardCode = '{1}'",
                        this.CompanyDb, pCardCode);
                    break;
            }

            if (string.IsNullOrEmpty(query))
                return "0";
            else
                return Connection.Instance.SqlExecuteScalar<String>(query);

        }
        

        
        /// <summary>
        /// Pega o tipo de determinação de imposto
        /// </summary>
        /// <param name="pCompanyDb">banco da empresa</param>
        /// <param name="pItemCode">Código do Item</param>
        /// <returns>Um enum com o tipo de determinação de código de imposto</returns>
        private TcdTypeEnum GetTcdType(string pCompanyDb, string pItemCode)
        {
            var itemClass = (ItemClassType)Connection.Instance.SqlExecuteScalar<Int16>(
                string.Format("Select ItemClass from [{0}]..OITM with (nolock) Where ItemCode = '{1}'",
                        pCompanyDb, pItemCode));

            var result = TcdTypeEnum.MaterialItem;

            switch (itemClass)
            {
                case ItemClassType.Service:
                    result = TcdTypeEnum.ServiceItem;
                    break;
                case ItemClassType.Material:
                    result = TcdTypeEnum.MaterialItem;
                    break;
                default:
                    throw new Exception("Não encontrado tipo de material");
            }

            return result;

        }
        

    }
}
