using System;

namespace Square
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WindowWidth = 150;

        //    var squareWidth = 8;
        //    var squareHeight = 8;
        //    var cellWidth = 8;
        //    var cellHeight = 3;
        //    var x = 10;
        //    var y = 3;

        //    PrintTheSquare(squareWidth, cellWidth, x, y, cellHeight, squareHeight);
        //    Console.ReadKey();
        //}

        static void PrintTheLine(int squareWidth, int cellWidth, string lineStart,string lineInsider, string lineEnd, int x, int y)
        {
            Console.SetCursorPosition(x, y);   

            Console.Write(lineStart);

            for (int i = 1; i <= squareWidth; i++)
            {   
                for (int j = 0; j < cellWidth; j++)
                    Console.Write("─");
                if (i != squareWidth)
                    Console.Write(lineInsider);
            }

            Console.Write(lineEnd);
        }

        static void PrintWhiteSpaces(int squareWidth,int cellWidth)
        {
            for (int i = 0; i < squareWidth; i++)
            {
                Console.Write("│");
                for (int j = 0; j < cellWidth; j++)
                    Console.Write(" ");
            }
            Console.Write("│");
        }

        static void PrintTheSquare(int squareWidth, int cellWidth, int x, int y, int cellHeight, int squareHeight)
        {
            PrintTheLine(squareWidth, cellWidth, "┌", "┬", "┐", x, y);

            for (int i = 1; i <= squareHeight; i++)
            { 
                y++;

                for (int j = 0; j < cellHeight; j ++)
                {
                    Console.SetCursorPosition(x, y);
                    PrintWhiteSpaces(squareWidth, cellWidth);
                    y++;
                }
                if (i != squareHeight)
                    PrintTheLine(squareWidth, cellWidth, "├", "┼", "┤", x, y);
            }

            PrintTheLine(squareWidth, cellWidth, "└", "┴", "┘", x, y);

            //x = 10;
            //y = 4;
            //SwitchByArrows(x, y, squareWidth, cellWidth, cellHeight, squareHeight);
        }

        //////////////////////////////////////////////////////////////////////////////////////////

        //    static void SwitchByArrows(int x, int y, int squareWidth, int cellWidth, int cellHeight, int squareHeight)
        //    {
        //        var pressedKey = ConsoleKey.Z;
        //        Console.SetCursorPosition(x,y);

        //        pressedKey = PressTheKey();

        //        while (pressedKey != ConsoleKey.Escape)
        //        {
        //            switch(pressedKey)
        //            {
        //                case ConsoleKey.UpArrow:
        //                    PrintTheColoredCell(squareWidth, cellWidth, x, y, cellHeight, squareHeight);
        //                    break;
        //                case ConsoleKey.DownArrow:
        //                    break;
        //                case ConsoleKey.LeftArrow:
        //                    break;
        //                case ConsoleKey.RightArrow:
        //                    break;
        //            }
        //        }
        //    }

        //    static void DecideTheCell(int position)
        //    {

        //    }

        //    static ConsoleKey PressTheKey()
        //    {
        //        return Console.ReadKey().Key;
        //    }

        //    static void PrintTheColoredCell(int squareWidth, int cellWidth, int x, int y, int cellHeight, int squareHeight)
        //    {
        //        PrintTheLine(squareWidth, cellWidth, "┌", "┬", "┐", x, y);

        //        for (int i = 1; i <= squareHeight; i++)
        //        {
        //            y++;

        //            for (int j = 0; j < cellHeight; j++)
        //            {
        //                Console.SetCursorPosition(x, y);
        //                ColorTheSpaces(squareWidth, cellWidth);
        //                y++;
        //            }
        //            if (i != squareHeight)
        //                PrintTheLine(squareWidth, cellWidth, "├", "┼", "┤", x, y);
        //        }

        //        PrintTheLine(squareWidth, cellWidth, "└", "┴", "┘", x, y);
        //    }

        //    static void ColorTheSpaces(int squareWidth, int cellWidth)
        //    {
        //        for (int i = 0; i < squareWidth; i++)
        //        {
        //            Console.Write("│");
        //            for (int j = 0; j < cellWidth; j++)
        //            {
        //                Console.BackgroundColor = ConsoleColor.Magenta;
        //                Console.Write(" ");
        //                Console.BackgroundColor = ConsoleColor.Black;
        //            }
        //        }
        //        Console.Write("│");
        //    }

        static void Main(string[] args)
        {
            var squareWidth = 8;
            var squareHeight = 8;
            var cellWidth = 8;
            var cellHeight = 3;


        }


    }
}
