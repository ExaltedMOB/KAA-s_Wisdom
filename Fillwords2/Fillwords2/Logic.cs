using System;
using System.Xml;
using Fillwords2.Enums;

namespace Fillwords2
{
    class Logic
    {
        private Logic() { }

        public static int location = 0;

        private static MenuType SwitchTheButtons(Panel[] panels, int locator )
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

            return (MenuType) locator;
        }
        
        public static void ChooseTheButton(Panel[] panels, Level[] levels, string[] vocabulary)
        {
            switch (SwitchTheButtons(panels, location))
            {
                case MenuType.NewGame:
                    Printer.GreetNewPlayer();
                    Printer.InputName();

                    Printer.ClearScreen();
                    levels[0].GenerateSquare();

                    levels[0].Field = levels[0].FillSquareWithLine();

                    Console.WriteLine();
                    levels[0].DrawField();

                    break;
                case MenuType.Resume:
                    Console.WriteLine("NYD_2");
                    break;
                case MenuType.HighScore:
                    Console.WriteLine("NYD_3");
                    break;
                case MenuType.Exit:
                    Console.WriteLine("NYD_4");
                    break;
            }
        }
    }
}
