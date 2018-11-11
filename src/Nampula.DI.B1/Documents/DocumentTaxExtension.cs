using System;
using System.Data;

namespace Nampula.DI.B1.Documents
{

    public class DocumentTaxExtension : TableAdapter
    {

        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string DocEntry = "DocEntry";
            public static readonly string ObjectType = "ObjectType";
            public static readonly string State = "State";
            public static readonly string County = "County";
            public static readonly string QoP = "QoP";
            public static readonly string Incoterms = "Incoterms";
            public static readonly string Vehicle = "Vehicle";
            public static readonly string VidState = "VidState";
            public static readonly string Carrier = "Carrier";
            public static readonly string PackDesc = "PackDesc";
            /// <summary>
            /// CNPJ
            /// </summary>
            public static readonly string TaxId0 = "TaxId0";
            /// <summary>
            /// I.E.
            /// </summary>
            public static readonly string TaxId1 = "TaxId1";
            /// <summary>
            /// I.M.
            /// </summary>
            public static readonly string TaxId3 = "TaxId3";

            /// <summary>
            /// CPF
            /// </summary>
            public static readonly string TaxId4 = "TaxId4";

            /// <summary>
            /// ID Estrangeiro
            /// </summary>
            public static readonly string TaxId5 = "TaxId5";

            /// <summary>
            /// Suframa
            /// </summary>
            public static readonly string TaxId8 = "TaxId8";

            public static readonly string Brand = "Brand";
            public static readonly string NoSu = "NoSu";
            public static readonly string GrsWeight = "GrsWeight";
            public static readonly string NetWeight = "NetWeight";
            public static readonly string NfRef = "NfRef";

            public static readonly string AddrTypeS = "AddrTypeS";
            public static readonly string AdresTypeS = "AdresTypeS";
            public static readonly string StreetS = "StreetS";
            public static readonly string StreetNoS = "StreetNoS";
            public static readonly string BlockS = "BlockS";
            public static readonly string ZipCodeS = "ZipCodeS";
            public static readonly string CityS = "CityS";
            public static readonly string CountyS = "CountyS";
            public static readonly string CountryS = "CountryS";
            public static readonly string StateS = "StateS";
            public static readonly string BuildingS = "BuildingS";

            public static readonly string AddrTypeB = "AddrTypeB";
            public static readonly string AdresTypeB = "AdresTypeB";
            public static readonly string StreetB = "StreetB";
            public static readonly string StreetNoB = "StreetNoB";
            public static readonly string BlockB = "BlockB";
            public static readonly string ZipCodeB = "ZipCodeB";
            public static readonly string CityB = "CityB";
            public static readonly string CountyB = "CountyB";
            public static readonly string CountryB = "CountryB";
            public static readonly string StateB = "StateB";
            public static readonly string BuildingB = "BuildingB";
            public static readonly string MainUsage = "MainUsage";
        }



        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string DocEntry = "Número";
            public static readonly string ObjectType = "Tipo de objeto";
            public static readonly string State = "UF";
            public static readonly string County = "Municipio";
            public static readonly string QoP = "Quantidade Embalagens";
            public static readonly string Incoterms = "Incoterms";
            public static readonly string Vehicle = "Placa";
            public static readonly string VidState = "Placa UF";
            public static readonly string Carrier = "Transportadora";
            public static readonly string PackDesc = "Descrição Emb.";

            public static readonly string TaxId0 = "CNPJ";
            public static readonly string TaxId1 = "I.E";

            public static readonly string TaxId3 = "I.M.";
            /// <summary>
            /// CPF
            /// </summary>
            public static readonly string TaxId4 = "CPF";

            public static readonly string TaxId5 = "Id Estrangeiro";

            /// <summary>
            /// Suframa
            /// </summary>
            public static readonly string TaxId8 = "Suframa";

            public static readonly string Brand = "Marca";
            public static readonly string NoSu = "N° Unidade Expedição";
            public static readonly string GrsWeight = "Peso Bruto";
            public static readonly string NetWeight = "Peso Liquido";
            public static readonly string NfRef = "Referência Nf";

