﻿using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    public class DefaultScanner : IPixelScanner
    {
        public Rectangle View { get; set; }

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
            int x;
            int y;
            for (x = 0; x < _provider.Size.Width; ++x)
            {
                for (y = 0; y < _provider.Size.Height; ++y)
                {
                    var readColor = _provider.GetPixel(x, y);
                    if (readColor == color)
                        yield return new Point(x, y);
                }
            }
        }

        //see: http://msdn.microsoft.com/en-us/library/bb535050.aspx
        public Point FirstOrDefault(Color color)
        {
            int x;
            int y;
            for (x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    if (_provider.GetPixel(x, y) == color)
                        return new Point(x, y);
            throw new InvalidOperationException();
        }

        public Point FirstOrDefault(Color color)
        {
            int x;
            int y;
            for (x = 0; x < _provider.Size.Width; ++x)
                for (y = 0; y < _provider.Size.Height; ++y)
                    if (_provider.GetPixel(x, y) == color)
                        return new Point(x, y);
            return default(Point);
        }
    }
}
