using System;
using Nampula.DI.B1.Documents;
using Nampula.Framework;

namespace Nampula.DI.B1.Version
{
    public class SboVersion
    {

        public const string Sap88Pl4 = "882066";
        public const string Sap9Pl09 = "902000";
        public const string Sap9Pl4 = "900056";
        public const string Sap91Pl04 = "910140";
        public static string LastVersionConsulted = "0";

        public static bool EqualOrMoreThenSap91Pl04()
        {
            return EqualOrMoreThenVersion(Sap91Pl04);
        }

        public static bool EqualOrMoreThenSap882Pl4()
        {
            return EqualOrMoreThenVersion(Sap88Pl4);
        }

        public static bool EqualOrMoreThenSap9Pl4()
        {
            return EqualOrMoreThenVersion(Sap9Pl4);
        }

        public static bool EqualOrMoreThenSap9P07()
        {
            return EqualOrMoreThenVersion(Sap9Pl09);
        }

        public static bool WasCreatedInSap9(string companyDb, eDocumentObjectType documentObjectType, int docEntry)
        {
            var query = string.Format(
                @"Select 
	                1
                From
	                {0} T0 
                Where 
	                Replace(T0.VersionNum,'.','')  >= '{1}%' And T0.DocEntry = {2}",
                documentObjectType.GetTableNameMaster(companyDb), Sap9Pl4, docEntry);

            return Connection.Instance.SqlExecuteScalar<int>(query) > 0;
        }

        public static bool EqualOrMoreThenVersion(string sapVersion)
        {
            if (LastVersionConsulted != "0")
                return LastVersionConsulted.To<int>() >= sapVersion.To<int>();

            var query = string.Format(
                "Select COUNT(1) From [SBO-COMMON]..[SINF] T0 With (NOLOCK) Where Version >= '{0}'", 
                sapVersion);

            var isMoreThan = Connection.Instance.SqlExecuteScalar<int>(query) > 0;

            if (isMoreThan && (LastVersionConsulted.To<int>() >= sapVersion.To<int>()))
            {
                LastVersionConsulted = sapVersion;
            }

            return isMoreThan;
        }

        public static bool IsMultFilialEnabled(string companyDb)
        {
            if (!EqualOrMoreThenSap882Pl4())
                return false;

            var query = string.Format(
                "Select Count(CompnyName) From [{0}]..[OADM] Where IsNull(MltpBrnchs,'N') = 'Y'", companyDb);

            return Connection.Instance.SqlExecuteScalar<int>(query) > 0;
        }



        public static bool EqualOrMoreThenSap882PL4()
        {
            const string query = "Select COUNT(*) From [SBO-COMMON]..[SINF] Where Version >= '882066'";
            return Connection.Instance.SqlExecuteScalar<int>(query) > 0;
        }

        public static bool IsSap882()
        {
            const string query = "Select Count(*) From [SBO-COMMON]..[SINF] Where Version >= '882066' and Version <= '900000' ";
            return Connection.Instance.SqlExecuteScalar<int>(query) > 0;
        }
    }
}
