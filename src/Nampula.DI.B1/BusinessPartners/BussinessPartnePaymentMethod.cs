using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.BusinessPartners
{
    public class BussinessPartnerPaymentMethod : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string CardCode = "CardCode";
            public static readonly string PymCode = "PymCode";
        }

        public struct Description
        {
            public static readonly string CardCode = "Parceiro";
            public static readonly string PymCode = "PymCode";
        }

        TableAdapterField m_CardCode = new TableAdapterField ( FieldsName.CardCode, Description.CardCode, DbType.String, 10, null, true, false);
        TableAdapterField m_PymCode = new TableAdapterField ( FieldsName.PymCode, Description.PymCode, DbType.String, 10, null, true, false);

        public BussinessPartnerPaymentMethod()
            : base("CRD2")
        {
        }

        public BussinessPartnerPaymentMethod(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public string PymCode
        {
            get { return m_PymCode.GetString(); }
            set { m_PymCode.Value = value; }
        }

        public bool GetByKey(string pCardCode, string pPymCode)
        {
            this.CardCode = pCardCode;
            this.PymCode = pPymCode;
            return base.GetByKey();
        }

        public List<BussinessPartnerPaymentMethod> GetByCardCode(string pCardCode)
        {
            TableQuery myQuery = new TableQuery(this);

            myQuery.Where.Add(new QueryParam(m_CardCode, pCardCode));

            return FillCollection<BussinessPartnerPaymentMethod>(GetData(myQuery).Rows);
        }

    }
}
