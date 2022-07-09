using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Views;

namespace Calculation2.Settings
{
    class SetPlayer
    {
        public static string Name { get; set; }

        public static void FirstText()
        {
            ViewPrints.PrintText($"Wat is je naam?\n", ConsoleColor.Yellow);
            GetName();
        }

        public static void CorrectedText()
        {
            ViewPrints.PrintText($"Wat is je naam?\n", ConsoleColor.Yellow);
            GetName();
        }

        public static void GetName()
        {
            Name = Console.ReadLine();
        }
    }
}
