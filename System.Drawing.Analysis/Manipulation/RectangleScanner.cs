using System.Collections.Generic;

namespace System.Drawing.Analysis.Manipulation
{
    public class RectangleScanner : IPixelScanner
    {
        public Rectangle View { get; set; }

        private readonly IGetPixelProvider _provider;

        #region Ctors

        public RectangleScanner(IGetPixelProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            _provider = provider;
        }

        #endregion

        public IEnumerable<Point> FindPixels(Color color)
        {
            throw new NotImplementedException();
        }
    }
}