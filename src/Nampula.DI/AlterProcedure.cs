using System;
using System.Text;
using System.Data;
using Nampula.Framework;


namespace Nampula.DI
{

    /// <summary>
    /// Classe para tratamento de alterações de StoredProcedures do SAP
    /// </summary>
    public class AlterProcedure
    {
        
        /// <summary>
        /// Nome das Procedures do SAP
        /// </summary>
        public struct SpNames
        {
            /// <summary>
            /// Procedure TransactionNotification
            /// </summary>
            public static readonly string TransNotification = "SBO_SP_TransactionNotification";
            /// <summary>
            /// Procedure PostTransactionNotification
            /// </summary>
            public static readonly string TransNotice = "SBO_SP_PostTransactionNotice";
        }
        
        /// <summary>
        /// Altera a store procedure
        /// </summary>
        /// <param name="pSpName">Nome da Store Procedure</param>
        /// <param name="pCompanyDb">Nome do Banco de dados da empresa</param>
        /// <param name="pStart">Texto de Inicio do Trecho do código</param>
        /// <param name="pEnd">Texto do fim do trecho do código</param>
        /// <param name="pText">Código da código a se adicionado a SP</param>
        public void UpdateProc(string pSpName, string pCompanyDb, string pStart, string pEnd, StringBuilder pText)
        {
            //Verifica se o texto existe na sp
            var sp = GetSpText(pSpName, pCompanyDb).ToString();

            if (sp.Contains(pStart))
            {
                var start = sp.IndexOf(pStart, System.StringComparison.Ordinal);
                var end = sp.IndexOf(pEnd, System.StringComparison.Ordinal);
                sp = sp.Remove(start, end - start + (pEnd.Length));
            }

            var endsp = sp.IndexOf("-- Select the return values", System.StringComparison.Ordinal);

            if (endsp < 0)
                throw new Exception("Não encontrado o fim da procedure.");

            pText = pText.Insert(0, string.Format("\n{0}\n", pStart)).Append(pEnd);

            sp = sp.Insert(endsp - 1, pText.ToString());

            Exec(sp, pCompanyDb);
        }
        

        
        /// <summary>
        /// Remove o trecho do código da procedure
        /// </summary>
        /// <param name="pSpName">Nome da Store Procedure</param>
        /// <param name="pCompanyDb">Nome do Banco de dados da empresa</param>
        /// <param name="pStart">Texto de Inicio do Trecho do código</param>
        /// <param name="pEnd">Texto do fim do trecho do código</param>
        public void RemoveCodeProc(string pSpName, string pCompanyDb, string pStart, string pEnd)
        {
            var sp = GetSpText(pSpName, pCompanyDb).ToString();

            if (sp.Contains(pStart))
            {
                var start = sp.IndexOf(pStart, System.StringComparison.Ordinal);
                var end = sp.IndexOf(pEnd, System.StringComparison.Ordinal);
                sp = sp.Remove(start, end - start + (pEnd.Length));
            }

            Exec(sp, pCompanyDb);
        }
        

        
        /// <summary>
        /// Verifica se o código existe na SP
        /// </summary>
        /// <param name="pSpName">Nome da Procedure</param>
        /// <param name="pCompanyDb">Nome do Banco de dados da empresa</param>
        /// <param name="pStart">O Texto de inicio do trecho</param>
        public bool Exists(string pSpName, string pCompanyDb, string pStart)
        {
            var sp = GetSpText(pSpName, pCompanyDb).ToString();
            return sp.Contains(pStart);
        }
        

        
        /// <summary>
        /// Executa a atualização do código da SP
        /// </summary>
        /// <param name="pText">Procedire</param>
        /// <param name="pCompanyDb">Nome do Banco de dados da empresa</param>
        private static void Exec(string pText, string pCompanyDb)
        {
            pCompanyDb.CheckForArgumentNull("pCompanyDb");

            var conn = Connection.Instance;
            var pCurrentDb = conn.ConnectionParameter.Database;

            try
            {
                using (var trans = TransManager.GetTrans())                
                {
                    conn.ConnectionParameter.Database = pCompanyDb;

                    pText = pText.Replace("CREATE proc", "ALTER proc");

                    conn.SqlServerExecute(pText);

                    trans.Complete();
                }
            }
            finally
            {
                conn.ConnectionParameter.Database = pCurrentDb;
            }
        }


        /// <summary>
        /// Pega o código da procedure
        /// </summary>
        /// <param name="procedureName">Nome da Procedure</param>
        /// <param name="pCompanyDb">Nome da Empresa</param>
        /// <returns>Um SP com o texto da procedure</returns>
        private static StringBuilder GetSpText(string procedureName, string pCompanyDb)
        {
            var sp = new StringBuilder();
            var sphelp = new sp_HelpText
            {
                ObjName = procedureName,
                DbName = pCompanyDb
            };

            if (!sphelp.Execute()) 
                return sp;

            foreach (DataRow item in sphelp.Result.Rows)
                sp.Append(item[sp_HelpText.FieldsNameResult.Text]);

            return sp;
        }
        

    }

}
