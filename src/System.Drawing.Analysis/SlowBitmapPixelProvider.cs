namespace System.Drawing.Analysis
{
    /// <summary>Represents a PixelProvider that uses the default GetPixel/SetPixel methods to retreive the pixel data.</summary>
    public class SlowBitmapPixelProvider : BitmapPixelProvider
    {
        #region Ctors

        /// <summary>Initializes a new instance of the <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        public SlowBitmapPixelProvider(Bitmap bitmap)
            : this(bitmap, true)
        { }

        /// <summary>Initializes a new instance of the <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        /// /// <param name="disposeBitmapOnFinalize">A value indicating whether the bitmap object is getting disposed if this <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider" /> instance is disposed.</param>
        public SlowBitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
            : base(bitmap, disposeBitmapOnFinalize)
        { }

        #endregion
        #region Static Inits

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> instance using a screenshot of the virtual screen.</summary>
        /// <returns>A new <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> instance.</returns>
        public static SlowBitmapPixelProvider FromScreen()
        {
            return FromScreen(Environment.VirtualScreen);
        }

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> instance using a screenshot of a spefic rectangle on the screen.</summary>
        /// <param name="rectangle">The rectangle</param>
        /// <returns>A new <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> instance.</returns>
        public static SlowBitmapPixelProvider FromScreen(Rectangle rectangle)
        {
            return FromScreen(rectangle, CopyPixelOperation.SourceCopy);
        }

        /// <summary>Creates a new <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> instance using a screenshot of a spefic rectangle on the screen.</summary>
        /// <param name="rectangle">The rectangle</param>
        /// <param name="operation">The <see cref="T:System.Drawing.CopyPixelOperation"/> to use.</param>
        /// <returns>A new <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> instance.</returns>
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
                    g.Clear(GdiConstants.CopyFromScreenBugFixColor.ToDrawingColor());
                    g.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bmp.Size, operation);
                    return new SlowBitmapPixelProvider(bmp.Clone() as Bitmap, true);
                }
            }
        }

        #endregion
        #region GetPixel

        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        public override bool SupportsGetPixelThreading { get { return false; } }

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel.</returns>
#if NET45
        [System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        public override NativeColor GetPixel(int x, int y)
        {
            return NativeColor.FromDrawingColor(Bitmap.GetPixel(x, y));
        }

        /// <summary>Gets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel.</returns>
#if NET45
        [System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        public override NativeColor GetPixel(Point point)
        {
            return NativeColor.FromDrawingColor(Bitmap.GetPixel(point.X, point.Y));
        }

        #endregion
        #region SetPixel

        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        public override bool SupportsSetPixelThreading { get { return false; } }

        /// <summary>Sets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> to assign to the specified pixel.</param>
#if NET45
        [System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        public override void SetPixel(int x, int y, NativeColor color)
        {
            Bitmap.SetPixel(x, y,  color.ToDrawingColor());
        }

        /// <summary>Sets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> to assign to the specified pixel.</param>
#if NET45
        [System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        public override void SetPixel(Point point, NativeColor color)
        {
            Bitmap.SetPixel(point.X, point.Y, color.ToDrawingColor());
        }

        #endregion
        #region IPixelProvider

        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> to assign to the specified pixel.</param>
        /// <returns>A NativeColor structure that represents the previous color of the specified pixel.</returns>
        public override NativeColor SwapPixel(int x, int y, NativeColor color)
        {
            var c = GetPixel(x, y);
            SetPixel(x, y, color);
            return c;
        }

        #endregion
        #region explicits

        /// <summary>Explicitly creates a new instance of <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/> using a <see cref="T:System.Drawing.Bitmap"/>.</summary>
        /// <param name="bitmap">The <see cref="T:System.Drawing.Bitmap"/> to use.</param>
        /// <returns>A new instance of <see cref="T:System.Drawing.Analysis.SlowBitmapPixelProvider"/></returns>
        /// <remarks>Same as the constructor using only one bitmap parameter.</remarks>
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
