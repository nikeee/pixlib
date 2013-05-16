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
        public static bool ValuesFitTolerance(this Color color, ColorToleranceBorders borders, ColorTolerance tolerance)// bool ignoreA, bool ignoreR, bool ignoreG, bool ignoreB)
        {
            return (tolerance.IgnoreA || (borders.MinA <= color.A && color.A <= borders.MaxA))
                && (tolerance.IgnoreR || (borders.MinR <= color.R && color.R <= borders.MaxR))
                && (tolerance.IgnoreG || (borders.MinG <= color.G && color.G <= borders.MaxG))
                && (tolerance.IgnoreB || (borders.MinB <= color.B && color.B <= borders.MaxB));
        }
        public static bool ValuesNotFitTolerance(this Color color, ColorToleranceBorders borders, ColorTolerance tolerance)// bool ignoreA, bool ignoreR, bool ignoreG, bool ignoreB)
        {
            return (tolerance.IgnoreA || (borders.MinA > color.A || color.A > borders.MaxA))
                || (tolerance.IgnoreR || (borders.MinR > color.R || color.R > borders.MaxR))
                || (tolerance.IgnoreG || (borders.MinG > color.G || color.G > borders.MaxG))
                || (tolerance.IgnoreB || (borders.MinB > color.B || color.B > borders.MaxB));
        }
    }
}
