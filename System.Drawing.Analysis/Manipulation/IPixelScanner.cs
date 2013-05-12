using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    // TODO: Maybe add a Pixel-Struct which contains coordinates + color
    // Maybe inherit from IEnumerable<Point> or something similar?
    // May provide async operations as well
    // TODO: Overloads providing tolerance-options
    public interface IPixelScanner
    {
        Rectangle View { get; set; }

        IEnumerable<Point> FindPixels(Color color);

        Point First(Color color);
        Point? FirstOrDefault(Color color);

        bool All(Color color);
        bool Any(Color color);

        void ForEach(Action<int, int, Color> action);

        IEnumerable<Point> Where(Func<int, int, Color, bool> condition);
    }
}