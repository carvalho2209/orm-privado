using System;
using System.Collections.Generic;
using System.Data;

namespace Nampula.DI.B1.Administrations
{
    public class CurrencyRate : TableAdapter
    {
        

        
        /// <summary>
        /// Nome da tabela do banco de dados.
        /// </summary>
        public struct Definition
        {
            public static readonly string TableName = "ORTT";
        }
        

        
        /// <summary>
        /// Objeto com o nome de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsName
        {
            public static readonly string RateDate = "RateDate";
            public static readonly string Currency = "Currency";
            public static readonly string Rate = "Rate";
        }
        

        
        /// <summary>
        /// Objeto com a descrição de cada coluna do banco de dados.
        /// </summary>
        public struct FieldsDescription
        {
            public static readonly string RateDate = "Date";
            public static readonly string Currency = "Moeda";
            public static readonly string Rate = "Taxa";
        }
        

        

        TableAdapterField m_RateDate = new TableAdapterField(FieldsName.RateDate, FieldsDescription.RateDate, DbType.DateTime, 11, 0, true, false);
        TableAdapterField m_Currency = new TableAdapterField(FieldsName.Currency, FieldsDescription.Currency, DbType.String, 3, 0, true, false);
        TableAdapterField m_Rate = new TableAdapterField(FieldsName.Rate, FieldsDescription.Rate, DbType.Decimal);

        

        

        

        public CurrencyRate()
            : base(Definition.TableName)
        {
        }

        public CurrencyRate(CurrencyRate pCurrencyRate)
            : this()
        {
            this.CopyBy(pCurrencyRate);
        }

        

        

        public DateTime RateDate
        {
            get { return m_RateDate.GetDateTime(); }
            set { m_RateDate.Value = value; }
        }
        public string Currency
        {
            get { return m_Currency.GetString(); }
            set { m_Currency.Value = value; }
        }

        public Decimal Rate
        {
            get { return m_Rate.GetDecimal(); }
            set { m_Rate.Value = value; }
        }
        public override void Add() { }

        public override void Update() { }

        public override void Remove() { }
        
        /// <summary>
        /// Consulta o registro pelo código.
        /// </summary>
        /// <param name="pRateDate">Data.</param>
        /// <param name="pCurrency">Moeda.</param>
        /// <returns>Verdadeiro, se retornou o ok, caso contrário, falso.</returns>
        public bool GetByKey(DateTime pRateDate, string pCurrency)
        {
            this.RateDate = pRateDate;
            this.Currency = pCurrency;
            return GetByKey();
        }
        

        
        /// <summary>
        /// Retorna todos os registros da tabela.
        /// </summary>
        /// <returns>Uma lista de CurrencyRate.</returns>
        public List<CurrencyRate> GetAll()
        {
            return FillCollection<CurrencyRate>(this.GetData().Rows);
        }
        

        
    }
}
