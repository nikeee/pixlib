namespace System.Drawing.Analysis
{
    public interface IGetPixelProvider
    {
        Size Size { get; }

        Color GetPixel(int x, int y);
        Color GetPixel(Point point);
    }
}