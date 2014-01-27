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
            _a = a;
            _r = r;
            _g = g;
            _b = b;
        }
        public Color(int bgra) {
            _bgra = bgra;
        }

        public static Color FromArgb(int argb)
        {
            return new Color((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
        }

        public System.Drawing.Color ToDrawingColor()
        {
            return System.Drawing.Color.FromArgb(_a, _r, _g, _b);
        }
        public static Color FromDrawingColor(System.Drawing.Color c)
        {
            return new Color(c.A, c.R, c.G, c.B);
        }
    }
}
