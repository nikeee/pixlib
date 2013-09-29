using System.Collections.Generic;
using System.IO;

namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>Provides scan directions for the <see cref="T:System.Drawing.Analysis.Manipulation.RectangleScanner"/>.</summary>
    public enum RectangleScanDirection
    {
        /// <summary>Scan from left to right.</summary>
        LeftToRight,
        /// <summary>Scan from right to left.</summary>
        RightToLeft,
        /// <summary>Scan from top to bottom.</summary>
        TopToBottom,
        /// <summary>Scan from bottom to top.</summary>
        BottomToTop
    }

    /// <summary>Represents the pixel scanner which provides more customization options than the default pixel scanner.</summary>
    public class RectangleScanner : IPixelScanner
    {
        private readonly IGetPixelProvider _provider;
        private Rectangle _view;

        /// <summary>Gets or sets the area in which the <see cref="T:System.Drawing.Analysis.Manipulation.IPixelScanner"/> instance operates.</summary>
        public Rectangle View
        {
            get { return _view; }
            set
            {
                if (value.X < 0 || value.Y < 0)
                    throw new InvalidOperationException();
                if (value.Width <= 0 || value.Height <= 0)
                    throw new InvalidOperationException();
                if (value.X + value.Width > _provider.Size.Width)
                    throw new InvalidOperationException();
                if (value.Y + value.Height > _provider.Size.Height)
                    throw new InvalidOperationException();
                _view = value;
            }
        }

        /// <summary>The direction the scanner scans while performing operations.</summary>
        public RectangleScanDirection ScanDirection { get; private set; }
        
        #region Ctors

        /// <summary>Creates a new instance of <see cref="T:System.Drawing.Analysis.Manipulation.RectangleScanner"/> using a given <see cref="T:System.Drawing.Analysis.IGetPixelProvider"/> scanning from top to bottom.</summary>
        /// <param name="provider">An <see cref="T:System.Drawing.Analysis.IGetPixelProvider"/> instance</param>
        public RectangleScanner(IGetPixelProvider provider)
            : this(provider, RectangleScanDirection.TopToBottom)
        { }

        /// <summary>Creates a new instance of <see cref="T:System.Drawing.Analysis.Manipulation.RectangleScanner"/> using a given <see cref="T:System.Drawing.Analysis.IGetPixelProvider"/>.</summary>
        /// <param name="provider">An <see cref="T:System.Drawing.Analysis.IGetPixelProvider"/> instance</param>
        /// <param name="scanDirection">The <see cref="T:System.Drawing.Analysis.Manipulation.RectangleScanDirection"/> for the scanner to use.</param>
        public RectangleScanner(IGetPixelProvider provider, RectangleScanDirection scanDirection)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            _provider = provider;
            ScanDirection = scanDirection;
            throw new NotImplementedException();
        }

        #endregion
        
        /// <summary>Filters the pixels matching a color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> that contains <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>s which matched the given color.</returns>
        public IEnumerable<Pixel> FindPixels(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>Filters the pixels matching a color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> that contains <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>s which matched the given color and tolerance.</returns>
        public IEnumerable<Pixel> FindPixels(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        /// <summary>Computes the average color in the current view.</summary>
        /// <returns>The average color.</returns>
        public Color Average()
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/> to find.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel.</returns>
        public Pixel First(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/> to find.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel.</returns>
        public Pixel First(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/> to find.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>.</returns>
        public Pixel? FirstOrDefault(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/> to find.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>.</returns>
        public Pixel? FirstOrDefault(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        /// <summary>Determines whether all pixels of the provider are the same color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        public bool All(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>Determines whether all pixels of the provider are the same color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        public bool All(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        /// <summary>Determines whether any pixel of the provider has this color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <returns>true if any pixel has this color; otherwise, false.</returns>
        public bool Any(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>Determines whether any pixel of the provider has this color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>true if any pixel is this color respecting a given tolerance; otherwise, false.</returns>
        public bool Any(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        /// <summary>Returns the number of pixels in the current view.</summary>
        /// <returns>The number of pixels in the current view.</returns>
        public int Count()
        {
            return _view.Width * _view.Height;
        }

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/>.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/>.</returns>
        public int Count(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/> respecting a tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.Color"/> respecting a tolerance.</returns>
        public int Count(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        /// <summary>Returns the number of pixels in the current view satisfying a condition.</summary>
        /// <param name="condition">A function to test each pixel for a condition.</param>
        /// <returns>A number of pixels in the current view satisfying a condition.</returns>
        public int Count(Func<int, int, Color, bool> condition)
        {
            throw new NotImplementedException();
        }

        /// <summary>Performs the specified action on each pixel in the current view.</summary>
        /// <param name="action">The <see cref="T:System.Action{T}"/> delegate to perform on each pixel.</param>
        public void ForEach(Action<int, int, Color> action)
        {
            throw new NotImplementedException();
        }

        /// <summary>Filters the pixels in the current view based on a predicate.</summary>
        /// <param name="condition">A function to test pixel for a condition.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> that contains <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>s from the input sequence that satisfy the condition.</returns>
        public IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}