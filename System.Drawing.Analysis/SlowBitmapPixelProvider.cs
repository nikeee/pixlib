using System.IO;

namespace System.Drawing.Analysis
{
    public class SlowBitmapPixelProvider : IPixelProvider
    {
        private readonly Bitmap _bitmap;
        public Bitmap Bitmap { get { return _bitmap; } }

        private bool _disposeBitmapOnFinalize = true;
        public bool DisposeBitmapOnFinalize
        {
            get { return _disposeBitmapOnFinalize; }
            set { _disposeBitmapOnFinalize = value; }
        }

        public Size Size { get; private set; }

        #region Ctors

        public SlowBitmapPixelProvider(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            _bitmap = bitmap;
            Size = _bitmap.Size;
        }

        #endregion

        #region static inits

        public static SlowBitmapPixelProvider FromScreen()
        {
            return FromScreen(Environment.VirtualScreen);
        }
        public static SlowBitmapPixelProvider FromScreen(Rectangle rectangle)
        {
            return FromScreen(rectangle, CopyPixelOperation.SourceCopy);
        }

        private static readonly Color CopyFromScreenFixColor = Color.FromArgb();
        public static SlowBitmapPixelProvider FromScreen(Rectangle rectangle, CopyPixelOperation operation)
        {
            
            if (rectangle.Width < 1)
                throw new InvalidDataException("The width must not be 0 or less.");
            if (rectangle.Height < 1)
                throw new InvalidDataException("The height must not be 0 or less.");

            var bmp = new Bitmap(rectangle.Width, rectangle.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(CopyFromScreenFixColor); // Fixes transparency bug
                g.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bmp.Size, operation);
            }
        }


        #endregion

        public Color GetPixel(int x, int y)
        {
            return _bitmap.GetPixel(x, y);
        }

        public Color GetPixel(Point point)
        {
            return GetPixel(point.X, point.Y);
        }

        public void SetPixel(int x, int y, Color color)
        {
            _bitmap.SetPixel(x, y, color);
        }

        public void SetPixel(Point point, Color color)
        {
            SetPixel(point.X, point.Y, color);
        }

        public Color SwapColor(int x, int y, Color color)
        {
            var c = GetPixel(x, y);
            SetPixel(x, y, color);
            return c;
        }

        #region explicits

        public static explicit operator SlowBitmapPixelProvider(Bitmap bitmap)
        {
            return new SlowBitmapPixelProvider(bitmap);
        }

        #endregion

        #region IDisposable support

        /// <summary>
        /// Checks if the current instance has been disposed. Id so, an <see cref="T:System.ObjectDisposedException">ObjectDisposedException</see> will be thrown.
        /// </summary>
        protected void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("SlowBitmapPixelProvider");
        }

        private bool _disposed;

        /// <summary>Disposes the current object instance.</summary>
        /// <param name="disposing">Determines wheter managed resources should be disposed, too.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                _disposed = true;
        }

        /// <summary>Disposes the current object instance.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}