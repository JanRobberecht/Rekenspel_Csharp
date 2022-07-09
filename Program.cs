using System;
using Calculation2.Settings;
using Calculation2.Games;
using Calculation2.Views;
using System.Collections.Generic;

namespace Calculation2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RekenSpel";

            MainStart();

           


        }

        public static void MainStart()
        {
            Console.Clear();
            MainName();
            Console.WriteLine();
            Console.WriteLine();
            MainCalculationType();
            Console.WriteLine();
            Console.WriteLine();
            MainTimeLimit();
            Console.WriteLine();
            Console.WriteLine();
            MainMaximumNumber();
            Console.WriteLine();
            Console.WriteLine();

            if (SetCalculationType.CalculationType > 3)
            {
                MainListMultiply();
            }


            MainViewSettings();
            Console.ReadKey();
            MainGamesStart();
            Console.ReadKey();
        }

        public static void MainName()
        {
            SetPlayer.FirstText();
        }

        public static void MainCalculationType()
        {
            SetCalculationType.FirstText();
        }

        public static void MainTimeLimit()
        {
            SetTimeLimit.FirstText();
        }

        public static void MainMaximumNumber()
        {
            SetMaximumNumber.FirstText();
        }

        public static void MainListMultiply()
        {
            SetListMultiply.FirstText();
        }

        public static void MainViewSettings()
        {
            ViewSettings.PrintSettings();
        }

        public static void MainGamesStart()
        {
            Console.Clear();
            Game.CountAll = 0;
            Game.CountRight = 0;
            Game.CountWrong = 0;

            ViewPrints.PrintText($"Ter info: de resultaten worden getoond in 3 kleuren\n", ConsoleColor.Yellow);
            ViewPrints.PrintText($"Groen = De uitkomst is juist en is gevonden binnen de {SetTimeLimit.TimeLimit} seconden.", ConsoleColor.Green);
            ViewPrints.PrintText($"Blauw = De uitkomst is juist maar is gevonden boven de {SetTimeLimit.TimeLimit} seconden.", ConsoleColor.Blue);
            ViewPrints.PrintText($"Rood = De uitkomst is niet juist.\n", ConsoleColor.Red);
            ViewPrints.PrintText($"Druk op een toets om verder te gaan.", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();

            Game game1 = new Game(true);
            game1.GameStart();
            Game game2 = new Game(false);
            game2.GameStart();
            Game game3 = new Game(true);
            game3.GameStart();
            Game game4 = new Game(false);
            game4.GameStart();
            Game game5 = new Game(true);
            game5.GameStart();
            Game game6 = new Game(false);
            game6.GameStart();
            Game game7 = new Game(true);
            game7.GameStart();
            Game game8 = new Game(false);
            game8.GameStart();
            Game game9 = new Game(true);
            game9.GameStart();
            Game game10 = new Game(false);
            game10.GameStart();

            List<Game> listGames = new List<Game> { game1, game2, game3, game4, game5, game6, game7, game8, game9, game10 };

            List<Game> correctionListGames = new List<Game>();
           
            MainGamesView(listGames, correctionListGames);
            Console.Clear();

        }

       

        public static void MainGamesView(List<Game> listGames, List<Game> correctionListGames)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ViewPrints.PrintText($"Resultaat:\n", ConsoleColor.Yellow);

            
           // List<Game> correctionListGames = new List<Game>();
            
            foreach (Game game in listGames)
            {
                if (Game.CountWrong == 0)
                {

                }
                else if (game.Correct == "Juist" && game.DurationInt <= SetTimeLimit.TimeLimit)
                {
                    ViewPrints.PrintText(game.Sentence, ConsoleColor.Green);
                }
                else if (game.Correct == "Juist" && game.DurationInt > SetTimeLimit.TimeLimit)
                {
                    ViewPrints.PrintText(game.Sentence, ConsoleColor.Blue);
                }
                else
                {
                    ViewPrints.PrintText(game.Sentence, ConsoleColor.Red);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            if (Game.CountWrong > 0)
            {
                ViewPrints.PrintText($"We gaan de fouten verbeteren. Druk op een toets om verder te gaan.\n", ConsoleColor.Yellow);
                Console.ReadKey();
                Console.Clear();
                foreach (Game game in listGames)
                {
                  
                    if (game.Correct == "Fout")
                    {
                        game.GameStart();
                        correctionListGames.Add(game);
                    }
                }
                MainGamesView(listGames, correctionListGames);
            }
            else
            {
                Console.Clear();
                ViewPrints.PrintText($"Alles juist!\n", ConsoleColor.Yellow);
                Console.WriteLine();
                foreach (Game game in listGames)
                {
                   if (game.DurationInt <= SetTimeLimit.TimeLimit)
                    {
                        ViewPrints.PrintText(game.Sentence, ConsoleColor.Green);
                    }
                    else
                    {
                        ViewPrints.PrintText(game.Sentence, ConsoleColor.Blue);
                    }
 

                   // ViewPrints.PrintText($"\t{game.Sentence}", ConsoleColor.DarkGray);
                }
                Console.WriteLine();
                Console.WriteLine();
                ViewPrints.PrintText($"Kies wat je nu wil doen:\n", ConsoleColor.Yellow);
                ViewPrints.PrintText($"1. Opnieuw hetzelfde spel spelen\n2. Iets aan het spel veranderen" +
                    $"\n3. Een nieuwe speler wil spelen\n4. Stoppen\n", ConsoleColor.Yellow);

                ChooseOption();
            }
        }

        public static void ChooseOption()
        {
            CheckNumeric.TestNumber(Console.ReadLine());

            if (CheckNumeric.Numeric && CheckNumeric.TestedNumber <= 4)
            {
                switch (CheckNumeric.TestedNumber)
                {
                    case 1:
                        MainGamesStart();
                        break;
                    case 2:
                        ViewSettings.PrintSettings();
                        break;
                    case 3:
                        MainStart();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;

                }
                
            }
        }
            

      
    }
}
