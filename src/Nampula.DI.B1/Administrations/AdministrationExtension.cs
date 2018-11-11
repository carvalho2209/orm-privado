using System;
using System.Data;

namespace Nampula.DI.B1.Administrations
{

    /// <summary>
    /// Dados adicionais da Empresa
    /// </summary>
    public class AdministrationExtension : TableAdapter
    {

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {

            public static readonly string Code = "Code";
            public static readonly string Street = "Street";
            public static readonly string Block = "Block";
            public static readonly string City = "City";
            public static readonly string ZipCode = "ZipCode";
            public static readonly string County = "County";
            public static readonly string State = "State";
            public static readonly string Country = "Country";
            public static readonly string Building = "Building";
            public static readonly string TaxIdNum4 = "TaxIdNum4";
            public static readonly string TaxIdNum5 = "TaxIdNum5";
            public static readonly string TaxIdNum6 = "TaxIdNum6";
            public static readonly string IntrntAdrs = "IntrntAdrs";
            public static readonly string StreetNo = "StreetNo";
            public static readonly string AddrType = "AddrType";

        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {

            public static readonly string Code = "Código";
            public static readonly string Street = "Logradouro";
            public static readonly string Block = "Bairro";
            public static readonly string City = "Cidade";
            public static readonly string ZipCode = "CEP";
            public static readonly string County = "Municipio";
            public static readonly string State = "Estado";
            public static readonly string Country = "Pais";
            public static readonly string Building = "Building";
            public static readonly string TaxIdNum4 = "TaxIdNum4";
            public static readonly string TaxIdNum5 = "TaxIdNum5";
            public static readonly string TaxIdNum6 = "TaxIdNum6";
            public static readonly string IntrntAdrs = "Web Site";
            public static readonly string StreetNo = "Rua nº";
            public static readonly string AddrType = "Tipo de endereço";

        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {

            public static readonly string TableName = "ADM1";

        }

        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, Description.Code, DbType.Int32, 11, null, true, false);
        TableAdapterField m_Street = new TableAdapterField(FieldsName.Street, Description.Street, 100);
        TableAdapterField m_Block = new TableAdapterField(FieldsName.Block, Description.Country, 3);
        TableAdapterField m_City = new TableAdapterField(FieldsName.City, Description.City, 100);
        TableAdapterField m_ZipCode = new TableAdapterField(FieldsName.ZipCode, Description.ZipCode, 20);
        TableAdapterField m_County = new TableAdapterField(FieldsName.County, Description.County, 100);
        TableAdapterField m_State = new TableAdapterField(FieldsName.State, Description.State, 3);
        TableAdapterField m_Country = new TableAdapterField(FieldsName.Country, Description.Country, 3);
        TableAdapterField m_Building = new TableAdapterField(FieldsName.Building, Description.Building, 20);
        TableAdapterField m_TaxIdNum4 = new TableAdapterField(FieldsName.TaxIdNum4, Description.TaxIdNum4, 100);
        TableAdapterField m_TaxIdNum5 = new TableAdapterField(FieldsName.TaxIdNum5, Description.TaxIdNum5, 100);
        TableAdapterField m_TaxIdNum6 = new TableAdapterField(FieldsName.TaxIdNum6, Description.TaxIdNum6, 100);
        TableAdapterField m_IntrntAdrs = new TableAdapterField(FieldsName.IntrntAdrs, Description.IntrntAdrs, 50);
        TableAdapterField m_StreetNo = new TableAdapterField(FieldsName.StreetNo, Description.StreetNo, 100);
        TableAdapterField m_AddrType = new TableAdapterField(FieldsName.AddrType, Description.AddrType, 100);

        /// <summary>
        /// Dados adicionais da Empresa
        /// </summary>
        /// <param name="pCompanyDb">Banco de Dados da Empresa do SAP</param>
        public AdministrationExtension(string pCompanyDb)
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

        public string Street
        {
            get { return m_Street.GetString(); }
            set { m_Street.Value = value; }
        }

        public string Block
        {
            get { return m_Block.GetString(); }
            set { m_Block.Value = value; }
        }

        public string City
        {
            get { return m_City.GetString(); }
            set { m_City.Value = value; }
        }

        public string ZipCode
        {
            get { return m_ZipCode.GetString(); }
            set { m_ZipCode.Value = value; }
        }

        public string County
        {
            get { return m_County.GetString(); }
            set { m_County.Value = value; }
        }

        public string State
        {
            get { return m_State.GetString(); }
            set { m_State.Value = value; }
        }

        public string Country
        {
            get { return m_Country.GetString(); }
            set { m_Country.Value = value; }
        }

        public string TaxIdNum4
        {
            get { return m_TaxIdNum4.GetString(); }
            set { m_TaxIdNum4.Value = value; }
        }

        public string TaxIdNum5
        {
            get { return m_TaxIdNum5.GetString(); }
            set { m_TaxIdNum5.Value = value; }
        }

        public string TaxIdNum6
        {
            get { return m_TaxIdNum6.GetString(); }
            set { m_TaxIdNum6.Value = value; }
        }

        public string IntrntAdrs
        {
            get { return m_IntrntAdrs.GetString(); }
            set { m_IntrntAdrs.Value = value; }
        }

        public string StreetNo
        {
            get { return m_StreetNo.GetString(); }
            set { m_StreetNo.Value = value; }
        }

        public string AddrType
        {
            get { return m_AddrType.GetString(); }
            set { m_AddrType.Value = value; }
        }

        public string Building
        {
            get { return m_Building.GetString(); }
            set { m_Building.Value = value; }
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
