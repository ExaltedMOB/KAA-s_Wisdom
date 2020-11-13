using System;

namespace Fillwords
{
    class Program
    {
        public static int location = 0;

        public static void Main(string[] args)
        {
            PrintTheMenu();
            ButtonsSelection.SwitchTheButton();
            ButtonsTransition.JumpToTheCurrentButton();
            Console.ReadKey();
        }

        public static void PrintTheMenu()
        {
            Menu.PrintTheTitle();
            Menu.FillTheButtons();
            Menu.PrintTheButtons();
        }
    }
}
