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
                    throw new IndexOutOfRangeException();
                if (value.Width <= 0 || value.Height <= 0)
                    throw new IndexOutOfRangeException();
                if (value.X + value.Width > _provider.Size.Width)
                    throw new IndexOutOfRangeException();
                if (value.Y + value.Height > _provider.Size.Height)
                    throw new IndexOutOfRangeException();
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
        }

        #endregion

        public IEnumerable<Point> FindPixels(Color color)
        {
            int targetX = _view.X + _view.Width;
            int targetY = _view.Y + _view.Height;

            for (int x = _view.X; x < targetX; ++x)
            {
                for (int y = _view.Y; y < targetY; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (readColor == color)
                        yield return new Point(x, y);
                }
            }
        }

        //see: http://msdn.microsoft.com/en-us/library/bb535050.aspx
        public Point First(Color color)
        {
            // TODO: Take the view into account
            int y;
            for (int x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    if (_provider.GetPixel(x, y) == color)
                        return new Point(x, y);
            throw new InvalidOperationException();
        }

        public Point? FirstOrDefault(Color color)
        {
            // TODO: Take the view into account
            int y;
            for (int x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    if (_provider.GetPixel(x, y) == color)
                        return new Point(x, y);
            return default(Point?);
        }

        public bool All(Color color)
        {
            // TODO: Take the view into account
            int y;
            for (int x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    if (_provider.GetPixel(x, y) != color)
                        return false;
            return true;
        }

        public bool Any(Color color)
        {
            // TODO: Take the view into account
            int y;
            for (int x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    if (_provider.GetPixel(x, y) == color)
                        return true;
            return false;
        }

        public void ForEach(Action<int, int, Color> action)
        {
            // TODO: Take the view into account
            if(action == null)
                throw new ArgumentNullException("action");

            int y;
            for (int x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    action(x, y, _provider.GetPixel(x, y));
        }
    }
}