namespace System.Drawing.Analysis
{
    public class SlowBitmapPixelProvider : IPixelProvider
    {
        public Color GetPixel(int x, int y)
        {
            throw new NotImplementedException();
        }

        public Color GetPixel(Point p)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(int x, int y, Color c)
        {
            throw new NotImplementedException();
        }

        public void SetPixel(Point p, Color c)
        {
            throw new NotImplementedException();
        }
    }
}