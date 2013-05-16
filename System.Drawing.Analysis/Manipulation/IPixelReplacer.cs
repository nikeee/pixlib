namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>Defines methods that can be used to perform replace operations on pixel data.</summary>
    public interface IPixelReplacer : IPixelScanner
    {
        /// <summary>Clears the current view using a specific <see cref="T:System.Drawing.Color"/>.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/>.</param>
        void Clear(Color color);
    }
}