using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{

    /// <summary>
    /// Parceiro de Negócios - Identificador Fiscal ( CNPJ, CPF ... )
    /// </summary>
    public class BusinessPartnerFiscalID : TableAdapter
    {

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public class FieldsName
        {

            public static readonly string CardCode = "CardCode";
            public static readonly string Address = "Address";
            public static readonly string AddrType = "AddrType";

            public static readonly string CNAEId = "CNAEId";
            public static readonly string TaxId0 = "TaxId0";
            public static readonly string TaxId1 = "TaxId1";
            public static readonly string TaxId2 = "TaxId2";
            public static readonly string TaxId3 = "TaxId3";
            public static readonly string TaxId4 = "TaxId4";
            public static readonly string TaxId5 = "TaxId5";
            public static readonly string TaxId6 = "TaxId6";
            public static readonly string TaxId7 = "TaxId7";
            public static readonly string TaxId8 = "TaxId8";

        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public class Description
        {

            public static readonly string CardCode = "Código do PN";
            public static readonly string Address = "Nome do Endereço";
            public static readonly string AdresType = "Tipo de Endereço";

            public static readonly string CNAEId = "CNAEId";
            public static readonly string TaxId0 = "CNPJ";
            public static readonly string TaxId1 = "Inscrição Estadual";
            public static readonly string TaxId2 = "IE do Substituto Tributário";
            public static readonly string TaxId3 = "Inscrição Municipal";
            public static readonly string TaxId4 = "CPF";
            public static readonly string TaxId5 = "Id de Estrangeiro";
            public static readonly string TaxId6 = "Descrição de Estrangerio";
            public static readonly string TaxId7 = "INSS";
            public static readonly string TaxId8 = "SUFRAMA";

        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "CRD7";
        }


        TableAdapterField m_CardCode = new TableAdapterField ( FieldsName.CardCode, Description.CardCode, DbType.String, 15, null, true, false);
        TableAdapterField m_Address = new TableAdapterField ( FieldsName.Address, Description.Address, DbType.String, 50, null, true, false);
        TableAdapterField m_AdresType = new TableAdapterField ( FieldsName.AddrType, Description.AdresType, DbType.String, 1, null, true, false);

        TableAdapterField m_CNAEId = new TableAdapterField ( FieldsName.CNAEId, Description.CNAEId, DbType.Int32);
        TableAdapterField m_TaxId0 = new TableAdapterField ( FieldsName.TaxId0, Description.TaxId0, 100);
        TableAdapterField m_TaxId1 = new TableAdapterField ( FieldsName.TaxId1, Description.TaxId1, 100);
        TableAdapterField m_TaxId2 = new TableAdapterField ( FieldsName.TaxId2, Description.TaxId2, 100);
        TableAdapterField m_TaxId3 = new TableAdapterField ( FieldsName.TaxId3, Description.TaxId3, 100);
        TableAdapterField m_TaxId4 = new TableAdapterField ( FieldsName.TaxId4, Description.TaxId4, 100);
        TableAdapterField m_TaxId5 = new TableAdapterField ( FieldsName.TaxId5, Description.TaxId5, 100);
        TableAdapterField m_TaxId6 = new TableAdapterField ( FieldsName.TaxId6, Description.TaxId6, 100);
        TableAdapterField m_TaxId7 = new TableAdapterField ( FieldsName.TaxId7, Description.TaxId7, 100);
        TableAdapterField m_TaxId8 = new TableAdapterField ( FieldsName.TaxId8, Description.TaxId8, 100);

        public BusinessPartnerFiscalID()
            : base(Definition.TableName)
        {
        }

        /// <summary>
        /// Parceiro de Negócios - Identificador Fiscal ( CNPJ, CPF ... )
        /// </summary>
        /// <param name="CompanyDb">Banco de dados da empresa</param>
        public BusinessPartnerFiscalID(string pCompanyDb)
            : this()
        {

            this.DBName = pCompanyDb;
        }

        public BusinessPartnerFiscalID(BusinessPartnerFiscalID pBusinessPartnerFiscalID)
            : this()
        {

            this.CopyBy(pBusinessPartnerFiscalID);
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            private set { m_CardCode.Value = value; }
        }

        public string Address
        {
            get { return m_Address.GetString(); }
            private set { m_Address.Value = value; }
        }

        public eAdresType AdresType
        {
            get { return AdresTypeClass.ToEnum(m_AdresType.GetString()); }
            private set { m_AdresType.Value = AdresTypeClass.ToString(value); }
        }

        public Int32 CNAEId
        {
            get { return m_CNAEId.GetInt32(); }
            private set { m_CNAEId.Value = value; }
        }

        /// <summary>
        /// CNPJ
        /// </summary>
        public string TaxId0
        {
            get { return m_TaxId0.GetString(); }
            private set { m_TaxId0.Value = value; }
        }

        /// <summary>
        /// Inscrição Estadual
        /// </summary>
        public string TaxId1
        {
            get { return m_TaxId1.GetString(); }
            private set { m_TaxId1.Value = value; }
        }

        /// <summary>
        /// IE do Substituto Tributário
        /// </summary>
        public string TaxId2
        {
            get { return m_TaxId2.GetString(); }
            private set { m_TaxId2.Value = value; }
        }

        /// <summary>
        /// Inscrição Municipal
        /// </summary>
        public string TaxId3
        {
            get { return m_TaxId3.GetString(); }
            private set { m_TaxId3.Value = value; }
        }

        /// <summary>
        /// CPF
        /// </summary>
        public string TaxId4
        {
            get { return m_TaxId4.GetString(); }
            private set { m_TaxId4.Value = value; }
        }

        /// <summary>
        /// Id de Estrangeiro
        /// </summary>
        public string TaxId5
        {
            get { return m_TaxId5.GetString(); }
            private set { m_TaxId5.Value = value; }
        }

        /// <summary>
        /// Descrição de Estrangerio
        /// </summary>
        public string TaxId6
        {
            get { return m_TaxId6.GetString(); }
            private set { m_TaxId6.Value = value; }
        }

        /// <summary>
        /// INSS
        /// </summary>
        public string TaxId7
        {
            get { return m_TaxId7.GetString(); }
            private set { m_TaxId7.Value = value; }
        }

        /// <summary>
        /// SUFRAMA
        /// </summary>
        public string TaxId8
        {
            get { return m_TaxId8.GetString(); }
            private set { m_TaxId7.Value = value; }
        }

        public bool GetByKey(string pCardCode, string pAddress, eAdresType pAdresType)
        {

            this.CardCode = pCardCode;
            this.Address = pAddress;
            this.AdresType = pAdresType;

            return this.GetByKey();
        }

        /// <summary>
        /// Pega os dados fiscal da aba imposto
        /// </summary>
        /// <param name="pCardCode"></param>
        /// <returns></returns>
        public bool GetByKey(string pCardCode)
        {

            this.CardCode = pCardCode;
            this.Address = "";
            this.AdresType = eAdresType.Shipto;
            return this.GetByKey();
        }

    }

}
