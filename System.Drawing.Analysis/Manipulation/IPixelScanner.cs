using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    // TODO: Maybe add a Pixel-Struct which contains coordinates + color
    public interface IPixelScanner
    {
        Rectangle View { get; set; }

        IEnumerable<Point> FindPixels(Color color);

        Point First(Color color);
        Point? FirstOrDefault(Color color);


        bool All(Color color);
        bool Any(Color color);

        // TODO: Implement
    }
}
