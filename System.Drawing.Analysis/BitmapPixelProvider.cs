namespace System.Drawing.Analysis
{
    public abstract class BitmapPixelProvider : IDisposable, IPixelProvider
    {
        private readonly Bitmap _internalBitmap;
        public Bitmap Bitmap { get { return _internalBitmap; } }

        public bool DisposeBitmapOnFinalize { get; set; }

        /// <summary> Gets the width and height, in pixels, of this provider.</summary>
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

        /// <summary>Gets the color of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents the color of the specified pixel.</returns>
        public abstract Color GetPixel(int x, int y);

        /// <summary>Gets the color of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents the color of the specified pixel.</returns>
        public abstract Color GetPixel(Point point);

        public abstract bool SupportsSetPixelThreading { get; }

        /// <summary>Sets the color of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        public abstract void SetPixel(int x, int y, Color color);

        /// <summary>Sets the color of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        public abstract void SetPixel(Point point, Color color);

        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        /// <returns>A Color structure that represents the previous color of the specified pixel.</returns>
        public abstract Color SwapPixel(int x, int y, Color color);
    }
}