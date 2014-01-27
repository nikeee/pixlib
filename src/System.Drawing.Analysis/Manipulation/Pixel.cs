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
        private int _x;

        /// <summary>Gets or sets the x-coordinate of the pixel.</summary>
        public int X
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _x; }
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            set { _x = value; }
        }

        private int _y;

        /// <summary>Gets or sets the y-coordinate of the pixel.</summary>
        public int Y
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _y; }
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            set { _y = value; }
        }

        private Color _color;
        /// <summary>Gets or sets The <see cref="T:System.Drawing.Color"/> of the pixel.</summary>
        public Color Color
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _color; }
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            set { _color = value; }
        }

        #region ctors


        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance using the given parameters.</summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <param name="a">The alpha value of the pixel.</param>
        /// <param name="r">The red value of the pixel.</param>
        /// <param name="g">The grenn value of the pixel.</param>
        /// <param name="b">The blue value of the pixel.</param>
        public Pixel(int x, int y, byte a, byte r, byte g, byte b)
            : this(x, y, new Color(a, r, g, b))
        { }

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance using the given parameters.</summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <param name="argb">An integer that represents the ARGB values.</param>
        public Pixel(int x, int y, int argb)
            : this(x, y, System.Drawing.Analysis.Color.FromArgb(argb))
        { }

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance using the given parameters.</summary>
        /// <param name="x">The x-coordinate of the pixel.</param>
        /// <param name="y">The y-coordinate of the pixel.</param>
        /// <param name="color">A <see cref="T:System.Drawing.Color"/> instance that represents the color of the pixel.</param>
        public Pixel(int x, int y, Color color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        #endregion
        #region equals

        /// <summary>Determines whether this instance and another specified <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> object have the same values.</summary>
        /// <param name="obj">The other <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <returns>true if the values of the <paramref name="obj"/> parameter are the same as this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var p = (Pixel)obj;
            return (p.X == X) && (p.Y == Y) && (p.Color.ValuesEqual(Color));
        }

        /// <summary>Returns the hash code for this <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>.</summary>
        /// <returns>The hash code for this <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/></returns>
        public override int GetHashCode()
        {
            return _x ^ _y ^ Color.GetHashCode();
        }

        #endregion
        #region ==-operator

        /// <summary>Determines whether two instances of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> objects have the same values.</summary>
        /// <param name="pixel1">The first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <param name="pixel2">The second <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <returns>true if the values of the given instances have the same values; otherwise, false.</returns>
        public static bool operator ==(Pixel pixel1, Pixel pixel2)
        {
            // In case of refactoring to class, take care of this!
            return (pixel1.X == pixel2.X) && (pixel1.Y == pixel2.Y) && (pixel1.Color.ValuesEqual(pixel2.Color));
        }

        /// <summary>Determines whether two instances of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> objects do not have the same values.</summary>
        /// <param name="pixel1">The first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <param name="pixel2">The second <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance.</param>
        /// <returns>true if the values of the given instances do not have the same values; otherwise, false.</returns>
        public static bool operator !=(Pixel pixel1, Pixel pixel2)
        {
            return !(pixel1 == pixel2);
        }

        #endregion
        #region overrides

        /// <summary>Converts this <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> structure to a human-readable string.</summary>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append("X=");
            sb.Append(_x);
            sb.Append(", Y=");
            sb.Append(_y);
            sb.Append(", Color: [A=");
            sb.Append(_color.A);
            sb.Append(", R=");
            sb.Append(_color.R);
            sb.Append(", G=");
            sb.Append(_color.G);
            sb.Append(", B=");
            sb.Append(_color.B);
            sb.Append(']');
            return sb.ToString();
        }

        #endregion
    }
}