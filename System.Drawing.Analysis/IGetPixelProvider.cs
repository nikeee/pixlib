namespace System.Drawing.Analysis
{
    public interface IGetPixelProvider
    {
        bool SupportsGetPixelThreading { get; }

        /// <summary> Gets the width and height, in pixels, of this provider.</summary>
        Size Size { get; }

        /// <summary>Gets the color of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents the color of the specified pixel.</returns>
        Color GetPixel(int x, int y);

        /// <summary>Gets the color of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents the color of the specified pixel.</returns>
        Color GetPixel(Point point);
    }
}