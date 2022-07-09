using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Views;

namespace Calculation2.Settings
{
    class SetTimeLimit
    {
        public static int TimeLimit { get; set; } = 3;


        public static void FirstText()
        {
           
            ViewPrints.PrintText($"Geef het hoogste aantal seconden waarbinnen je de oplossingen moet vinden?\n", ConsoleColor.Yellow);
            GetTimeLimit();

          
        }

        public static void GetTimeLimit()
        {
            CheckNumeric.TestNumber(Console.ReadLine());


            if (CheckNumeric.Numeric)
            {
                TimeLimit = CheckNumeric.TestedNumber;
            }
            else
            {
                ViewPrints.PrintText($"\nOeps, dit is niet juist. Geef opnieuw een getal in.\n", ConsoleColor.DarkRed);
                GetTimeLimit();
            }
        }
    }
}

