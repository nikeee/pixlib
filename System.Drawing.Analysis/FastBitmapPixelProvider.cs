using System.Drawing.Imaging;
using System.Security;

namespace System.Drawing.Analysis
{
    public class FastBitmapPixelProvider : BitmapPixelProvider, IPixelProvider
    {
        private readonly Rectangle _bitmapDimensions;
        private BitmapData _bitmapData;

        private IntPtr _scan0;

        private const int PixelSize = 4;

        #region Ctors

        public FastBitmapPixelProvider(Bitmap bitmap)
            : this(bitmap, true)
        { }

        public FastBitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
            : base(bitmap, disposeBitmapOnFinalize)
        {
            _bitmapDimensions = new Rectangle(Point.Empty, Bitmap.Size);
            Lock();
        }

        #endregion
        #region Lock/Unlock

        private bool _isLocked;
        private void Lock()
        {
            if (_isLocked)
                throw new InvalidOperationException();
            _bitmapData = Bitmap.LockBits(_bitmapDimensions, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            _scan0 = _bitmapData.Scan0;
            _isLocked = true;
        }
        private void Unlock()
        {
            if (!_isLocked)
                throw new InvalidOperationException();
            Bitmap.UnlockBits(_bitmapData);
            _isLocked = false;
        }

        #endregion
        #region Static Inits

        public static FastBitmapPixelProvider FromScreen()
        {
            return FromScreen(Environment.VirtualScreen);
        }

        public static FastBitmapPixelProvider FromScreen(Rectangle rectangle)
        {
            return FromScreen(rectangle, CopyPixelOperation.SourceCopy);
        }

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

        internal unsafe Color GetPixelInternal(int x, int y)
        {
            int index = (((y * Size.Width) + x) * PixelSize) + 4;
            byte* p = (byte*)_scan0;
            return Color.FromArgb(
                    p[--index],
                    p[--index],
                    p[--index],
                    p[--index]
                );
        }

        public Color GetPixel(int x, int y)
        {
            if (x >= Size.Width || y >= Size.Height)
                throw new InvalidOperationException();
            return GetPixelInternal(x, y);
        }

        public Color GetPixel(Point point)
        {
            return GetPixel(point.X, point.Y);
        }

        #endregion
        #region SetPixel

        // TODO: Testing
        internal unsafe void SetPixelInternal(int x, int y, Color color)
        {
            int index = (((y * Size.Width) + x) * PixelSize) + 4;
            byte* p = (byte*)_scan0;
            p[--index] = color.A;
            p[--index] = color.R;
            p[--index] = color.G;
            p[--index] = color.B;
        }

        // TODO: Testing
        public void SetPixel(int x, int y, Color color)
        {
            if (x >= Size.Width || y >= Size.Height)
                throw new InvalidOperationException();
            SetPixelInternal(x, y, color);
        }

        // TODO: Testing
        public void SetPixel(Point point, Color color)
        {
            SetPixel(point.X, point.Y, color);
        }

        #endregion
        #region IPixelProvider
        
        private unsafe Color SwapPixelInternal(int x, int y, Color color)
        {
            int index = (((y * Size.Width) + x) * PixelSize) + 4;
            byte* p = ((byte*)_scan0);

            int a = p[--index];
            int r = p[--index];
            int g = p[--index];
            int b = p[--index];

            p[index] = color.B;
            p[++index] = color.G;
            p[++index] = color.R;
            p[++index] = color.A;

            return Color.FromArgb(a, r, g, b);
        }

        public Color SwapPixel(int x, int y, Color color)
        {
            if (x >= Size.Width || y >= Size.Height)
                throw new InvalidOperationException();
            return SwapPixelInternal(x,y, color);
        }

        #endregion
        #region explicits

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