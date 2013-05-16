namespace System.Drawing.Analysis
{
    public interface ISetPixelProvider
    {
        bool SupportsSetPixelThreading { get; }

        Size Size { get; }

        void SetPixel(int x, int y, Color color);
        void SetPixel(Point point, Color color);
    }
}