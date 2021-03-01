using System;

namespace Fillwords2
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.SetWindowSize();

            Panel[] panels = new Panel[4]{
                new Panel { buttonTitle = "New Game" },
                new Panel { buttonTitle = "Resume" },
                new Panel { buttonTitle = "HighScore" },
                new Panel { buttonTitle = "Exit" },
            };

            SetPanelsWidth(panels);
            Printer.PrintTheHeadline();
            GenerateMenu(panels, Logic.location);

            Logic.ChooseTheButton(panels);
        }

        public static void GenerateMenu(Panel[] panels, int index)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i == index) 
                {
                    panels[i].PrintHighlightedTitle();
                }

                else panels[i].PrintTheTitle();
            }
        }

        public static void SetPanelsWidth(Panel[] panels)
        {
            panels[0].width = 5;

            for (int i = 1; i < 4; i++)
            {
                panels[i].width = panels[i - 1].width + 2;
            }
        }
    }
}
