using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    public class DefaultScanner : IPixelScanner
    {
        private Rectangle _view;
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

        private readonly IGetPixelProvider _provider;

        #region Ctors

        public DefaultScanner(IGetPixelProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            _provider = provider;
            _view = new Rectangle(0, 0, _provider.Size.Width, _provider.Size.Height);
        }

        #endregion
        #region Helpers

        protected int GetTargetX { get { return _view.X + _view.Width; } }
        protected int GetTargetY { get { return _view.Y + _view.Height; } }

        #endregion

        /// <summary>Computes the average color in the given view.</summary>
        /// <returns>The average color.</returns>
        public Color Average()
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
            return Color.FromArgb((byte)avgA, (byte)avgR, (byte)avgG, (byte)avgB);
        }

        public IEnumerable<Pixel> FindPixels(Color color)
        {
            // TODO: Unit testing
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
            {
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color.ValuesEqual(readColor))
                        yield return new Pixel(x, y, readColor);
                }
            }
        }
        public IEnumerable<Pixel> FindPixels(Color color, ColorTolerance tolerance)
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
                    if (_provider.GetPixel(x, y).ValuesFitTolerance(borders, tolerance))
                        yield return new Pixel(x, y, readColor);
                }
            }
        }

        //see: http://msdn.microsoft.com/en-us/library/bb535050.aspx
        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel.</returns>
        public Pixel First(Color color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color.ValuesEqual(readColor))
                        return new Pixel(x, y, readColor);
                }

            throw new InvalidOperationException();
        }

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color taking care of a given tolerance.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel.</returns>
        public Pixel First(Color color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (_provider.GetPixel(x, y).ValuesFitTolerance(borders, tolerance))
                        return new Pixel(x, y, readColor);
                }

            throw new InvalidOperationException();
        }

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:Pixel"/>.</returns>
        public Pixel? FirstOrDefault(Color color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color.ValuesEqual(readColor))
                        return new Pixel(x, y, readColor);
                }

            return default(Pixel?);
        }

        /// <summary>Gets the first <see cref="T:Pixel"/> matching a specified color taking care of a given tolerance.</summary>
        /// <param name="color">The color to find.</param>
        /// <returns>A <see cref="T:Pixel"/> instance which represents the found pixel. If there is none, the method returns the default value of <see cref="T:Pixel"/>.</returns>
        public Pixel? FirstOrDefault(Color color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (_provider.GetPixel(x, y).ValuesFitTolerance(borders, tolerance))
                        return new Pixel(x, y, readColor);
                }

            return default(Pixel?);
        }

        /// <summary>Determines whether all pixels of the provider are the same color.</summary>
        /// <param name="color">The color.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        public bool All(Color color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (color.ValuesNotEqual(_provider.GetPixel(x, y)))
                        return false;
            return true;
        }

        /// <summary>Determines whether all pixels of the provider are the same color respecting a given tolerance.</summary>
        /// <param name="color">The color.</param>
        /// <param name="tolerance">The tolerance.</param>
        /// <returns>true if every pixel is the same color, or if the sequence is empty; otherwise, false.</returns>
        public bool All(Color color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y).ValuesNotFitTolerance(borders, tolerance)) // FitNot (!)
                        return false;
            return true;
        }

        public bool Any(Color color)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (color.ValuesEqual(_provider.GetPixel(x, y)))
                        return true;
            return false;
        }
        public bool Any(Color color, ColorTolerance tolerance)
        {
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y).ValuesFitTolerance(borders, tolerance))
                        return true;
            return false;
        }

        public void ForEach(Action<int, int, Color> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            int targetX = GetTargetX;
            int targetY = GetTargetY;
            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    action(x, y, _provider.GetPixel(x, y));
        }

        public int Count()
        {
            return _view.Width * _view.Height;
        }
        public int Count(Color color)
        {
            int counter = 0;
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (color.ValuesEqual(_provider.GetPixel(x, y)))
                        ++counter;
            return counter;
        }
        public int Count(Color color, ColorTolerance tolerance)
        {
            int counter = 0;
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            ColorToleranceBorders borders = new ColorToleranceBorders(color, tolerance);

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y).ValuesFitTolerance(borders, tolerance))
                        ++counter;
            return counter;
        }
        public int Count(Func<int, int, Color, bool> condition)
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

        public IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition)
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