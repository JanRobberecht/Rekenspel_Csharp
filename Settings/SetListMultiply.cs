using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Views;

namespace Calculation2.Settings
{
    class SetListMultiply
    {
        public static List<int> ListMultiply = new List<int>();
        public static void FirstText()
        {
            ViewPrints.PrintText($"Welke maaltafels wil je oefenen?  Als je klaar bent, typ je 'ok'\n", ConsoleColor.Yellow);
            GetListMultiplyAdd();
        }

        public static  void FirstTextAdd()
        {
            ViewPrints.PrintText($"Welke maaltafels wil je toevoegen?  Als je klaar bent, typ je 'ok'\n", ConsoleColor.Yellow);
            GetListMultiplyAdd();
        }

        public static void FirstTextRemove()
        {
            ViewPrints.PrintText($"Welke maaltafels wil je wegdoen?  Als je klaar bent, typ je 'ok'\n", ConsoleColor.Yellow);
            GetListMultiplyRemove();
        }

        public static void GetListMultiplyAdd()
        {
            Console.CursorVisible = true;
            string b = Console.ReadLine();
            CheckNumeric.TestNumber(b);

            if (CheckNumeric.Numeric)
            {
                if (!ListMultiply.Contains(CheckNumeric.TestedNumber))
                {
                    ListMultiply.Add(CheckNumeric.TestedNumber);
                }

                GetListMultiplyAdd();
            }
            else if (b == "ok")
            {
               
                Console.WriteLine();
               
            }
            else
            {
                ViewPrints.PrintText($"\nOeps, dit is niet juist. Geef opnieuw een getal of 'ok' in.\n", ConsoleColor.DarkRed);
                GetListMultiplyAdd();
            }

        }

        public static void GetListMultiplyRemove()
        {
            Console.CursorVisible = true;
            string b = Console.ReadLine();
            CheckNumeric.TestNumber(b);

            if (CheckNumeric.Numeric)
            {
                if (ListMultiply.Contains(CheckNumeric.TestedNumber))
                {
                    ListMultiply.Remove(CheckNumeric.TestedNumber);
                }

                GetListMultiplyRemove();
            }
            else if (b == "ok")
            {

                Console.WriteLine();
               
            }
            else
            {
                ViewPrints.PrintText($"\nOeps, dit is niet juist. Geef opnieuw een getal of 'ok' in.\n", ConsoleColor.DarkRed);
                GetListMultiplyRemove();
            }

        }
    }
}
