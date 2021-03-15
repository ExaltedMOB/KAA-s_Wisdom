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
                    
                if (((pressedKey == Printer.Keys[0]) || (pressedKey == Printer.Keys[2])) && (locator != 0))
                {
                    locator--;
                    Program.GenerateMenu(panels, locator);
                }

                else if (((pressedKey == Printer.Keys[1]) || (pressedKey == Printer.Keys[3])) && (locator != 3))
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

                    levels[0].field = levels[0].FillSquareWithLine();

                    Console.WriteLine();
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
    }
}
