namespace Fillwords2
{
    class Level
    {
        private int levelNumber { get; set; }

        private int squareWidth { get; set; }
        private int squareHeight { get; set; }

        private readonly int cellWidth = 8;
        private readonly int cellHeight = 3;

        public string[,] field;

        public Level(int level, int width, int height)
        {
            levelNumber = level;
            squareWidth = width;
            squareHeight = height;
            field = SetArray(squareWidth, squareHeight);
        }

        public void GenerateSquare() => Printer.PrintTheSquare(squareWidth, squareHeight, cellWidth, cellHeight, levelNumber);

        public static string[,] SetArray (int width, int height)
        {
            return new string[width, height];
        }
    }
}
