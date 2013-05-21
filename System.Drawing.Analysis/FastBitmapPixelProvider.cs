using System.Drawing.Imaging;
using System.Security;

namespace System.Drawing.Analysis
{
    /// <summary>Represents a PixelProvider that uses native pointers and LockBits to retreive the pixel data.</summary>
    public class FastBitmapPixelProvider : BitmapPixelProvider
    {
        private readonly Rectangle _bitmapDimensions;
        private BitmapData _bitmapData;

        [SecurityCritical]
        private unsafe byte* _scan0;

        private const int PixelSize = 4;

        #region Ctors

        /// <summary>Initializes a new instance of the <see cref="T:FastBitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        public FastBitmapPixelProvider(Bitmap bitmap)
            : this(bitmap, true)
        { }

        /// <summary>Initializes a new instance of the <see cref="T:FastBitmapPixelProvider" /> class with the specified bitmap image.</summary>
        /// <param name="bitmap">The bitmap to use</param>
        /// /// <param name="disposeBitmapOnFinalize">A value indicating whether the bitmap object is getting disposed if this <see cref="T:FastBitmapPixelProvider" /> instance is disposed.</param>
        public FastBitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
            : base(bitmap, disposeBitmapOnFinalize)
        {
            _bitmapDimensions = new Rectangle(Point.Empty, Bitmap.Size);
            Lock();
        }

        #endregion
        #region Lock/Unlock

        private bool _isLocked;
        [SecurityCritical]
        private void Lock()
        {
            if (_isLocked)
                throw new InvalidOperationException();
            _bitmapData = Bitmap.LockBits(_bitmapDimensions, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            unsafe
            {
                _scan0 = (byte*)_bitmapData.Scan0.ToPointer();
            }
            _isLocked = true;
        }

        [SecurityCritical]
        private void Unlock()
        {
            if (!_isLocked)
                throw new InvalidOperationException();
            Bitmap.UnlockBits(_bitmapData);
            unsafe
            {
                _scan0 = null;
            }
            _isLocked = false;
        }

        #endregion
        #region Static Inits

        /// <summary>Creates a new <see cref="T:FastBitmapPixelProvider"/> instance using a screenshot of the virtual screen.</summary>
        /// <returns>A new <see cref="T:FastBitmapPixelProvider"/> instance.</returns>
        public static FastBitmapPixelProvider FromScreen()
        {
            return FromScreen(Environment.VirtualScreen);
        }

        /// <summary>Creates a new <see cref="T:FastBitmapPixelProvider"/> instance using a screenshot of a spefic rectangle on the screen.</summary>
        /// <param name="rectangle">The rectangle</param>
        /// <returns>A new <see cref="T:FastBitmapPixelProvider"/> instance.</returns>
        public static FastBitmapPixelProvider FromScreen(Rectangle rectangle)
        {
            return FromScreen(rectangle, CopyPixelOperation.SourceCopy);
        }

        /// <summary>Creates a new <see cref="T:FastBitmapPixelProvider"/> instance using a screenshot of a spefic rectangle on the screen.</summary>
        /// <param name="rectangle">The rectangle</param>
        /// <param name="operation">The <see cref="T:System.Drawing.CopyPixelOperation"/> to use.</param>
        /// <returns>A new <see cref="T:FastBitmapPixelProvider"/> instance.</returns>
        public static FastBitmapPixelProvider FromScreen(Rectangle rectangle, CopyPixelOperation operation)
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
                    return new FastBitmapPixelProvider(bmp.Clone() as Bitmap, true);
                }
            }
        }

        #endregion
        #region GetPixel

        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        public override bool SupportsGetPixelThreading { get { return true; } }

        internal unsafe Color GetPixelInternal(int x, int y)
        {
            int index = PixelSize * Size.Width * y + PixelSize * x + 3;
            return Color.FromArgb(
                    _scan0[index],
                    _scan0[--index],
                    _scan0[--index],
                    _scan0[--index]
                );
        }

        /// <summary>Gets The <see cref="T:System.Drawing.Color"/> of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents The <see cref="T:System.Drawing.Color"/> of the specified pixel.</returns>
        public override Color GetPixel(int x, int y)
        {
            if (x >= Size.Width || y >= Size.Height)
                throw new InvalidOperationException();
            return GetPixelInternal(x, y);
        }

        /// <summary>Gets The <see cref="T:System.Drawing.Color"/> of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents The <see cref="T:System.Drawing.Color"/> of the specified pixel.</returns>
        public override Color GetPixel(Point point)
        {
            return GetPixel(point.X, point.Y);
        }

        /// <summary>Copies the entire pixel data to another provider.</summary>
        /// <param name="destination">The destination pixel provider.</param>
        public override void CopyTo(ISetPixelProvider destination)
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

        #endregion
        #region SetPixel

        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        public override bool SupportsSetPixelThreading { get { return true; } }

        internal unsafe void SetPixelInternal(int x, int y, Color color)
        {
            int index = PixelSize * Size.Width * y + PixelSize * x + 3;
            _scan0[index] = color.A;
            _scan0[--index] = color.R;
            _scan0[--index] = color.G;
            _scan0[--index] = color.B;
        }

        /// <summary>Sets The <see cref="T:System.Drawing.Color"/> of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents The <see cref="T:System.Drawing.Color"/> to assign to the specified pixel.</param>
        public override void SetPixel(int x, int y, Color color)
        {
            if (x >= Size.Width || y >= Size.Height)
                throw new InvalidOperationException();
            SetPixelInternal(x, y, color);
        }

        /// <summary>Sets The <see cref="T:System.Drawing.Color"/> of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A Color structure that represents The <see cref="T:System.Drawing.Color"/> to assign to the specified pixel.</param>
        public override void SetPixel(Point point, Color color)
        {
            SetPixel(point.X, point.Y, color);
        }

        #endregion
        #region IPixelProvider

        private unsafe Color SwapPixelInternal(int x, int y, Color color)
        {
            int index = PixelSize * Size.Width * y + PixelSize * x + 3;

            int a = _scan0[index];
            _scan0[index] = color.A;

            int r = _scan0[--index];
            _scan0[index] = color.R;

            int g = _scan0[--index];
            _scan0[index] = color.G;

            int b = _scan0[--index];
            _scan0[index] = color.B;

            return Color.FromArgb(a, r, g, b);
        }
        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents The <see cref="T:System.Drawing.Color"/> to assign to the specified pixel.</param>
        /// <returns>A Color structure that represents the previous color of the specified pixel.</returns>
        public override Color SwapPixel(int x, int y, Color color)
        {
            if (x >= Size.Width || y >= Size.Height)
                throw new InvalidOperationException();
            return SwapPixelInternal(x, y, color);
        }

        #endregion
        #region explicits

        /// <summary>Explicitly creates a new instance of <see cref="T:FastBitmapPixelProvider"/> using a <see cref="T:System.Drawing.Bitmap"/>.</summary>
        /// <param name="bitmap">The <see cref="T:System.Drawing.Bitmap"/> to use.</param>
        /// <returns>A new instance of <see cref="T:FastBitmapPixelProvider"/></returns>
        /// <remarks>Same as the constructor using only one bitmap parameter.</remarks>
        public static explicit operator FastBitmapPixelProvider(Bitmap bitmap)
        {
            return new FastBitmapPixelProvider(bitmap);
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
            if (disposing)
                if (Bitmap != null)
                    Unlock(); // Unlock Bitmap on Dispose
            _disposed = true;
            base.Dispose(disposing);
        }

        #endregion
    }
}