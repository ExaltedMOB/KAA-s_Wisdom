using System;

namespace Fillwords2
{
    class Logic
    {
        public static int location = 0;

        public static ConsoleKey PressTheKey()
        {
            return Console.ReadKey().Key;
        }

        public static int SwitchTheButtons(Panel[] panels, int locator)
        {
            var pressedKey = ConsoleKey.Delete;

            while (pressedKey != ConsoleKey.Enter)
            {
                pressedKey = PressTheKey();
                    
                if (((pressedKey == ConsoleKey.UpArrow) || (pressedKey == ConsoleKey.W)) & (locator != 0))
                {
                    locator--;
                    Program.GenerateMenu(panels, locator);
                }

                else if (((pressedKey == ConsoleKey.DownArrow) || (pressedKey == ConsoleKey.S)) & (locator != 3))
                {

                    locator++;
                    Program.GenerateMenu(panels, locator);
                }

                else
                {
                    Program.GenerateMenu(panels, locator);
                }
            }

            return locator;
        }

        public static void ChooseTheButton(Panel[] panels)
        {
            switch (SwitchTheButtons(panels, location))
            {
                case 0:
                    Console.WriteLine("NYD_1");
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
