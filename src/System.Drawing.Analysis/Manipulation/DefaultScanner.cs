using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>Represents the default pixel scanner.</summary>
    public class DefaultScanner : IPixelScanner
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


        #region Ctors

        /// <summary>Creates a new instance of <see cref="T:System.Drawing.Analysis.Manipulation.DefaultScanner"/> using a given <see cref="T:System.Drawing.Analysis.IGetPixelProvider"/>.</summary>
        /// <param name="provider">An <see cref="T:System.Drawing.Analysis.IGetPixelProvider"/> instance</param>
        public DefaultScanner(IGetPixelProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            _provider = provider;
            _view = new Rectangle(0, 0, _provider.Size.Width, _provider.Size.Height);
        }

        #endregion
        #region Helpers

        /// <summary>Gets the target x-coordinate for the default scanner for-loop.</summary>
        protected int GetTargetX
        {
#if NET45
            [System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
            get { return _view.X + _view.Width; }
        }

        /// <summary>Gets the target y-coordinate for the default scanner for-loop.</summary>
        protected int GetTargetY
        {
#if NET45
            [System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
            get { return _view.Y + _view.Height; }
        }

        #endregion

        /// <summary>Computes the average color in the current view.</summary>
        /// <returns>The average color.</returns>
        public NativeColor Average()
        {
            uint avgA = 0;
            uint avgR = 0;
            uint avgG = 0;
            uint avgB = 0;

            int targetX = GetTargetX;
            int targetY = GetTargetY;
            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var color = _provider.GetPixel(x, y);
                    avgA += color.A;
                    avgR += color.R;
                    avgG += color.G;
                    avgB += color.B;
                }
            var pixelCount = (uint)Count();
            avgA /= pixelCount;
            avgR /= pixelCount;
            avgG /= pixelCount;
            avgB /= pixelCount;
            return new NativeColor((byte)avgA, (byte)avgR, (byte)avgG, (byte)avgB);
        }

        /// <summary>Filters the pixels matching a color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> that contains <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>s which matched the given color.</returns>
        public IEnumerable<Pixel> FindPixels(NativeColor color)
        {
            // TODO: Unit testing
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
            {
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color == readColor)
                        yield return new Pixel(x, y, readColor);
                }
            }
        }

        /// <summary>Filters the pixels matching a color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> that contains <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>s which matched the given color and tolerance.</returns>
        public IEnumerable<Pixel> FindPixels(NativeColor color, ColorTolerance tolerance)
        {
            // TODO: Unit testing
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
            {
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (_provider.GetPixel(x, y).FitsTolerance(borders, tolerance))
                        yield return new Pixel(x, y, readColor);
                }
            }
        }

        //see: http://msdn.microsoft.com/en-us/library/bb535050.aspx
        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/> to find.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel.</returns>
        public Pixel First(NativeColor color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color == readColor)
                        return new Pixel(x, y, readColor);
                }

            throw new InvalidOperationException();
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color taking care of a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/> to find.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel.</returns>
        public Pixel First(NativeColor color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (_provider.GetPixel(x, y).FitsTolerance(borders, tolerance))
                        return new Pixel(x, y, readColor);
                }

            throw new InvalidOperationException();
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/> to find.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>.</returns>
        public Pixel? FirstOrDefault(NativeColor color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color == readColor)
                        return new Pixel(x, y, readColor);
                }

            return default(Pixel?);
        }

        /// <summary>Gets the first <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> matching a specified color taking care of a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/> to find.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>A <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>.</returns>
        public Pixel? FirstOrDefault(NativeColor color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (_provider.GetPixel(x, y).FitsTolerance(borders, tolerance))
                        return new Pixel(x, y, readColor);
                }

            return default(Pixel?);
        }

        /// <summary>Determines whether all pixels of the provider are the same color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        public bool All(NativeColor color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (color != _provider.GetPixel(x, y))
                        return false;
            return true;
        }

        /// <summary>Determines whether all pixels of the provider are the same color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        public bool All(NativeColor color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y).NotFitsTolerance(borders, tolerance)) // FitNot (!)
                        return false;
            return true;
        }

        /// <summary>Determines whether any pixel of the provider has this color.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <returns>true if any pixel has this color; otherwise, false.</returns>
        public bool Any(NativeColor color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (color == _provider.GetPixel(x, y))
                        return true;
            return false;
        }

        /// <summary>Determines whether any pixel of the provider has this color respecting a given tolerance.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>true if any pixel is this color respecting a given tolerance; otherwise, false.</returns>
        public bool Any(NativeColor color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y).FitsTolerance(borders, tolerance))
                        return true;
            return false;
        }

        /// <summary>Returns the number of pixels in the current view.</summary>
        /// <returns>The number of pixels in the current view.</returns>
        public int Count()
        {
            return _view.Width * _view.Height;
        }

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.NativeColor"/>.</summary>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.NativeColor"/>.</returns>
        public int Count(NativeColor color)
        {
            int counter = 0;
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (color == _provider.GetPixel(x, y))
                        ++counter;
            return counter;
        }

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.NativeColor"/>.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        /// <param name="tolerance">The <see cref="T:System.Drawing.Analysis.ColorTolerance"/>.</param>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.NativeColor"/>.</returns>
        public int Count(NativeColor color, ColorTolerance tolerance)
        {
            int counter = 0;
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y).FitsTolerance(borders, tolerance))
                        ++counter;
            return counter;
        }

        /// <summary>Returns the number of pixels in the current view matching a given <see cref="T:System.Drawing.NativeColor"/> respecting a tolerance.</summary>
        /// <param name="condition">A function to test each pixel for a condition.</param>
        /// <returns>The number of pixels in the current view matching a given <see cref="T:System.Drawing.NativeColor"/> respecting a tolerance.</returns>
        public int Count(Func<int, int, NativeColor, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition");

            int counter = 0;
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (condition(x, y, _provider.GetPixel(x, y)))
                        ++counter;
            return counter;
        }

        /// <summary>Performs the specified action on each pixel in the current view.</summary>
        /// <param name="action">The <see cref="T:System.Action{T}"/> delegate to perform on each pixel.</param>
        public void ForEach(Action<int, int, NativeColor> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            int targetX = GetTargetX;
            int targetY = GetTargetY;
            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    action(x, y, _provider.GetPixel(x, y));
        }

        /// <summary>Filters the pixels in the current view based on a predicate.</summary>
        /// <param name="condition">A function to test pixel for a condition.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> that contains <see cref="T:System.Drawing.Analysis.Manipulation.Pixel"/>s from the input sequence that satisfy the condition.</returns>
        public IEnumerable<Pixel> Where(Func<int, int, NativeColor, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition");

            int targetX = GetTargetX;
            int targetY = GetTargetY;
            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var color = _provider.GetPixel(x, y);
                    if (condition(x, y, color))
                        yield return new Pixel(x, y, color);
                }
        }
    }
}
