using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>Provides extension methods for the <see cref="T:Pixel"/> type.</summary>
    public static class PixelExtensions
    {
        /// <summary>Iterates through a set of <see cref="T:Pixel"/>s and sets the <see cref="T:System.Drawing.Color"/> using a given <see cref="T:ISetPixelProvider"/>.</summary>
        /// <param name="source">The source.</param>
        /// <param name="color">The <see cref="T:System.Drawing.Color"/> to set the <see cref="T:Pixel"/> to.</param>
        /// <param name="provider">The <see cref="T:ISetPixelProvider"/> that will be used to perform the SetPixel operation.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{Pixel}"/> with the new colors set.</returns>
        public static IEnumerable<Pixel> SetColor(this IEnumerable<Pixel> source, Color color, ISetPixelProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            foreach (var item in source)
            {
                provider.SetPixel(item.X, item.Y, color);
                yield return new Pixel(item.X, item.Y, color);
            }
        }
    }
}