            public static readonly string AddrTypeS = "Rua/Av./Pça";
            public static readonly string StreetS = "Nome da Rua";
            public static readonly string StreetNoS = "Número";
            public static readonly string BlockS = "Bairro";
            public static readonly string ZipCodeS = "CEP";
            public static readonly string CityS = "Cidade";
            public static readonly string CountyS = "Município";
            public static readonly string CountryS = "País";
            public static readonly string StateS = "Estado";
            public static readonly string BuildingS = "Edificio/Andar/Sala";

            public static readonly string AddrTypeB = "Rua/Av./Pça";
            public static readonly string StreetB = "Nome da Rua";
            public static readonly string StreetNoB = "Número";
            public static readonly string BlockB = "Bairro";
            public static readonly string ZipCodeB = "CEP";
            public static readonly string CityB = "Cidade";
            public static readonly string CountyB = "Município";
            public static readonly string CountryB = "País";
            public static readonly string StateB = "Estado";
            public static readonly string BuildingB = "Edificio/Andar/Sala";

            public static readonly string MainUsage = "Uso Principal";

        }




        TableAdapterField m_DocEntry = new TableAdapterField(FieldsName.DocEntry, FieldsDescription.DocEntry, DbType.Int32, 11, null, true, false);
        TableAdapterField m_ObjectType = new TableAdapterField(FieldsName.ObjectType, FieldsDescription.ObjectType, DbType.Int32);
        TableAdapterField m_State = new TableAdapterField(FieldsName.State, FieldsDescription.State, 3);
        TableAdapterField m_County = new TableAdapterField(FieldsName.County, FieldsDescription.County, DbType.Int32);
        TableAdapterField m_QoP = new TableAdapterField(FieldsName.QoP, FieldsDescription.QoP, 20);
        TableAdapterField m_Incoterms = new TableAdapterField(FieldsName.Incoterms, FieldsDescription.Incoterms, 3);
        TableAdapterField m_Vehicle = new TableAdapterField(FieldsName.Vehicle, FieldsDescription.Vehicle, 10);
        TableAdapterField m_VidState = new TableAdapterField(FieldsName.VidState, FieldsDescription.VidState, 3);
        TableAdapterField m_Carrier = new TableAdapterField(FieldsName.Carrier, FieldsDescription.Carrier, 15);
        TableAdapterField m_PackDesc = new TableAdapterField(FieldsName.PackDesc, FieldsDescription.PackDesc, 11);

        TableAdapterField m_TaxId0 = new TableAdapterField(FieldsName.TaxId0, FieldsDescription.TaxId0, 20);
        TableAdapterField m_TaxId1 = new TableAdapterField(FieldsName.TaxId1, FieldsDescription.TaxId1, 20);
        TableAdapterField m_TaxId3 = new TableAdapterField(FieldsName.TaxId3, FieldsDescription.TaxId3, 20);
        TableAdapterField m_TaxId4 = new TableAdapterField(FieldsName.TaxId4, FieldsDescription.TaxId4, 20);
        TableAdapterField m_TaxId5 = new TableAdapterField(FieldsName.TaxId5, FieldsDescription.TaxId5, 20);
        TableAdapterField m_TaxId8 = new TableAdapterField(FieldsName.TaxId8, FieldsDescription.TaxId8, 20);

        TableAdapterField m_Brand = new TableAdapterField(FieldsName.Brand, FieldsDescription.Brand, 20);
        TableAdapterField m_NoSu = new TableAdapterField(FieldsName.NoSu, FieldsDescription.NoSu, DbType.Int32);
        TableAdapterField m_NetWeight = new TableAdapterField(FieldsName.NetWeight, FieldsDescription.NetWeight, DbType.Decimal);
        TableAdapterField m_GrsWeight = new TableAdapterField(FieldsName.GrsWeight, FieldsDescription.GrsWeight, DbType.Decimal);
        private TableAdapterField m_NfRef = new TableAdapterField(FieldsName.NfRef, FieldsDescription.NfRef, 200);

        TableAdapterField m_AddrTypeS = new TableAdapterField(FieldsName.AddrTypeS, FieldsDescription.AddrTypeS, 100);
        TableAdapterField m_StreetS = new TableAdapterField(FieldsName.StreetS, FieldsDescription.StreetS, 100);
        TableAdapterField m_StreetNoS = new TableAdapterField(FieldsName.StreetNoS, FieldsDescription.StreetNoS, 200);
        TableAdapterField m_BlockS = new TableAdapterField(FieldsName.BlockS, FieldsDescription.BlockS, 200);
        TableAdapterField m_ZipCodeS = new TableAdapterField(FieldsName.ZipCodeS, FieldsDescription.ZipCodeS, 20);
        TableAdapterField m_CityS = new TableAdapterField(FieldsName.CityS, FieldsDescription.CityS, 100);
        TableAdapterField m_CountyS = new TableAdapterField(FieldsName.CountyS, FieldsDescription.CountyS, 100);
        TableAdapterField m_CountryS = new TableAdapterField(FieldsName.CountryS, FieldsDescription.CountryS, 3);
        TableAdapterField m_StateS = new TableAdapterField(FieldsName.StateS, FieldsDescription.StateS, 3);
        TableAdapterField m_BuildingS = new TableAdapterField(FieldsName.BuildingS, FieldsDescription.BuildingS, 100);

        TableAdapterField m_AddrTypeB = new TableAdapterField(FieldsName.AddrTypeB, FieldsDescription.AddrTypeB, 100);
        TableAdapterField m_StreetB = new TableAdapterField(FieldsName.StreetB, FieldsDescription.StreetB, 100);
        TableAdapterField m_StreetNoB = new TableAdapterField(FieldsName.StreetNoB, FieldsDescription.StreetNoB, 200);
        TableAdapterField m_BlockB = new TableAdapterField(FieldsName.BlockB, FieldsDescription.BlockB, 200);
        TableAdapterField m_ZipCodeB = new TableAdapterField(FieldsName.ZipCodeB, FieldsDescription.ZipCodeB, 20);
        TableAdapterField m_CityB = new TableAdapterField(FieldsName.CityB, FieldsDescription.CityB, 100);
        TableAdapterField m_CountyB = new TableAdapterField(FieldsName.CountyB, FieldsDescription.CountyB, 100);
        TableAdapterField m_CountryB = new TableAdapterField(FieldsName.CountryB, FieldsDescription.CountryB, 3);
        TableAdapterField m_StateB = new TableAdapterField(FieldsName.StateB, FieldsDescription.StateB, 3);
        TableAdapterField m_BuildingB = new TableAdapterField(FieldsName.BuildingB, FieldsDescription.BuildingB, 100);
        TableAdapterField m_MainUsage = new TableAdapterField(FieldsName.MainUsage, FieldsDescription.MainUsage, 100);


        public DocumentTaxExtension()
        {
        }

        public DocumentTaxExtension(string pCompanyDb, eDocumentObjectType pDocumentObjectType)
            : base(pCompanyDb, pDocumentObjectType.GetTableNameSufix() + "12")
        {
        }

        public DocumentTaxExtension(DocumentTaxExtension pDocumentTaxExtension)
            : this()
        {
            CopyBy(pDocumentTaxExtension);
        }


        public int DocEntry
        {
            get { return m_DocEntry.GetInt32(); }
            set { m_DocEntry.Value = value; }
        }

        public eDocumentObjectType ObjectType
        {
            get { return m_DocEntry.GetInt32().ToDocumentObjectTypeEnum(); }
            set { m_DocEntry.Value = value.ToInt32(); }
        }

        public string State
        {
            get { return m_State.GetString(); }
            set { m_State.Value = value; }
        }

        public int County
        {
            get { return m_County.GetInt32(); }
            set { m_County.Value = value; }
        }

        public string QoP
        {
            get { return m_QoP.GetString(); }
            set { m_QoP.Value = value; }
        }

        public string Incoterms
        {
            get { return m_Incoterms.GetString(); }
            set { m_Incoterms.Value = value; }
        }

        public string Vehicle
        {
            get { return m_Vehicle.GetString(); }
            set { m_Vehicle.Value = value; }
        }

        public string VidState
        {
            get { return m_VidState.GetString(); }
            set { m_VidState.Value = value; }
        }

        public string Carrier
        {
            get { return m_Carrier.GetString(); }
            set { m_Carrier.Value = value; }
        }

        public string PackDesc
        {
            get { return m_PackDesc.GetString(); }
            set { m_PackDesc.Value = value; }
        }

        /// <summary>
        /// CNPJ
        /// </summary>
        public string TaxId0
        {
            get { return m_TaxId0.GetString(); }
            set { m_TaxId0.Value = value; }
        }

        /// <summary>
        /// I.E
        /// </summary>
        public string TaxId1
        {
            get { return m_TaxId1.GetString(); }
            set { m_TaxId1.Value = value; }
        }

        /// <summary>
        /// CPF
        /// </summary>
        public String TaxId3
        {
            get { return m_TaxId3.GetString(); }
            set { m_TaxId3.Value = value; }
        }

        /// <summary>
        /// CPF
        /// </summary>
        public String TaxId4
        {
            get { return m_TaxId4.GetString(); }
            set { m_TaxId4.Value = value; }
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
        /// SUFRAMA
        /// </summary>
        public String TaxId8
        {
            get { return m_TaxId8.GetString(); }
            set { m_TaxId8.Value = value; }
        }


        public String Brand
        {
            get { return m_Brand.GetString(); }
            set { m_Brand.Value = value; }
        }

        public int NoSu
        {
            get { return m_NoSu.GetInt32(); }
            set { m_NoSu.Value = value; }
        }

        public Decimal GrsWeight
        {
            get { return m_GrsWeight.GetDecimal(); }
            set { m_GrsWeight.Value = value; }
        }

        public Decimal NetWeight
        {
            get { return m_NetWeight.GetDecimal(); }
            set { m_NetWeight.Value = value; }
        }

        public String NfRef
        {
            get { return m_NfRef.GetString(); }
            set { m_NfRef.Value = value; }
        }

        public string AddrTypeS
        {
            get { return m_AddrTypeS.GetString(); }
            set { m_AddrTypeS.Value = value; }
        }

        public string StreetS
        {
            get { return m_StreetS.GetString(); }
            set { m_StreetS.Value = value; }
        }

        public string StreetNoS
        {
            get { return m_StreetNoS.GetString(); }
            set { m_StreetNoS.Value = value; }
        }

        public string BlockS
        {
            get { return m_BlockS.GetString(); }
            set { m_BlockS.Value = value; }
        }

        public string ZipCodeS
        {
            get { return m_ZipCodeS.GetString(); }
            set { m_ZipCodeS.Value = value; }
        }

        public string CityS
        {
            get { return m_CityS.GetString(); }
            set { m_CityS.Value = value; }
        }

        public string CountyS
        {
            get { return m_CountyS.GetString(); }
            set { m_CountyS.Value = value; }
        }

        public string CountryS
        {
            get { return m_CountryS.GetString(); }
            set { m_CountryS.Value = value; }
        }

        public string StateS
        {
            get { return m_StateS.GetString(); }
            set { m_StateS.Value = value; }
        }

        public string BuildingS
        {
            get { return m_BuildingS.GetString(); }
            set { m_BuildingS.Value = value; }
        }

        public string AddrTypeB
        {
            get { return m_AddrTypeB.GetString(); }
            set { m_AddrTypeB.Value = value; }
        }

        public string StreetB
        {
            get { return m_StreetB.GetString(); }
            set { m_StreetB.Value = value; }
        }

        public string StreetNoB
        {
            get { return m_StreetNoB.GetString(); }
            set { m_StreetNoB.Value = value; }
        }

        public string BlockB
        {
            get { return m_BlockB.GetString(); }
            set { m_BlockB.Value = value; }
        }

        public string ZipCodeB
        {
            get { return m_ZipCodeB.GetString(); }
            set { m_ZipCodeB.Value = value; }
        }

        public string CityB
        {
            get { return m_CityB.GetString(); }
            set { m_CityB.Value = value; }
        }

        public string CountyB
        {
            get { return m_CountyB.GetString(); }
            set { m_CountyB.Value = value; }
        }

        public string CountryB
        {
            get { return m_CountryB.GetString(); }
            set { m_CountryB.Value = value; }
        }

        public string StateB
        {
            get { return m_StateB.GetString(); }
            set { m_StateB.Value = value; }
        }

        public string BuildingB
        {
            get { return m_BuildingB.GetString(); }
            set { m_BuildingB.Value = value; }
        }

        public string MainUsage
        {
            get { return m_MainUsage.GetString(); }
            set { m_MainUsage.Value = value; }
        }


    }

}
