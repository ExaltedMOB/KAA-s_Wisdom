using System;

namespace Fillwords
{
    public class ButtonsSelection
    {
        public static int SwitchTheButton()
        {
            var location = 0;

            Menu.PrintTheHighlightedButton(location);

            var pressedKey = ConsoleKey.Z;

            while (pressedKey != ConsoleKey.Enter)
            {
                pressedKey = PressTHeKey();

                if ((pressedKey == ConsoleKey.DownArrow) || (pressedKey == ConsoleKey.S))
                {
                    if(location == 3)
                    {
                        Menu.PrintTheTitle();
                        Menu.PrintTheHighlightedButton(location);
                    }
                    else
                    {
                        Menu.PrintTheTitle();
                        location++;
                        Menu.PrintTheHighlightedButton(location);
                    }
                }
                else if ((pressedKey == ConsoleKey.UpArrow) || (pressedKey == ConsoleKey.W))
                {
                    if(location == 0)
                    {
                        Menu.PrintTheTitle();
                        Menu.PrintTheHighlightedButton(location);
                    }
                    else
                    {
                        Menu.PrintTheTitle();
                        location--;
                        Menu.PrintTheHighlightedButton(location);
                    }
                }
            }
            return location;
        }

        public static ConsoleKey PressTHeKey()
        {
            return Console.ReadKey().Key;
        }
    }
}
