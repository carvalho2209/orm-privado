using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using System.IO.Compression;

namespace Nampula.Framework
{

    /// <summary>
    /// Classe estática para tratamento de conversões
    /// </summary>
    public static class ConvertExtentions
    {

        //Conversions
        [Obsolete("Usar o método To<Decimal>()")]
        public static decimal ToDecimal(this Object pObject)
        {

            if (pObject == null)
            {
                return Decimal.Zero;
            }

            if (pObject is string && (String.IsNullOrEmpty(Convert.ToString(pObject))))
            {
                return Decimal.Zero;
            }
            else if (Convert.IsDBNull(pObject))
                return 0;

            else
            {
                return Convert.ToDecimal(pObject);
            }

        }

        [Obsolete("Usar o método To<Int32>()")]
        public static Int32 ToInt32(this Object pObject)
        {
            if (pObject is string && (String.IsNullOrEmpty(Convert.ToString(pObject))))
                return 0;
            else if (Convert.IsDBNull(pObject))
                return 0;
            else
                return Convert.ToInt32(pObject);
        }

        [Obsolete("Usar o método To<Double>()")]
        public static double ToDouble(this object pObject)
        {

            if (pObject is string && (String.IsNullOrEmpty(Convert.ToString(pObject))))
                return 0;

            else if (Convert.IsDBNull(pObject))
                return 0;

            return Convert.ToDouble(pObject);
        }


        [Obsolete("Usar o método To<Boolean>()")]
        public static bool ToBool(this Object pObject)
        {
            return !Convert.IsDBNull(pObject) && Convert.ToBoolean(pObject);
        }

        [Obsolete("Usar o método To<DateTime>()")]
        public static DateTime ToDateTime(this Object pObject)
        {
            return Convert.ToDateTime(pObject);
            //Favot não colocar Today aqui.. pois não é genérico
        }

        //Comparison
        public static bool IsZeroOrNull(this Object pObject)
        {
            //Necessário coersão para o tipo inteiro
            return ((pObject == (Object)0) || (pObject.ToString() == "0.0")) || (pObject == null);
        }

        [Obsolete("Usar o método To<Int64>()")]
        public static long ToInt64(this Object pObject)
        {
            if (pObject == null)
                return 0;

            if (pObject is string && (String.IsNullOrEmpty(Convert.ToString(pObject))))
                return 0;

            return Convert.ToInt64(pObject);
        }




        /// <summary>
        /// Remove os carcteres 
        /// </summary>
        /// <param name="pValue">Valor</param>
        /// <param name="pCharacters">Carcteres a serem substituido</param>
        /// <param name="pNewCharacter">Novo caractere</param>
        /// <returns></returns>
        public static string RemoveCharacter(this string pValue, string pCharacters, string pNewCharacter)
        {
            return pCharacters.ToCharArray().Aggregate(pValue, (current, item) 
                => current.Replace(item.ToString(), pNewCharacter));
        }


        /// <summary>
        /// Remover acentos da strins
        /// </summary>
        /// <param name="pValue">String com Acentos</param>
        /// <returns>Uma string sem accentos</returns>
        public static string NoAccents(this string pValue)
        {
            if (string.IsNullOrEmpty(pValue))
                return pValue;

            var normalizedString = pValue.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            for (var i = 0; i < normalizedString.Length; i++)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);

                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }



        /// <summary>
        /// Converter caracteres de simbols (&) para (&amp) < > " ' para códigos HMTLs
        /// </summary>
        /// <param name="pValue">String com Acentos</param>
        /// <param name="pKeepSpecialCharacters">Bool. Caso seja true retornar o próprio texto, sem alterações.</param>
        /// <returns>Uma string sem accentos</returns>
        public static string ToParserSimbol(this string pValue, bool pKeepSpecialCharacters = false)
        {
            if (string.IsNullOrEmpty(pValue))
                return pValue;

            if (pKeepSpecialCharacters)
                return pValue;

            var dic = new Dictionary<char, string>(){ 
                { '<' , "&alt;" },
                { '>' , "&gt;" },
                { '&' , "&amp;" },
                { '"' , "&quot;" },
                {  "'"[0] , "&#39" }
            };

            foreach (var item in dic)
                pValue = pValue.Replace(item.Key.ToString(), item.Value);

            return pValue;
        }



