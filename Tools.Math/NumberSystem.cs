using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Math
{
    public class NumberSystem
    {
        #region Fields

        private readonly string m_characters;
        private readonly int m_base;

        #endregion

        #region Constructor

        public NumberSystem(string characters)
        {
            m_characters = characters;
            m_base = m_characters.Length;
        }

        #endregion

        #region Helper

        private string RestValueToHexDigit(int value)
        {
            if (value + 1 > m_base)
            {
                throw new OverflowException();
            }

            return m_characters[value].ToString();
        }

        private int[] ToNumberArray(string value)
        {
            int[] result = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                result[value.Length - i - 1] = m_characters.IndexOf(value[i]);
                if (result[i] == -1)
                {
                    throw new ArgumentException(string.Format("Invalid character '{0}' detected at position '{1}'", value[i], i + 1), "value");
                }
            }

            return result;
        }

        #endregion

        #region Methods

        public string ToString(int value)
        {
            Stack<int> rValues = new Stack<int>();
            while (true)
            {
                int q = value / m_base;
                int r = value % m_base;

                rValues.Push(r);

                value = q;
                if (value == 0)
                {
                    break;
                }
            }

            StringBuilder response = new StringBuilder();
            while (rValues.Count > 0)
            {
                int r = rValues.Pop();
                response.Append(RestValueToHexDigit(r));
            }

            return response.ToString();
        }

        public int ToNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            int sum = 0;

            int[] numbers = ToNumberArray(value);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i > 0)
                {
                    sum += (int)System.Math.Pow(m_base, i) * numbers[i];
                }
                else
                {
                    sum += numbers[i];
                }
            }

            return sum;
        }

        #endregion

        #region Properties

        public int Base
        {
            get { return m_base; }
        }

        public string Characters
        {
            get { return m_characters; }
        }

        #endregion
    }
}