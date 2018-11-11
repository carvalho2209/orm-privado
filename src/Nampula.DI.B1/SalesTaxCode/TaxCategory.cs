using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.SalesTaxCode
{

    public class TaxCategory : TableAdapter
    {
        public struct FieldsName
        {
            public const string AbsID = "AbsID";
            public const string Code = "Code";
            public const string Locked = "Locked";
        }

        TableAdapterField m_AbsID = new TableAdapterField(FieldsName.AbsID, null, DbType.Int32, 11, null, true, false);
        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, null, 20);
        TableAdapterField m_Locked = new TableAdapterField(FieldsName.Locked, null, 1);

        public TaxCategory()
            : base("ONFT")
        {
        }

        public TaxCategory(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public int AbsID
        {
            get { return m_AbsID.GetInt32(); }
            set { m_AbsID.Value = value; }
        }

        public string Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public string Locked
        {
            get { return m_Locked.GetString(); }
            set { m_Locked.Value = value; }
        }

        public bool GetByKey(int AbsID)
        {
            this.AbsID = AbsID;
            return this.GetByKey();
        }

        public List<TaxCategory> GetAll()
        {
            return FillCollection<TaxCategory>();
        }
    }
}
