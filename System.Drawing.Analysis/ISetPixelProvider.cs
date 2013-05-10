namespace System.Drawing.Analysis
{
    public interface ISetPixelProvider
    {
        void SetPixel(int x, int y, Color c);
        void SetPixel(Point p, Color c);
    }
}