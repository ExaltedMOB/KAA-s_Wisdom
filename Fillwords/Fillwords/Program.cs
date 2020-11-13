using System;

namespace Fillwords
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintTheMenu();
            ButtonsSelection.SwitchTheButton();
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
