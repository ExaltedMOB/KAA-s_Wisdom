namespace Fillwords2
{
    class Panel
    {
        public string buttonTitle;
        readonly int height = 32;
        public int width;

        public void PrintTheTitle() => Printer.Print( buttonTitle, height, width );

        public void PrintHighlightedTitle() => Printer.PrintHighlighted( buttonTitle, height, width );
    }
}
