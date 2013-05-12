using System.Collections.Generic;
using System.Diagnostics;

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
        
        private int GetTargetX()
        {
            return _view.X + _view.Width;
        }
        private int GetTargetY()
        {
            return _view.Y + _view.Height;
        }

        #endregion

        public IEnumerable<Pixel> FindPixels(Color color)
        {
            // TODO: Unit testing
            int targetX = GetTargetX();
            int targetY = GetTargetY();

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

        //see: http://msdn.microsoft.com/en-us/library/bb535050.aspx
        public Pixel First(Color color)
        {
            int targetX = GetTargetX();
            int targetY = GetTargetY();

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color.ValuesEqual(readColor))
                        return new Pixel(x, y, readColor);
                }

            throw new InvalidOperationException();
        }

        public Pixel? FirstOrDefault(Color color)
        {
            int targetX = GetTargetX();
            int targetY = GetTargetY();

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (color.ValuesEqual(readColor))
                        return new Pixel(x, y, readColor);
                }

            return default(Pixel?);
        }

        public bool All(Color color)
        {
            int targetX = GetTargetX();
            int targetY = GetTargetY();

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    if (_provider.GetPixel(x, y) != color)
                        return false;
            return true;
        }

        public bool Any(Color color)
        {
            int targetX = GetTargetX();
            int targetY = GetTargetY();

            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                {
                    if (color.ValuesEqual(_provider.GetPixel(x, y)))
                        return true;
                }
            return false;
        }

        public void ForEach(Action<int, int, Color> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            int targetX = GetTargetX();
            int targetY = GetTargetY();
            for (int x = _view.X; x < targetX; ++x)
                for (int y = _view.Y; y < targetY; ++y)
                    action(x, y, _provider.GetPixel(x, y));
        }

        public IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition");

            int targetX = GetTargetX();
            int targetY = GetTargetY();
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