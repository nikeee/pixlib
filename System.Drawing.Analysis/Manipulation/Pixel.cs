namespace System.Drawing.Analysis.Manipulation
{
    public struct Pixel
    {
        public int X;
        public int Y;

        public Color Color;

        #region ctors

        public Pixel(int x, int y, byte a, byte r, byte g, byte b)
            : this(x, y, Color.FromArgb(a, r, g, b))
        { }

        public Pixel(int x, int y, int argb)
            : this(x, y, Color.FromArgb(argb))
        { }

        public Pixel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        #endregion
    }
}