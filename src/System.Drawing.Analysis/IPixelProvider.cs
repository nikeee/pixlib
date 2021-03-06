namespace System.Drawing.Analysis
{
    /// <summary>Defines SwapPixel methods including Set- and GetPixel methods for all PixelProviders.</summary>
    public interface IPixelProvider : IGetPixelProvider, ISetPixelProvider, IDisposable
    {
        /// <summary>Swaps a pixel color at a specific location with the given one.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> to assign to the specified pixel.</param>
        /// <returns>A NativeColor structure that represents the previous color of the specified pixel.</returns>
        NativeColor SwapPixel(int x, int y, NativeColor color);
    }
}
