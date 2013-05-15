namespace System.Drawing.Analysis
{
    public interface IPixelProvider : IGetPixelProvider, ISetPixelProvider, IDisposable
    {
        Color SwapPixel(int x, int y, Color color);
    }
}