// TODO: Implement using LockBits and unsafe pointers

using System.Drawing.Imaging;

namespace System.Drawing.Analysis
{
    public abstract class BitmapPixelProvider : IDisposable
    {
        //public Bitmap Bitmap { get { return InternalBitmap; } }

        public bool DisposeBitmapOnFinalize { get; set; }

        protected readonly Bitmap InternalBitmap;
        protected BitmapPixelProvider(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            InternalBitmap = bitmap;
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
    public class FastBitmapPixelProvider : BitmapPixelProvider, IPixelProvider
    {
        public Size Size { get; private set; }


        private readonly Rectangle _bitmapDimensions;
        private BitmapData _bitmapData;

        #region Ctors
        
        public FastBitmapPixelProvider(Bitmap bitmap)
            : this(bitmap, true)
        { }

        public FastBitmapPixelProvider(Bitmap bitmap, bool disposeBitmapOnFinalize)
            : base(bitmap)
        {
            Size = InternalBitmap.Size;
            DisposeBitmapOnFinalize = disposeBitmapOnFinalize;

            _bitmapDimensions = new Rectangle(Point.Empty, InternalBitmap.Size);
            Lock();
        }

        private bool _isLocked;
        private void Lock()
        {
            if (_isLocked)
                throw new InvalidOperationException();
            _bitmapData = InternalBitmap.LockBits(_bitmapDimensions, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            _isLocked = true;
        }
        private void Unlock()
        {
            if (!_isLocked)
                throw new InvalidOperationException();
            InternalBitmap.UnlockBits(_bitmapData);
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

        public Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Color GetPixel(Point point)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region SetPixel

        public void SetPixel(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(Point point, Color color)
        {
            throw new NotImplementedException();
        }
        
        #endregion
        #region IPixelProvider

        public Color SwapColor(int x, int y, Color color)
        {
            var c = GetPixel(x, y);
            SetPixel(x, y, color);
            return c;
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
                if (InternalBitmap != null)
                    Unlock(); // Unlock Bitmap on Dispose
            _disposed = true;
            base.Dispose(disposing);
        }

        #endregion
    }
}