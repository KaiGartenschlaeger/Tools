using System;
using System.Security.Cryptography;
using System.Text;
using Tools.Helper.Hashing;

namespace Tools.Helper
{
    /// <summary>
    /// Stellt Methoden zum erstellen von Hashwerten zur Verfügung.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Erstellt einen MD5-Hash.
        /// </summary>
        public static string ToMD5(string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            return HashHelper.ToMD5(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Erstellt einen MD5-Hash.
        /// </summary>
        public static string ToMD5(byte[] data)
        {
            if (data == null)
            {
                data = new byte[0];
            }

            byte[] computedBytes = MD5.Create().ComputeHash(data);

            return BitConverter.ToString(computedBytes).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Erstellt einen SHA1-Hash.
        /// </summary>
        public static string ToSHA1(string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            return HashHelper.ToSHA1(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Erstellt einen SHA1-Hash.
        /// </summary>
        public static string ToSHA1(byte[] data)
        {
            if (data == null)
            {
                data = new byte[0];
            }

            byte[] computedBytes = SHA1.Create().ComputeHash(data);

            return BitConverter.ToString(computedBytes).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Erstellt einen CRC32-Hash.
        /// </summary>
        public static string ToCRC32(string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            return HashHelper.ToCRC32(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Erstellt einen CRC32-Hash.
        /// </summary>
        public static string ToCRC32(byte[] data)
        {
            if (data == null)
            {
                data = new byte[0];
            }

            Crc32 crc32 = new Crc32();

            byte[] computedHash = crc32.ComputeHash(data);

            Array.Reverse(computedHash);

            return BitConverter.ToUInt32(computedHash, 0).ToString("X8").ToLower();
        }
    }
}