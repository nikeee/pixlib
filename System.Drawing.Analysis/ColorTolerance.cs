namespace System.Drawing.Analysis
{
    [Serializable]
    public struct ColorTolerance
    {
        private readonly int _a;
        public int A { get { return _a; } }
                                          
        private readonly int _r;          
        public int R { get { return _r; } }
                                          
        private readonly int _g;          
        public int G { get { return _g; } }
                                          
        private readonly int _b;          
        public int B { get { return _b; } }

        private readonly bool _ignoreAlpha;
        public bool IgnoreAlpha { get { return _ignoreAlpha; } }

        #region Ctors

        public ColorTolerance(byte all, bool ignoreAlpha)
        {
            _a = _r = _g = _b = all;
            _ignoreAlpha = ignoreAlpha;
        }

        public ColorTolerance(byte a, byte r, byte g, byte b, bool ignoreAlpha)
        {
            _a = a;
            _r = r;
            _g = g;
            _b = b;
            _ignoreAlpha = ignoreAlpha;
        }

        #endregion
        #region Min/MaxToleranceValues

        public ColorTolerance GetMinimumValuesFromColor(Color color)
        {
            return new ColorTolerance(
                    (byte)(color.A < A ? 0 : (color.A - A)),
                    (byte)(color.R < R ? 0 : (color.R - R)),
                    (byte)(color.G < G ? 0 : (color.G - G)),
                    (byte)(color.B < B ? 0 : (color.B - B)),
                    false
                );
        }

        public ColorTolerance GetMaximumValuesFromColor(Color color)
        {
            return new ColorTolerance(
                    (byte)((color.A + A > 255) ? 255 : (color.A + A)),
                    (byte)((color.R + R > 255) ? 255 : (color.R + R)),
                    (byte)((color.G + G > 255) ? 255 : (color.G + G)),
                    (byte)((color.B + B > 255) ? 255 : (color.B + B)),
                    false
                );
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var ct = (ColorTolerance)obj;
            return (ct.A == A) && (ct.R == R) && (ct.G == G) && (ct.B == B) && (ct.IgnoreAlpha == IgnoreAlpha);
        }
        public override int GetHashCode()
        {
            return A ^ R ^ G ^ B ^ (IgnoreAlpha ? 1 : 0);
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
                && (tolerance1.IgnoreAlpha == tolerance2.IgnoreAlpha);
        }
        public static bool operator !=(ColorTolerance tolerance1, ColorTolerance tolerance2)
        {
            return !(tolerance1 == tolerance2);
        }


        #endregion
    }
}
