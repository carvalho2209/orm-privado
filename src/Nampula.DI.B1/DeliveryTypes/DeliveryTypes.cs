using System;
using System.Collections.Generic;
using Nampula.DI;

using System.Text;
using System.Data;

namespace Nampula.DI.B1.DeliveryTypes
{
    public class DeliveryTypes : TableAdapter
    {
        public struct FieldsName
        {
            public static readonly string TrnspCode = "TrnspCode";
            public static readonly string TrnspName = "TrnspName";
            public static readonly string WebSite = "WebSite";
        }

        public struct Description
        {
            public static readonly string TrnspCode = "Códigp";
            public static readonly string TrnspName = "Nome";
            public static readonly string WebSite = "Web Site";
        }

        TableAdapterField m_TrnspCode = new TableAdapterField(FieldsName.TrnspCode, Description.TrnspCode, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_TrnspName = new TableAdapterField(FieldsName.TrnspName, "Name", DbType.String, 40, 0, true, false);
        TableAdapterField m_WebSite = new TableAdapterField(FieldsName.WebSite, "WebSite", 50);

        public DeliveryTypes()
            : base("OSHP")
        {
        }

        public DeliveryTypes(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public DeliveryTypes(DeliveryTypes pDeliveryTypes)
            : this()
        {
            this.CopyBy(pDeliveryTypes);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public int TrnspCode
        {
            get { return m_TrnspCode.GetInt32(); }
            set { m_TrnspCode.Value = value; }
        }
        public string TrnspName
        {
            get { return m_TrnspName.GetString(); }
            set { m_TrnspName.Value = value; }
        }
        public string WebSite
        {
            get { return m_WebSite.GetString(); }
            set { m_WebSite.Value = value; }
        }

        public bool GetByKey(int pTrnspCode)
        {
            this.TrnspCode = pTrnspCode;
            return base.GetByKey();
        }

        public bool GetByKey(string pTrnspName)
        {
            this.TrnspName = pTrnspName;
            return base.GetByKey();
        }

        public List<DeliveryTypes> GetAll()
        {
            return FillCollection<DeliveryTypes>();
        }

    }
}
