namespace System.Drawing.Analysis
{
    /// <summary>Represents a base class implementation for all pixel providers that uses a <see cref="T:System.Drawing.Bitmap"/> object as source.</summary>
    public abstract class BitmapPixelProvider : IDisposable, IPixelProvider
    {
        private readonly Bitmap _internalBitmap;
        /// <summary>Gets the <see cref="T:System.Drawing.Bitmap"/> the current <see cref="T:BitmapPixelProvider" /> instance uses for its pixel data.</summary>
        public Bitmap Bitmap { get { return _internalBitmap; } }

        /// <summary>Gets a value indicating whether the bitmap object is getting disposed if this <see cref="T:BitmapPixelProvider" /> instance is disposed.</summary>
        public bool DisposeBitmapOnFinalize { get; set; }

        /// <summary> Gets the width and height, in pixels, of this provider.</summary>
        public Size Size { get; private set; }

        /// <summary>Initializes a new instance of the <see cref="T:BitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        /// /// <param name="disposeBitmapOnFinalize">A value indicating whether the bitmap object is getting disposed if this <see cref="T:BitmapPixelProvider" /> instance is disposed.</param>
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

        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        public abstract bool SupportsGetPixelThreading { get; }

        /// <summary>Gets The <see cref="T:System.Drawing.Color"/> of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents The <see cref="T:System.Drawing.Color"/> of the specified pixel.</returns>
        public abstract Color GetPixel(int x, int y);

        /// <summary>Gets The <see cref="T:System.Drawing.Color"/> of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents The <see cref="T:System.Drawing.Color"/> of the specified pixel.</returns>
        public abstract Color GetPixel(Point point);

        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        public abstract bool SupportsSetPixelThreading { get; }

        /// <summary>Sets The <see cref="T:System.Drawing.Color"/> of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents The <see cref="T:System.Drawing.Color"/> to assign to the specified pixel.</param>
        public abstract void SetPixel(int x, int y, Color color);

        /// <summary>Sets The <see cref="T:System.Drawing.Color"/> of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A Color structure that represents The <see cref="T:System.Drawing.Color"/> to assign to the specified pixel.</param>
        public abstract void SetPixel(Point point, Color color);

        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents The <see cref="T:System.Drawing.Color"/> to assign to the specified pixel.</param>
        /// <returns>A Color structure that represents the previous color of the specified pixel.</returns>
        public abstract Color SwapPixel(int x, int y, Color color);

        /// <summary>Copies the entire pixel data to another provider.</summary>
        /// <param name="destination">The destination pixel provider.</param>
        public virtual void CopyTo(ISetPixelProvider destination)
        {
            if (Size != destination.Size)
                throw new InvalidOperationException("Unmatiching sizes!");
            int x, y;
            Color c;
            for (y = 0; y < Size.Height; ++y)
                for (x = 0; x < Size.Width; ++x)
                {
                    c = GetPixel(x, y);
                    destination.SetPixel(x, y, c);
                }
        }
    }
}