using System;
using System.Collections.Generic;
using System.Text;
using Calculation2.Settings;
using Calculation2.Views;

namespace Calculation2.Games
{
    class Game
    {
        Random rnd = new Random();

      

        public Game(bool evenuneven)
        {
            CountAll++;
            Evenuneven = evenuneven;
            NumMax = rnd.Next(1, SetMaximumNumber.MaximumNumber+1);
            Num2 = rnd.Next(1, NumMax+1);
            Num3 = NumMax - Num2;
            GameType = SetCalculationType.CalculationType;

            if (GameType > 3)
            {
                int index = rnd.Next(SetListMultiply.ListMultiply.Count);
                NumList = SetListMultiply.ListMultiply[index];
                NumMult = NumMax * NumList;
            }

        }

        public static int CountAll { get; set; }
        public static int CountRight { get; set; }

        private static int countWrong;

        public static int CountWrong
        {
            get { return countWrong; }
            set { countWrong = 10 - CountRight; }
        }


        public int NumMax { get; set; }

        public int Num2 { get; set; }

        public int Num3 { get; set; }

        public int NumList { get; set; }

        public int NumMult { get; set; }

        public int NumA { get; set; }

        public bool Evenuneven { get; set; }

        public int GameType { get; set; }

        public int GameTypeDef { get; set; }

        public int Answer { get; set; }

        public string Operation { get; set; }

        public char Operator { get; set; }

        public string Correct { get; set; }

        public string Sentence { get; set; }

        public TimeSpan Duration { get; set; }

        public int DurationInt { get; set; }


        public void GameStart()
        {
            if (GameType == 3 || GameType == 6)
            {
                if (Evenuneven)
                {
                    GameTypeDef = GameType - 2;
                }
                else
                {
                    GameTypeDef = GameType - 1;
                }
            }
            else
            {
                GameTypeDef = GameType;
            }

            switch (GameTypeDef)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Substract();
                    break;
                case 3:
                    break;
                case 4:
                    Multiply();
                    break;
                case 5:
                    Divide();
                    break;
                case 6:
                    break;
            }
        }

        
        public void Add()
        { 
            DateTime start = DateTime.Now;
            Operator = '+';
            Operation = $"{Num2} {Operator} {Num3} = ";
            ViewPrints.PrintTextInLine(Operation, ConsoleColor.Gray);

            CheckNumeric.TestNumber(Console.ReadLine());

            if (CheckNumeric.Numeric)
            {
                Answer = CheckNumeric.TestedNumber;

                if (Answer == NumMax)
                {
                    Correct = $"Juist";
                    CountWrong = 10 - CountRight++;
                }
                else
                {
                    Correct = $"Fout";
                }

            }
            else
            {
                ViewPrints.PrintText($"\nDit is geen getal. Probeer opnieuw.\n",ConsoleColor.DarkRed);
                Add();
            }

            DateTime end = DateTime.Now;
            Duration = end - start;
            ChangeDurationToInt();
            MakeSentence();
        }

        public void Substract()
        {
            DateTime start = DateTime.Now;
            Operator = '-';
            Operation = $"{NumMax} {Operator} {Num2} = ";
            ViewPrints.PrintTextInLine(Operation, ConsoleColor.Gray);

            CheckNumeric.TestNumber(Console.ReadLine());

            if (CheckNumeric.Numeric)
            {
                Answer = CheckNumeric.TestedNumber;

                if (Answer == Num3)
                {
                    Correct = $"Juist";
                    CountWrong = 10 - CountRight++;
                }
                else
                {
                    Correct = $"Fout";
                }
            }
            else
            {
                ViewPrints.PrintText($"\nDit is geen getal. Probeer opnieuw.\n", ConsoleColor.DarkRed);
                Substract();
            }

            DateTime end = DateTime.Now;
            Duration = end - start;
            ChangeDurationToInt();
            MakeSentence();
        }

        public void Multiply()
        {
            DateTime start = DateTime.Now;
            Operator = 'x';
            Operation = $"{NumMax} {Operator} {NumList} = ";
            ViewPrints.PrintTextInLine(Operation, ConsoleColor.Gray);

            CheckNumeric.TestNumber(Console.ReadLine());

            if (CheckNumeric.Numeric)
            {
                Answer = CheckNumeric.TestedNumber;

                if (Answer == NumMult)
                {
                    Correct = $"Juist";
                    CountWrong = 10 - CountRight++;
                }
                else
                {
                    Correct = $"Fout";
                }

                
            }
            else
            {
                ViewPrints.PrintText($"\nDit is geen getal. Probeer opnieuw.\n", ConsoleColor.DarkRed);
                Multiply();
            }

            DateTime end = DateTime.Now;
            Duration = end - start;
            ChangeDurationToInt();
            MakeSentence();
        }

        public void Divide()
        {
            DateTime start = DateTime.Now;
            Operator = ':';
            Operation = $"{NumMult} {Operator} {NumList} = ";
            ViewPrints.PrintTextInLine(Operation, ConsoleColor.Gray);

            CheckNumeric.TestNumber(Console.ReadLine());

            if (CheckNumeric.Numeric)
            {
                Answer = CheckNumeric.TestedNumber;

                if (Answer == NumMax)
                {
                    Correct = $"Juist";
                    CountWrong = 10 - CountRight++;
                }
                else
                {
                    Correct = $"Fout";
                }
            }
            else
            {
                ViewPrints.PrintText($"\nDit is geen getal. Probeer opnieuw.\n", ConsoleColor.DarkRed);
                Divide();
            }

            DateTime end = DateTime.Now;
            Duration = end - start;
            ChangeDurationToInt();
            MakeSentence();

        }

        public void MakeSentence()
        {
            Sentence = $"{Operation}{Answer}\t{Correct}\t{Duration.Seconds} seconden";
        }

        public void ChangeDurationToInt()
        { 
                DurationInt = Convert.ToInt32(Duration.Seconds);
        }
    }
}
