using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    // Maybe inherit from IEnumerable<Point> or something similar?
    // May provide async operations as well
    public interface IPixelScanner
    {
        /// <summary>Gets or sets the area in which the <see cref="T:IPixelScanner"/> instance operates.</summary>
        Rectangle View { get; set; }

        /// <summary>Filters the pixels matching a color.</summary>
        /// <param name="color">The color.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable<T>"/> that contains <see cref="T:Pixel"/>s which matched the given color.</returns>
        IEnumerable<Pixel> FindPixels(Color color);

        /// <summary>Filters the pixels matching a color respecting a given tolerance.</summary>
        /// <param name="color">The color.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable<T>"/> that contains <see cref="T:Pixel"/>s which matched the given color and tolerance.</returns>
        IEnumerable<Pixel> FindPixels(Color color, ColorTolerance tolerance);

        /// <summary>Computes the average color in the current view.</summary>
        /// <returns>The average color.</returns>
        Color Average();

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel.</returns>
        Pixel First(Color color);

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color respecting a given tolerance.</summary>
        /// <param name="color">The color to find.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel.</returns>
        Pixel First(Color color, ColorTolerance tolerance);

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:Pixel"/>.</returns>
        Pixel? FirstOrDefault(Color color);

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color respecting a given tolerance.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:Pixel"/>.</returns>
        Pixel? FirstOrDefault(Color color, ColorTolerance tolerance);

        /// <summary>Determines whether all pixels of the provider are the same color.</summary>
        /// <param name="color">The color.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        bool All(Color color);

        /// <summary>Determines whether all pixels of the provider are the same color respecting a given tolerance.</summary>
        /// <param name="color">The color.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        bool All(Color color, ColorTolerance tolerance);

        /// <summary>Determines whether any pixel of the provider has this color.</summary>
        /// <param name="color">The color.</param>
        /// <returns>true if any pixel has this color; otherwise, false.</returns>
        bool Any(Color color);

        /// <summary>Determines whether any pixel of the provider has this color respecting a given tolerance.</summary>
        /// <param name="color">The color.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>true if any pixel is this color respecting a given tolerance; otherwise, false.</returns>
        bool Any(Color color, ColorTolerance tolerance);
        
        /// <summary>Returns the number of pixels in the current view.</summary>
        /// <returns>The number of pixels in the current view.</returns>
        int Count();

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/>.</summary>
        /// <param name="color">The color.</param>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/>.</returns>
        int Count(Color color);

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/> respecting a tolerance.</summary>
        /// <param name="color">The color.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/> respecting a tolerance.</returns>
        int Count(Color color, ColorTolerance tolerance);

        /// <summary>Returns the number of pixels in the current view satisfying a condition.</summary>
        /// <param name="condition">A function to test each pixel for a condition.</param>
        /// <returns>A number of pixels in the current view satisfying a condition.</returns>
        int Count(Func<int, int, Color, bool> condition);

        /// <summary>Performs the specified action on each pixel in the current view.</summary>
        /// <param name="action">The <see cref="T:Action<T>"/> delegate to perform on each pixel.</param>
        void ForEach(Action<int, int, Color> action);

        /// <summary>Filters the pixels in the current view based on a predicate.</summary>
        /// <param name="condition">A function to test pixel for a condition.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable<T>"/> that contains <see cref="T:Pixel"/>s from the input sequence that satisfy the condition.</returns>
        IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition);
    }
}