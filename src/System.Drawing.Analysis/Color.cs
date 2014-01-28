using System.Runtime.InteropServices;

namespace System.Drawing.Analysis
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Color
    {
        [FieldOffset(0)]
        private byte _b;
        [FieldOffset(1)]
        private byte _g;
        [FieldOffset(2)]
        private byte _r;
        [FieldOffset(3)]
        private byte _a;
        [FieldOffset(0)]
        private int _bgra;

        public byte A { get { return _a; } set { _a = value; } }
        public byte R { get { return _r; } set { _r = value; } }
        public byte G { get { return _g; } set { _g = value; } }
        public byte B { get { return _b; } set { _b = value; } }
        public int Bgra { get { return _bgra; } set { _bgra = value; } }

        public Color(byte a, byte r, byte g, byte b)
        {
            _bgra = 0;
            _a = a;
            _r = r;
            _g = g;
            _b = b;
        }
        public Color(int bgra)
        {
            _a = _r = _b = _g = 0;
            _bgra = bgra;
        }

        public static Color FromArgb(int argb)
        {
            return new Color((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
        }

        public override string ToString()
        {
            return string.Concat("A: ", _a, ", R: ", _r, ", G:", _g, ", B: ", _b);
        }

        public System.Drawing.Color ToDrawingColor()
        {
            return System.Drawing.Color.FromArgb(_a, _r, _g, _b);
        }
        public static Color FromDrawingColor(System.Drawing.Color c)
        {
            return new Color(c.A, c.R, c.G, c.B);
        }

        /// <summary>Indicates whether the channel values of two colors are equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Analysis.Color"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Analysis.Color"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are equal.</returns>
        public static bool operator ==(Color color1, Color color2)
        {
            return color1.A == color2.A
                    && color1.R == color2.R
                    && color1.G == color2.G
                    && color1.B == color2.B;
        }

        /// <summary>Indicates whether the channel values of two colors are not equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Analysis.Color"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Analysis.Color"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are not equal.</returns>
        public static bool operator !=(Color color1, Color color2)
        {
            return color1.A != color2.A
                    || color1.R != color2.R
                    || color1.G != color2.G
                    || color1.B != color2.B;
        }
    }

    public static class Colors
    {
        private static Color _white = new Color(0xFF, 0xFF, 0xFF, 0xFF);
        public static Color White { get { return _white; } }

        private static Color _black = new Color(0xFF, 0x0, 0x0, 0x0);
        public static Color Black { get { return _black; } }

        private static Color _transparent = new Color(0x0, 0x0, 0x0, 0x0);
        public static Color Transparent { get { return _transparent; } }

        private static Color _red = new Color(0xFF, 0xFF, 0x0, 0x0);
        public static Color Red { get { return _red; } }

        private static Color _green = new Color(0xFF, 0x0, 0xFF, 0x0);
        public static Color Green { get { return _green; } }

        private static Color _blue = new Color(0xFF, 0x0, 0x0, 0xFF);
        public static Color Blue { get { return _blue; } }
    }
}
