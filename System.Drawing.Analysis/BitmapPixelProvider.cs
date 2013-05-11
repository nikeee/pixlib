namespace System.Drawing.Analysis
{
    public abstract class BitmapPixelProvider : IDisposable
    {
        protected readonly Bitmap InternalBitmap;
        public Bitmap Bitmap { get { return InternalBitmap; } }

        public bool DisposeBitmapOnFinalize { get; set; }

        protected BitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            InternalBitmap = bitmap;
            DisposeBitmapOnFinalize = disposeBitmapOnFinalize;
        }

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
                if (InternalBitmap != null)
                {
                    if (DisposeBitmapOnFinalize)
                        InternalBitmap.Dispose();
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