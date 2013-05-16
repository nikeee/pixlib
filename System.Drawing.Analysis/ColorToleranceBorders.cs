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
        private readonly int _minR;
        private readonly int _minG;
        private readonly int _minB;

        /// <summary>Gets the minimum alpha value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MinA { get { return _minA; } }

        /// <summary>Gets the minimum red value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MinR { get { return _minR; } }

        /// <summary>Gets the minimum green value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MinG { get { return _minG; } }

        /// <summary>Gets the minimum blue value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MinB { get { return _minB; } }

        private readonly int _maxA;
        private readonly int _maxR;
        private readonly int _maxG;
        private readonly int _maxB;

        /// <summary>Gets the maximum alpha value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MaxA { get { return _maxA; } }

        /// <summary>Gets the maximum red value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MaxR { get { return _maxR; } }

        /// <summary>Gets the maximum green value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MaxG { get { return _maxG; } }

        /// <summary>Gets the maximum blue value the the a can have to match the <see cref="T:ColorTolerance"/>.</summary>
        public int MaxB { get { return _maxB; } }

        private Color _baseColor;
        private ColorTolerance _baseTolerance;

        /// <summary>Creates a new instance of <see cref="T:ColorToleranceBorders"/> from a given <see cref="T:System.Drawing.Color"/> and <see cref="T:ColorTolerance"/>.</summary>
        /// <param name="baseColor">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="tolerance">The <see cref="T:ColorTolerance"/>.</param>
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
