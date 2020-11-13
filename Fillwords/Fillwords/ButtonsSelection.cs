using System;

namespace Fillwords
{
    public class ButtonsSelection
    {
        public static int SwitchTheButton()
        {
            Menu.PrintTheHighlightedButton();

            var pressedKey = ConsoleKey.Z;

            while (pressedKey != ConsoleKey.Enter)
            {
                pressedKey = PressTHeKey();

                if ((pressedKey == ConsoleKey.DownArrow) || (pressedKey == ConsoleKey.S))
                {
                    if(Program.location == 3)
                    {
                        Menu.PrintTheTitle();
                        Menu.PrintTheHighlightedButton();
                    }
                    else
                    {
                        Menu.PrintTheTitle();
                        Program.location++;
                        Menu.PrintTheHighlightedButton();
                    }
                }
                else if ((pressedKey == ConsoleKey.UpArrow) || (pressedKey == ConsoleKey.W))
                {
                    if(Program.location == 0)
                    {
                        Menu.PrintTheTitle();
                        Menu.PrintTheHighlightedButton();
                    }
                    else
                    {
                        Menu.PrintTheTitle();
                        Program.location--;
                        Menu.PrintTheHighlightedButton();
                    }
                }
            }
            return Program.location;
        }

        public static ConsoleKey PressTHeKey()
        {
            return Console.ReadKey().Key;
        }
    }
}
