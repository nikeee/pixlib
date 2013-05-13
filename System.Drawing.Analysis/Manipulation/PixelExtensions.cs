using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Drawing.Analysis.Manipulation
{
    public static class PixelExtensions
    {
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