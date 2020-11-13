using System;

namespace Fillwords
{
    class ButtonsTransition
    {
        public static void JumpToTheCurrentButton()
        {
            Console.Clear();

            switch (Program.location)
            {
                case 0:
                    ButtonsContains.ExploreTheNewGame();
                    break;
                case 1:
                    Console.WriteLine("NOT DONE YET");
                    break;
                case 2:
                    Console.WriteLine("NOT DONE YET");
                    break;
                case 3:
                    Console.WriteLine("NOT DONE YET");
                    break;
            }
        }
    }
}
