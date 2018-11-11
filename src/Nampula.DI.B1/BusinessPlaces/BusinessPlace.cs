using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nampula.DI.B1.BusinessPartners;

namespace Nampula.DI.B1.BusinessPlaces
{

    /// <summary>
    /// Tabela de Empresas
    /// </summary>
    public class BusinessPlace : TableAdapter
    {
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OBPL";
        }

        public struct FieldsName
        {
            public static readonly string BPLId = "BPLId";
            public static readonly string BPLName = "BPLName";
            public static readonly string BPLFrName = "BPLFrName";
            public static readonly string RepName = "RepName";
            public static readonly string Industry = "Industry";
            public static readonly string Business = "Business";
            public static readonly string Address = "Address";
            public static readonly string AddressFr = "AddressFr";
            public static readonly string MainBPL = "MainBPL";

            public static readonly string TxOffcNo = "TxOffcNo";
            public static readonly string Disabled = "Disabled";

            public static readonly string LogInstanc = "LogInstanc";
            public static readonly string UserSign2 = "UserSign2";
            public static readonly string UpdateDate = "UpdateDate";
            public static readonly string DflCust = "DflCust";
            public static readonly string DflVendor = "DflVendor";
            public static readonly string DflWhs = "DflWhs";
            public static readonly string DflTaxCode = "DflTaxCode";
            public static readonly string RevOffice = "RevOffice";
            public static readonly string TaxIdNum = "TaxIdNum";
            public static readonly string TaxIdNum2 = "TaxIdNum2";
            public static readonly string TaxIdNum3 = "TaxIdNum3";
            public static readonly string AddtnlId = "AddtnlId";
            public static readonly string CompNature = "CompNature";
            public static readonly string EconActT = "EconActT";
            public static readonly string CredCOrig = "CredCOrig";
            public static readonly string IPIPeriod = "IPIPeriod";
            public static readonly string CoopAssocT = "CoopAssocT";
            public static readonly string PrefState = "PrefState";
            public static readonly string ProfTax = "ProfTax";
            public static readonly string CompQualif = "CompQualif";
            public static readonly string DeclType = "DeclType";

            public static readonly string AddrType = "AddrType";
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

        public struct FieldsDescription
        {
            public static readonly string BPLId = "Id da Filial";
            public static readonly string BPLName = "Nome da Filial";
            public static readonly string BPLFrName = "Nome Estrangeiro";
            public static readonly string RepName = "Nome do Relatório";
            public static readonly string Industry = "Setor Industrial";
            public static readonly string Business = "Negócio";
            public static readonly string Address = "Endereço";
            public static readonly string AddressFr = "Endereço Estrangeiro";
            public static readonly string MainBPL = "Filial Principal";

            public static readonly string TxOffcNo = "N° da repartição de finanças";
            public static readonly string Disabled = "Desativado";

            public static readonly string LogInstanc = "Instancia do Log";
            public static readonly string UserSign2 = "Usuário";
            public static readonly string UpdateDate = "Data de Atualização";
            public static readonly string DflCust = "Id do cliente padrão";
            public static readonly string DflVendor = "Id do fornecedor padrão";
            public static readonly string DflWhs = "Id do depósito padrão";
            public static readonly string DflTaxCode = "Cód. CNAE";
            public static readonly string RevOffice = "CPF";
            public static readonly string TaxIdNum = "CNPJ";
            public static readonly string TaxIdNum2 = "IE Padrão";
            public static readonly string TaxIdNum3 = "IE do ST";
            public static readonly string AddtnlId = "Inscrição Municipal";
            public static readonly string CompNature = "Indicador da natureza de pessoa júridica";
            public static readonly string EconActT = "Indicador de tipo de atividade preponderante";
            public static readonly string CredCOrig = "Ind. da apuração das contribuições e créditos (NF-e e ECF)";
            public static readonly string IPIPeriod = "Indicador de Apuração de IPI";
            public static readonly string CoopAssocT = "Indicador de tipo de sociedade cooperativa";
            public static readonly string PrefState = "Estado Padrão";
            public static readonly string ProfTax = "Tributação do Lucro";
            public static readonly string CompQualif = "Qualificação da Empresa";
            public static readonly string DeclType = "Tipo de declarante";

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

