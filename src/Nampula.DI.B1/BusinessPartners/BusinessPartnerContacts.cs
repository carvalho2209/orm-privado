using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{
    public class BusinessPartnerContact : TableAdapter
    {

        public class FieldsName
        {
            public static readonly string CardCode = "CardCode";
            public static readonly string CntctCode = "CntctCode";
            public static readonly string Name = "Name";
        }

        public class Description
        {
            public static readonly string CardCode = "CardCode";
            public static readonly string CntctCode = "CntctCode";
            public static readonly string Name = "Name";
        }

        /// <summary>
        /// Definições da Tabela
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "OCPR";
        }

        TableAdapterField m_CntctCode = new TableAdapterField(0, FieldsName.CntctCode, Description.CntctCode,DbType.Int32,11,null,true,false );
        TableAdapterField m_CardCode = new TableAdapterField(0, FieldsName.CardCode, Description.CardCode, 15);
        TableAdapterField m_Name = new TableAdapterField(0, FieldsName.Name, Description.Name,50 );

        public BusinessPartnerContact(string pCompanyDb)
            : base(pCompanyDb,Definition.TableName)
        {
        }

        public BusinessPartnerContact(BusinessPartnerContact pBusinessPartnerContact)
            : this(pBusinessPartnerContact.DBName)
        {
            this.CopyBy(pBusinessPartnerContact);
        }

        public override bool Add()
        {
            return false;
        }

        public override bool Update()
        {
            return false;
        }

        public override bool Remove()
        {
            return false;
        }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            private set { m_CardCode.Value = value; }
        }

        public int CntctCode
        {
            get { return m_CntctCode.GetInt32 (); }
            private set { m_CntctCode.Value = value; }
        }

        public string Name
        {
            get { return m_Name.GetString(); }
            private set { m_Name.Value = value; }
        }       

        public bool GetByKey(int pCntctCode)
        {
            this.CntctCode = pCntctCode;
            return this.GetByKey();
        }

        private BusinessPartnerContact CreateObject()
        {
            return new BusinessPartnerContact(this.DBName);
        }

        public List<BusinessPartnerContact> GetByBusinessPartner(string pCardCode)
        {
            TableQuery myQuery = new TableQuery(this);
            myQuery.Where.Add(new QueryParam(m_CardCode, pCardCode));

            return FillCollection<BusinessPartnerContact>(GetData(myQuery).Rows, CreateObject);
        }
    
    }
}
