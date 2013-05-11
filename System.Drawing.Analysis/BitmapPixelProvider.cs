namespace System.Drawing.Analysis
{
    public abstract class BitmapPixelProvider : IDisposable
    {
        private Bitmap _internalBitmap;
        public Bitmap Bitmap { get { return _internalBitmap; }}

        public bool DisposeBitmapOnFinalize { get; set; }
        public Size Size { get; private set; }

        protected BitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            _internalBitmap = bitmap;
            DisposeBitmapOnFinalize = disposeBitmapOnFinalize;
            Size = bitmap.Size;
        }

        //protected Bitmap GetBitmap()
        //{
        //    return _internalBitmap;
        //}

        #region IDisposable support

        private bool _disposed;

        /// <summary>Disposes the current object instance.</summary>
        /// <param name="disposing">Determines wheter managed resources should be disposed, too.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_internalBitmap != null)
                {
                    if (DisposeBitmapOnFinalize)
                        _internalBitmap.Dispose();
                }
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