        TableAdapterField m_BPLId = new TableAdapterField(FieldsName.BPLId, FieldsDescription.BPLId, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_BPLName = new TableAdapterField(FieldsName.BPLName, FieldsDescription.BPLName, 100);
        TableAdapterField m_BPLFrName = new TableAdapterField(FieldsName.BPLFrName, FieldsDescription.BPLFrName, 100);
        TableAdapterField m_RepName = new TableAdapterField(FieldsName.RepName, FieldsDescription.RepName, 100);
        TableAdapterField m_Industry = new TableAdapterField(FieldsName.Industry, FieldsDescription.Industry, 20);
        TableAdapterField m_Business = new TableAdapterField(FieldsName.Business, FieldsDescription.Business, 20);
        TableAdapterField m_Address = new TableAdapterField(FieldsName.Address, FieldsDescription.Address, 254);
        TableAdapterField m_AddressFr = new TableAdapterField(FieldsName.AddressFr, FieldsDescription.AddressFr, 254);
        TableAdapterField m_MainBPL = new TableAdapterField(FieldsName.MainBPL, FieldsDescription.MainBPL, 1);
        TableAdapterField m_TxOffcNo = new TableAdapterField(FieldsName.TxOffcNo, FieldsDescription.TxOffcNo, 3);
        TableAdapterField m_Disabled = new TableAdapterField(FieldsName.Disabled, FieldsDescription.Disabled, 1);
        TableAdapterField m_LogInstanc = new TableAdapterField(FieldsName.LogInstanc, FieldsDescription.LogInstanc, DbType.Int32);
        TableAdapterField m_UserSign2 = new TableAdapterField(FieldsName.UserSign2, FieldsDescription.UserSign2, DbType.Int32);
        TableAdapterField m_UpdateDate = new TableAdapterField(FieldsName.UpdateDate, FieldsDescription.UpdateDate, DbType.Date);
        TableAdapterField m_DflCust = new TableAdapterField(FieldsName.DflCust, FieldsDescription.DflCust, 15);
        TableAdapterField m_DflVendor = new TableAdapterField(FieldsName.DflVendor, FieldsDescription.DflVendor, 15);
        TableAdapterField m_DflWhs = new TableAdapterField(FieldsName.DflWhs, FieldsDescription.DflWhs, 15);
        TableAdapterField m_DflTaxCode = new TableAdapterField(FieldsName.DflTaxCode, FieldsDescription.DflTaxCode, 8);
        TableAdapterField m_RevOffice = new TableAdapterField(FieldsName.RevOffice, FieldsDescription.RevOffice, 100);
        TableAdapterField m_TaxIdNum = new TableAdapterField(FieldsName.TaxIdNum, FieldsDescription.TaxIdNum, 32);
        TableAdapterField m_TaxIdNum2 = new TableAdapterField(FieldsName.TaxIdNum2, FieldsDescription.TaxIdNum2, 32);
        TableAdapterField m_TaxIdNum3 = new TableAdapterField(FieldsName.TaxIdNum3, FieldsDescription.TaxIdNum3, 32);
        TableAdapterField m_AddtnlId = new TableAdapterField(FieldsName.AddtnlId, FieldsDescription.AddtnlId, 32);
        TableAdapterField m_CompNature = new TableAdapterField(FieldsName.CompNature, FieldsDescription.CompNature, DbType.Int32);
        TableAdapterField m_EconActT = new TableAdapterField(FieldsName.EconActT, FieldsDescription.EconActT, DbType.Int32);
        TableAdapterField m_CredCOrig = new TableAdapterField(FieldsName.CredCOrig, FieldsDescription.CredCOrig, 2);
        TableAdapterField m_IPIPeriod = new TableAdapterField(FieldsName.IPIPeriod, FieldsDescription.IPIPeriod, 2);
        TableAdapterField m_CoopAssocT = new TableAdapterField(FieldsName.CoopAssocT, FieldsDescription.CoopAssocT, DbType.Int32);
        TableAdapterField m_PrefState = new TableAdapterField(FieldsName.PrefState, FieldsDescription.PrefState, 3);
        TableAdapterField m_ProfTax = new TableAdapterField(FieldsName.ProfTax, FieldsDescription.ProfTax, DbType.Int32);
        TableAdapterField m_CompQualif = new TableAdapterField(FieldsName.CompQualif, FieldsDescription.CompQualif, DbType.Int32);
        TableAdapterField m_DeclType = new TableAdapterField(FieldsName.DeclType, FieldsDescription.DeclType, DbType.Int32);

        TableAdapterField m_AddrType = new TableAdapterField(FieldsName.AddrType, FieldsDescription.AddrType, 100);
        TableAdapterField m_Street = new TableAdapterField(FieldsName.Street, FieldsDescription.Street, 100);
        TableAdapterField m_StreetNo = new TableAdapterField(FieldsName.StreetNo, FieldsDescription.StreetNo, 200);
        TableAdapterField m_Block = new TableAdapterField(FieldsName.Block, FieldsDescription.Block, 200);
        TableAdapterField m_ZipCode = new TableAdapterField(FieldsName.ZipCode, FieldsDescription.ZipCode, 20);
        TableAdapterField m_City = new TableAdapterField(FieldsName.City, FieldsDescription.City, 100);
        TableAdapterField m_County = new TableAdapterField(FieldsName.County, FieldsDescription.County, 100);
        TableAdapterField m_Country = new TableAdapterField(FieldsName.Country, FieldsDescription.Country, 3);
        TableAdapterField m_State = new TableAdapterField(FieldsName.State, FieldsDescription.State, 3);
        TableAdapterField m_Building = new TableAdapterField(FieldsName.Building, FieldsDescription.Building, 100);

        public BusinessPlace(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public BusinessPlace()
            : base(Definition.TableName)
        {
        }

        public BusinessPlace(BusinessPlace pBusinessPlace)
            : this()
        {
            this.CopyBy(pBusinessPlace);
        }

        public Int32 BPLId
        {
            get { return m_BPLId.GetInt32(); }
            set { m_BPLId.Value = value; }
        }

        public String BPLName
        {
            get { return m_BPLName.GetString(); }
            set { m_BPLName.Value = value; }
        }

        public string BPLFrName
        {
            get { return m_BPLFrName.GetString(); }
            set { m_BPLFrName.Value = value; }
        }

        public String RepName
        {
            get { return m_RepName.GetString(); }
            set { m_RepName.Value = value; }
        }

        public String Industry
        {
            get { return m_Industry.GetString(); }
            set { m_Industry.Value = value; }
        }

        public String Business
        {
            get { return m_Business.GetString(); }
            set { m_Business.Value = value; }
        }

        public String Address
        {
            get { return m_Address.GetString(); }
            set { m_Address.Value = value; }
        }

        public String AddressFr
        {
            get { return m_AddressFr.GetString(); }
            set { m_AddressFr.Value = value; }
        }

        public eYesNo MainBPL
        {
            get { return m_MainBPL.GetString().ToYesNoEnum(); }
            set { m_MainBPL.Value = value.ToYesNoString(); }
        }

        public String TxOffcNo
        {
            get { return m_TxOffcNo.GetString(); }
            set { m_TxOffcNo.Value = value; }
        }

        public eYesNo Disabled
        {
            get { return m_Disabled.GetString().ToYesNoEnum(); }
            set { m_Disabled.Value = value.ToYesNoString(); }
        }

        public Int32 LogInstanc
        {
            get { return m_LogInstanc.GetInt32(); }
            set { m_LogInstanc.Value = value; }
        }

        public Int32 UserSign2
        {
            get { return m_UserSign2.GetInt32(); }
            set { m_UserSign2.Value = value; }
        }

        public DateTime UpdateDate
        {
            get { return m_UpdateDate.GetDateTime(); }
            set { m_UpdateDate.Value = value; }
        }

        public String DflCust
        {
            get { return m_DflCust.GetString(); }
            set { m_DflCust.Value = value; }
        }

        public String DflVendor
        {
            get { return m_DflVendor.GetString(); }
            set { m_DflVendor.Value = value; }
        }

        public String DflWhs
        {
            get { return m_DflWhs.GetString(); }
            set { m_DflWhs.Value = value; }
        }

        public String DflTaxCode
        {
            get { return m_DflTaxCode.GetString(); }
            set { m_DflTaxCode.Value = value; }
        }

        public String RevOffice
        {
            get { return m_RevOffice.GetString(); }
            set { m_RevOffice.Value = value; }
        }

        public String TaxIdNum
        {
            get { return m_TaxIdNum.GetString(); }
            set { m_TaxIdNum.Value = value; }
        }

        public String TaxIdNum2
        {
            get { return m_TaxIdNum2.GetString(); }
            set { m_TaxIdNum2.Value = value; }
        }

        public String TaxIdNum3
        {
            get { return m_TaxIdNum3.GetString(); }
            set { m_TaxIdNum3.Value = value; }
        }

        public String AddtnlId
        {
            get { return m_AddtnlId.GetString(); }
            set { m_AddtnlId.Value = value; }
        }

        public Int32 CompNature
        {
            get { return m_CompNature.GetInt32(); }
            set { m_CompNature.Value = value; }
        }

        public Int32 EconActT
        {
            get { return m_EconActT.GetInt32(); }
            set { m_EconActT.Value = value; }
        }

        public String CredCOrig
        {
            get { return m_CredCOrig.GetString(); }
            set { m_CredCOrig.Value = value; }
        }

        public String IPIPeriod
        {
            get { return m_IPIPeriod.GetString(); }
            set { m_IPIPeriod.Value = value; }
        }

        public Int32 CoopAssocT
        {
            get { return m_CoopAssocT.GetInt32(); }
            set { m_CoopAssocT.Value = value; }
        }

        public String PrefState
        {
            get { return m_PrefState.GetString(); }
            set { m_PrefState.Value = value; }
        }

        public Int32 ProfTax
        {
            get { return m_ProfTax.GetInt32(); }
            set { m_ProfTax.Value = value; }
        }

        public Int32 CompQualif
        {
            get { return m_CompQualif.GetInt32(); }
            set { m_CompQualif.Value = value; }
        }

        public Int32 DeclType
        {
            get { return m_DeclType.GetInt32(); }
            set { m_DeclType.Value = value; }
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



    }
}
