using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Views;

namespace Calculation2.Settings
{
    class SetCalculationType
    {

        public static int CalculationType { get; set; }

        public static void FirstText()
        {
            ViewPrints.PrintText($"Welke oefeningen wil je doen?\n\n1. Optellen\n2. Aftrekken" +
                 $"\n3. Optellen en aftrekken\n4. Vermenigvuldigen" +
                 $"\n5. Delen\n6. Vermenigvuldigen en delen\n", ConsoleColor.Yellow);
            GetCalculationType();
        }

        public static void GetCalculationType()
        {
            CheckNumeric.TestNumber(Console.ReadLine());



            if (CheckNumeric.Numeric && CheckNumeric.TestedNumber <= 6)
            {
                CalculationType = CheckNumeric.TestedNumber;
            }
            else
            {
                ViewPrints.PrintText($"\nOeps, dit is niet juist. Geef opnieuw een getal van 1 tot 6 in.\n", ConsoleColor.DarkRed);
                GetCalculationType();
            }
        }
    }
}
