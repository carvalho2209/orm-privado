using System;
using System.Data;
using Nampula.DI.B1.Documents;

namespace Nampula.DI.B1.NotaFiscal
{

    public class CfopDetermination
    {
        private readonly int _categoryIdForIpi;
        private readonly int _categoryIdForPis;
        private readonly int _categoryIdForCofins;
        private readonly int _categoryIdForIcms;

        public string Cfop { get; set; }
        public string CstForIcms { get; set; }
        public string CstForIpi { get; set; }
        public string CstForPis { get; set; }
        public string CstForCofins { get; set; }
        public string CompanyDb { get; set; }
        public eTransactionType TransType { get; set; }
        public decimal RateForIpi { get; set; }
        public decimal RateForPis { get; set; }
        public decimal RateForCofins { get; set; }
        public string ProductSource { get; set; }

        public CfopDetermination(string pCompanyDb, eTransactionType pTransaciotn,
            int categoryIdForIpi = -4,
            int categoryIdForPis = -8,
            int categoryIdForCofins = -9,
            int categoryIdForIcms = -6)
        {
            CompanyDb = pCompanyDb;
            TransType = pTransaciotn;

            _categoryIdForIpi = categoryIdForIpi;
            _categoryIdForPis = categoryIdForPis;
            _categoryIdForCofins = categoryIdForCofins;
            _categoryIdForIcms = categoryIdForIcms;
        }


        public bool GetCfop(Int32 pUsage, string pTaxCode, string pItemCode)
        {

            var query = string.Format(
                "SELECT T0.[TaxIcms],T0.[CfopIn],T0.[CfopOut] FROM [{0}]..OSTC T0 With (NOLOCK) WHERE CODE = '{1}'",
                CompanyDb, pTaxCode);

            var data = Connection.Instance.SqlServerQuery(query);

            if (data.Rows.Count == 0)
                return false;

            var firstDataTow = data.Rows[0];

            if (TransType == eTransactionType.oOut)
            {
                Cfop = !firstDataTow.IsNull("CfopOut") ? firstDataTow.Field<string>("CfopOut") : string.Empty;
            }
            else
            {
                Cfop = !firstDataTow.IsNull("CfopIn") ? firstDataTow.Field<string>("CfopIn") : string.Empty;
            }

            // Carrega Situacao Tributaria ICMS Tabela A
            query = string.Format(
                "SELECT T0.[ProductSrc] FROM [{0}]..[OITM] T0 With (NOLOCK) WHERE T0.[ItemCode] = '{1}'"
                , CompanyDb, pItemCode);

            ProductSource = Connection.Instance.SqlExecuteScalar<string>(query);

            //// Carrega Situacao Tributaria da Tabela B  

            //switch (productSource)
            //{
            //    case "1":
            //        productSource = "0";
            //        break;
            //    case "2":
            //        productSource = "1";
            //        break;
            //    case "3":
            //        productSource = "2";
            //        break;
            //    default:
            //        productSource = "0";
            //        break;
            //}

            //' Carrega Situacao Tributaria ICMS Tabela B
            //m_CFOP = myPreffix + mySuffix

            //Verifica o sufixo do CST nas versões antes do PL10
            var suffixCst = !firstDataTow.IsNull("TaxIcms") ? firstDataTow.Field<string>("TaxIcms") : string.Empty;

            //Caso retorno nulo verifica o sufixo no CST na tabela nova
            if (string.IsNullOrEmpty(suffixCst))
            {
                suffixCst = GetCst(pTaxCode, _categoryIdForIcms, true);
            }

            CstForIcms = string.IsNullOrWhiteSpace(suffixCst)
                ? string.Empty
                : ProductSource + "." + suffixCst;

            CstForIpi = GetCst(pTaxCode, _categoryIdForIpi);
            CstForPis = GetCst(pTaxCode, _categoryIdForPis);
            CstForCofins = GetCst(pTaxCode, _categoryIdForCofins);

            RateForIpi = GetRate(pTaxCode, _categoryIdForIpi);
            RateForPis = GetRate(pTaxCode, _categoryIdForPis);
            RateForCofins = GetRate(pTaxCode, _categoryIdForCofins);

            return !String.IsNullOrWhiteSpace(Cfop);
        }

        private Decimal GetRate(string pTaxCode, int pStaType)
        {
            var query = @"
                    Select
                        S1.EfctivRate
                    From    [{0}]..[OSTT] TI With (NOLOCK),
                            [{0}]..[ONFT] IP With (NOLOCK),
                            [{0}]..[STC1] S1 With (NOLOCK)
                    Where 
                            TI.NFTAXID =IP.ABSID
                        and S1.STATYPE =TI.ABSID
                        and IP.AbsId={1}
                        and S1.[STCCode] ='{2}'";

            query = string.Format(query, CompanyDb, pStaType, pTaxCode);

            // -- Codigo do Imposto
            return Connection.Instance.SqlExecuteScalar<Decimal>(query);
        }

        public string GetCst(string pTaxCode, int pStaType, bool onlyTaxOne = false)
        {
            var query = @"
                    Select
                        IsNull(S1.CstCodeIn, S1.CstSuffix)
                    From    [{0}]..[OSTT] TI With (NOLOCK),
                            [{0}]..[ONFT] IP With (NOLOCK),
                            [{0}]..[STC1] S1 With (NOLOCK)
                    Where 
                            TI.NFTAXID =IP.ABSID
                        and S1.STATYPE =TI.ABSID
                        and IP.AbsId={1}
                        and S1.[STCCode] ='{2}'";

            query = string.Format(query, CompanyDb, pStaType, pTaxCode);

            var cstForIn = Connection.Instance.SqlExecuteScalar<String>(query);

            if (TransType != eTransactionType.oOut || onlyTaxOne)  
                return cstForIn;

            query = string.Format(
                "Select CodeOut From [{0}]..[OTSC] Where CODE = '{1}' and Category = {2}"
                , CompanyDb, cstForIn, pStaType);

            return Connection.Instance.SqlExecuteScalar<string>(query);
        }

    }

}
