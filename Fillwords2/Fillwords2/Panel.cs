namespace Fillwords2
{
    class Panel
    {
        private string buttonTitle { get; set; }
        private readonly int height = 32;
        private int width { get; set; }

        public Panel(string title, int y)
        {
            buttonTitle = title;
            width = y;
        }

        public void PrintTheTitle() => Printer.Print( buttonTitle, height, width );

        public void PrintHighlightedTitle() => Printer.PrintHighlighted( buttonTitle, height, width );
    }
}
