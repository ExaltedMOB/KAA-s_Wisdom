namespace Fillwords2
{
    class Level
    {
        private int levelNumber { get; set; }

        private int squareWidth { get; set; }
        private int squareHeight { get; set; }

        private static readonly int cellWidth = 4;
        private static readonly int cellHeight = 1;

        public string[,] field;

        public Level(int level, int width, int height)
        {
            levelNumber = level;
            squareWidth = width;
            squareHeight = height;
            field = SetArray(squareWidth, squareHeight);
        }

        public void GenerateSquare() => Printer.PrintTheSquare(squareWidth, squareHeight, cellWidth, cellHeight, levelNumber);

        public string GenerateLine() => Program.CreateLineOfWords(field);

        public string[,] FillSquareWithLine() => Program.FillFieldWithWords(field, GenerateLine());

        public void DrawField() => Printer.PrintTheField(field);

        public static string[,] SetArray (int width, int height)
        {
            return new string[width, height];
        }
    }
}
