using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    public class RadialScanner : IPixelScanner
    {
        public Rectangle View { get; set; }

        private readonly IGetPixelProvider _provider;

        #region Ctors

        public RadialScanner(IGetPixelProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            _provider = provider;
            throw new NotImplementedException();
        }

        #endregion

        public IEnumerable<Pixel> FindPixels(Color color)
        {
            throw new NotImplementedException();
        }

        public Pixel First(Color color)
        {
            throw new NotImplementedException();
        }

        public Pixel? FirstOrDefault(Color color)
        {
            throw new NotImplementedException();
        }

        public bool All(Color color)
        {
            throw new NotImplementedException();
        }

        public bool Any(Color color)
        {
            throw new NotImplementedException();
        }

        public bool Any(Color color, ColorTolerance tolerance)
        {
            throw new NotImplementedException();
        }

        public void ForEach(Action<int, int, Color> action)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Color color)
        {
            throw new NotImplementedException();
        }

        public int Count(Func<int, int, Color, bool> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pixel> Where(Func<int, int, Color, bool> condition)
        {
            throw new NotImplementedException();
        }
    }
}