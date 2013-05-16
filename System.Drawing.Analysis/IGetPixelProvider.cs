namespace System.Drawing.Analysis
{
    public interface IGetPixelProvider
    {
        bool SupportsGetPixelThreading { get; }

        Size Size { get; }

        Color GetPixel(int x, int y);
        Color GetPixel(Point point);
    }
}