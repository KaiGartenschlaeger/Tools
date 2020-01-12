using System;

namespace Tools.Helper.SC
{
    internal struct ColumnFormat
    {
        public void Reset()
        {
            Width = 0;

            Alignment = TextAlignment.Left;

            Color = ConsoleColor.Gray;
            Background = ConsoleColor.Black;
        }

        public int Width { get; set; }

        public TextAlignment Alignment { get; set; }
        
        public ConsoleColor Color { get; set; }
        public ConsoleColor Background { get; set; }
    }
}