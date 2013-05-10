namespace System.Drawing.Analysis
{
    public class BitmapPixelProvider : IPixelProvider
    {
        // TODO: Implement using LockBits and unsafe pointers

        private readonly Bitmap _bitmap;
        public Bitmap Bitmap { get { return _bitmap; } }
        
        public Size Size { get; private set; }

        private bool _disposeBitmapOnFinalize = true;
        public bool DisposeBitmapOnFinalize
        {
            get { return _disposeBitmapOnFinalize; }
            set { _disposeBitmapOnFinalize = value; }
        }

        #region Ctors

        public BitmapPixelProvider(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            _bitmap = bitmap;
            Size = _bitmap.Size;
        }

        #endregion

        public Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Color GetPixel(Point point)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(Point point, Color color)
        {
            throw new NotImplementedException();
        }

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

        /// <summary>
        /// Checks if the current instance has been disposed. Id so, an <see cref="T:System.ObjectDisposedException">ObjectDisposedException</see> will be thrown.
        /// </summary>
        protected void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException("BitmapPixelProvider");
        }

        private bool _disposed;

        /// <summary>Disposes the current object instance.</summary>
        /// <param name="disposing">Determines wheter managed resources should be disposed, too.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_disposeBitmapOnFinalize && _bitmap != null)
                        _bitmap.Dispose();
                }
                _disposed = true;
            }
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