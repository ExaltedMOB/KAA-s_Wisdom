using System;

namespace Fillwords
{
    public class LogicPatterns
    {
        public static Print[] common;

        public static void FillTheButtons()
        {
            common = new[]
            {
                new Print
                {
                    buttons = new string[4]{
                        "New Game",
                        "Resume",
                        "High Score",
                        "Exit"}
                }
            };
        }

        public static int SwitchTheButton()
        {
            Print.PrintTheHighlightedButton();

            var pressedKey = ConsoleKey.Z; 

            while (pressedKey != ConsoleKey.Enter)
            {
                pressedKey = PressTHeKey();

                Console.Clear();

                if ((pressedKey == ConsoleKey.DownArrow) || (pressedKey == ConsoleKey.S))
                {
                    if(Program.location == 3)
                    {
                        Print.PrintTheTitle();
                        Print.PrintTheHighlightedButton();
                    }

                    else
                    {
                        Print.PrintTheTitle();
                        Program.location++;
                        Print.PrintTheHighlightedButton();
                    }
                }
                else if ((pressedKey == ConsoleKey.UpArrow) || (pressedKey == ConsoleKey.W))
                {
                    if(Program.location == 0)
                    {
                        Print.PrintTheTitle();
                        Print.PrintTheHighlightedButton();
                    }

                    else
                    {
                        Print.PrintTheTitle();
                        Program.location--;
                        Print.PrintTheHighlightedButton();
                    }
                }
            }
            return Program.location;
        }

        public static ConsoleKey PressTHeKey()
        {
            return Console.ReadKey().Key;
        }

        public static void JumpToTheCurrentButton()
        {
            Console.Clear();

            switch (Program.location)
            {
                case 0:
                    ButtonsContains.ExploreTheNewGame();
                    break;
                case 1:
                    Console.WriteLine("NOT DONE YET");
                    break;
                case 2:
                    Console.WriteLine("NOT DONE YET");
                    break;
                case 3:
                    Console.WriteLine("NOT DONE YET");
                    break;
            }
        }
    }
}
