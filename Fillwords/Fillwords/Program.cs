using System;

namespace Fillwords
{
    class Program
    {
        //public static Buttons[] common;

        public static void Main(string[] args)
        {
            Menu.PrintTheTitle();
            Menu.FillTheButtons();
            Menu.PrintTheButtons();
            Console.ReadKey();
        }

        //static void PrintTheTitle()
        //{
        //    Console.SetWindowSize(80, 30);
        //    Console.SetCursorPosition(30, 3);
        //    Console.WriteLine("<<FILLWORDS>>");
        //}

        //static void FillTheButtons()
        //{
        //    common = new[]
        //    {
        //        new Buttons
        //        {
        //            buttons = new string[4]{
        //                "New Game",
        //                "Resume",
        //                "High Score",
        //                "Exit"}
        //        }
        //    };
        //}

        //static void PrintTheButtons()
        //{
        //    var k = 5;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Console.SetCursorPosition(32, k);
        //        Console.WriteLine(common[0].buttons[i]);
        //        k+=2;
        //    }
        //}
    }
}
