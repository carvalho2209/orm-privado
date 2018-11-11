using System;
using System.Data;

namespace Nampula.DI.B1.Administrations
{

    /// <summary>
    /// Tabela de Informações da Empresa 
    /// </summary>
    public class Administration : TableAdapter
    {

        /// <summary>
        /// Nome dos campos 
        /// </summary>
        public struct FieldsName
        {

            public static readonly string Code = "Code";

            public static readonly string CompnyName = "CompnyName";
            public static readonly string Country = "Country";
            public static readonly string TaxIdNum = "TaxIdNum";
            public static readonly string TaxIdNum2 = "TaxIdNum2";
            public static readonly string TaxIdNum3 = "TaxIdNum3";
            public static readonly string FreeZoneNo = "FreeZoneNo";
            public static readonly string MltpBrnchs = "MltpBrnchs";
            public static readonly string Phone1 = "Phone1";
            public static readonly string Phone2 = "Phone2";
            public static readonly string Fax = "Fax";
            public static readonly string E_Mail = "E_Mail";
            public static readonly string Color = "Color";
            public static readonly string DecSep = "DecSep";
            public static readonly string ThousSep = "ThousSep";
            public static readonly string State = "State";

            public static readonly string PriceSys = "PriceSys";
            public static readonly string DflTaxCode = "DflTaxCode";
            public static readonly string TreePricOn = "TreePricOn";

            public static readonly string SumDec = "SumDec";
            public static readonly string PriceDec = "PriceDec";
            public static readonly string RateDec = "RateDec";
            public static readonly string QtyDec = "QtyDec";
            public static readonly string PercentDec = "PercentDec";
            public static readonly string MeasureDec = "MeasureDec";
            public static readonly string QueryDec = "QueryDec";
            public static readonly string MainCurncy = "MainCurncy";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {

            public static readonly string Code = "Código";

            public static readonly string CompnyName = "Nome da Empresa";
            public static readonly string Country = "País";
            public static readonly string TaxIdNum = "CNPJ";
            public static readonly string TaxIdNum2 = "Inscrição Estadual";
            public static readonly string TaxIdNum3 = "Ins. Est. Substituto Tributário";
            public static readonly string FreeZoneNo = "Inscrição Municipal";
            public static readonly string MltpBrnchs = "Ativar filiais múltiplas";
            public static readonly string Phone1 = "Telefone";
            public static readonly string Phone2 = "Telefone 2";
            public static readonly string Fax = "Fax";
            public static readonly string E_Mail = "E-mail";
            public static readonly string Color = "Cor de Fundo";
            public static readonly string DecSep = "Separador de Decimal";
            public static readonly string ThousSep = "Separador de Milhar";
            public static readonly string State = "Estado";

            public static readonly string PriceSys = "Custo por Deposito";
            public static readonly string DflTaxCode = "CNAE Code";
            public static readonly string TreePricOn = "Estrutura de Documentos, Exibir";

            public static readonly string SumDec = "Casas Decimais (Valores)";
            public static readonly string PriceDec = "Casas Decimais (Preços)";
            public static readonly string RateDec = "Casas Decimais (Taxas)";
            public static readonly string QtyDec = "Casas Decimais (Quantidade)";
            public static readonly string PercentDec = "Casas Decimais (%)";
            public static readonly string MeasureDec = "Casas Decimais (Unidade)";
            public static readonly string QueryDec = "Casas Decimais (Consultas)";
            public static readonly string MainCurncy = "Moeda Corrente";
        }

        /// <summary>
        /// Definição das Tabelas
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OADM";
        }

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, Description.Code, DbType.Int32, 11, null, true, false);
        TableAdapterField m_CompnyName = new TableAdapterField(FieldsName.CompnyName, Description.CompnyName, 100);
        TableAdapterField m_Country = new TableAdapterField(FieldsName.Country, Description.Country, 3);
        TableAdapterField m_TaxIdNum = new TableAdapterField(FieldsName.TaxIdNum, Description.TaxIdNum, 32);
        TableAdapterField m_TaxIdNum2 = new TableAdapterField(FieldsName.TaxIdNum2, Description.TaxIdNum2, 32);
        TableAdapterField m_TaxIdNum3 = new TableAdapterField(FieldsName.TaxIdNum3, Description.TaxIdNum3, 32);
        TableAdapterField m_FreeZoneNo = new TableAdapterField(FieldsName.FreeZoneNo, Description.FreeZoneNo, 32);
        TableAdapterField m_Phone1 = new TableAdapterField(FieldsName.Phone1, Description.Phone1, 20);
        TableAdapterField m_Phone2 = new TableAdapterField(FieldsName.Phone2, Description.Phone2, 20);
        TableAdapterField m_Fax = new TableAdapterField(FieldsName.Fax, Description.Phone2, 20);
        TableAdapterField m_E_Mail = new TableAdapterField(FieldsName.E_Mail, Description.E_Mail, 100);
        TableAdapterField m_Color = new TableAdapterField(FieldsName.Color, Description.Color, DbType.Int32);
        TableAdapterField m_DecSep = new TableAdapterField(FieldsName.DecSep, Description.DecSep, 1);
        TableAdapterField m_ThouSep = new TableAdapterField(FieldsName.ThousSep, Description.ThousSep, 1);
        TableAdapterField m_State = new TableAdapterField(FieldsName.State, Description.State, 3);
        TableAdapterField m_PriceSys = new TableAdapterField(FieldsName.PriceSys, Description.PriceSys, 1);
        TableAdapterField m_DflTaxCode = new TableAdapterField(FieldsName.DflTaxCode, Description.DflTaxCode, 8);
        TableAdapterField m_TreePricOn = new TableAdapterField(FieldsName.TreePricOn, Description.TreePricOn, 1);
        TableAdapterField m_MltpBrnchs = new TableAdapterField(FieldsName.MltpBrnchs, Description.MltpBrnchs, 1);
        TableAdapterField m_SumDec = new TableAdapterField(FieldsName.SumDec, Description.SumDec, DbType.Int16);
        TableAdapterField m_PriceDec = new TableAdapterField(FieldsName.PriceDec, Description.PriceDec, DbType.Int16);
        TableAdapterField m_RateDec = new TableAdapterField(FieldsName.RateDec, Description.RateDec, DbType.Int16);
        TableAdapterField m_QtyDec = new TableAdapterField(FieldsName.QtyDec, Description.QtyDec, DbType.Int16);
        TableAdapterField m_PercentDec = new TableAdapterField(FieldsName.PercentDec, Description.PercentDec, DbType.Int16);
        TableAdapterField m_MeasureDec = new TableAdapterField(FieldsName.MeasureDec, Description.MeasureDec, DbType.Int16);
        TableAdapterField m_QueryDec = new TableAdapterField(FieldsName.QueryDec, Description.QueryDec, DbType.Int16);
        TableAdapterField m_MainCurncy = new TableAdapterField(FieldsName.MainCurncy, Description.MainCurncy, 3);

