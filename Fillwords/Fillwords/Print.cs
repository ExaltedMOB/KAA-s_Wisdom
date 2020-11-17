using System;

namespace Fillwords
{
    public class Print
    {
        public string[] buttons;

        public static void PrintTheTitle()
        {
            Console.SetWindowSize(80, 30);
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("<<FILLWORDS>>");
        }

        public static void PrintTheMenu()
        {
            PrintTheTitle();
            LogicPatterns.FillTheButtons();
            PrintTheButtons();
        }

        public static void PrintTheButtons()
        {
            var k = 5;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(32, k);
                Console.WriteLine(LogicPatterns.common[0].buttons[i]);
                k += 2;
            }
        }

        public static void PrintTheHighlightedButton()
        {
            var k = 5;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(32, k);
                if (Program.location == i)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine(LogicPatterns.common[0].buttons[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    k += 2;
                }
                else
                {
                    Console.WriteLine(LogicPatterns.common[0].buttons[i]);
                    k += 2;
                }
            }
        }
    }
}
