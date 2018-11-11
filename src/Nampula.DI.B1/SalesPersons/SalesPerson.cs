using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nampula.DI;

using System.Data;

namespace Nampula.DI.B1.SalesPersons
{
    public class SalesPerson : TableAdapter
    {
        /// <summary>
        /// Quando não há nenhum vendedor esse é o vendeor padrao
        /// </summary>
        public static readonly SalesPerson DefaultSeller = new SalesPerson
                                                               {
                                                                   SlpCode = -1,
                                                                   SlpName = "Nenhum Vendedor"
                                                               };

        public struct FieldsName
        {
            public static readonly string SlpCode = "SlpCode"; //PK
            public static readonly string SlpName = "SlpName"; //PK
            public static readonly string Commission = "Commission";
        }

        public struct Description
        {
            public static readonly string SlpCode = "Código"; //PK
            public static readonly string SlpName = "Nome"; //PK
            public static readonly string Commission = "Commission";
        }

        TableAdapterField m_SlpCode = new TableAdapterField(FieldsName.SlpCode, Description.SlpCode, DbType.Int32, 6, 0, true, false);
        TableAdapterField m_SlpName = new TableAdapterField(FieldsName.SlpName, Description.SlpName, 32);
        TableAdapterField m_Commission = new TableAdapterField(FieldsName.Commission, Description.Commission, DbType.Decimal);

        public SalesPerson()
            : base("OSLP")
        {
        }

        public SalesPerson(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public SalesPerson(SalesPerson pSalesPerson)
            : this()
        {
            this.CopyBy(pSalesPerson);
        }

        public int SlpCode
        {
            get { return m_SlpCode.GetInt32(); }
            set { m_SlpCode.Value = value; }
        }
        public string SlpName
        {
            get { return m_SlpName.GetString(); }
            set { m_SlpName.Value = value; }
        }
        public string Commission
        {
            get { return m_Commission.GetString(); }
            set { m_Commission.Value = value; }
        }

        public bool GetByKey(int pSlpCode)
        {
            this.SlpCode = pSlpCode;

            return base.GetByKey();
        }

        public List<SalesPerson> GetAll()
        {
            return FillCollection<SalesPerson>();
        }
    }
}
