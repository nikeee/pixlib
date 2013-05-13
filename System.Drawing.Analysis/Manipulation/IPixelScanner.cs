using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    // Maybe inherit from IEnumerable<Point> or something similar?
    // May provide async operations as well
    public interface IPixelScanner
    {
        Rectangle View { get; set; }

        IEnumerable<Pixel> FindPixels(Color color);
        IEnumerable<Pixel> FindPixels(Color color, ColorTolerance tolerance);

        Color Average();

        Pixel First(Color color);
        Pixel First(Color color, ColorTolerance tolerance);

        Pixel? FirstOrDefault(Color color);
        Pixel? FirstOrDefault(Color color, ColorTolerance tolerance);

        bool All(Color color);
        bool All(Color color, ColorTolerance tolerance);

        bool Any(Color color);
        bool Any(Color color, ColorTolerance tolerance);
        
        int Count();
        int Count(Color color);
        int Count(Color color, ColorTolerance tolerance);
        int Count(Func<int, int, Color, bool> condition);

        void ForEach(Action<int, int, Color> action);

        IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition);
    }
}