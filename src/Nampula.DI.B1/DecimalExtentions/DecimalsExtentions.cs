using System;
using System.Collections.Generic;
using Nampula.DI.B1.Administrations;

namespace Nampula.DI.B1.DecimalExtentions
{
    public static class DecimalsExtentions
    {
        public static decimal RoundSum(this decimal sumValue, string companyDb = null)
        {
            var sumDecimals = GetDecimalsForSum(companyDb);
            return Math.Round(sumValue, sumDecimals);
        }

        public static decimal RoundPrice(this decimal price, string companyDb = null)
        {
            var priceDecimals = GetDecimalsForPrice(companyDb);
            return Math.Round(price, priceDecimals);
        }

        public static decimal RoundRate(this decimal rate, string companyDb = null)
        {
            var rateDec = GetDecimalsForRate(companyDb);
            return Math.Round(rate, rateDec);
        }

        public static decimal RoundQuantity(this decimal quantity, string companyDb = null)
        {
            var quantityDec = GetDecimalsForQuantity(companyDb);
            return Math.Round(quantity, quantityDec);
        }

        public static decimal RoundPercent(this decimal percent, string companyDb = null)
        {
            var percentDec = GetDecimalsForPercent(companyDb);
            return Math.Round(percent, percentDec);
        }

        public static decimal RoundMeasure(this decimal measuredValue, string companyDb = null)
        {
            var measuredDec = GetDecimalsForMeasure(companyDb);
            return Math.Round(measuredValue, measuredDec);
        }

        public static decimal RoundQuery(this decimal queryValue, string companyDb = null)
        {
            var queryDec = GetDecimalsForQuery(companyDb);
            return Math.Round(queryValue, queryDec);
        }

        public static short GetDecimalsForSum(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.SumDec;
        }

        public static short GetDecimalsForPrice(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.PriceDec;
        }

        public static short GetDecimalsForRate(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.RateDec;
        }

        public static short GetDecimalsForQuantity(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.QtyDec;
        }

        public static short GetDecimalsForPercent(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.PercentDec;
        }

        public static short GetDecimalsForMeasure(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.MeasureDec;
        }

        public static short GetDecimalsForQuery(string companyDb = null)
        {
            var administraction = GetAddministration(companyDb);
            return administraction.QueryDec;
        }

        private static readonly Dictionary<string, Administration> Administrations = new Dictionary<string, Administration>();
        private static Administration GetAddministration(string companyDb)
        {
            if (companyDb == null)
                companyDb = Connection.Instance.ConnectionParameter.CompanyDb;

            if (!Administrations.ContainsKey(companyDb))
            {
                var adm = new Administration(companyDb);
                adm.GetByKey();
                Administrations.Add(companyDb, adm);
            }

            return Administrations[companyDb];
        }
    }
}
