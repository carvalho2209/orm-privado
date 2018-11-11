using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Nampula.DI.B1.BillOfExchanges
{

    public class BillOfExchange : TableAdapter
    {

        public struct FieldsName
        {
            public static readonly string BoeKey = "BoeKey";
            public static readonly string BoeNum = "BoeNum";
            public static readonly string BoeType = "BoeType";
            public static readonly string BarcodeRep = "BarcodeRep";
            public static readonly string BoeStatus = "BoeStatus";
            public static readonly string BoeSum = "BoeSum";
            public static readonly string CardCode = "CardCode";
            public static readonly string CardName = "CardName";
            public static readonly string DueDate = "DueDate";
            public static readonly string TaxDate = "TaxDate";
            public static readonly string PayMethCod = "PayMethCod";
            public static readonly string OurNum = "OurNum";
            public static readonly string BarcodeNum = "BarcodeNum";
        }

        public struct Descritpion
        {
            public static readonly string BoeKey = "Chave do Boleto";
            public static readonly string BoeNum = "Nº do Boleto";
            public static readonly string BoeType = "Tipo de Transação";
            public static readonly string BarcodeRep = "Linha Digitável";
            public static readonly string BoeStatus = "Status";
            public static readonly string BoeSum = "Total";
            public static readonly string CardCode = "Parceiro";
            public static readonly string CardName = "Nome";
            public static readonly string DueDate = "Data do Vencimento";
            public static readonly string TaxDate = "Data de Lançamento";
            public static readonly string PayMethCod = "Cond. de Pgto";
            public static readonly string OurNum = "Nosso Número";
            public static readonly string BarcodeNum = "Código de Barras";
        }

        public struct Definition
        {
            public static readonly string TableName = "OBOE";
        }

        TableAdapterField m_BoeKey = new TableAdapterField(FieldsName.BoeKey, Descritpion.BoeKey, DbType.Int32, 11, null, true, true);
        TableAdapterField m_BoeNum = new TableAdapterField(FieldsName.BoeNum, Descritpion.BoeNum, DbType.Int32);
        TableAdapterField m_BoeType = new TableAdapterField(FieldsName.BoeType, Descritpion.BoeType, 1);
        TableAdapterField m_BarcodeRep = new TableAdapterField(FieldsName.BarcodeRep, Descritpion.BarcodeRep, 100);
        TableAdapterField m_BoeStatus = new TableAdapterField(FieldsName.BoeStatus, Descritpion.BoeStatus, 1);
        TableAdapterField m_BoeSum = new TableAdapterField(FieldsName.BoeSum, Descritpion.BoeSum, DbType.Decimal);
        TableAdapterField m_CardCode = new TableAdapterField(FieldsName.CardCode, Descritpion.CardCode, 15);
        TableAdapterField m_CardName = new TableAdapterField(FieldsName.CardName, Descritpion.CardName, 200);
        TableAdapterField m_DueDate = new TableAdapterField(FieldsName.DueDate, Descritpion.DueDate, DbType.DateTime);
        TableAdapterField m_TaxDate = new TableAdapterField(FieldsName.TaxDate, Descritpion.TaxDate, DbType.DateTime);
        TableAdapterField m_PayMethCod = new TableAdapterField(FieldsName.PayMethCod, Descritpion.PayMethCod, 20);
        TableAdapterField m_OurNum = new TableAdapterField(FieldsName.OurNum, Descritpion.OurNum, DbType.Int32);
        TableAdapterField m_BarcodeNum = new TableAdapterField(FieldsName.BarcodeNum, Descritpion.BarcodeNum, 100);

        public BillOfExchange()
            : base(Definition.TableName)
        {
        }

        public BillOfExchange(string pCompanyDb)
            : this()
        {
            this.DBName = pCompanyDb;
        }

        public int BoeKey
        {
            get { return m_BoeKey.GetInt32(); }
            set { m_BoeKey.Value = value; }
        }

        public int BoeNum
        {
            get { return m_BoeNum.GetInt32(); }
            set { m_BoeNum.Value = value; }
        }

        public eBoeType BoeType
        {
            get { return m_BoeType.GetString().ToEnum(); }
            set { m_BoeNum.Value = value.ToStringEnum(); }
        }

        public string BarcodeRep
        {
            get { return m_BarcodeRep.GetString(); }
            set { m_BarcodeRep.Value = value; }
        }

        public string BoeStatus
        {
            get { return m_BoeStatus.GetString(); }
            set { m_BoeStatus.Value = value; }
        }

        public decimal BoeSum
        {
            get { return m_BoeSum.GetDecimal(); }
            set { m_BoeSum.Value = value; }
        }

        public string CardCode
        {
            get { return m_CardCode.GetString(); }
            set { m_CardCode.Value = value; }
        }

        public string CardName
        {
            get { return m_CardName.GetString(); }
            set { m_CardName.Value = value; }
        }

        public DateTime DueDate
        {
            get { return m_DueDate.GetDateTime(); }
            set { m_DueDate.Value = value; }
        }

        public DateTime TaxDate
        {
            get { return m_TaxDate.GetDateTime(); }
            set { m_TaxDate.Value = value; }
        }

        public string PayMethCod
        {
            get { return m_PayMethCod.GetString(); }
            set { m_PayMethCod.Value = value; }
        }

        public Int32 OurNum
        {
            get { return m_OurNum.GetInt32(); }
            set { m_OurNum.Value = value; }
        }

        public string BarcodeNum
        {
            get { return m_BarcodeNum.GetString(); }
            set { m_BarcodeNum.Value = value; }
        }

        public bool GetByKey(int pBoeKey)
        {
            this.BoeKey = pBoeKey;
            return base.GetByKey();
        }

        public bool GetByBoeNum(int pBoeNum, eBoeType pBoeType)
        {

            TableQuery myQuery = new TableQuery(this);

            myQuery.Where.Add(new QueryParam(m_BoeNum, pBoeNum));
            myQuery.Where.Add(new QueryParam(m_BoeType, pBoeType.ToStringEnum()));

            DataTable myData = GetData(myQuery);

            if (myData.Rows.Count > 0)
            {
                FillFields(myData.Rows[0]);
                return true;
            }
            else
            {
                return false;
            }

        }


        public String GetUpdateQuery()
        {

            StringBuilder myQuery = new StringBuilder();

            myQuery.AppendLine("exec sp_executesql ");
            myQuery.AppendLine("N' ");

            myQuery.AppendLine("  Update ");
            myQuery.AppendLine("          OBOE ");
            myQuery.AppendLine("  Set ");
            myQuery.AppendLine("          BarcodeRep = @BarcodeRep ");
            myQuery.AppendLine("  Where ");
            myQuery.AppendLine("          BoeNum = @BoeNum ");
            myQuery.AppendLine("      And BoeType = @BoeType ");

            myQuery.AppendLine("',N'");

            myQuery.AppendLine("      @BarcodeRep nvarchar(100) ");
            myQuery.AppendLine("  ,   @BoeNum int");
            myQuery.AppendLine("  ,   @BoeType nvarchar(1)");
            myQuery.AppendLine("', ");

            myQuery.AppendLine("  @BarcodeRep = '" + this.BarcodeRep + "'");
            myQuery.AppendLine(", @BoeNum = " + this.BoeNum);
            myQuery.AppendLine(", @BoeType = '" + this.BoeType.ToStringEnum() + "'");

            return myQuery.ToString();


        }
    }
}
