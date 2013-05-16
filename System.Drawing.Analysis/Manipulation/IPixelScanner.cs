using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    // Maybe inherit from IEnumerable<Point> or something similar?
    // May provide async operations as well
    public interface IPixelScanner
    {
        Rectangle View { get; set; }

        IEnumerable<Pixel> FindPixels(Color color);
        IEnumerable<Pixel> FindPixels(Color color, ColorTolerance tolerance);

        /// <summary>Computes the average color in the given view.</summary>
        /// <returns>The average color.</returns>
        Color Average();

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel.</returns>
        Pixel First(Color color);

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color taking care of a given tolerance.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel.</returns>
        Pixel First(Color color, ColorTolerance tolerance);

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:Pixel"/>.</returns>
        Pixel? FirstOrDefault(Color color);

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color taking care of a given tolerance.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:Pixel"/>.</returns>
        Pixel? FirstOrDefault(Color color, ColorTolerance tolerance);

        /// <summary>Determines whether all pixels of the provider are the same color.</summary>
        /// <param name="color">The color.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        bool All(Color color);
        bool All(Color color, ColorTolerance tolerance);

        bool Any(Color color);
        bool Any(Color color, ColorTolerance tolerance);
        
        int Count();
        int Count(Color color);
        int Count(Color color, ColorTolerance tolerance);
        int Count(Func<int, int, Color, bool> condition);

        void ForEach(Action<int, int, Color> action);

        IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition);
    }
}