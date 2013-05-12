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
        public static bool ToleranceValuesEqual(this Color color1, Color color2, byte[] minValues, byte[] maxValues)
        {
            return (minValues[0] <= color1.A && color1.A <= maxValues[0])
                && (minValues[1] <= color1.R && color1.R <= maxValues[1])
                && (minValues[2] <= color1.G && color1.G <= maxValues[2])
                && (minValues[3] <= color1.B && color1.B <= maxValues[3]);
        }
    }
}
