using System;

namespace Fillwords
{
    class ButtonsContains
    {
        public static void ExploreTheNewGame()
        {
            Console.SetCursorPosition(30, 3);
            Console.WriteLine("Input your name please!");
            Console.SetCursorPosition(37, 5);
            InputTheName();
        }

        public static string InputTheName()
        {
            return Console.ReadLine();
        }
    }
}
