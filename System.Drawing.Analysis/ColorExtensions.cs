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
        public static bool ValuesNotEqual(this Color color1, Color color2)
        {
            return color1.A != color2.A
                || color1.R != color2.R
                || color1.G != color2.G
                || color1.B != color2.B;
        }

        // May enhance?
        public static bool ValuesFitTolerance(this Color color, ColorTolerance minValues, ColorTolerance maxValues, ColorTolerance tolerance)// bool ignoreA, bool ignoreR, bool ignoreG, bool ignoreB)
        {
            return (tolerance.IgnoreA || (minValues.A <= color.A && color.A <= maxValues.A))
                && (tolerance.IgnoreR || (minValues.R <= color.R && color.R <= maxValues.R))
                && (tolerance.IgnoreG || (minValues.G <= color.G && color.G <= maxValues.G))
                && (tolerance.IgnoreB || (minValues.B <= color.B && color.B <= maxValues.B));
        }
        public static bool ValuesNotFitTolerance(this Color color, ColorTolerance minValues, ColorTolerance maxValues, ColorTolerance tolerance)// bool ignoreA, bool ignoreR, bool ignoreG, bool ignoreB)
        {
            return (tolerance.IgnoreA || (minValues.A > color.A || color.A > maxValues.A))
               || (tolerance.IgnoreR || (minValues.R > color.R || color.R > maxValues.R))
               || (tolerance.IgnoreG || (minValues.G > color.G || color.G > maxValues.G))
               || (tolerance.IgnoreB || (minValues.B > color.B || color.B > maxValues.B));
        }
    }
}
