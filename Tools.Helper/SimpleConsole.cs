using System;
using Tools.Helper.SC;

namespace Tools.Helper
{
    /// <summary>
    /// Stellt eine vereinfachte Ausgabe auf der Konsole dar.
    /// </summary>
    public class SimpleConsole
    {
        #region Constructor

        /// <summary>
        /// Stellt eine vereinfachte Ausgabe auf der Konsole dar.
        /// </summary>
        public SimpleConsole()
        {
            m_columns = new ColumnFormat[80];
            for (int i = 0; i < m_columns.Length; i++)
            {
                m_columns[i].Reset();
            }

            ResetInternal(false);
        }

        #endregion

        #region Helper

        private void ResetInternal(bool autoReset)
        {
            // fill
            if (!autoReset || (autoReset && m_fillAutomaticallyReset))
            {
                m_fill = ' ';
                m_fillAutomaticallyReset = true;
            }

            // width
            if (!autoReset || (autoReset && m_widthAutomaticallyReset))
            {
                m_width = 0;
                m_widthAutomaticallyReset = true;
            }

            // alignment
            if (!autoReset || (autoReset && m_alignmentAutomaticallyReset))
            {
                m_alignment = TextAlignment.Left;
                m_alignmentAutomaticallyReset = true;
            }

            // color
            if (!autoReset || (autoReset && m_foregroundAutomaticallyReset))
            {
                m_foreground = ConsoleColor.Gray;
                m_foregroundAutomaticallyReset = true;
            }

            // background
            if (!autoReset || (autoReset && m_backgroundAutomaticallyReset))
            {
                m_background = ConsoleColor.Black;
                m_backgroundAutomaticallyReset = true;
            }
        }

        private void CalculateSpace(int contentLength, int width, TextAlignment alignment, out int left, out int right)
        {
            left = 0;
            right = 0;

            int paddingFull = width - contentLength;
            if (paddingFull > 0)
            {
                switch (alignment)
                {
                    case TextAlignment.Left:
                        right = paddingFull;
                        break;

                    case TextAlignment.Right:
                        left = paddingFull;
                        break;

                    case TextAlignment.Center:
                        left = paddingFull / 2;
                        right = paddingFull - left;
                        break;
                }
            }
        }

        private void WriteChars(char ch, int length)
        {
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write(ch);
                }
            }
        }

        private void WriteInternal(string text, bool lineBreak)
        {
            if (text == null)
            {
                text = string.Empty;
            }

            // colors
            ConsoleColor foreground = m_foreground;
            ConsoleColor background = m_background;

            if (m_tableContext && m_columnIndex < m_columns.Length)
            {
                foreground = m_columns[m_columnIndex].Color;
                background = m_columns[m_columnIndex].Background;
            }

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            // write output text
            int paddingLeft, paddingRight, width;

            width = m_width;
            TextAlignment alignment = m_alignment;

            if (m_tableContext && m_columnIndex < m_columns.Length && m_columns[m_columnIndex].Width > 0)
            {
                width = m_columns[m_columnIndex].Width;
                alignment = m_columns[m_columnIndex].Alignment;
            }

            CalculateSpace(text.Length, width, alignment, out paddingLeft, out paddingRight);

            WriteChars(m_fill, paddingLeft);
            Console.Write(text);
            WriteChars(m_fill, paddingRight);

            // line break
            if (lineBreak)
            {
                EndLine();
            }
            else
            {
                m_columnIndex++;
            }

            // reset
            ResetInternal(true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Setzt alle Einstellungen zurück.
        /// </summary>
        public void Reset()
        {
            ResetInternal(false);
        }

        public SimpleConsole Width(int length)
        {
            return Width(length, true);
        }
        public SimpleConsole Width(int length, bool automaticallyReset)
        {
            if (length >= 0)
            {
                m_width = length;
                m_widthAutomaticallyReset = automaticallyReset;
            }

            return this;
        }

        public SimpleConsole Color(ConsoleColor color)
        {
            return Color(color, true);
        }
        public SimpleConsole Color(ConsoleColor color, bool automaticallyReset)
        {
            m_foreground = color;
            m_foregroundAutomaticallyReset = automaticallyReset;

            return this;
        }

        public SimpleConsole Background(ConsoleColor color)
        {
            return Background(color, true);
        }
        public SimpleConsole Background(ConsoleColor color, bool automaticallyReset)
        {
            m_background = color;
            m_backgroundAutomaticallyReset = automaticallyReset;

            return this;
        }

        public SimpleConsole Left()
        {
            return Left(true);
        }
        public SimpleConsole Left(bool automaticallyReset)
        {
            m_alignment = TextAlignment.Left;
            m_alignmentAutomaticallyReset = automaticallyReset;

            return this;
        }

        public SimpleConsole Center()
        {
            return Center(true);
        }
        public SimpleConsole Center(bool automaticallyReset)
        {
            m_alignment = TextAlignment.Center;
            m_alignmentAutomaticallyReset = automaticallyReset;

            return this;
        }

        public SimpleConsole Right()
        {
            return Right(true);
        }
        public SimpleConsole Right(bool automaticallyReset)
        {
            m_alignment = TextAlignment.Right;
            m_alignmentAutomaticallyReset = automaticallyReset;

            return this;
        }

        public SimpleConsole Fill(char ch)
        {
            return Fill(ch, true);
        }
        public SimpleConsole Fill(char ch, bool automaticallyReset)
        {
            m_fill = ch;
            m_fillAutomaticallyReset = automaticallyReset;

            return this;
        }


        public SimpleConsole ColumnWidth(int column, int length)
        {
            if (length >= 0 && column < m_columns.Length)
            {
                m_columns[column].Width = length;
            }

            return this;
        }

        public SimpleConsole ColumnColor(int column, ConsoleColor color)
        {
            if (column < m_columns.Length)
            {
                m_columns[column].Color = color;
            }

            return this;
        }

        public SimpleConsole ColumnBackground(int column, ConsoleColor color)
        {
            if (column < m_columns.Length)
            {
                m_columns[column].Background = color;
            }

            return this;
        }

        public SimpleConsole ColumnAlignment(int column, TextAlignment alignment)
        {
            if (column < m_columns.Length)
            {
                m_columns[column].Alignment = alignment;
            }

            return this;
        }


        public SimpleConsole BeginTable()
        {
            m_tableContext = true;
            return this;
        }

        public SimpleConsole EndTable()
        {
            m_tableContext = false;
            return this;
        }


        public char ReadChar()
        {
            return (char)Console.Read();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public SimpleConsole Write(string text)
        {
            WriteInternal(text, false);
            return this;
        }

        public SimpleConsole WriteLine(string text)
        {
            WriteInternal(text, true);
            return this;
        }

        /// <summary>
        /// Schreibt ein Zeilenumbruch.
        /// </summary>
        public SimpleConsole EndLine()
        {
            m_columnIndex = 0;
            Console.Write(Environment.NewLine);

            return this;
        }

        #endregion

        #region Properties

        private int m_width;
        private bool m_widthAutomaticallyReset;

        private TextAlignment m_alignment;
        private bool m_alignmentAutomaticallyReset;

        private ConsoleColor m_foreground;
        private bool m_foregroundAutomaticallyReset;

        private ConsoleColor m_background;
        private bool m_backgroundAutomaticallyReset;

        private char m_fill;
        private bool m_fillAutomaticallyReset;


        private bool m_tableContext;
        private int m_columnIndex;
        private ColumnFormat[] m_columns;

        #endregion
    }
}