        /// <summary>
        /// Verifica se uma string é numérica
        /// </summary>
        /// <param name="pStr">String</param>
        /// <returns>True de for numérica, false se não for</returns>
        public static bool IsNumeric(this string pStr)
        {
            const string STR_REGEX = @"^[0-9]*[,][0-9]*$";
            return System.Text.RegularExpressions.Regex.IsMatch(pStr, STR_REGEX);
        }

        /// <summary>
        /// Converte um valor de forma segura
        /// </summary>
        /// <typeparam name="T">Converter para tipo</typeparam>
        /// <param name="value">valor para conversão</param>
        /// <returns></returns>
        public static T To<T>(this object value)
        {
            var conversionType = typeof(T);
            return (T)To(value, conversionType);
        }

        public static object To(this object value, Type conversionType)
        {
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || Convert.IsDBNull(value))
                    return null;

                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else if (conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());

            }

            if ((value is string || value == null || value is DBNull) &&
                (conversionType == typeof(short) ||
                conversionType == typeof(int) ||
                conversionType == typeof(long) ||
                conversionType == typeof(double) ||
                conversionType == typeof(decimal) ||
                conversionType == typeof(float)))
            {
                decimal number;
                if (!decimal.TryParse(value as string, out number))
                    value = "0";
            }

            return Convert.ChangeType(value, conversionType);
        }
        
        /// <summary>
        /// Converte um dataTable para um dicionário
        /// </summary>
        /// <param name="pDataTable">Data Table</param>
        /// <param name="pKey">Nome do Campo de Chave</param>
        /// <param name="pValue">Nome do Campo de Valor</param>
        /// <returns></returns>
        public static Dictionary<object, string> ToDictionary(
            this DataTable pDataTable, string pKey, params string[] pValue)
        {
            var dic = new Dictionary<object, string>();

            foreach (DataRow row in pDataTable.Rows)
            {
                var value = string.Empty;

                foreach (var item in pValue)
                    value = string.Format("{0}{1}{2}", value,
                        string.IsNullOrEmpty(value) ? string.Empty : "-",
                        row.Field<string>(item));

                if (!dic.ContainsKey(row[pKey]))
                    dic.Add(row[pKey], value);
            }

            return dic;
        }






        /// <summary>
        /// Verifica se uma coleção está vazia.
        /// </summary>
        /// <typeparam name="T">O Tipo da coleção.</typeparam>
        /// <param name="source">A coleção.</param>
        /// <returns></returns>
        public static Boolean IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null || source.Count() == 0)
                return true;

            return !source.Any();
        }





        /// <summary>
        /// Salva um objeto com um binário no disco
        /// </summary>
        /// <param name="path">Caminho do Arquivo</param>
        /// <param name="obj">Objeto</param>
        public static void SaveToBinary(this object obj, string path)
        {
            using (Stream textWriter = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(textWriter, obj);
            }
        }



        /// <summary>
        /// Carrega um objeto através do arquivo
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto</typeparam>
        /// <param name="path">Caminho do Arquivo</param>
        /// <returns>Um bjeto preenchido</returns>
        public static T LoadFromBinary<T>(string path) where T : class
        {
            T serializableObject = null;
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                serializableObject = bFormatter.Deserialize(stream) as T;
            }
            return serializableObject;
        }



        /// <summary>
        /// Converte uma string em uma imagem.
        /// </summary>
        /// <param name="base64String">Imagem convertida para base64string.</param>
        /// <returns>Uma imagem.</returns>
        public static Image Base64ToImage(this string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }


        public static byte[] ZipStr(this string str)
        {
            using (var output = new MemoryStream())
            {
                using (var gzip = new DeflateStream(output, CompressionMode.Compress))
                {
                    using (var writer = new StreamWriter(gzip, Encoding.UTF8))
                    {
                        writer.Write(str);
                    }
                }

                return output.ToArray();
            }
        }

        public static string UnZipStr(this byte[] input)
        {
            using (var inputStream = new MemoryStream(input))
            {
                using (var gzip = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(gzip, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        public static string Fmt(this string message, params  object[] parametes)
        {
            return string.Format(message, parametes);
        }

    }

}
