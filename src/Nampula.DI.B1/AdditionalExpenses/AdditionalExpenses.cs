using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.AdditionalExpenses
{
    /// <summary>
    /// Despesas adicionais
    /// </summary>
    public class AdditionalExpense : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string ExpnsCode = "ExpnsCode";
            public static readonly string ExpnsName = "ExpnsName";
            public static readonly string ExpnsType = "ExpnsType";
        }

        public struct Description
        {
            public static readonly string ExpnsCode = "Despesa Adicional";
            public static readonly string ExpnsName = "Descrição";
            public static readonly string ExpnsType = "Tipo de Despesas";
        }

        TableAdapterField m_ExpnsCode = new TableAdapterField(FieldsName.ExpnsCode, Description.ExpnsCode, DbType.Int32, 4, null, true, false);
        TableAdapterField m_ExpnsName = new TableAdapterField(FieldsName.ExpnsName, Description.ExpnsName, 40);
        TableAdapterField m_ExpnsType = new TableAdapterField(FieldsName.ExpnsType, Description.ExpnsType, 1);

        public AdditionalExpense()
            : base("OEXD")
        {
        }

        public AdditionalExpense(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public AdditionalExpense(AdditionalExpense pAdditionalExpense)
            : this(pAdditionalExpense.DBName)
        {
            this.CopyBy(pAdditionalExpense);
        }

        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public int ExpnsCode
        {
            get { return m_ExpnsCode.GetInt32(); }
            set { m_ExpnsCode.Value = value; }
        }

        public string ExpnsName
        {
            get { return m_ExpnsName.GetString(); }
            set { m_ExpnsName.Value = value; }
        }

        public string ExpnsType
        {
            get { return m_ExpnsType.GetString(); }
            set { m_ExpnsType.Value = value; }
        }

        public ExpensesFreightTypeEnum ExpnsTypeEnum
        {
            get { return this.ExpnsType.ToFreightEnum(); }
            set { m_ExpnsType.Value = this.ExpnsType.ToFreightEnum(); }
        }

        public bool GetByKey(int pExpnsCode)
        {
            this.ExpnsCode = pExpnsCode;
            return base.GetByKey();
        }

        public List<AdditionalExpense> GetAll()
        {
            return FillCollection<AdditionalExpense>(this.GetData().Rows);
        }

    }
}
