using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    public enum RadialScanDirection
    {
        Clockwise,
        Counterclockwise
    }

    public class RadialScanner : IPixelScanner
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

        public RadialScanDirection ScanDirection { get; private set; }

        private readonly IGetPixelProvider _provider;

        #region Ctors

        public RadialScanner(IGetPixelProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            _provider = provider;
            throw new NotImplementedException();
        }

        #endregion

        public Color Average()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pixel> FindPixels(Color color)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Pixel> FindPixels(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        public Pixel First(Color color)
        {
            throw new NotImplementedException();
        }
        public Pixel First(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        public Pixel? FirstOrDefault(Color color)
        {
            throw new NotImplementedException();
        }
        public Pixel? FirstOrDefault(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        public bool All(Color color)
        {
            throw new NotImplementedException();
        }
        public bool All(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        public bool Any(Color color)
        {
            throw new NotImplementedException();
        }
        public bool Any(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        public void ForEach(Action<int, int, Color> action)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _view.Width * _view.Height;
        }
        public int Count(Color color)
        {
            throw new NotImplementedException();
        }
        public int Count(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }
        public int Count(Func<int, int, Color, bool> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}