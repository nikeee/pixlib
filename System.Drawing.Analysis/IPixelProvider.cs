namespace System.Drawing.Analysis
{
    /// <summary>Represents an interface which can get and set pixel data.</summary>
    public interface IPixelProvider : IGetPixelProvider, ISetPixelProvider, IDisposable
    {
        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        /// <returns>A Color structure that represents the previous color of the specified pixel.</returns>
        Color SwapPixel(int x, int y, Color color);
    }
}