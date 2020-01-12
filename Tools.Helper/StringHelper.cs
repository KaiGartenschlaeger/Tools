using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Tools.Helper
{
    /// <summary>
    /// Stellt Hilfsmethoden für Zeichenketten-Operationen bereit.
    /// </summary>
    public static class StringHelper
    {
        private static CultureInfo Culture = new CultureInfo("en-GB");

        /// <summary>
        /// Zerlegt eine Zeichenkette anhand eines Trennzeichens.
        /// </summary>
        /// <param name="value">Zeichenkette die zerlegt werden soll.</param>
        /// <param name="separator">Trennzeichen anhand dessen die Zeichenkette zerlegt wird.</param>
        /// <param name="trim">Falls gesetzt, werden alle Leerzeichen am Anfang und am Ende von jeden Wert entfernt.</param>
        /// <param name="removeEmptyElements">Falls gesetzt, werden Werte die nur aus Leerzeichen bestehen oder leer sind entfernt.</param>
        public static string[] SplitString(string value, char separator, bool trim, bool removeEmptyElements)
        {
            string[] result;

            if (string.IsNullOrEmpty(value))
            {
                result = new string[0];
            }
            else
            {
                string[] values = value.Split(separator);

                if (trim)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                    }
                }

                if (removeEmptyElements)
                {
                    List<string> list = new List<string>(values.Length);
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(values[i]))
                        {
                            list.Add(values[i]);
                        }
                    }

                    result = list.ToArray();
                }
                else
                {
                    result = values;
                }
            }

            return result;
        }

        /// <summary>
        /// Versucht einen Wert zu parsen.
        /// </summary>
        /// <typeparam name="T">Typ des Wertes der geparsed werden soll.</typeparam>
        /// <param name="value">Wert der geparsed werden soll.</param>
        /// <param name="fallbackValue">Ein alternativer Wert, der zurückgegeben wird, falls das parsen fehlschlägt.</param>
        public static T Parse<T>(string value, T fallbackValue)
        {
            T result;

            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    result = (T)converter.ConvertFromString(value);
                }
                catch (Exception)
                {
                    result = fallbackValue;
                }
            }
            else
            {
                result = fallbackValue;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Boolean.
        /// </summary>
        public static bool ParseBool(object value, bool failoverValue)
        {
            bool result;
            if (!bool.TryParse(value.ToString(), out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static bool? ParseBool(object value)
        {
            bool result;
            if (!bool.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu ein Byte.
        /// </summary>
        public static byte ParseByte(object value, byte failoverValue)
        {
            byte result;
            if (!byte.TryParse(value.ToString(), NumberStyles.Number, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static byte? ParseByte(object value)
        {
            byte result;
            if (!byte.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Short.
        /// </summary>
        public static short ParseShort(object value, short failoverValue)
        {
            short result;
            if (!short.TryParse(value.ToString(), NumberStyles.Number, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static short? ParseShort(object value)
        {
            short result;
            if (!short.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Integer.
        /// </summary>
        public static int ParseInt(object value, int failoverValue)
        {
            int result;
            if (!int.TryParse(value.ToString(), NumberStyles.Number, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static int? ParseInt(object value)
        {
            int result;
            if (!int.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Long.
        /// </summary>
        public static long ParseLong(object value, long failoverValue)
        {
            long result;
            if (!long.TryParse(value.ToString(), NumberStyles.Number, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static long? ParseLong(object value)
        {
            long result;
            if (!long.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Float.
        /// </summary>
        public static float ParseFloat(object value, float failoverValue)
        {
            float result;
            if (!float.TryParse(value.ToString(), NumberStyles.Float, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static float? ParseFloat(object value)
        {
            float result;
            if (!float.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Double.
        /// </summary>
        public static double ParseDouble(object value, double failoverValue)
        {
            double result;
            if (!double.TryParse(value.ToString(), NumberStyles.Float, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static double? ParseDouble(object value)
        {
            double result;
            if (!double.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert eine Zeichenkette zu einen Decimal.
        /// </summary>
        public static decimal ParseDecimal(object value, decimal failoverValue)
        {
            decimal result;
            if (!decimal.TryParse(value.ToString(), NumberStyles.Float, Culture, out result))
            {
                result = failoverValue;
            }

            return result;
        }

        public static decimal? ParseDecimal(object value)
        {
            decimal result;
            if (!decimal.TryParse(value.ToString(), out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Boolean konvertiert werden kann.
        /// </summary>
        public static bool IsBool(string value)
        {
            bool tmp;
            return bool.TryParse(value, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Byte konvertiert werden kann.
        /// </summary>
        public static bool IsByte(string value)
        {
            byte tmp;
            return byte.TryParse(value, NumberStyles.Number, Culture, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Short konvertiert werden kann.
        /// </summary>
        public static bool IsShort(string value)
        {
            short tmp;
            return short.TryParse(value, NumberStyles.Number, Culture, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Integer konvertiert werden kann.
        /// </summary>
        public static bool IsInt(string value)
        {
            int tmp;
            return int.TryParse(value, NumberStyles.Number, Culture, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Long konvertiert werden kann.
        /// </summary>
        public static bool IsLong(string value)
        {
            long tmp;
            return long.TryParse(value, NumberStyles.Number, Culture, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Float konvertiert werden kann.
        /// </summary>
        public static bool IsFloat(string value)
        {
            float tmp;
            return float.TryParse(value, NumberStyles.Float, Culture, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Double konvertiert werden kann.
        /// </summary>
        public static bool IsDouble(string value)
        {
            double tmp;
            return double.TryParse(value, NumberStyles.Float, Culture, out tmp);
        }

        /// <summary>
        /// Überprüft ob der Wert zu einen Decimal konvertiert werden kann.
        /// </summary>
        public static bool IsDecimal(string value)
        {
            decimal tmp;
            return decimal.TryParse(value, NumberStyles.Float, Culture, out tmp);
        }

        /// <summary>
        /// Liefert den Wert in fallbackValue falls value null ist.
        /// </summary>
        public static string IfNull(string value, string fallbackValue)
        {
            if (value == null)
            {
                return fallbackValue;
            }

            return value;
        }

        /// <summary>
        /// Liefert den Wert in fallbackValue falls value keine Zeichen enthält.
        /// </summary>
        public static string IfEmpty(string value, string fallbackValue)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return fallbackValue;
            }

            return value;
        }
    }
}