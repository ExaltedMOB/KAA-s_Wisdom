namespace Fillwords2
{
    class Panel
    {
        public string buttonTitle;

        public static int height;
        public static int width;

        public void PrintTheTitle() => Printer.Print( buttonTitle, height, width );

        public void PrintHighlightedTitle() => Printer.PrintHighlighted( buttonTitle, height, width );
    }
}
