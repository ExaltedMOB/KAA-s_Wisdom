using System;
using System.IO;

namespace Fillwords2
{
    class Program
    {
        public static string[] vocabulary = File.ReadAllLines("Vocabulary.txt");
        public static Random rnd = new Random();
        public static readonly int levelsNumber = 10;

        static void Main(string[] args)
        {
            Panel[] panels = new Panel[4]{
                new Panel ( "New Game", 5 ),
                new Panel ( "Resume", 7 ),
                new Panel ( "HighScore", 9 ),
                new Panel ( "Exit", 11 )
            };

            Level[] levels = new Level[levelsNumber];
            levels = CreateLevels(levels, levelsNumber);

            Printer.SetWindow();
            Printer.PrintTheHeadline();
            GenerateMenu(panels, Logic.location);

            Logic.ChooseTheButton(panels, levels, rnd, vocabulary);
        }

        public static Level[] CreateLevels(Level[] levels, int count)
        {
            int width;
            int heigth;
            width = heigth = 6;

            for (int i = 0; i < count; i++)
            {
                levels[i] = new Level (i, width, heigth);
                width++;
                heigth++;
            }
            return levels;
        }

        public static void GenerateMenu(Panel[] panels, int index)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == index) panels[i].PrintHighlightedTitle();
                else panels[i].PrintTheTitle();
            }
        }

        public static int GenerateRandomIndex() => rnd.Next(0, vocabulary.Length);

        public static string GetRandomWord()
        {
            var index = GenerateRandomIndex();
            return vocabulary[index].Contains("-") ? GetRandomWord() : vocabulary[index];
        }

        public static string AbortTheGrowth(string word, string line) => line.Remove(line.Length - word.Length);

        public static string CreateLineOfWords(string[,] field)
        {
            string word;
            string line;
            string temporary = line = "";

            while ( line.Length != field.Length )
            {
                if (line.Length < field.Length - 2)
                {
                    word = GetRandomWord();
                    temporary = word;
                    line += word;
                }
                else if (((line.Length >= field.Length - 2) && (line.Length < field.Length)) || (line.Length > field.Length))
                    line = AbortTheGrowth(temporary, line);
            }
            return line;
        }

        public static string[,] FillFieldWithWords(string[,] field, string line)
        {
            var k = 0;

            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = line[k].ToString();
                    k++;
                }
            return field;
        }
    }
}
