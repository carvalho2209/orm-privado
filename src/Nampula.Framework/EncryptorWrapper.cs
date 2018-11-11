using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace Nampula.Framework
{
    
    public class EncryptorWrapper<T> {

        

        private const string _Vector = "init vec";
        private const string _Key = "password";
        private const Encryption.EncryptionAlgorithm _Encryption = Encryption.EncryptionAlgorithm.Des;

        public T GetDecrypt(MemoryStream pObjectEncrpty) {
            try {

                Encryption.Decryptor myDecryp = new Encryption.Decryptor(_Encryption);
                myDecryp.IV = Encoding.ASCII.GetBytes(_Vector);

                MemoryStream myNewMemorySstream = new MemoryStream(myDecryp.Decrypt(pObjectEncrpty.ToArray(), Encoding.ASCII.GetBytes(_Key)));

                XmlSerializer mySerializer = new XmlSerializer(typeof(T));

                return (T)mySerializer.Deserialize(myNewMemorySstream);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public MemoryStream GetEncrpty(T pObjectDescrypt) {
            try {
                
                MemoryStream myWriter = new System.IO.MemoryStream();
                XmlSerializer mySerializer = new XmlSerializer(pObjectDescrypt.GetType());

                mySerializer.Serialize(myWriter, pObjectDescrypt);
                myWriter.Flush();

                Encryption.Encryptor myEncryp = new Encryption.Encryptor(_Encryption);
                myEncryp.IV = Encoding.ASCII.GetBytes(_Vector);

                return new MemoryStream(myEncryp.Encrypt(myWriter.ToArray(), Encoding.ASCII.GetBytes(_Key)));

            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public string EncodeToMD5 ( string pPlanString ) {

            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider ( );
            originalBytes = ASCIIEncoding.Default.GetBytes ( pPlanString );
            encodedBytes = md5.ComputeHash ( originalBytes );

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString ( encodedBytes );
        }

        

    }

}
