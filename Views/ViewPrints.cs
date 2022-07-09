using System;
using System.Collections.Generic;
using System.Text;

namespace Calculation2.Views
{
    class ViewPrints
    {

        public static void PrintText(string a, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(a);
            Console.ResetColor();
        }

        public static void PrintTextInLine(string a, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(a);
            Console.ResetColor();
        }
    }
}
