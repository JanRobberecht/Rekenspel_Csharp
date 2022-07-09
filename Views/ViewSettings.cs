using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Settings;

namespace Calculation2.Views
{
    class ViewSettings
    {



        public static string CalculationTypeName { get; set; }

        public static string ListMultiplyToString { get; set; }


        public static void GetCalculationTypeName()
        {

            switch (SetCalculationType.CalculationType)
            {
                case 1:
                    CalculationTypeName = "Optellen";
                    break;
                case 2:
                    CalculationTypeName = "Aftrekken";
                    break;
                case 3:
                    CalculationTypeName = "Optellen en aftrekken";
                    break;
                case 4:
                    CalculationTypeName = "Vermenigvuldigen";
                    break;
                case 5:
                    CalculationTypeName = "Delen";
                    break;
                case 6:
                    CalculationTypeName = "Vermenigvuldigen en delen";
                    break;
            }
        }

        public static void GetListMultiplyToString()
        {
            if (SetListMultiply.ListMultiply != null)
            {
                ListMultiplyToString = string.Join(", ", SetListMultiply.ListMultiply);
            }
        }

        public static void PrintSettings()
        {
            Console.Clear();
            SetListMultiply.ListMultiply.Sort();
            GetCalculationTypeName();
            GetListMultiplyToString();

            ViewPrints.PrintText($"Dit heb jij gekozen:", ConsoleColor.Yellow);
            ViewPrints.PrintText($"-------------------\n\n", ConsoleColor.Yellow);
            ViewPrints.PrintText($"Naam:\t\t\t{SetPlayer.Name}\n", ConsoleColor.Yellow);
            ViewPrints.PrintText($"Oefeningen:\t\t{CalculationTypeName}\n", ConsoleColor.Yellow);
            ViewPrints.PrintText($"Tijdslimiet:\t\t{SetTimeLimit.TimeLimit} seconden\n", ConsoleColor.Yellow);
            ViewPrints.PrintText($"Grootste getal:\t\t{SetMaximumNumber.MaximumNumber}\n", ConsoleColor.Yellow);

            if (SetCalculationType.CalculationType > 3)
            {
                ViewPrints.PrintText($"Maaltafels:\t\t{ListMultiplyToString}\n", ConsoleColor.Yellow);
            }

            

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ChangeSettings();
        }

        public static void ChangeSettings()
        {
            ViewPrints.PrintText($"Wil je iets aanpassen of wil je beginnen oefenen?", ConsoleColor.Yellow);
            ViewPrints.PrintText($"-------------------------------------------------\n", ConsoleColor.Yellow);
            Console.WriteLine();
            ViewPrints.PrintText($"1. Beginnen met oefenen...\n2. Naam veranderen\n3. Oefening veranderen" +
                $"\n4. Tijdslimiet veranderen\n5. Grootste getal veranderen", ConsoleColor.Yellow);

            if (SetCalculationType.CalculationType > 3)
            {
                ViewPrints.PrintText($"6. Maaltafels toevoegen\n7. Maaltafels verwijderen", ConsoleColor.Yellow);
            }

            Console.WriteLine();
            CheckNumeric.TestNumber(Console.ReadLine());
            Console.Clear();

            if (CheckNumeric.Numeric)
            {
                if (SetCalculationType.CalculationType > 3)
                {
                    switch (CheckNumeric.TestedNumber)
                    {
                        case 1:
                            Program.MainGamesStart();
                            Console.WriteLine();
                            break;
                        case 2:
                            SetPlayer.CorrectedText();
                            Console.WriteLine();
                            PrintSettings();
                            break;

                        case 3:
                            SetCalculationType.FirstText();
                            Console.WriteLine();
                            PrintSettings();
                            break;

                        case 4:
                            SetTimeLimit.FirstText();
                            Console.WriteLine();
                            PrintSettings();
                            break;

                        case 5:
                            SetMaximumNumber.FirstText();
                            Console.WriteLine();
                            PrintSettings();
                            break;

                        case 6:
                            SetListMultiply.FirstTextAdd();
                            Console.WriteLine();
                            PrintSettings();
                            break;

                        case 7:
                            SetListMultiply.FirstTextRemove();
                            Console.WriteLine();
                            PrintSettings();
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine();
                            ViewPrints.PrintText($"Er ging iets mis. Geef opnieuw een getal in\n", ConsoleColor.DarkRed);
                            ChangeSettings();
                            Console.WriteLine();
                            Console.WriteLine();
                            break;
                    }
                }
                else
                {
                    switch (CheckNumeric.TestedNumber)
                    {
                        case 1:
                            Program.MainGamesStart();
                            Console.WriteLine();
                            break;
                        case 2:
                            SetPlayer.CorrectedText();
                            Console.WriteLine();
                            PrintSettings();
                            break;

                        case 3:
                            SetCalculationType.FirstText();
                            if (SetCalculationType.CalculationType > 3)
                            {
                                Console.WriteLine();
                                SetListMultiply.FirstText();
                            }
                            PrintSettings();
                            break;

                        case 4:
                            SetTimeLimit.FirstText();
                            PrintSettings();
                            break;

                        case 5:
                            SetMaximumNumber.FirstText();
                            PrintSettings();
                            break;

                        default:
                            Console.WriteLine();
                            Console.WriteLine();
                            ViewPrints.PrintText($"Er ging iets mis. Geef opnieuw een getal in\n", ConsoleColor.DarkRed);
                            ChangeSettings();
                            Console.WriteLine();
                            Console.WriteLine();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                ViewPrints.PrintText($"Er ging iets mis. Geef opnieuw een getal in\n", ConsoleColor.DarkRed);
                ChangeSettings();
            }


        }


    }
}
