namespace System.Drawing.Analysis
{
    public interface ISetPixelProvider
    {
        bool SupportsSetPixelThreading { get; }

        /// <summary> Gets the width and height, in pixels, of this provider.</summary>
        Size Size { get; }

        /// <summary>Sets the color of the specified pixel in this provider.</summary>
        /// <param name="x">The x-coordinate of the pixel to set.</param>
        /// <param name="y">The y-coordinate of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        void SetPixel(int x, int y, Color color);

        /// <summary>Sets the color of the specified pixel in this provider.</summary>
        /// <param name="point">The coordinates of the pixel to set.</param>
        /// <param name="color">A Color structure that represents the color to assign to the specified pixel.</param>
        void SetPixel(Point point, Color color);
    }
}