namespace System.Drawing.Analysis.Manipulation
{
    [Serializable]
    public struct Pixel
    {
        private int _x;
        public int X { get { return _x; } set { _x = value; } }

        private int _y;
        public int Y { get { return _y; } set { _y = value; } }

        private Color _color;
        public Color Color { get { return _color; } set { _color = value; } }

        #region ctors

        public Pixel(int x, int y, byte a, byte r, byte g, byte b)
            : this(x, y, Color.FromArgb(a, r, g, b))
        { }

        public Pixel(int x, int y, int argb)
            : this(x, y, Color.FromArgb(argb))
        { }

        public Pixel(int x, int y, Color color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var p = (Pixel)obj;
            return (p.X == X) && (p.Y == Y) && (p.Color.ValuesEqual(Color));
        }
        public override int GetHashCode()
        {
            return X ^ Y ^ Color.GetHashCode();
        }

        #endregion
        #region ==-operator

        public static bool operator ==(Pixel pixel1, Pixel pixel2)
        {
            // In case of refactoring to class, take care of this!
            return (pixel1.X == pixel2.X) && (pixel1.Y == pixel2.Y) && (pixel1.Color.ValuesEqual(pixel2.Color));
        }
        public static bool operator !=(Pixel pixel1, Pixel pixel2)
        {
            return !(pixel1 == pixel2);
        }


        #endregion
    }
}