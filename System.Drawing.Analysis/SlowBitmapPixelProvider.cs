namespace System.Drawing.Analysis
{
    /// <summary>Represents a PixelProvider that uses the default GetPixel/SetPixel methods to retreive the pixel data.</summary>
    public class SlowBitmapPixelProvider : BitmapPixelProvider
    {
        #region Ctors

        /// <summary>Initializes a new instance of the <see cref="T:SlowBitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        public SlowBitmapPixelProvider(Bitmap bitmap)
            : this(bitmap, true)
        { }

        /// <summary>Initializes a new instance of the <see cref="T:SlowBitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        /// /// <param name="disposeBitmapOnFinalize">A value indicating whether the bitmap object is getting disposed if this <see cref="T:SlowBitmapPixelProvider" /> instance is disposed.</param>
        public SlowBitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
            : base(bitmap, disposeBitmapOnFinalize)
        { }

        #endregion
        #region Static Inits

        /// <summary>Creates a new <see cref="T:SlowBitmapPixelProvider"/> instance using a screenshot of the virtual screen.</summary>
        /// <returns>A new <see cref="T:SlowBitmapPixelProvider"/> instance.</returns>
        public static SlowBitmapPixelProvider FromScreen()
        {
            return FromScreen(Environment.VirtualScreen);
        }

        /// <summary>Creates a new <see cref="T:SlowBitmapPixelProvider"/> instance using a screenshot of a spefic rectangle on the screen.</summary>
        /// <param name="rectangle">The rectangle</param>
        /// <returns>A new <see cref="T:SlowBitmapPixelProvider"/> instance.</returns>
        public static SlowBitmapPixelProvider FromScreen(Rectangle rectangle)
        {
            return FromScreen(rectangle, CopyPixelOperation.SourceCopy);
        }

        /// <summary>Creates a new <see cref="T:SlowBitmapPixelProvider"/> instance using a screenshot of a spefic rectangle on the screen.</summary>
        /// <param name="rectangle">The rectangle</param>
        /// <param name="operation">The <see cref="T:System.Drawing.CopyPixelOperation"/> to use.</param>
        /// <returns>A new <see cref="T:SlowBitmapPixelProvider"/> instance.</returns>
        public static SlowBitmapPixelProvider FromScreen(Rectangle rectangle, CopyPixelOperation operation)
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
                    return new SlowBitmapPixelProvider(bmp.Clone() as Bitmap, true);
                }
            }
        }

        #endregion
        #region GetPixel

        public override bool SupportsGetPixelThreading { get { return false; } }

        /// <summary>Gets the color of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents the color of the specified pixel.</returns>
        public override Color GetPixel(int x, int y)
        {
            return Bitmap.GetPixel(x, y);
        }

        /// <summary>Gets the color of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents the color of the specified pixel.</returns>
        public override Color GetPixel(Point point)
        {
            return GetPixel(point.X, point.Y);
        }

        #endregion
        #region SetPixel

        public override bool SupportsSetPixelThreading { get { return false; } }

        /// <summary>Sets the color of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        public override void SetPixel(int x, int y, Color color)
        {
            Bitmap.SetPixel(x, y, color);
        }

        /// <summary>Sets the color of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        public override void SetPixel(Point point, Color color)
        {
            SetPixel(point.X, point.Y, color);
        }

        #endregion
        #region IPixelProvider

        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        /// <returns>A Color structure that represents the previous color of the specified pixel.</returns>
        public override Color SwapPixel(int x, int y, Color color)
        {
            var c = GetPixel(x, y);
            SetPixel(x, y, color);
            return c;
        }

        #endregion
        #region explicits

        public static explicit operator SlowBitmapPixelProvider(Bitmap bitmap)
        {
            return new SlowBitmapPixelProvider(bitmap);
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
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;
            base.Dispose(disposing);
        }

        #endregion

    }
}