using System;

namespace Fillwords
{
    public class Menu
    {
        public string[] buttons;

        public static Menu[] common;

        public static void PrintTheTitle()
        {
            Console.SetWindowSize(80, 30);
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("<<FILLWORDS>>");
        }

        public static void FillTheButtons()
        {
            common = new[]
            {
                new Menu
                {
                    buttons = new string[4]{
                        "New Game",
                        "Resume",
                        "High Score",
                        "Exit"}
                }
            };
        }

        public static void PrintTheButtons()
        {
            var k = 5;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(32, k);
                Console.WriteLine(common[0].buttons[i]);
                k += 2;
            }
        }

        public static void PrintTheHighlightedButton(int location)
        {
            var k = 5;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(32, k);
                if (location == i)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(common[0].buttons[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    k += 2;
                }
                else
                {
                    Console.WriteLine(common[0].buttons[i]);
                    k += 2;
                }
            }
        }
    }
}
