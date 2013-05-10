using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    public interface IPixelScanner
    {
        Rectangle View { get; set; }

        IEnumerable<Point> FindPixels(Color color);
        Point First(Color color);
        Point FirstOrDefault(Color color);

        // TODO: Implement
    }
}
