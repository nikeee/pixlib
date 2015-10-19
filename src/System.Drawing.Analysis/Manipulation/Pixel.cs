#if NET40
using System.Runtime;
#endif

namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>
    /// Represents a pixel.
    /// </summary>
    [Serializable]
    public struct Pixel
    {
        /// <summary>Gets the x-coordinate of the pixel.</summary>
        public int X { get; }

        /// <summary>Gets the y-coordinate of the pixel.</summary>
        public int Y { get; }

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the pixel.</summary>
        public NativeColor Color { get; }

        #region ctors


        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance using the given parameters.</summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <param name="a">The alpha value of the pixel.</param>
        /// <param name="r">The red value of the pixel.</param>
        /// <param name="g">The grenn value of the pixel.</param>
        /// <param name="b">The blue value of the pixel.</param>
        public Pixel(int x, int y, byte a, byte r, byte g, byte b)
            : this(x, y, new NativeColor(a, r, g, b))
        { }

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance using the given parameters.</summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <param name="argb">An integer that represents the ARGB values.</param>
        public Pixel(int x, int y, int argb)
            : this(x, y, System.Drawing.Analysis.NativeColor.FromArgb(argb))
        { }

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance using the given parameters.</summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <param name="color">A <see cref="T:System.Drawing.Analysis.NativeColor"/> instance that represents the color of the pixel.</param>
        public Pixel(int x, int y, NativeColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        #endregion
        #region equals

        /// <summary>Determines whether this instance and another specified <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> object have the same values.</summary>
        /// <param name="obj">The other <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <returns>true if the values of the <paramref name="obj"/> parameter are the same as this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var p = (Pixel)obj;
            return (p.X == X) && (p.Y == Y) && (p.Color == Color);
        }

        /// <summary>Returns the hash code for this <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>.</summary>
        /// <returns>The hash code for this <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/></returns>
        public override int GetHashCode() => X ^ Y ^ Color.GetHashCode();

        #endregion
        #region ==-operator

        /// <summary>Determines whether two instances of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> objects have the same values.</summary>
        /// <param name="pixel1">The first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <param name="pixel2">The second <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <returns>true if the values of the given instances have the same values; otherwise, false.</returns>
        public static bool operator ==(Pixel pixel1, Pixel pixel2)
        {
            // In case of refactoring to class, take care of this!
            return (pixel1.X == pixel2.X) && (pixel1.Y == pixel2.Y) && (pixel1.Color == pixel2.Color);
        }

        /// <summary>Determines whether two instances of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> objects do not have the same values.</summary>
        /// <param name="pixel1">The first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <param name="pixel2">The second <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <returns>true if the values of the given instances do not have the same values; otherwise, false.</returns>
        public static bool operator !=(Pixel pixel1, Pixel pixel2) => !(pixel1 == pixel2);

        #endregion
        #region overrides

        /// <summary>Converts this <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> structure to a human-readable string.</summary>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("X=");
            sb.Append(X);
            sb.Append(", Y=");
            sb.Append(Y);
            sb.Append(", NativeColor: [A=");
            sb.Append(Color.A);
            sb.Append(", R=");
            sb.Append(Color.R);
            sb.Append(", G=");
            sb.Append(Color.G);
            sb.Append(", B=");
            sb.Append(Color.B);
            sb.Append(']');
            return sb.ToString();
        }

        #endregion
    }
}
