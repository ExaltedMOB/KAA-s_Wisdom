namespace Fillwords2
{
    internal class Level
    {
        private const int CellWidth = 4;
        private const int CellHeight = 1;
        private readonly int _levelNumber;
        private readonly int _squareHeight;
        private readonly int _squareWidth;

        public string[,] Field { get; set; }

        public Level(int level, int width, int height)
        {
            _levelNumber = level;
            _squareWidth = width;
            _squareHeight = height;
            Field = SetArray(_squareWidth, _squareHeight);
        }

        public void GenerateSquare()
        {
            Printer.PrintTheSquare(_squareWidth, _squareHeight, CellWidth, CellHeight, _levelNumber);
        }

        public string GenerateLine()
        {
            return Program.CreateLineOfWords(Field);
        }

        public string[,] FillSquareWithLine()
        {
            return Program.FillFieldWithWords(Field, GenerateLine());
        }

        public void DrawField()
        {
            Printer.PrintTheField(Field);
        }

        public string[,] SetArray(int width, int height)
        {
            return new string[width, height];
        }
    }
}