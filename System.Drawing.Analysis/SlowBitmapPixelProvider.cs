namespace System.Drawing.Analysis
{
    public class SlowBitmapPixelProvider : IPixelProvider
    {
        private readonly Bitmap _bitmap;
        public Bitmap Bitmap { get { return _bitmap; } }

        public SlowBitmapPixelProvider(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            _bitmap = bitmap;
        }

        public Color GetPixel(int x, int y)
        {
            return _bitmap.GetPixel(x, y);
        }

        public Color GetPixel(Point point)
        {
            return GetPixel(point.X, point.Y);
        }

        public void SetPixel(int x, int y, Color color)
        {
            _bitmap.SetPixel(x, y, color);
        }

        public void SetPixel(Point point, Color color)
        {
            SetPixel(point.X, point.Y, color);
        }


        #region explicits

        public static explicit operator SlowBitmapPixelProvider(Bitmap bitmap)
        {
            return new SlowBitmapPixelProvider(bitmap);
        }

        #endregion

    }
}