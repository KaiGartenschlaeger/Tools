using System;
using Tools.Helper;
using Tools.Helper.SC;

namespace SimpleConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleConsole console = new SimpleConsole();
            
            // table
            console.BeginTable();
            
            console.ColumnWidth(0, 12);
            console.ColumnColor(0, ConsoleColor.Green);
            console.ColumnAlignment(0, TextAlignment.Center);

            console.ColumnWidth(1, 12);
            console.ColumnColor(1, ConsoleColor.Yellow);
            console.ColumnAlignment(1, TextAlignment.Center);

            console.ColumnWidth(2, 30);
            console.ColumnColor(2, ConsoleColor.White);

            console.Write("Kapitel").Write("Seite").Write("Titel");

            console.EndLine().EndLine();

            console.Write("1").Write("25").WriteLine("Aller Anfang ist schwer");
            console.Write("2").Write("42").WriteLine("Variablen");

            console.EndTable();
            
            // satz
            console.EndLine();

            console.
                Color(ConsoleColor.Red).Write("Hallo ").
                Color(ConsoleColor.Yellow).Write("du ").
                Color(ConsoleColor.Blue).Write("da!");
            
            // read
            console.ReadChar();
        }
    }
}