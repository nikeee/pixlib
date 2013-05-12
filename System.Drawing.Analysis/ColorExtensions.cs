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

        public static bool ValuesFitTolerance(this Color color, ref ColorTolerance minValues, ref ColorTolerance maxValues, bool ignoreAlpha)
        {
            return (ignoreAlpha || (minValues.A <= color.A && color.A <= maxValues.A))
                && (minValues.R <= color.R && color.R <= maxValues.R)
                && (minValues.G <= color.G && color.G <= maxValues.G)
                && (minValues.B <= color.B && color.B <= maxValues.B);
        }
    }
}
