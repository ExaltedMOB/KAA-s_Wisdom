using System;

namespace Fillwords2
{
    class Logic
    {
        public static ConsoleKey PressTheKey()
        {
            return Console.ReadKey().Key;
        }

        public static int SwitchTheButtons( ConsoleKey pressedKey, Panel[] panels )
        {
            while (pressedKey != ConsoleKey.Enter)
            {
                pressedKey = PressTheKey();

                if (((pressedKey == ConsoleKey.UpArrow) || (pressedKey == ConsoleKey.W)) & (Program.locator != 0))
                {

                }

                else if (((pressedKey == ConsoleKey.DownArrow) || (pressedKey == ConsoleKey.S)) & (Program.locator != 3))
                {

                }

                else PressTheKey();
            }

            return Program.locator;
        }
    }
}
