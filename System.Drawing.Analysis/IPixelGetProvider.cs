namespace System.Drawing.Analysis
{
    public interface IGetPixelProvider
    {
        Color GetPixel(int x, int y);
        Color GetPixel(Point p);
    }
}
