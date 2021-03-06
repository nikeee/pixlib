﻿#if NET40
using System.Runtime;
#endif

namespace System.Drawing.Analysis
{
    /// <summary>Represents a tolerance value that can be used when comparing colors.</summary>
    [Serializable]
    public struct ColorTolerance
    {
        private readonly int _a;
        private readonly int _r;
        private readonly int _g;
        private readonly int _b;

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.ColorTolerance"/> value of the alpha channel.</summary>
        public int A
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _a; }
        }

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.ColorTolerance"/> value of the red channel.</summary>
        public int R
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _r; }
        }

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.ColorTolerance"/> value of the green channel.</summary>
        public int G
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _g; }
        }

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.ColorTolerance"/> value of the blue channel.</summary>
        public int B
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _b; }
        }

        /// <summary>Gets a value indicating whether the alpha channel is being ignored regarding The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</summary>
        public bool IgnoreA
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _a < 0; }
        }

        /// <summary>Gets a value indicating whether the red channel is being ignored regarding The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</summary>
        public bool IgnoreR
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _r < 0; }
        }

        /// <summary>Gets a value indicating whether the green channel is being ignored regarding The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</summary>
        public bool IgnoreG
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _g < 0; }
        }

        /// <summary>Gets a value indicating whether the blue channel is being ignored regarding The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</summary>
        public bool IgnoreB
        {
#if NET40
            [TargetedPatchingOptOut(CompileConstants.TargetedPatchingOptOutText)]
#endif
            get { return _b < 0; }
        }

        #region Ctors

        /// <summary>Creates a new instance of a <see cref="T:System.Drawing.Analysis.ColorTolerance"/> setting every color channel to a single value.</summary>
        /// <param name="all">The value for every color channel.</param>
        /// <param name="ignoreAlpha">A value indicating whether to do ignore the alpha channel.</param>
        public ColorTolerance(int all, bool ignoreAlpha)
        {
            _r = _g = _b = all;
            _a = ignoreAlpha ? -1 : all;
        }

        /// <summary>Creates a new instance of a <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</summary>
        /// <param name="alpha">The value for the alpha channel.</param>
        /// <param name="red">The value for the red channel.</param>
        /// <param name="green">The value for the green channel.</param>
        /// <param name="blue">The value for the blue channel.</param>
        public ColorTolerance(int alpha, int red, int green, int blue)
        {
            _a = alpha;
            _r = red;
            _g = green;
            _b = blue;
        }

        #endregion
        #region equals

        /// <summary>Determines whether this instance and another specified <see cref="T:System.Drawing.Analysis.ColorTolerance"/> object have the same values.</summary>
        /// <param name="obj">The other <see cref="T:System.Drawing.Analysis.ColorTolerance"/> instance.</param>
        /// <returns>true if the values of the <paramref name="obj"/> parameter are the same as this instance; otherwise, false.</returns>
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

        /// <summary>Returns the hash code for this <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</summary>
        /// <returns>The hash code for this <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</returns>
        public override int GetHashCode()
        {
            return A ^ R ^ G ^ B;
        }

        #endregion
        #region ==-operator

        /// <summary>Determines whether two instances of <see cref="T:System.Drawing.Analysis.ColorTolerance"/> objects have the same values.</summary>
        /// <param name="tolerance1">The first <see cref="T:System.Drawing.Analysis.ColorTolerance"/> instance.</param>
        /// <param name="tolerance2">The second <see cref="T:System.Drawing.Analysis.ColorTolerance"/> instance.</param>
        /// <returns>true if the values of the given instances have the same values; otherwise, false.</returns>
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

        /// <summary>Determines whether two instances of <see cref="T:System.Drawing.Analysis.ColorTolerance"/> objects do not have the same values.</summary>
        /// <param name="tolerance1">The first <see cref="T:System.Drawing.Analysis.ColorTolerance"/> instance.</param>
        /// <param name="tolerance2">The second <see cref="T:System.Drawing.Analysis.ColorTolerance"/> instance.</param>
        /// <returns>true if the values of the given instances do not have the same values; otherwise, false.</returns>
        public static bool operator !=(ColorTolerance tolerance1, ColorTolerance tolerance2)
        {
            return !(tolerance1 == tolerance2);
        }


        #endregion
    }
}
