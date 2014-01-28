namespace System.Drawing.Analysis
{
    /// <summary>Defines GetPixel methods, size and multi threading support for all GetPixelProviders.</summary>
    public interface IGetPixelProvider
    {
        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        bool SupportsGetPixelThreading { get; }

        /// <summary> Gets the width and height, in pixels, of this provider.</summary>
        Size Size { get; }

        /// <summary>Gets The <see cref="T:System.Drawing.Color"/> of the specified pixel in the provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to retrieve.</param>
        /// <param name="y">The y-coordinate of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents The <see cref="T:System.Drawing.Color"/> of the specified pixel.</returns>
        Color GetPixel(int x, int y);

        /// <summary>Gets The <see cref="T:System.Drawing.Color"/> of the specified pixel in the provider.</summary>
        /// <param name="point">The coordinates of the pixel to retrieve.</param>
        /// <returns>A Color structure that represents The <see cref="T:System.Drawing.Color"/> of the specified pixel.</returns>
        Color GetPixel(Point point);

        /// <summary>Copies the entire pixel data to another provider.</summary>
        /// <param name="destination">The destination pixel provider.</param>
        void CopyTo(ISetPixelProvider destination);
    }
}
