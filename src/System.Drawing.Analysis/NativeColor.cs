using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace System.Drawing.Analysis
{
    ///<summary>Represents an ARGB (alpha, red, green, blue) color that is often used in native memory bitmaps.</summary>
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

        /// <summary>
        /// Gets or sets the alpha component value of this <see cref="T:System.Drawing.Analysis.NativeColor"/> structure.
        /// </summary>
        public byte A { get { return _a; } set { _a = value; } }

        /// <summary>
        /// Gets or sets the red component value of this <see cref="T:System.Drawing.Analysis.NativeColor"/> structure.
        /// </summary>
        public byte R { get { return _r; } set { _r = value; } }

        /// <summary>
        /// Gets or sets the green component value of this <see cref="T:System.Drawing.Analysis.NativeColor"/> structure.
        /// </summary>
        public byte G { get { return _g; } set { _g = value; } }

        /// <summary>
        /// Gets or sets the blue component value of this <see cref="T:System.Drawing.Analysis.NativeColor"/> structure.
        /// </summary>
        public byte B { get { return _b; } set { _b = value; } }
        
        /// <summary>
        /// Gets or sets all component values of this <see cref="T:System.Drawing.Analysis.NativeColor"/> structure.
        /// </summary>
        public int Bgra { get { return _bgra; } set { _bgra = value; } }

        /// <summary>Creates a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure from the four ARGB component (alpha, red, green, and blue) values.</summary>
        /// <param name="alpha">The alpha component.</param>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <returns>A new instance of <see cref="T:System.Drawing.Analysis.NativeColor" />.</returns>
        public NativeColor(byte alpha, byte red, byte green, byte blue)
        {
            _bgra = 0;
            _a = alpha;
            _r = red;
            _g = green;
            _b = blue;
        }
        /// <summary>Creates a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure from a 32-bit ARGB value.</summary>
        /// <param name="bgra">A value specifying the 32-bit BGRA value. </param>
        /// <returns>A new instance of <see cref="T:System.Drawing.Analysis.NativeColor" />.</returns>
        public NativeColor(int bgra)
        {
            _a = _r = _b = _g = 0;
            _bgra = bgra;
        }
        
        #region "Common overrides"

        /// <summary>Converts this <see cref="T:System.Drawing.Analysis.NativeColor" /> structure to a human-readable string.</summary>
        /// <returns>A string that consists of the ARGB component names and their values.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return string.Concat("A: ", _a, ", R: ", _r, ", G:", _g, ", B: ", _b);
        }
        /// <summary>Returns a hash code for this <see cref="T:System.Drawing.Analysis.NativeColor" /> structure.</summary>
        /// <returns>An integer value that specifies the hash code for this <see cref="T:System.Drawing.Analysis.NativeColor" />.</returns>
        /// <filterpriority>1</filterpriority>
        public override int GetHashCode()
        {
            return _bgra;
        }

        /// <summary>Tests whether the specified object is a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure and is equivalent to this <see cref="T:System.Drawing.Analysis.NativeColor" /> structure.</summary>
        /// <returns>true if <paramref name="obj" /> is a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure equivalent to this <see cref="T:System.Drawing.Analysis.NativeColor" /> structure; otherwise, false.</returns>
        /// <param name="obj">The object to test. </param>
        /// <filterpriority>1</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var c = (NativeColor)obj;

            return Equals(c);
        }
        
        #endregion
        #region "Color Interop"

        #region Argb
        /// <summary>
        /// Gets the 32-bit ARGB value of this <see cref="T:System.Drawing.Analysis.NativeColor"/> structure.
        /// </summary>
        /// <returns>The 32-bit ARGB value of this <see cref="T:System.Drawing.Analysis.NativeColor"/>.</returns>
        public int ToArgb()
        {
            return (_a << 24) | (_r << 16) | (_g << 8) | (_b << 0);
        }

        /// <summary>Creates a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure from a 32-bit ARGB value.</summary>
        /// <param name="argb">A value specifying the 32-bit ARGB value. </param>
        /// <returns>The <see cref="T:System.Drawing.Analysis.NativeColor" /> structure that this method creates.</returns>
        public static NativeColor FromArgb(int argb)
        {
            return new NativeColor((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
        }

        #endregion
        #region "System.Drawing.Color"

        /// <summary>Creates a <see cref="T:System.Drawing.Color" /> structure using current instance of <see cref="T:System.Drawing.Analysis.NativeColor" />.</summary>
        /// <returns>The <see cref="T:System.Drawing.Color" /> structure that this method creates.</returns>
        public Color ToDrawingColor()
        {
            return Color.FromArgb(_a, _r, _g, _b);
        }
        /// <summary>Creates a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure from a 32-bit ARGB value.</summary>
        /// <param name="color">A color value.</param>
        /// <returns>The <see cref="T:System.Drawing.Analysis.NativeColor" /> structure that this method creates.</returns>
        public static NativeColor FromDrawingColor(Color color)
        {
            return new NativeColor(color.A, color.R, color.G, color.B);
        }

        #endregion

        #endregion
        #region "Operators"

        /// <summary>Indicates whether the channel values of two colors are equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are equal.</returns>
        public static bool operator ==(NativeColor color1, NativeColor color2)
        {
            return color1._bgra == color2._bgra;
        }

        /// <summary>Indicates whether the channel values of two colors are not equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Analysis.NativeColor"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are not equal.</returns>
        public static bool operator !=(NativeColor color1, NativeColor color2)
        {
            return color1._bgra != color2._bgra;
        }

        /// <summary>Tests whether the specified object is a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure and is equivalent to this <see cref="T:System.Drawing.Analysis.NativeColor" /> structure.</summary>
        /// <returns>true if <paramref name="other" /> is a <see cref="T:System.Drawing.Analysis.NativeColor" /> structure equivalent to this <see cref="T:System.Drawing.Analysis.NativeColor" /> structure; otherwise, false.</returns>
        /// <param name="other">The other <see cref="T:System.Drawing.Analysis.NativeColor" /> to test. </param>
        /// <filterpriority>1</filterpriority>
        public bool Equals(NativeColor other)
        {
            return this == other;
        }

        #endregion
    }

    /// <summary>Standard colors. This class cannot be inherited.</summary>
    public static class Colors
    {
        private static readonly NativeColor _white = new NativeColor(0xFF, 0xFF, 0xFF, 0xFF);
        /// <summary>Gets a system-defined color that has an ARGB value of #FFFFFFFF.</summary>
        /// <returns>A <see cref="T:System.Drawing.Analysis.NativeColor" /> representing a system-defined color.</returns>
        public static NativeColor White { get { return _white; } }

        private static readonly NativeColor _black = new NativeColor(0xFF, 0x0, 0x0, 0x0);
        /// <summary>Gets a system-defined color that has an ARGB value of #FF000000.</summary>
        /// <returns>A <see cref="T:System.Drawing.Analysis.NativeColor" /> representing a system-defined color.</returns>
        public static NativeColor Black { get { return _black; } }

        private static readonly NativeColor _transparent = new NativeColor(0x0, 0x0, 0x0, 0x0);
        /// <summary>Gets a system-defined color that has an ARGB value of #00000000.</summary>
        /// <returns>A <see cref="T:System.Drawing.Analysis.NativeColor" /> representing a system-defined color.</returns>
        public static NativeColor Transparent { get { return _transparent; } }

        private static readonly NativeColor _red = new NativeColor(0xFF, 0xFF, 0x0, 0x0);
        /// <summary>Gets a system-defined color that has an ARGB value of #FFFF0000.</summary>
        /// <returns>A <see cref="T:System.Drawing.Analysis.NativeColor" /> representing a system-defined color.</returns>
        public static NativeColor Red { get { return _red; } }

        private static readonly NativeColor _green = new NativeColor(0xFF, 0x0, 0xFF, 0x0);
        /// <summary>Gets a system-defined color that has an ARGB value of #FF00FF00.</summary>
        /// <returns>A <see cref="T:System.Drawing.Analysis.NativeColor" /> representing a system-defined color.</returns>
        public static NativeColor Green { get { return _green; } }

        private static readonly NativeColor _blue = new NativeColor(0xFF, 0x0, 0x0, 0xFF);
        /// <summary>Gets a system-defined color that has an ARGB value of #FF0000FF.</summary>
        /// <returns>A <see cref="T:System.Drawing.Analysis.NativeColor" /> representing a system-defined color.</returns>
        public static NativeColor Blue { get { return _blue; } }
    }
}
