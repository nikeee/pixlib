using System.Runtime.InteropServices;

namespace System.Drawing.Analysis
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public struct NativeColor
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b")]
        public NativeColor(byte a, byte r, byte g, byte b)
        {
            _bgra = 0;
            _a = a;
            _r = r;
            _g = g;
            _b = b;
        }
        public NativeColor(int bgra)
        {
            _a = _r = _b = _g = 0;
            _bgra = bgra;
        }

        public static NativeColor FromArgb(int argb)
        {
            return new NativeColor((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
        }

        public override string ToString()
        {
            return string.Concat("A: ", _a, ", R: ", _r, ", G:", _g, ", B: ", _b);
        }
        public override int GetHashCode()
        {
            return _bgra;
        }

        public System.Drawing.Color ToDrawingColor()
        {
            return System.Drawing.Color.FromArgb(_a, _r, _g, _b);
        }
        public static NativeColor FromDrawingColor(Color color)
        {
            return new NativeColor(color.A, color.R, color.G, color.B);
        }

        /// <summary>Indicates whether the channel values of two colors are equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are equal.</returns>
        public static bool operator ==(NativeColor color1, NativeColor color2)
        {
            return color1.A == color2.A
                    && color1.R == color2.R
                    && color1.G == color2.G
                    && color1.B == color2.B;
        }

        /// <summary>Indicates whether the channel values of two colors are not equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are not equal.</returns>
        public static bool operator !=(NativeColor color1, NativeColor color2)
        {
            return color1.A != color2.A
                    || color1.R != color2.R
                    || color1.G != color2.G
                    || color1.B != color2.B;
        }
    }

    public static class Colors
    {
        private static NativeColor _white = new NativeColor(0xFF, 0xFF, 0xFF, 0xFF);
        public static NativeColor White { get { return _white; } }

        private static NativeColor _black = new NativeColor(0xFF, 0x0, 0x0, 0x0);
        public static NativeColor Black { get { return _black; } }

        private static NativeColor _transparent = new NativeColor(0x0, 0x0, 0x0, 0x0);
        public static NativeColor Transparent { get { return _transparent; } }

        private static NativeColor _red = new NativeColor(0xFF, 0xFF, 0x0, 0x0);
        public static NativeColor Red { get { return _red; } }

        private static NativeColor _green = new NativeColor(0xFF, 0x0, 0xFF, 0x0);
        public static NativeColor Green { get { return _green; } }

        private static NativeColor _blue = new NativeColor(0xFF, 0x0, 0x0, 0xFF);
        public static NativeColor Blue { get { return _blue; } }
    }
}
