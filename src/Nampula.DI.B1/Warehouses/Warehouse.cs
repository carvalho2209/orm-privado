using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.Warehouses
{

    public class Warehouse : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string WhsCode = "WhsCode";
            public static readonly string WhsName = "WhsName";
            public static readonly string OwnerCode = "OwnerCode";
            public static readonly string BPLid = "BPLid";
        }

        public struct FieldsDescription
        {
            public static readonly string WhsCode = "Código";
            public static readonly string WhsName = "Nome";
            public static readonly string OwnerCode = "Código do proprietário";
            public static readonly string BPLid = "Filial";
        }

        readonly TableAdapterField m_WhsCode = new TableAdapterField(FieldsName.WhsCode, FieldsDescription.WhsCode, DbType.String, 8, null, true, false);
        readonly TableAdapterField m_WhsName = new TableAdapterField(FieldsName.WhsName, FieldsDescription.WhsName, 100);
        readonly TableAdapterField m_OwnerCode = new TableAdapterField(FieldsName.OwnerCode, FieldsDescription.OwnerCode, 1);
        readonly TableAdapterField m_BPLid = new TableAdapterField(FieldsName.BPLid, FieldsDescription.BPLid, DbType.Int32);

        public Warehouse()
            : base("OWHS")
        {
        }

        public Warehouse(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public string WhsCode
        {
            get { return m_WhsCode.GetString(); }
            set { m_WhsCode.Value = value; }
        }

        public string WhsName
        {
            get { return m_WhsName.GetString(); }
            set { m_WhsName.Value = value; }
        }

        public String OwnerCode
        {
            get { return m_OwnerCode.GetString(); }
            set { m_OwnerCode.Value = value; }
        }


        public bool GetByKey(string pWhsCode)
        {
            this.WhsCode = pWhsCode;
            return base.GetByKey();
        }

        public Int32 BPLid
        {
            get { return m_BPLid.GetInt32(); }
            set { m_BPLid.Value = value; }
        }
        
        public List<Warehouse> GetAll()
        {
            return FillCollection<Warehouse>();
        }

    }

}
