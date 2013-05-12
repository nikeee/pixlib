﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.Drawing.Analysis
{
    public struct ColorTolerance
    {
        public readonly byte A;
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;

        public readonly bool IgnoreAlpha;

        #region Ctors

        public ColorTolerance(byte all)
            : this(all, false)
        { }

        public ColorTolerance(byte all, bool ignoreAlpha)
        {
            A = R = G = B = all;
            IgnoreAlpha = ignoreAlpha;
        }

        public ColorTolerance(byte a, byte r, byte g, byte b)
            : this(a, r, g, b, false)
        { }

        public ColorTolerance(byte a, byte r, byte g, byte b, bool ignoreAlpha)
        {
            A = a;
            R = r;
            G = g;
            B = b;
            IgnoreAlpha = ignoreAlpha;
        }

        #endregion
        #region Min/MaxToleranceValues

        public ColorTolerance GetMinimumValuesFromColor(Color color)
        {
            return new ColorTolerance(
                    (byte)(color.A < A ? 0 : (color.A - A)),
                    (byte)(color.R < R ? 0 : (color.R - R)),
                    (byte)(color.G < G ? 0 : (color.G - G)),
                    (byte)(color.B < B ? 0 : (color.B - B))
                );
        }

        public ColorTolerance GetMaximumValuesFromColor(Color color)
        {
            return new ColorTolerance(
                    (byte)((color.A + A > 255) ? 255 : (color.A + A)),
                    (byte)((color.R + R > 255) ? 255 : (color.R + R)),
                    (byte)((color.G + G > 255) ? 255 : (color.G + G)),
                    (byte)((color.B + B > 255) ? 255 : (color.B + B))
                );
        }

        #endregion
        #region explicits

        public static explicit operator ColorTolerance(byte value)
        {
            return new ColorTolerance(value);
        }

        public static explicit operator ColorTolerance(int value)
        {
            if (value < 0 || value > 255)
                throw new InvalidCastException();
            return new ColorTolerance((byte)value);
        }

        #endregion
    }
}