        /// <summary>
        /// Administração
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public Administration(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
        {
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public Int32 Code
        {
            get { return m_Code.GetInt32(); }
            set { m_Code.Value = value; }
        }

        public string CompnyName
        {
            get { return m_CompnyName.GetString(); }
            set { m_CompnyName.Value = value; }
        }

        public string Country
        {
            get { return m_Country.GetString(); }
            set { m_Country.Value = value; }
        }



        /// <summary>
        /// CNPJ
        /// </summary>
        public string TaxIdNum
        {
            get { return m_TaxIdNum.GetString(); }
            set { m_TaxIdNum.Value = value; }
        }

        /// <summary>
        /// Inscrição Estadual
        /// </summary>
        public string TaxIdNum2
        {
            get { return m_TaxIdNum2.GetString(); }
            set { m_TaxIdNum2.Value = value; }
        }

        /// <summary>
        /// "Ins. Est. Substituto Tributário"
        /// </summary>
        public string TaxIdNum3
        {
            get { return m_TaxIdNum3.GetString(); }
            set { m_TaxIdNum3.Value = value; }
        }
        /// <summary>
        /// "Inscrição Municipal"
        /// </summary>
        public string FreeZoneNo
        {
            get { return m_FreeZoneNo.GetString(); }
            set { m_FreeZoneNo.Value = value; }
        }

        public string Phone1
        {
            get { return m_Phone1.GetString(); }
            set { m_Phone1.Value = value; }
        }

        public string Phone2
        {
            get { return m_Phone2.GetString(); }
            set { m_Phone2.Value = value; }
        }

        public string Fax
        {
            get { return m_Fax.GetString(); }
            set { m_Fax.Value = value; }
        }

        public string E_Mail
        {
            get { return m_E_Mail.GetString(); }
            set { m_E_Mail.Value = value; }
        }

        public string Color
        {
            get { return m_Color.GetString(); }
            set { m_Color.Value = value; }
        }

        public string DecSep
        {
            get { return m_DecSep.GetString(); }
            set { m_DecSep.Value = value; }
        }

        public string ThousSep
        {
            get { return m_ThouSep.GetString(); }
            set { m_ThouSep.Value = value; }
        }

        public string State
        {
            get { return m_State.GetString(); }
            set { m_State.Value = value; }
        }

        public eYesNo PriceSys
        {
            get { return m_PriceSys.GetString().ToYesNoEnum(); }
            set { m_PriceSys.Value = value.ToYesNoString(); }
        }

        public string DflTaxCode
        {
            get { return m_DflTaxCode.GetString(); }
            set { m_DflTaxCode.Value = value; }
        }

        public eYesNo TreePricOn
        {
            get { return m_TreePricOn.GetString().ToYesNoEnum(); }
            set { m_TreePricOn.Value = value.ToYesNoString(); }
        }

        public Int16 SumDec
        {
            get { return m_SumDec.GetInt16(); }
            set { m_SumDec.Value = value; }
        }

        public Int16 PriceDec
        {
            get { return m_PriceDec.GetInt16(); }
            set { m_PriceDec.Value = value; }
        }

        public Int16 QtyDec
        {
            get { return m_QtyDec.GetInt16(); }
            set { m_QtyDec.Value = value; }
        }

        public Int16 RateDec
        {
            get { return m_RateDec.GetInt16(); }
            set { m_RateDec.Value = value; }
        }

        public Int16 PercentDec
        {
            get { return m_PercentDec.GetInt16(); }
            set { m_PercentDec.Value = value; }
        }

        public Int16 MeasureDec
        {
            get { return m_MeasureDec.GetInt16(); }
            set { m_MeasureDec.Value = value; }
        }

        public Int16 QueryDec
        {
            get { return m_QueryDec.GetInt16(); }
            set { m_QueryDec.Value = value; }
        }

        public String MainCurncy
        {
            get { return m_MainCurncy.GetString(); }
            set { m_MainCurncy.Value = value; }
        }

        public eYesNo MltpBrnchs
        {
            get { return m_MltpBrnchs.GetString().ToYesNoEnum(); }
            set { m_MltpBrnchs.Value = value.GetYesNoName(); }
        }


        /// <summary>
        /// Somente existe um registro nessa tabela
        /// </summary>
        /// <returns></returns>
        public new bool GetByKey()
        {
            this.Code = 1; // sempre será 1 , existe somente 1 registro nessa tabela
            return base.GetByKey();
        }


    }
}
