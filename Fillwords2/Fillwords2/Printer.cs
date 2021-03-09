﻿using System;

namespace Fillwords2
{
    class Printer
    {
        public static ConsoleKey[] Keys = new ConsoleKey[6] {
            ConsoleKey.UpArrow,
            ConsoleKey.DownArrow,
            ConsoleKey.W,
            ConsoleKey.S,
            ConsoleKey.Delete,
            ConsoleKey.Enter
        };

        public static void SetCursor(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void PrintTheHeadline()
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(29, 3);
            Console.WriteLine("< < FILLWORDS > >");
        }

        public static void ClearScreen()
        {
            Console.Clear();
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

        public static ConsoleKey PressTheKey()
        {
            return Console.ReadKey().Key;
        }

        public static void GreetNewPlayer()
        {
            ClearScreen();           

            Console.SetCursorPosition(28, 5);
            Console.WriteLine("Enter your name, please!");
            Console.SetCursorPosition(33, 7);
        }

        public static string InputName()
        {
            return Console.ReadLine();
        }

        public static void PrintLevelIndex(int number)
        {
            SetCursor(15, 2);
            Console.WriteLine($"LEVEL -- {number}");
        }

        public static void PrintTheLine(int sWidth, int cWidth, string lineStart, string lineInsider, string lineEnd, int x, int y)
        {
            SetCursor(x, y);

            Console.Write(lineStart);

            for (int i = 1; i <= sWidth; i++)
            {
                for (int j = 0; j < cWidth; j++)
                    Console.Write("─");
                if (i != sWidth)
                    Console.Write(lineInsider);
            }

            Console.Write(lineEnd);
        }

        public static void PrintWhiteSpaces(int sWidth, int cWidth)
        {
            for (int i = 0; i < sWidth; i++)
            {
                Console.Write("│");
                for (int j = 0; j < cWidth; j++)
                    Console.Write(" ");
            }
            Console.Write("│");
        }

        public static void PrintTheSquare(int squareWidth, int squareHeight, int cellWidth, int cellHeight, int number)
        {
            var x = 10;
            var y = 3;

            PrintLevelIndex(number);

            PrintTheLine(squareWidth, cellWidth, "┌", "┬", "┐", x, y);

            for (int i = 1; i <= squareHeight; i++)
            {
                y++;

                for (int j = 0; j < cellHeight; j++)
                {
                    SetCursor(x, y);
                    PrintWhiteSpaces(squareWidth, cellWidth);
                    y++;
                }
                if (i != squareHeight) PrintTheLine(squareWidth, cellWidth, "├", "┼", "┤", x, y);
            }

            PrintTheLine(squareWidth, cellWidth, "└", "┴", "┘", x, y);
        }
    }
}