using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Nampula.UI.SqlUserLoggin
{
    internal class PasswordEncrypter
    {

        internal string GetDencryptUserPassword(string password, string installationId)
        {
            byte[] _key = Encoding.ASCII.GetBytes(GetInstalationId(installationId));
            byte[] _iv = Encoding.ASCII.GetBytes("Devjoker7.37hAES");

            if (string.IsNullOrEmpty(password))
                return string.Empty;

            var inputBytes = Convert.FromBase64String(password);
            var resultBytes = new byte[inputBytes.Length];            
            
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                var cripto = new RijndaelManaged();

                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(_key, _iv), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        internal string GetEncryptUserPassword(string password, string installationId)
        {
            byte[] _key = Encoding.ASCII.GetBytes(GetInstalationId( installationId));
            byte[] _iv = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
            
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            byte[] inputBytes = Encoding.ASCII.GetBytes(password);                        

            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                var cripto = new RijndaelManaged();

                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(_key, _iv), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();

                    return Convert.ToBase64String(ms.ToArray());                
                }
            }
          
        }

        private string GetInstalationId(string installationId)
        {
            const string AMBIENTE_SEM_LICENCA = "-1";

            if (installationId == AMBIENTE_SEM_LICENCA)
                return installationId.PadLeft(16, '0');

            return installationId;
        }
    }
}
