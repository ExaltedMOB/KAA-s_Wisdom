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
        
        public static void ChooseTheButton(Panel[] panels, Level[] levels, Random rnd, string[] vocabulary)
        {
            switch (SwitchTheButtons(panels, location))
            {
                case 0:
                    Printer.GreetNewPlayer();
                    Printer.InputName();

                    Printer.ClearScreen();
                    levels[0].GenerateSquare();

                    //levels[0].field = PlaceTheWord(levels[0].field, letters);

                    FillTheField(levels[0].field, rnd, vocabulary);
                    levels[0].DrawField();

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
            for (int k = 0; k < letters.Length; k++)
                for (int i = 0;  i < field.GetLength(0); i++)
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if ((ReactOnFreeCell(field, i, j)) & (CheckNearbyCells(field, i, j) != 0))
                        {
                            field[i, j] = letters[k];
                            break;
                        }
                    }

            return field;
        }

        public static void FillTheField(string[,] field, Random rnd, string[] vocabulary)
        {
            while (CheckUnfilledCells(field) == false)
            {
                string[] letters = Program.GetRandomWord(Program.GenerateRandomIndex(rnd, vocabulary), vocabulary);
                field = PlaceTheWord(field, letters);
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
            if ((j > 0) && (ReactOnFreeCell(field, i, j - 1))) return j - 1;
            else if ((j < 7) && (ReactOnFreeCell(field, i, j + 1))) return j + 1;
            else if ((i > 0) && (ReactOnFreeCell(field, i - 1, j))) return i - 1;
            else if ((i < 7) && (ReactOnFreeCell(field, i + 1, j))) return i + 1;
            else return 0;
        }
    }
}
