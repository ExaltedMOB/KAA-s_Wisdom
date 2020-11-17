using System;

namespace Fillwords
{
    class Program
    {
        public static int location = 0;

        public static void Main(string[] args)
        {
            Print.PrintTheMenu();
            LogicPatterns.SwitchTheButton();
            LogicPatterns.JumpToTheCurrentButton();
            Console.ReadKey();
        }
    }
}
