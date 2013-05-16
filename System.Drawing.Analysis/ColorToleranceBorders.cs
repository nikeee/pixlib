using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Drawing.Analysis
{
    /// <summary>
    /// Defines an interval of color channel values that can be used to determine if a <see cref="T:System.Drawing.Color"/> matches another <see cref="T:System.Drawing.Color"/> with a given <see cref="T:ColorTolerance"/>.
    /// </summary>
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

        #region equals

        /// <summary>Determines whether this instance and another specified <see cref="T:ColorToleranceBorders"/> object have the same values.</summary>
        /// <param name="obj">The other <see cref="T:ColorToleranceBorders"/> instance.</param>
        /// <returns>true if the values of the <paramref name="obj"/> parameter are the same as this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var other = (ColorToleranceBorders)obj;
            return _minA == other._minA
                && _minR == other._minR
                && _minG == other._minG
                && _minB == other._minB
                && _maxA == other._maxA
                && _maxR == other._maxR
                && _maxG == other._maxG
                && _maxB == other._maxB
                && _baseColor.ValuesEqual(other._baseColor)
                && _baseTolerance == other._baseTolerance;
        }

        /// <summary>Returns the hash code for this <see cref="T:ColorToleranceBorders"/>.</summary>
        /// <returns>The hash code for this <see cref="T:ColorToleranceBorders"/></returns>
        public override int GetHashCode()
        {
            return (_minA ^ _minR ^ _minG ^ _minB) ^ (_maxA ^ _maxR ^ _maxG ^ _maxB) ^ _baseColor.GetHashCode();
        }

        #endregion
        #region ==-operator

        /// <summary>Determines whether two instances of <see cref="T:ColorToleranceBorders"/> objects have the same values.</summary>
        /// <param name="toleranceBorder1">The first <see cref="T:ColorToleranceBorders"/> instance.</param>
        /// <param name="toleranceBorder2">The second <see cref="T:ColorToleranceBorders"/> instance.</param>
        /// <returns>true if the values of the given instances have the same values; otherwise, false.</returns>
        public static bool operator ==(ColorToleranceBorders toleranceBorder1, ColorToleranceBorders toleranceBorder2)
        {
            // In case of refactoring to class, take care of this!
            return toleranceBorder1._minA == toleranceBorder2._minA
                && toleranceBorder1._minR == toleranceBorder2._minR
                && toleranceBorder1._minG == toleranceBorder2._minG
                && toleranceBorder1._minB == toleranceBorder2._minB
                && toleranceBorder1._maxA == toleranceBorder2._maxA
                && toleranceBorder1._maxR == toleranceBorder2._maxR
                && toleranceBorder1._maxG == toleranceBorder2._maxG
                && toleranceBorder1._maxB == toleranceBorder2._maxB
                && toleranceBorder1._baseColor.ValuesEqual(toleranceBorder2._baseColor)
                && toleranceBorder1._baseTolerance == toleranceBorder2._baseTolerance;
        }

        /// <summary>Determines whether two instances of <see cref="T:ColorToleranceBorders"/> objects do not have the same values.</summary>
        /// <param name="toleranceBorder1">The first <see cref="T:ColorToleranceBorders"/> instance.</param>
        /// <param name="toleranceBorder2">The second <see cref="T:ColorToleranceBorders"/> instance.</param>
        /// <returns>true if the values of the given instances do not have the same values; otherwise, false.</returns>
        public static bool operator !=(ColorToleranceBorders toleranceBorder1, ColorToleranceBorders toleranceBorder2)
        {
            return !(toleranceBorder1 == toleranceBorder2);
        }

        #endregion
    }
}
