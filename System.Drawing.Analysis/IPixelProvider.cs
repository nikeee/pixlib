namespace System.Drawing.Analysis
{
    public interface IPixelProvider : IGetPixelProvider, ISetPixelProvider
    {
        // TODO: Find something that could be used in this interface

        Color SwapColor(int x, int y, Color color);
    }
}