using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Drawing.Analysis
{
    public static class ColorExtensions
    {
        public static bool ValuesEqual(this Color color1, Color color2)
        {
            return color1.A == color2.A
                && color1.R == color2.R
                && color1.G == color2.G
                && color1.B == color2.B;
        }


        // May enhance?

        public static bool ToleranceValuesEqual(this Color color1, Color color2, ref byte[] minValues, ref byte[] maxValues)
        {
            return (minValues[0] <= color1.A && color1.A <= maxValues[0])
                && (minValues[1] <= color1.R && color1.R <= maxValues[1])
                && (minValues[2] <= color1.G && color1.G <= maxValues[2])
                && (minValues[3] <= color1.B && color1.B <= maxValues[3]);
        }

        public static byte[] GetMinimumValuesFromTolerance(this Color color, byte tolerance)
        {
            return new[] {
                            (byte)(color.A < tolerance ? 0 : (color.A - tolerance)),
                            (byte)(color.R < tolerance ? 0 : (color.R - tolerance)),
                            (byte)(color.G < tolerance ? 0 : (color.G - tolerance)),
                            (byte)(color.B < tolerance ? 0 : (color.B - tolerance))
                        };
        }
        public static byte[] GetMaximumValuesFromTolerance(this Color color, byte tolerance)
        {
            return new[] {
                            (byte)((color.A + tolerance > 255) ? 255 : (color.A + tolerance)),
                            (byte)((color.R + tolerance > 255) ? 255 : (color.R + tolerance)),
                            (byte)((color.G + tolerance > 255) ? 255 : (color.G + tolerance)),
                            (byte)((color.B + tolerance > 255) ? 255 : (color.B + tolerance))
                        };
        }
    }
}
