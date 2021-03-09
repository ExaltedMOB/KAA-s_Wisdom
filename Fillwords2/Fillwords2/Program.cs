using System;
using System.IO;

namespace Fillwords2
{
    class Program
    {
        static void Main(string[] args)
        {
            Panel[] panels = new Panel[4]{
                new Panel ( "New Game", 5 ),
                new Panel ( "Resume", 7 ),
                new Panel ( "HighScore", 9 ),
                new Panel ( "Exit", 11 )
            };

            Level[] levels = new Level[2]{
                new Level (1,8,8),
                new Level (2,9,9)
            };

            var rnd = new Random();

            string[] vocabulary = File.ReadAllLines("Vocabulary.txt");

            Printer.SetWindowSize();
            Printer.PrintTheHeadline();
            GenerateMenu(panels, Logic.location);
            
            Logic.ChooseTheButton(panels, levels, rnd, vocabulary);
        }

        public static void GenerateMenu(Panel[] panels, int index)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == index) panels[i].PrintHighlightedTitle(); 
                else panels[i].PrintTheTitle();
            }
        }

        public static int GenerateRandomIndex(Random rnd, string[] vocabulary)
        {
            return rnd.Next(0, vocabulary.Length);
        }

        public static string[] GetRandomWord(int index, string[] vocabulary)
        {
            string[] letters = new string[vocabulary[index].Length];

            for (int i = 0; i < vocabulary[index].Length; i++)
                letters[i] = $"   {vocabulary[index][i]}   ";

            return letters;
        }
    }
}
