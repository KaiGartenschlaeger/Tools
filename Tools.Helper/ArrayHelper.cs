using System;
using System.Text;

namespace Tools.Helper
{
    public static class ArrayHelper
    {
        private static bool IsSame(byte[] source, byte[] compare, long pos)
        {
            for (int i = 0; i < compare.Length; i++)
            {
                if (source[pos + i] != compare[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static long FindArray(byte[] data, byte[] searchData)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentNullException("data");
            }

            long result = -1;
            for (long i = 0; i < data.LongLength; i++)
            {
                if (IsSame(data, searchData, i))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public static long FindString(byte[] data, string value, Encoding encoding)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            byte[] searchData = encoding.GetBytes(value);
            return FindArray(data, searchData);
        }

        public static long FindInt32(byte[] data, int value)
        {
            byte[] searchData = BitConverter.GetBytes(value);
            return FindArray(data, searchData);
        }

        public static long FindInt64(byte[] data, long value)
        {
            byte[] searchData = BitConverter.GetBytes(value);
            return FindArray(data, searchData);
        }

        public static bool IncrementArray(ref int[] array, int maxValue)
        {
            int placeToIncrement = -1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < maxValue)
                {
                    placeToIncrement = i;
                    break;
                }
            }

            if (placeToIncrement != -1)
            {
                if (placeToIncrement < array.Length - 1)
                {
                    array[placeToIncrement]++;
                    for (int i = placeToIncrement + 1; i < array.Length; i++)
                    {
                        array[i] = 0;
                    }
                    return true;
                }
                else
                {
                    array[placeToIncrement]++;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Berechnet die Quersumme.
        /// </summary>
        public static int Sum(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}
