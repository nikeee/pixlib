namespace System.Drawing.Analysis
{
    public class BitmapPixelProvider : IPixelProvider
    {
        // TODO: Implement using LockBits and unsafe pointers

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
    }
}