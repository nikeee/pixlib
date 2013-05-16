namespace System.Drawing.Analysis
{
    [Serializable]
    public struct ColorTolerance
    {
        private readonly int _a;
        private readonly int _r;
        private readonly int _g;
        private readonly int _b;

        /// <summary>Gets The <see cref="T:ColorTolerance"/> value of the alpha channel.</summary>
        public int A { get { return _a; } }

        /// <summary>Gets The <see cref="T:ColorTolerance"/> value of the red channel.</summary>
        public int R { get { return _r; } }
                                    
        /// <summary>Gets The <see cref="T:ColorTolerance"/> value of the green channel.</summary>
        public int G { get { return _g; } }

        /// <summary>Gets The <see cref="T:ColorTolerance"/> value of the blue channel.</summary>
        public int B { get { return _b; } }

        /// <summary>Gets a value indicating whether the alpha channel is being ignored regarding The <see cref="T:ColorTolerance"/>.</summary>
        public bool IgnoreA { get { return _a < 0; } }
        
        /// <summary>Gets a value indicating whether the red channel is being ignored regarding The <see cref="T:ColorTolerance"/>.</summary>
        public bool IgnoreR { get { return _r < 0; } }
        
        /// <summary>Gets a value indicating whether the green channel is being ignored regarding The <see cref="T:ColorTolerance"/>.</summary>
        public bool IgnoreG { get { return _g < 0; } }

        /// <summary>Gets a value indicating whether the blue channel is being ignored regarding The <see cref="T:ColorTolerance"/>.</summary>
        public bool IgnoreB { get { return _b < 0; } }

        #region Ctors

        public ColorTolerance(byte all, bool ignoreAlpha)
        {
            _r = _g = _b = all;
            _a = ignoreAlpha ? -1 : all;
        }

        public ColorTolerance(byte a, byte r, byte g, byte b, bool ignoreAlpha)
        {
            _a = ignoreAlpha ? -1 : a;
            _r = r;
            _g = g;
            _b = b;
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var ct = (ColorTolerance)obj;
            return (ct.A == A)
                && (ct.R == R)
                && (ct.G == G)
                && (ct.B == B)
                && (ct.IgnoreA == IgnoreA)
                && (ct.IgnoreR == IgnoreR)
                && (ct.IgnoreG == IgnoreG)
                && (ct.IgnoreB == IgnoreB);
        }

        /// <summary>Returns the hash code for this <see cref="T:ColorTolerance"/>.</summary>
        /// <returns>The hash code for this <see cref="T:ColorTolerance"/>.</returns>
        public override int GetHashCode()
        {
            return A ^ R ^ G ^ B;
        }

        #endregion
        #region ==-operator

        public static bool operator ==(ColorTolerance tolerance1, ColorTolerance tolerance2)
        {
            // In case of refactoring to class, take care of this!
            return (tolerance1.A == tolerance2.A)
                && (tolerance1.R == tolerance2.R)
                && (tolerance1.G == tolerance2.G)
                && (tolerance1.B == tolerance2.B)
                && (tolerance1.IgnoreA == tolerance2.IgnoreA)
                && (tolerance1.IgnoreR == tolerance2.IgnoreR)
                && (tolerance1.IgnoreG == tolerance2.IgnoreG)
                && (tolerance1.IgnoreB == tolerance2.IgnoreB);
        }
        public static bool operator !=(ColorTolerance tolerance1, ColorTolerance tolerance2)
        {
            return !(tolerance1 == tolerance2);
        }


        #endregion
    }


}
