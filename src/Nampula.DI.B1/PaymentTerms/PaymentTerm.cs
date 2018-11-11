using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.PaymentTerms
{

    public class PaymentTerm : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string GroupNum = "GroupNum";
            public static readonly string PymntGroup = "PymntGroup";
            public static readonly string InstNum = "InstNum";
            public static readonly string VolumDscnt = "VolumDscnt";
            public static readonly string LatePyChrg = "LatePyChrg";
            public static readonly string ListNum = "ListNum";
            public static readonly string ExtraMonth = "ExtraMonth";
            public static readonly string ExtraDays = "ExtraDays";
        }

        public struct Description
        {
            public static readonly string GroupNum = "Código";
            public static readonly string PymntGroup = "Condição de Pagamento";
            public static readonly string InstNum = "Parcelas";
            public static readonly string VolumDscnt = "Desconto (%)";
            public static readonly string LatePyChrg = "Juros (%)";
            public static readonly string ListNum = "Lista de Preço";
            public static readonly string ExtraMonth = "Meses";
            public static readonly string ExtraDays = "Dias";
        }

        public struct Definition
        {
            public static readonly string TableName = "OCTG";
        }

        private TableAdapterField m_GroupNum = new TableAdapterField(FieldsName.GroupNum, Description.GroupNum, DbType.Int32, 10, 0, true, false);
        private TableAdapterField m_PymntGroup = new TableAdapterField(FieldsName.PymntGroup, Description.PymntGroup, 50);
        private TableAdapterField m_InstNum = new TableAdapterField(FieldsName.InstNum, Description.InstNum, DbType.Int32);
        private TableAdapterField m_VolumDscnt = new TableAdapterField(FieldsName.VolumDscnt, Description.VolumDscnt, DbType.Decimal, 19, 6);
        private TableAdapterField m_LatePyChrg = new TableAdapterField(FieldsName.LatePyChrg, Description.LatePyChrg, DbType.Decimal, 19, 6);
        private TableAdapterField m_ListNum = new TableAdapterField(FieldsName.ListNum, Description.ListNum, DbType.Int32);
        private TableAdapterField m_ExtraMonth = new TableAdapterField(FieldsName.ExtraMonth, Description.ExtraMonth, DbType.Int32);
        private TableAdapterField m_ExtraDays = new TableAdapterField(FieldsName.ExtraDays, Description.ExtraDays, DbType.Int32);


        public PaymentTerm(string pCompanyDb)
            : base(pCompanyDb, Definition.TableName)
        {
        }

        public PaymentTerm()
            : base(Definition.TableName)
        {
        }

        public int GroupNum
        {
            get { return m_GroupNum.GetInt32(); }
            set { m_GroupNum.Value = value; }
        }

        public string PymntGroup
        {
            get { return m_PymntGroup.GetString(); }
            set { m_PymntGroup.Value = value; }
        }

        public int InstNum
        {
            get { return m_InstNum.GetInt32(); }
            set { m_InstNum.Value = value; }
        }

        public decimal VolumDscnt
        {
            get { return m_VolumDscnt.GetDecimal(); }
            set { m_VolumDscnt.Value = value; }
        }

        public decimal LatePyChrg
        {
            get { return m_LatePyChrg.GetDecimal(); }
            set { m_LatePyChrg.Value = value; }
        }

        public Int32 ListNum
        {
            get { return m_ListNum.GetInt32(); }
            set { m_ListNum.Value = value; }
        }

        public Int32 ExtraMonth
        {
            get { return m_ExtraMonth.GetInt32(); }
            set { m_ExtraMonth.Value = value; }
        }

        public Int32 ExtraDays
        {
            get { return m_ExtraDays.GetInt32(); }
            set { m_ExtraDays.Value = value; }
        }

        public bool GetByKey(int GroupNum)
        {
            this.GroupNum = GroupNum;
            return base.GetByKey();
        }

        public List<PaymentTerm> GetAll()
        {
            return FillCollection<PaymentTerm>();
        }
    }
}
