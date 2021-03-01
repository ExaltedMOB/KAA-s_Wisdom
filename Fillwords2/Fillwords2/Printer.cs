using System;

namespace Fillwords2
{
    class Printer
    {
        public static void SetCursorLocation()
        {
            Panel.height = 32;
            Panel.width = 5;
        }

        public static void PrintTheHeadline()
        {
            Console.SetCursorPosition(29, 3);
            Console.WriteLine("< < FILLWORDS > >");
        }

        public static void SetWindowSize()
        {
            Console.SetWindowSize(80, 30);
        }

        public static void Print(string title, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(title);
        }

        public static void PrintHighlighted(string title, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Print(title, x, y);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
