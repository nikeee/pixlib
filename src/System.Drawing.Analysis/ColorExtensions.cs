namespace System.Drawing.Analysis
{
    /// <summary>Provides extension methods for the <see cref="T:System.Drawing.Color"/> type.</summary>
    public static class ColorExtensions
    {
        /// <summary>Indicates whether the channel values of two colors are equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Color"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are equal.</returns>
        //public static bool ValuesEqual(this Color color1, Color color2)
        //{
        //    return color1.A == color2.A
        //        && color1.R == color2.R
        //        && color1.G == color2.G
        //        && color1.B == color2.B;
        //}

        /// <summary>Indicates whether the channel values of two colors are not equal.</summary>
        /// <param name="color1">The first <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="color2">The second <see cref="T:System.Drawing.Color"/>.</param>
        /// <returns>A value that indicates whether the channel values of two colors are not equal.</returns>
        //public static bool ValuesNotEqual(this Color color1, Color color2)
        //{
        //    return color1.A != color2.A
        //        || color1.R != color2.R
        //        || color1.G != color2.G
        //        || color1.B != color2.B;
        //}

        /// <summary>Indicates whether a <see cref="T:System.Drawing.Color"/> fits within a set of <see cref="T:System.Drawing.Analysis.ColorToleranceBorders"/>.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="borders">The <see cref="T:System.Drawing.Analysis.ColorToleranceBorders"/> to check the color for.</param>
        /// <param name="tolerance">The initial <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>A value which indicates whether a <see cref="T:System.Drawing.Color"/> fits within a set of <see cref="T:System.Drawing.Analysis.ColorToleranceBorders"/>.</returns>
        public static bool ValuesFitTolerance(this Color color, ColorToleranceBorders borders, ColorTolerance tolerance)
        {
            // May enhance?
            return (tolerance.IgnoreA || (borders.MinA <= color.A && color.A <= borders.MaxA))
                && (tolerance.IgnoreR || (borders.MinR <= color.R && color.R <= borders.MaxR))
                && (tolerance.IgnoreG || (borders.MinG <= color.G && color.G <= borders.MaxG))
                && (tolerance.IgnoreB || (borders.MinB <= color.B && color.B <= borders.MaxB));
        }

        /// <summary>Indicates whether a <see cref="T:System.Drawing.Color"/> does not fit within a set of <see cref="T:System.Drawing.Analysis.ColorToleranceBorders"/>.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="borders">The <see cref="T:System.Drawing.Analysis.ColorToleranceBorders"/> to check the color for.</param>
        /// <param name="tolerance">The initial <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>A value which indicates whether a <see cref="T:System.Drawing.Color"/> does not fit within a set of <see cref="T:System.Drawing.Analysis.ColorToleranceBorders"/>.</returns>
        public static bool ValuesNotFitTolerance(this Color color, ColorToleranceBorders borders, ColorTolerance tolerance)
        {
            return (tolerance.IgnoreA || (borders.MinA > color.A || color.A > borders.MaxA))
                || (tolerance.IgnoreR || (borders.MinR > color.R || color.R > borders.MaxR))
                || (tolerance.IgnoreG || (borders.MinG > color.G || color.G > borders.MaxG))
                || (tolerance.IgnoreB || (borders.MinB > color.B || color.B > borders.MaxB));
        }
    }
}
