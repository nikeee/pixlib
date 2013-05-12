using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    // Maybe inherit from IEnumerable<Point> or something similar?
    // May provide async operations as well
    // TODO: Overloads providing tolerance-options
    public interface IPixelScanner
    {
        Rectangle View { get; set; }

        IEnumerable<Pixel> FindPixels(Color color);

        Pixel First(Color color);
        Pixel? FirstOrDefault(Color color);

        bool All(Color color);

        bool Any(Color color);
        bool Any(Color color, int tolerance);

        void ForEach(Action<int, int, Color> action);

        int Count();
        int Count(Color color);
        int Count(Func<int, int, Color, bool> condition);

        IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition);
    }
}