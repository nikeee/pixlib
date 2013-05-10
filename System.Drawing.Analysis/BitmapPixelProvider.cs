namespace System.Drawing.Analysis
{
    public class BitmapPixelProvider : IPixelProvider
    {
        // TODO: Implement using LockBits and unsafe pointers

        private readonly Bitmap _bitmap;
        public Bitmap Bitmap { get { return _bitmap; } }

        public BitmapPixelProvider(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            _bitmap = bitmap;
            throw new NotImplementedException();
        }

        public Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Color GetPixel(Point point)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(Point p, Color color)
        {
            throw new NotImplementedException();
        }

        public Color SwapColor(int x, int y, Color color)
        {
            throw new NotImplementedException();
        }

        #region explicits

        public static explicit operator BitmapPixelProvider(Bitmap bitmap)
        {
            return new BitmapPixelProvider(bitmap);
        }

        #endregion
    }
}