using System;

namespace Fillwords2
{
    class Program
    {
        public static ConsoleKey key = ConsoleKey.Delete;
        public static int locator = 0;

        static void Main(string[] args)
        {
            Panel[] panels = new Panel[4]{
                new Panel { buttonTitle = "New Game" },
                new Panel { buttonTitle = "Resume" },
                new Panel { buttonTitle = "HighScore" },
                new Panel { buttonTitle = "Exit" },
            };

            Printer.SetWindowSize();
            Printer.PrintTheHeadline();
            PrintTheMenu(panels);

            //Logic.SwitchTheButtons(key, panels);
        }

        public static void PrintTheMenu(Panel[] panels)
        {
            for (int i = 0; i < 4; i++)
            {
                Printer.SetCursorLocation();

                if (locator == i)
                {
                    panels[i].PrintHighlightedTitle();
                    Panel.width += 2;
                }

                else
                {
                    panels[i].PrintTheTitle();
                    Panel.width += 2;
                }
            }
        }

        //public static void GenerateMenu(Panel[] panels)
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (locator != 0)
        //        {
        //            panels[locator].PrintEachHighlightedButton();
        //            Panel.width += 2;
        //        }

        //        panels[i].PrintTheButton();
        //        Panel.width += 2;
        //    }

        //    Panel.width = 5;
        //}
    }
}
