using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Nampula.DI;

namespace Nampula.DI.B1.PriceLists
{

    public class PriceList : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string ListNum = "ListNum";                //int
            public static readonly string ListName = "ListName";              //String(32)
            public static readonly string BasePriceList = "BASE_NUM";    //int
            public static readonly string Factor = "Factor";                  //decimal
            public static readonly string GroupCode = "GroupCode";            //int
        }

        public struct Description
        {
            public static readonly string ListNum = "Lista de Preço";                //int
            public static readonly string ListName = "Nome";              //String(32)
            public static readonly string BasePriceList = "Lista de Preço Base";    //int
            public static readonly string Factor = "Fator";                  //decimal
            public static readonly string GroupCode = "Grupo";            //int
        }

        TableAdapterField m_ListNum = new TableAdapterField(FieldsName.ListNum, Description.ListNum, DbType.Int16, 6, null, true, false);
        TableAdapterField m_ListName = new TableAdapterField(FieldsName.ListName, Description.ListName, 32);
        TableAdapterField m_BasePriceList = new TableAdapterField(FieldsName.BasePriceList, Description.BasePriceList, DbType.Int16);
        TableAdapterField m_Factor = new TableAdapterField(FieldsName.Factor, Description.Factor, DbType.Decimal);
        TableAdapterField m_GroupCode = new TableAdapterField(FieldsName.GroupCode, Description.GroupCode, DbType.Int32);

        public PriceList()
            : base("OPLN")
        {
        }

        public PriceList(String pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public PriceList(PriceList pPriceList)
            : this(pPriceList.DBName)
        {

            this.CopyBy(pPriceList);
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }

        public short ListNum
        {
            get { return m_ListNum.GetInt16(); }
            set { m_ListNum.Value = value; }
        }
        public string ListName
        {
            get { return m_ListName.GetString(); }
            set { m_ListName.Value = value; }
        }
        public short BasePriceList
        {
            get { return m_BasePriceList.GetInt16(); }
            set { m_BasePriceList.Value = value; }
        }
        public decimal Factor
        {
            get { return m_Factor.GetDecimal(); }
            set { m_Factor.Value = value; }
        }
        public int GroupCode
        {
            get { return m_GroupCode.GetInt32(); }
            set { m_GroupCode.Value = value; }
        }

        public bool GetByKey(short pListNum)
        {
            this.ListNum = pListNum;
            return this.GetByKey();
        }
    }
}
