using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Drawing.Analysis
{
    [Serializable]
    public struct ColorToleranceBorders
    {
        private readonly int _minA;
        public int MinA { get { return _minA; } }

        private readonly int _minR;
        public int MinR { get { return _minR; } }

        private readonly int _minG;
        public int MinG { get { return _minG; } }

        private readonly int _minB;
        public int MinB { get { return _minB; } }

        private readonly int _maxA;
        public int MaxA { get { return _maxA; } }

        private readonly int _maxR;
        public int MaxR { get { return _maxR; } }

        private readonly int _maxG;
        public int MaxG { get { return _maxG; } }

        private readonly int _maxB;
        public int MaxB { get { return _maxB; } }

        private Color _baseColor;
        private ColorTolerance _baseTolerance;

        public ColorToleranceBorders(Color baseColor, ColorTolerance tolerance)
        {
            _baseColor = baseColor;
            _baseTolerance = tolerance;

            _minA = (baseColor.A < tolerance.A ? 0 : (baseColor.A - tolerance.A));
            _minR = (baseColor.R < tolerance.R ? 0 : (baseColor.R - tolerance.R));
            _minG = (baseColor.G < tolerance.G ? 0 : (baseColor.G - tolerance.G));
            _minB = (baseColor.B < tolerance.B ? 0 : (baseColor.B - tolerance.B));

            _maxA = (baseColor.A + tolerance.A > 255) ? 255 : (baseColor.A + tolerance.A);
            _maxR = (baseColor.R + tolerance.R > 255) ? 255 : (baseColor.R + tolerance.R);
            _maxG = (baseColor.G + tolerance.G > 255) ? 255 : (baseColor.G + tolerance.G);
            _maxB = (baseColor.B + tolerance.B > 255) ? 255 : (baseColor.B + tolerance.B);
        }
    }
}
