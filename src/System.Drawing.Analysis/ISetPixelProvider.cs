namespace System.Drawing.Analysis
{
    /// <summary>Defines SetPixel methods, size and multi threading support for all SetPixelProviders.</summary>
    public interface ISetPixelProvider
    {
        /// <summary>Gets a value indicating whether the current provider supports multiple threads.</summary>
        bool SupportsSetPixelThreading { get; }

        /// <summary> Gets the width and height, in pixels, of this provider.</summary>
        Size Size { get; }

        /// <summary>Sets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> to assign to the specified pixel.</param>
        void SetPixel(int x, int y, NativeColor color);

        /// <summary>Sets The <see cref="T:System.Drawing.Analysis.NativeColor"/> of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A NativeColor structure that represents The <see cref="T:System.Drawing.Analysis.NativeColor"/> to assign to the specified pixel.</param>
        void SetPixel(Point point, NativeColor color);
    }
}
