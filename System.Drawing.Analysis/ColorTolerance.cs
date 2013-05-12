using System;
using System.Collections.Generic;
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

        public ColorTolerance(byte all)
        {
            A = R = G = B = all;
        }
        public ColorTolerance(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

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
    }
}
