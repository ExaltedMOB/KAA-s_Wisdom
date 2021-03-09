using System;

namespace Fillwords2
{
    class Logic
    {
        public static int location = 0;

        private static int SwitchTheButtons(Panel[] panels, int locator )
        {
            var pressedKey = Printer.Keys[4];

            while (pressedKey != Printer.Keys[5])
            {
                pressedKey = Printer.PressTheKey();
                    
                if (((pressedKey == Printer.Keys[0]) || (pressedKey == Printer.Keys[2])) & (locator != 0))
                {
                    locator--;
                    Program.GenerateMenu(panels, locator);
                }

                else if (((pressedKey == Printer.Keys[1]) || (pressedKey == Printer.Keys[3])) & (locator != 3))
                {
                    locator++;
                    Program.GenerateMenu(panels, locator);
                }

                else Program.GenerateMenu(panels, locator);
            }

            return locator;
        }
        
        public static void ChooseTheButton(Panel[] panels, Level[] levels, Random rnd)
        {
            switch (SwitchTheButtons(panels, location))
            {
                case 0:
                    Printer.GreetNewPlayer();
                    Printer.InputName();

                    Printer.ClearScreen();
                    levels[0].GenerateSquare();

                    //levels[0].field = PlaceTheWord(levels[0].field, letters);

                    break;
                case 1:
                    Console.WriteLine("NYD_2");
                    break;
                case 2:
                    Console.WriteLine("NYD_3");
                    break;
                case 3:
                    Console.WriteLine("NYD_4");
                    break;
            }
        }

        public static string[,] PlaceTheWord(string[,] field, string[] letters)
        {
            var rows = field.GetUpperBound(0) + 1;
            var columns = field.Length / rows;

            for (int k = 0; k < letters.Length; k++)
                for (int i = 0;  i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        if ((ReactOnFreeCell(field, i, j)) & (CheckNearbyCells(field, i, j) != 0))
                            field[i, j] = letters[k];
                        
                    }

            return field;
        }

        public static void FillTheField(string[,] field, string[] letters, string[] words, Random rnd, string[] vocabulary)
        {
            while (CheckUnfilledCells(field) == false)
            {
                letters = Program.GetRandomWord(words, Program.GenerateRandomIndex(rnd, vocabulary), vocabulary);
            }    
        }

        public static bool ReactOnFreeCell(string[,] field, int i, int j)
        {
            if (field[i, j] == null) return true;
            else return false;
        }

        public static bool CheckUnfilledCells(string[,] field)
        {
            bool flag = false;

            foreach (string value in field)
            {
                if (value != null) flag = true;
                else
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public static int CheckNearbyCells(string[,] field, int i, int j)
        {
            if ((j > 0) & (ReactOnFreeCell(field, i, j - 1))) return j--;
            else if ((j < 7) & (ReactOnFreeCell(field, i, j + 1))) return j++;
            else if ((i > 0) & (ReactOnFreeCell(field, i - 1, j))) return i--;
            else if ((i < 7) & (ReactOnFreeCell(field, i + 1, j))) return i++;
            else return 0;
        }
    }
}
