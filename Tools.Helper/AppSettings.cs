using System.Configuration;

namespace Tools.Helper
{
    /// <summary>
    /// Stellt einfachen Zugriff auf die AppSettings der Konfigurations-Datei zur Verfügung.
    /// </summary>
    public static class AppSettings
    {
        #region Methods

        /// <summary>
        /// Überprüft ob der angegebene Wert vorhanden ist.
        /// Dabei wird zusätzlich überprüft, ob auch ein Wert eingetragen wurde.
        /// </summary>
        /// <param name="key">Name des zu überprüfenden Wertes.</param>
        public static bool HasKey(string key)
        {
            return !string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]);
        }

        /// <summary>
        /// Liest einen Byte-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static byte ReadByte(string key, byte fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            byte result;
            if (!byte.TryParse(value, out result))
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Liest einen Bool-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static bool ReadBool(string key, bool fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            bool result;
            if (!bool.TryParse(value, out result))
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Liest eine Int-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static int ReadInt(string key, int fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            int result;
            if (!int.TryParse(value, out result))
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Liest eine Long-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static long ReadLong(string key, long fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            long result;
            if (!long.TryParse(value, out result))
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Liest eine Double-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static double ReadDouble(string key, double fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            double result;
            if (!double.TryParse(value, out result))
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Liest eine Float-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static float ReadFloat(string key, float fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            float result;
            if (!float.TryParse(value, out result))
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Liest eine String-Wert aus.
        /// Falls der Wer nicht konvertiert werden kann, oder nicht vorhanden ist, wird der Alternative-Wert zurückgeliefert.
        /// </summary>
        /// <param name="key">Schlüssel des auszulesenden Wertes.</param>
        /// <param name="fallbackValue">Alternativer Wert der zurückgegeben wird, falls der Wert nicht gefunden oder gelesen werden konnte.</param>
        public static string ReadString(string key, string fallbackValue)
        {
            string value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(value))
            {
                value = fallbackValue;
            }

            return value;
        }

        #endregion
    }
}