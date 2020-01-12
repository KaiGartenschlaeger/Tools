using System;
using System.Text;

namespace Tools.Helper
{
    /// <summary>
    /// Liefert Hilfsmethoden zum encodieren und dekodieren von Zeichenketten.
    /// </summary>
    public class EncodingHelper
    {
        /// <summary>
        /// Kodiert eine Zeichenfolge zu Base64.
        /// </summary>
        public static string EncodeBase64(byte[] data, string fallbackValue)
        {
            string result;

            try
            {
                result = Convert.ToBase64String(data);
            }
            catch (Exception)
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Kodiert eine Byte-Array zu eine Base64 Zeichenfolge.
        /// </summary>
        public static string EncodeBase64(string value, string fallbackValue)
        {
            string result;

            try
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                byte[] data = Encoding.UTF8.GetBytes(value);

                return EncodeBase64(data, fallbackValue);
            }
            catch (Exception)
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Dekodiert eine Base64 kodierte Zeichenfolge.
        /// </summary>
        public static string DecodeBase64(byte[] data, string fallbackValue)
        {
            string result;

            try
            {
                result = Encoding.UTF8.GetString(data);
            }
            catch (Exception)
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Dekodiert ein Base64 kodiertes Byte-Array.
        /// </summary>
        public static string DecodeBase64(string value, string fallbackValue)
        {
            string result;

            try
            {
                if (value == null)
                {
                    value = string.Empty;
                }

                byte[] encodedBytes = Convert.FromBase64String(value);

                result = DecodeBase64(encodedBytes, fallbackValue);
            }
            catch (Exception)
            {
                result = fallbackValue;
            }

            return result;
        }

    }
}