using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nampula.DI.B1.Itens
{
    public class BrazilFuelIndexer : TableAdapter
    {
        public struct Definition
        {
            public static readonly string TableName = "OBFI";
        }

        public struct FieldsName
        {
            public static readonly string ID = "ID";
            public static readonly string Code = "Code";
            public static readonly string FGroupCode = "FGroupCode";
            public static readonly string Descr = "Descr";
            public static readonly string UserSign = "UserSign";
        }

        public struct FieldsDescription
        {
            public static readonly string ID = "ID";
            public static readonly string Code = "Código";
            public static readonly string FGroupCode = "Código Grupo de Combustível";
            public static readonly string Descr = "Descrição";
            public static readonly string UserSign = "Usuário";
        }

        TableAdapterField m_ID = new TableAdapterField(FieldsName.ID, FieldsDescription.ID, DbType.Int32, 11, 0, true, false);
        TableAdapterField m_Code = new TableAdapterField(FieldsName.Code, FieldsDescription.Code, 10);
        TableAdapterField m_FGroupCode = new TableAdapterField(FieldsName.FGroupCode, FieldsDescription.FGroupCode, DbType.Int32);
        TableAdapterField m_Descr = new TableAdapterField(FieldsName.Descr, FieldsDescription.Descr, 254);
        TableAdapterField m_UserSign = new TableAdapterField(FieldsName.UserSign, FieldsDescription.UserSign, DbType.Int32);

        public BrazilFuelIndexer()
            : base(Definition.TableName)
        {

        }

        public BrazilFuelIndexer(String pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public BrazilFuelIndexer(BrazilFuelIndexer pBrazilFuelIndexer)
            : this(pBrazilFuelIndexer.DBName)
        {
            this.CopyBy(pBrazilFuelIndexer);
        }

        public string Code
        {
            get { return m_Code.GetString(); }
            set { m_Code.Value = value; }
        }

        public Int32 FGroupCode
        {
            get { return m_FGroupCode.GetInt32(); }
            set { m_FGroupCode.Value = value; }
        }

        public string Descr
        {
            get { return m_Descr.GetString(); }
            set { m_Descr.Value = value; }
        }

        public Int32 UserSign
        {
            get { return m_UserSign.GetInt32(); }
            set { m_UserSign.Value = value; }
        }

        public Int32 ID
        {
            get { return m_ID.GetInt32(); }
            set { m_ID.Value = value; }
        }

        public bool GetByKey(Int32 pID)
        {
            this.ID = pID;
            return base.GetByKey();
        }
    }
}
