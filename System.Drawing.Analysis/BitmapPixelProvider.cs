// TODO: Implement using LockBits and unsafe pointers

namespace System.Drawing.Analysis
{
    public class BitmapPixelProvider : IPixelProvider
    {
        private readonly Bitmap _bitmap;
        public Bitmap Bitmap { get { return _bitmap; } }
        
        public Size Size { get; private set; }

        public bool DisposeBitmapOnFinalize { get; set; }

        #region Ctors
        
        public BitmapPixelProvider(Bitmap bitmap)
            : this(bitmap, true)
        { }

        public BitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            _bitmap = bitmap;
            Size = _bitmap.Size;
            DisposeBitmapOnFinalize = disposeBitmapOnFinalize;
        }

        #endregion
        #region Static Inits
        
        public static BitmapPixelProvider FromScreen()
        {
            return FromScreen(Environment.VirtualScreen);
        }

        public static BitmapPixelProvider FromScreen(Rectangle rectangle)
        {
            return FromScreen(rectangle, CopyPixelOperation.SourceCopy);
        }

        public static BitmapPixelProvider FromScreen(Rectangle rectangle, CopyPixelOperation operation)
        {
            if (rectangle.Width < 1)
                throw new ArgumentException("The width must not be 0 or less.");
            if (rectangle.Height < 1)
                throw new ArgumentException("The height must not be 0 or less.");

            using (var bmp = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(GdiConstants.CopyFromScreenBugFixColor);
                    g.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bmp.Size, operation);
                    return new BitmapPixelProvider(bmp.Clone() as Bitmap, true);
                }
            }
        }

        #endregion
        #region GetPixel

        public Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Color GetPixel(Point point)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region SetPixel

        public void SetPixel(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(Point point, Color color)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        public Color SwapColor(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        #region explicits

        public static explicit operator BitmapPixelProvider(Bitmap bitmap)
        {
            return new BitmapPixelProvider(bitmap);
        }

        #endregion
        #region IDisposable support

        ///// <summary>
        ///// Checks if the current instance has been disposed. Id so, an <see cref="T:System.ObjectDisposedException">ObjectDisposedException</see> will be thrown.
        ///// </summary>
        //protected void CheckDisposed()
        //{
        //    if (_disposed)
        //        throw new ObjectDisposedException("BitmapPixelProvider");
        //}

        private bool _disposed;

        /// <summary>Disposes the current object instance.</summary>
        /// <param name="disposing">Determines wheter managed resources should be disposed, too.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (DisposeBitmapOnFinalize && _bitmap != null)
                    _bitmap.Dispose();
            }
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