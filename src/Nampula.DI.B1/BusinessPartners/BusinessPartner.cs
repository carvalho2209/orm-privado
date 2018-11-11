using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{
    /// <summary>
    /// Parceiro de Negócios
    /// </summary>
    public class BusinessPartner : TableAdapter
    {

        /// <summary>
        /// Nome dos Campos
        /// </summary>
        public struct FieldsName
        {
            public static readonly string CardCode = "CardCode";
            public static readonly string CardName = "CardName";
            public static readonly string CardFName = "CardFName";
            public static readonly string CardType = "CardType";
            public static readonly string GroupCode = "GroupCode";
            public static readonly string CreditLine = "CreditLine";
            public static readonly string BillToDef = "BillToDef";
            public static readonly string ShipToDef = "ShipToDef";
            public static readonly string ListNum = "ListNum";
            public static readonly string CollecAuth = "CollecAuth";
            public static readonly string GroupNum = "GroupNum";
            public static readonly string SlpCode = "SlpCode";
            public static readonly string Territory = "Territory";
            public static readonly string City = "City";
            public static readonly string Block = "Block";
            public static readonly string Address = "Address";
            public static readonly string Discount = "Discount";
            public static readonly string PymCode = "PymCode";
            public static readonly string E_Mail = "E_Mail";
            public static readonly string Notes = "Notes";
            public static readonly string Password = "Password";
            public static readonly string AddID = "AddID";
            public static readonly string IntrstRate = "IntrstRate";
            public static readonly string AvrageLate = "AvrageLate";
            public static readonly string FatherCard = "FatherCard";
            public static readonly string validFor = "validFor";
            public static readonly string frozenFrom = "frozenFrom";
            public static readonly string frozenTo = "frozenTo";
            public static readonly string validFrom = "validFrom";
            public static readonly string validTo = "validTo";
            public static readonly string PartDelivr = "PartDelivr";
            public static readonly string Phone1 = "Phone1";
            public static readonly string Phone2 = "Phone2";
            public static readonly string CntctPrsn = "CntctPrsn";
            public static readonly string CmpPrivate = "CmpPrivate";
            public static readonly string State1 = "State1";
            public static readonly string State2 = "State2";
            public static readonly string Cellular = "Cellular";
            public static readonly string AliasName = "AliasName";
            public static readonly string CreateDate = "CreateDate";
            public static readonly string Currency = "Currency";
        }

        /// <summary>
        /// Descrição dos Campos
        /// </summary>
        public struct Description
        {
            public static readonly string CardCode = "Código";
            public static readonly string CardName = "Nome";
            public static readonly string CardFName = "Nome Fantasia";
            public static readonly string CardType = "Tipo de PN";
            public static readonly string GroupCode = "Grupo";
            public static readonly string CreditLine = "Limite de Crédito";
            public static readonly string BillToDef = "End. de Combrança Padrão";
            public static readonly string ShipToDef = "End. de Entrega Padrão";
            public static readonly string ListNum = "Lista de Preço";
            public static readonly string CollecAuth = "Autorização de Cobrança";
            public static readonly string GroupNum = "Condições de Pagamento";
            public static readonly string SlpCode = "Código do Vendedor";
            public static readonly string Territory = "Território";
            public static readonly string City = "Cidade";
            public static readonly string Block = "Bairro";
            public static readonly string Address = "Endereço";
            public static readonly string Discount = "% Desconto";
            public static readonly string PymCode = "Meio de Pagemnto padrão";
            public static readonly string E_Mail = "EMail";
            public static readonly string Notes = "Notes";
            public static readonly string Password = "Senha";
            public static readonly string AddID = "AddID";
            public static readonly string IntrstRate = "% Juros";
            public static readonly string AvrageLate = "Prazo de Entrega";
            public static readonly string FatherCard = "Consolidação de PN.";
            public static readonly string validFor = "Inativo";
            public static readonly string frozenFrom = "Inativo De";
            public static readonly string frozenTo = "Inativo Até";
            public static readonly string validFrom = "Ativo De";
            public static readonly string validTo = "Ativo até";
            public static readonly string PartDelivr = "Permitir entrega parcial";
            public static readonly string Phone1 = "Telefone";
            public static readonly string Phone2 = "DDD";
            public static readonly string CntctPrsn = "Contato";
            public static readonly string CmpPrivate = "Tipo de Pessoa";
            public static readonly string State1 = "Estado 1";
            public static readonly string State2 = "Estado 2";
            public static readonly string Cellular = "Tel.celular";
            public static readonly string AliasName = "Nome do alias";
            public static readonly string CreateDate = "CreateDate";
            public static readonly string Currency = "Moeda";
        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCRD";
        }

        readonly TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, Description.CardCode, DbType.String, 15, null, true, false);
        readonly TableAdapterField m_CardName = new TableAdapterField(FieldsName.CardName, Description.CardName, 200);
        readonly TableAdapterField m_CardFName = new TableAdapterField(FieldsName.CardFName, Description.CardFName, 200);
        readonly TableAdapterField m_CardType = new TableAdapterField(FieldsName.CardType, Description.CardType, 1);
        readonly TableAdapterField m_GroupCode = new TableAdapterField(FieldsName.GroupCode, Description.GroupCode, DbType.Int32);
        readonly TableAdapterField m_CreditLine = new TableAdapterField(FieldsName.CreditLine, Description.CreditLine, DbType.Decimal);
        readonly TableAdapterField m_BillToDef = new TableAdapterField(FieldsName.BillToDef, Description.BillToDef, 50);
        readonly TableAdapterField m_ShipToDef = new TableAdapterField(FieldsName.ShipToDef, Description.ShipToDef, 50);
        readonly TableAdapterField m_ListNum = new TableAdapterField(FieldsName.ListNum, Description.ListNum, DbType.Int16);
        readonly TableAdapterField m_CollecAuth = new TableAdapterField(FieldsName.CollecAuth, Description.CollecAuth, 1);
        readonly TableAdapterField m_GroupNum = new TableAdapterField(FieldsName.GroupNum, Description.GroupNum, DbType.Int32);
        readonly TableAdapterField m_SlpCode = new TableAdapterField(FieldsName.SlpCode, Description.SlpCode, DbType.Int32);
        readonly TableAdapterField m_Territory = new TableAdapterField(FieldsName.Territory, Description.Territory, DbType.Int32);
        readonly TableAdapterField m_City = new TableAdapterField(FieldsName.City, Description.City, 100);
        readonly TableAdapterField m_Block = new TableAdapterField(FieldsName.Block, Description.Block, 100);
        readonly TableAdapterField m_Address = new TableAdapterField(FieldsName.Address, Description.Address, 100);
        readonly TableAdapterField m_Discount = new TableAdapterField(FieldsName.Discount, Description.Discount, DbType.Decimal);
        readonly TableAdapterField m_PymCode = new TableAdapterField(FieldsName.PymCode, Description.PymCode, 15);
        readonly TableAdapterField m_E_Mail = new TableAdapterField(FieldsName.E_Mail, Description.E_Mail, 100);
        readonly TableAdapterField m_Notes = new TableAdapterField(FieldsName.Notes, Description.Notes, 100);
        readonly TableAdapterField m_Password = new TableAdapterField(FieldsName.Password, Description.Password, 100);
        readonly TableAdapterField m_AddID = new TableAdapterField(FieldsName.AddID, Description.AddID, 18);
        readonly TableAdapterField m_IntrstRate = new TableAdapterField(FieldsName.IntrstRate, Description.IntrstRate, DbType.Decimal);
        readonly TableAdapterField m_AvrageLate = new TableAdapterField(FieldsName.AvrageLate, Description.AvrageLate, DbType.Int32);
        readonly TableAdapterField m_FatherCard = new TableAdapterField(FieldsName.FatherCard, Description.FatherCard, 15);
        readonly TableAdapterField m_validFor = new TableAdapterField(FieldsName.validFor, Description.validFor, 1);
        readonly TableAdapterField m_frozenFrom = new TableAdapterField(FieldsName.frozenFrom, Description.frozenFrom, DbType.DateTime);
        readonly TableAdapterField m_frozenTo = new TableAdapterField(FieldsName.frozenTo, Description.frozenTo, DbType.DateTime);
        readonly TableAdapterField m_validFrom = new TableAdapterField(FieldsName.validFrom, Description.validFrom, DbType.DateTime);
        readonly TableAdapterField m_validTo = new TableAdapterField(FieldsName.validTo, Description.validTo, DbType.DateTime);
        readonly TableAdapterField m_PartDelivr = new TableAdapterField(FieldsName.PartDelivr, Description.PartDelivr, 1);
        readonly TableAdapterField m_Phone1 = new TableAdapterField(FieldsName.Phone1, Description.Phone1, 20);
        readonly TableAdapterField m_Phone2 = new TableAdapterField(FieldsName.Phone2, Description.Phone2, 20);
        readonly TableAdapterField m_CntctPrsn = new TableAdapterField(FieldsName.CntctPrsn, Description.CntctPrsn, 90);
        readonly TableAdapterField m_CmpPrivate = new TableAdapterField(FieldsName.CmpPrivate, Description.CmpPrivate, 1);
        readonly TableAdapterField m_State1 = new TableAdapterField(FieldsName.State1, Description.State1, 3);
        readonly TableAdapterField m_State2 = new TableAdapterField(FieldsName.State2, Description.State2, 3);
        readonly TableAdapterField m_Currency = new TableAdapterField(FieldsName.Currency, Description.Currency, 3);
        readonly TableAdapterField m_Cellular = new TableAdapterField(FieldsName.Cellular, Description.Cellular, 20);
        readonly TableAdapterField m_AliasName = new TableAdapterField(FieldsName.AliasName, Description.AliasName, 100);

        readonly TableAdapterField m_CreateDate = new TableAdapterField(FieldsName.CreateDate, Description.CreateDate, DbType.DateTime);

        public BusinessPartner()
            : base(Definition.TableName)
        {

        }

        /// <summary>
        /// Parceiro de Negócios
        /// </summary>
        public BusinessPartner(string pCompanyDb)
            : this()
        {
            DBName = pCompanyDb;
        }

        public BusinessPartner(BusinessPartner pBusinessPartner)
            : this()
        {
            CopyBy(pBusinessPartner);
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public string CardName
        {
            get { return m_CardName.GetString(); }
            set { m_CardName.Value = value; }
        }

        public string CardFName
        {
            get { return m_CardFName.GetString(); }
            set { m_CardFName.Value = value; }
        }

        public eCardType CardType
        {
            get { return m_CardType.GetString().ToEnum(); }
            set { m_CardType.Value = value.ToStringEnum(); }
        }

        /// <summary>
        /// Moeda
        /// </summary>
        public String Currency
        {
            get { return m_Currency.GetString(); }
            set { m_Currency.Value = value; }
        }

        public Int32 GroupCode
        {
            get { return m_GroupCode.GetInt32(); }
            set { m_GroupCode.Value = value; }
        }

        public Decimal CreditLine
        {
            get { return m_CreditLine.GetDecimal(); }
            set { m_CreditLine.Value = value; }
        }

        public string BillToDef
        {
            get { return m_BillToDef.GetString(); }
            set { m_BillToDef.Value = value; }
        }

        public string ShipToDef
        {
            get { return m_ShipToDef.GetString(); }
            set { m_ShipToDef.Value = value; }
        }

        public eYesNo CollecAuth
        {
            get { return m_CollecAuth.GetString().ToYesNoEnum(); }
            set { m_CollecAuth.Value = value.ToYesNoString(); }
        }

        public short ListNum
        {
            get { return m_ListNum.GetInt16(); }
            set { m_ListNum.Value = value; }
        }

        public Int32 GroupNum
        {
            get { return m_GroupNum.GetInt32(); }
            set { m_GroupNum.Value = value; }
        }

        public Int32 SlpCode
        {
            get { return m_SlpCode.GetInt32(); }
            set { m_SlpCode.Value = value; }
        }

        public Int32 Territory
        {
            get { return m_Territory.GetInt32(); }
            set { m_Territory.Value = value; }
        }

        public string City
        {
            get { return m_City.GetString(); }
            set { m_City.Value = value; }
        }

        public string Block
        {
            get { return m_Block.GetString(); }
            set { m_Block.Value = value; }
        }

        public string Address
        {
            get { return m_Address.GetString(); }
            set { m_Address.Value = value; }
        }

        public decimal Discount
        {
            get { return m_Discount.GetDecimal(); }
            set { m_Discount.Value = value; }
        }

        public string PymCode
        {
            get { return m_PymCode.GetString(); }
            set { m_PymCode.Value = value; }
        }

        public string E_Mail
        {
            get { return m_E_Mail.GetString(); }
            set { m_E_Mail.Value = value; }
        }

        public string Notes
        {
            get { return m_Notes.GetString(); }
            set { m_Notes.Value = value; }
        }

        public string Password
        {
            get { return m_Password.GetString(); }
            set { m_Password.Value = value; }
        }

        public string AddID
        {
            get { return m_AddID.GetString(); }
            set { m_AddID.Value = value; }
        }

        public Decimal IntrstRate
        {
            get { return m_IntrstRate.GetDecimal(); }
            set { m_IntrstRate.Value = value; }
        }

        public Int32 AvrageLate
        {
            get { return m_AvrageLate.GetInt32(); }
            set { m_AvrageLate.Value = value; }
        }

        public string FatherCard
        {
            get { return m_FatherCard.GetString(); }
            set { m_FatherCard.Value = value; }
        }

        public DateTime validFrom
        {
            get { return m_validFrom.GetDateTime();}
            set { m_validFrom.Value = value; }
        }

        public DateTime validTo
        {
            get { return m_validTo.GetDateTime(); }
            set { m_validTo.Value = value; }
        }

        public eYesNo validFor
        {
            get { return m_validFor.GetString().ToYesNoEnum(); }
            set { m_validFor.Value = value.ToYesNoString(); }
        }

        public DateTime frozenFrom
        {
            get { return m_frozenFrom.GetDateTime(); }
            set { m_frozenFrom.Value = value; }
        }

        public DateTime frozenTo
        {
            get { return m_frozenTo.GetDateTime(); }
            set { m_frozenTo.Value = value; }
        }

        public eYesNo PartDelivr
        {
            get { return m_PartDelivr.GetString().ToYesNoEnum(); }
            set { m_PartDelivr.Value = value.ToYesNoString(); }
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

        public String CmpPrivate
        {
            get { return m_CmpPrivate.GetString(); }
            set { m_CmpPrivate.Value = value; }
        }

        /// <summary>
        /// Contato
        /// </summary>
        public String CntctPrsn
        {
            get { return m_CntctPrsn.GetString(); }
            set { m_CntctPrsn.Value = value; }
        }

        public String State1
        {
            get { return m_State1.GetString(); }
            set { m_State1.Value = value; }
        }

        public String State2
        {
            get { return m_State2.GetString(); }
            set { m_State2.Value = value; }
        }

        public String Cellular
        {
            get { return m_Cellular.GetString(); }
            set { m_Cellular.Value = value; }
        }

        public String AliasName
        {
            get { return m_AliasName.GetString(); }
            set { m_AliasName.Value = value; }
        }

        public DateTime CreateDate
        {
            get { return m_CreateDate.GetDateTime(); }
            set { m_CreateDate.Value = value; }
        }


        public bool GetByKey(string cardCode)
        {
            CardCode = cardCode;
            return GetByKey();
        }

        public List<BusinessPartner> GetAll(eCardType pCardType)
        {
            var myQuery = new TableQuery(this);
            myQuery.Where.Add(new QueryParam(m_CardType, pCardType.ToStringEnum()));
            return FillCollection<BusinessPartner>(myQuery);
        }



    }
}
