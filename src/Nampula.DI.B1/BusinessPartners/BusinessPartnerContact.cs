using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{
    public class BusinessPartnerContact : TableAdapter
    {

        public class FieldsName
        {
            public static readonly string CardCode = "CardCode";
            public static readonly string CntctCode = "CntctCode";
            
            public static readonly string Address = "Address";
            public static readonly string Tel1 = "Tel1";
            public static readonly string Tel2 = "Tel2";
            public static readonly string Cellolar = "Cellolar";
            public static readonly string Title = "Title";
            public static readonly string FirstName = "FirstName";
            public static readonly string Name = "Name";
            public static readonly string LastName = "LastName";
            
            public static readonly string E_MailL = "E_MailL";
            public static readonly string Active = "Active";
        }

        public class Description
        {
            public static readonly string CardCode = "N° do Parceiro";
            public static readonly string CntctCode = "N° do Contato";

            public static readonly string Name = "Nome";
            public static readonly string Address = "Endereço";
            public static readonly string Tel1 = "Telefone 1";
            public static readonly string Tel2 = "Telefone 2";
            public static readonly string Cellolar = "Celular";
            public static readonly string Title = "Título";
            public static readonly string FirstName = "Primeiro nome";
            public static readonly string LastName = "Último nome";
            
            public static readonly string E_MailL = "E_MailL";
            public static readonly string Active = "Ativo";
        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCPR";
        }

        TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, Description.CardCode, 15);
        TableAdapterField m_CntctCode = new TableAdapterField(FieldsName.CntctCode, Description.CntctCode, DbType.Int32, 11, 0, true, true);
        TableAdapterField m_Name = new TableAdapterField(FieldsName.Name, Description.Name, 50);
        TableAdapterField m_Address = new TableAdapterField(FieldsName.Address, Description.Address, 100);
        TableAdapterField m_Tel1 = new TableAdapterField(FieldsName.Tel1, Description.Tel1, 20);
        TableAdapterField m_Tel2 = new TableAdapterField(FieldsName.Tel2, Description.Tel2, 20);
        TableAdapterField m_Cellolar = new TableAdapterField(FieldsName.Cellolar, Description.Cellolar, 50);
        TableAdapterField m_Title = new TableAdapterField(FieldsName.Title, Description.Title, 10);
        TableAdapterField m_FirstName = new TableAdapterField(FieldsName.FirstName, Description.FirstName, 50);
        TableAdapterField m_LastName = new TableAdapterField(FieldsName.LastName, Description.LastName, 50);
        TableAdapterField m_E_MailL = new TableAdapterField(FieldsName.E_MailL, Description.E_MailL, 100);
        TableAdapterField m_Active = new TableAdapterField(FieldsName.Active, Description.Active, 100);

        public BusinessPartnerContact()
            : base(Definition.TableName)
        {
        }

        public BusinessPartnerContact(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public BusinessPartnerContact(BusinessPartnerContact pBusinessPartnerContact)
            : this(pBusinessPartnerContact.DBName)
        {
            this.CopyBy(pBusinessPartnerContact);
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public int CntctCode
        {
            get { return m_CntctCode.GetInt32(); }
            set { m_CntctCode.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString(); }
            set { m_Name.Value = value; }
        }

        public String Address
        {
            get { return m_Address.GetString(); }
            set { m_Address.Value = value; }
        }

        public String Tel1
        {
            get { return m_Tel1.GetString(); }
            set { m_Tel1.Value = value; }
        }

        public String Tel2
        {
            get { return m_Tel2.GetString(); }
            set { m_Tel2.Value = value; }
        }

        public String Cellolar
        {
            get { return m_Cellolar.GetString(); }
            set { m_Cellolar.Value = value; }
        }

        public String Title
        {
            get { return m_Title.GetString(); }
            set { m_Title.Value = value; }
        }

        public String FirstName
        {
            get { return m_FirstName.GetString(); }
            set { m_FirstName.Value = value; }
        }

        public String LastName
        {
            get { return m_LastName.GetString(); }
            set { m_LastName.Value = value; }
        }

        public String E_MailL
        {
            get { return m_E_MailL.GetString(); }
            set { m_E_MailL.Value = value; }
        }

        public String Active
        {
            get { return m_Active.GetString(); }
            set { m_Active.Value = value; }
        }

        public bool IsActive()
        {
            return Active.ToYesNoEnum() == eYesNo.Yes;
        }

        public bool GetByKey(int pCntctCode)
        {
            this.CntctCode = pCntctCode;
            return this.GetByKey();
        }

        public List<BusinessPartnerContact> GetByBusinessPartner(string pCardCode)
        {
            TableQuery myQuery = new TableQuery(this);
            myQuery.Where.Add(new QueryParam(m_CardCode, pCardCode));

            return FillCollection<BusinessPartnerContact>(GetData(myQuery).Rows);
        }

    }
}
