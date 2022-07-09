using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Views;

namespace Calculation2.Settings
{
    class SetMaximumNumber
    {
        public static int MaximumNumber { get; set; }


        public static void FirstText()
        {
            int calculationType = SetCalculationType.CalculationType;

            if (calculationType <= 3)
            {
                ViewPrints.PrintText($"Geef het grootste getal waar je mee wil optellen en/of aftrekken?\n", ConsoleColor.Yellow);
                GetMaximumNumber();

            }
            else
            {
                ViewPrints.PrintText($"Geef het grootste getal waar je de maaltafels mee wil vermenigvuldigen en/of delen?\n", ConsoleColor.Yellow);
                GetMaximumNumber();
            }
        }

        public static void GetMaximumNumber()
        {
            CheckNumeric.TestNumber(Console.ReadLine());


            if (CheckNumeric.Numeric)
            {
                MaximumNumber = CheckNumeric.TestedNumber;
            }
            else
            { 
                ViewPrints.PrintText($"\nOeps, dit is niet juist. Geef opnieuw een getal in.\n", ConsoleColor.DarkRed);
                GetMaximumNumber();
            }
        }
    }
}
