using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{

    /// <summary>
    /// Parceiro de Negócios - Endereço
    /// </summary>
    public class BusinessPartnerAddress : TableAdapter
    {

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public class FieldsName
        {

            public static readonly string CardCode = "CardCode";
            public static readonly string Address = "Address";
            public static readonly string AddrType = "AddrType";
            public static readonly string AdresType = "AdresType";
            public static readonly string Street = "Street";
            public static readonly string StreetNo = "StreetNo";
            public static readonly string Block = "Block";
            public static readonly string ZipCode = "ZipCode";
            public static readonly string City = "City";
            public static readonly string County = "County";
            public static readonly string Country = "Country";
            public static readonly string State = "State";
            public static readonly string Building = "Building";

        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public class Description
        {

            public static readonly string CardCode = "Código do PN";
            public static readonly string Address = "Nome do Endereço";
            public static readonly string AdresType = "Tipo de Endereço";
            public static readonly string AddrType = "Rua/Av./Pça";
            public static readonly string Street = "Nome da Rua";
            public static readonly string StreetNo = "Número";
            public static readonly string Block = "Bairro";
            public static readonly string ZipCode = "CEP";
            public static readonly string City = "Cidade";
            public static readonly string County = "Município";
            public static readonly string Country = "País";
            public static readonly string State = "Estado";
            public static readonly string Building = "Edificio/Andar/Sala";

        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "CRD1";
        }


        TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, Description.CardCode, DbType.String, 15, null, true, false);
        TableAdapterField m_Address = new TableAdapterField(FieldsName.Address, Description.Address, DbType.String, 50, null, true, false);
        TableAdapterField m_AdresType = new TableAdapterField(FieldsName.AdresType, Description.AdresType, DbType.String, 1, null, true, false);
        TableAdapterField m_AddrType = new TableAdapterField(FieldsName.AddrType, Description.AddrType, 100);
        TableAdapterField m_Street = new TableAdapterField(FieldsName.Street, Description.Street, 100);
        TableAdapterField m_StreetNo = new TableAdapterField(FieldsName.StreetNo, Description.StreetNo, 200);
        TableAdapterField m_Block = new TableAdapterField(FieldsName.Block, Description.Block, 200);
        TableAdapterField m_ZipCode = new TableAdapterField(FieldsName.ZipCode, Description.ZipCode, 20);
        TableAdapterField m_City = new TableAdapterField(FieldsName.City, Description.City, 100);
        TableAdapterField m_County = new TableAdapterField(FieldsName.County, Description.County, 100);
        TableAdapterField m_Country = new TableAdapterField(FieldsName.Country, Description.Country, 3);
        TableAdapterField m_State = new TableAdapterField(FieldsName.State, Description.State, 3);
        TableAdapterField m_Building = new TableAdapterField(FieldsName.Building, Description.Building, 100);

        public BusinessPartnerAddress()
            : base(Definition.TableName)
        {
        }

        /// <summary>
        /// Parceiro de Negócios Endereços
        /// </summary>
        /// <param name="CompanyDb">Banco de dados da empresa</param>
        public BusinessPartnerAddress(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public BusinessPartnerAddress(BusinessPartnerAddress pBusinessPartnerAddress)
            : this(pBusinessPartnerAddress.DBName)
        {
            this.CopyBy(pBusinessPartnerAddress);
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

        public string AddrType
        {
            get { return m_AddrType.GetString(); }
            private set { m_AddrType.Value = value; }
        }

        public string Street
        {
            get { return m_Street.GetString(); }
            private set { m_Street.Value = value; }
        }

        public string StreetNo
        {
            get { return m_StreetNo.GetString(); }
            private set { m_StreetNo.Value = value; }
        }

        public string Block
        {
            get { return m_Block.GetString(); }
            private set { m_Block.Value = value; }
        }

        public string ZipCode
        {
            get { return m_ZipCode.GetString(); }
            private set { m_ZipCode.Value = value; }
        }

        public string City
        {
            get { return m_City.GetString(); }
            private set { m_City.Value = value; }
        }

        public string County
        {
            get { return m_County.GetString(); }
            private set { m_County.Value = value; }
        }

        public string Country
        {
            get { return m_Country.GetString(); }
            private set { m_Country.Value = value; }
        }

        public string State
        {
            get { return m_State.GetString(); }
            private set { m_State.Value = value; }
        }

        public string Building
        {
            get { return m_Building.GetString(); }
            private set { m_Building.Value = value; }
        }

        public bool GetByKey(string pCardCode, string pAddress, eAdresType pAdresType)
        {

            this.CardCode = pCardCode;
            this.Address = pAddress;
            this.AdresType = pAdresType;

            return this.GetByKey();
        }

        //public BusinessPartnerAddressCollection GetBPAddressDelivery ( string p, string p_2, string p_3 ) {
        //    return new BusinessPartnerAddressCollection ( );
        //}
    }
}
