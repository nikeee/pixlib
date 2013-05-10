namespace System.Drawing.Analysis
{
    public interface ISetPixelProvider
    {
        void SetPixel(int x, int y, Color color);
        void SetPixel(Point point, Color color);
    }
}