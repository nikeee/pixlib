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

        IEnumerable<Pixel> FindPixels(Color color);

        Pixel First(Color color);
        Pixel? FirstOrDefault(Color color);

        bool All(Color color);
        bool Any(Color color);

        void ForEach(Action<int, int, Color> action);

        IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition);
    }
}