namespace System.Drawing.Analysis
{
    public abstract class BitmapPixelProvider : IDisposable, IPixelProvider
    {
        private readonly Bitmap _internalBitmap;
        public Bitmap Bitmap { get { return _internalBitmap; } }

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


        public abstract bool SupportsGetPixelThreading { get; }

        public abstract Color GetPixel(int x, int y);
        public abstract Color GetPixel(Point point);

        public abstract bool SupportsSetPixelThreading { get; }

        public abstract void SetPixel(int x, int y, Color color);
        public abstract void SetPixel(Point point, Color color);


        public abstract Color SwapPixel(int x, int y, Color color);
    }
}