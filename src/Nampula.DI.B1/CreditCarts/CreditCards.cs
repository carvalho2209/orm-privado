using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.CreditCarts
{
    public class CreditCards : TableAdapter
    {
        public struct Definition
        {
            public static readonly string TableName = "OCRC";
        }

        public struct FieldsName
        {
            public static readonly string CreditCard = "CreditCard";
            public static readonly string CardName = "CardName";
            public static readonly string AcctCode = "AcctCode";
            public static readonly string Phone = "Phone";
            public static readonly string CompanyId = "CompanyId";
        }

        public struct FieldsDescription
        {
            public static readonly string CreditCard = "Cartão de Crédito Código";
            public static readonly string CardName = "Cartão de Crédito Nome";
            public static readonly string AcctCode = "Conta Contábil";
            public static readonly string Phone = "Telefone";
            public static readonly string CompanyId = "Company Id";
        }

        readonly TableAdapterField m_CreditCard = new TableAdapterField(FieldsName.CreditCard, FieldsDescription.CreditCard, DbType.Int32);
        readonly TableAdapterField m_CardName = new TableAdapterField(FieldsName.CardName, FieldsDescription.CardName, 30);
        readonly TableAdapterField m_AcctCode = new TableAdapterField(FieldsName.AcctCode, FieldsDescription.AcctCode, 15);
        readonly TableAdapterField m_Phone = new TableAdapterField(FieldsName.Phone, FieldsDescription.Phone, 20);
        readonly TableAdapterField m_CompanyId = new TableAdapterField(FieldsName.CompanyId, FieldsDescription.CompanyId, 20);

        public Int32 CreditCard
        {
            get { return m_CreditCard.GetInt32(); }
            set { m_CreditCard.Value = value; }
        }

        public String CardName
        {
            get { return m_CardName.GetString(); }
            set { m_CardName.Value = value; }
        }

        public String AcctCode
        {
            get { return m_AcctCode.GetString(); }
            set { m_AcctCode.Value = value; }
        }

        public String Phone
        {
            get { return m_Phone.GetString(); }
            set { m_Phone.Value = value; }
        }

        public String CompanyId
        {
            get { return m_CompanyId.GetString(); }
            set { m_CompanyId.Value = value; }
        }


        public CreditCards(string pCompanyDb)
            : base(pCompanyDb, "OCRC")
        {

        }

        public CreditCards()
        {
            base.TableName = "OCRC";
        }

        public List<CreditCards> GetAll()
        {
            return FillCollection<CreditCards>(GetData().Rows);
        }



    }
}
