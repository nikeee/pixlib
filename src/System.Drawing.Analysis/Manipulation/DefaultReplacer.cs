namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>Provides basic functionality to perform replace operations on pixel data.</summary>
    public class DefaultReplacer : DefaultScanner, IPixelReplacer
    {
        private readonly IPixelProvider _provider;

        #region Ctors

        /// <summary>Creates a new instance of <see cref="T:System.Drawing.Analysis.Manipulation.DefaultReplacer"/> using a given <see cref="T:System.Drawing.Analysis.IPixelProvider"/>.</summary>
        /// <param name="provider">The <see cref="T:System.Drawing.Analysis.IPixelProvider"/>.</param>
        public DefaultReplacer(IPixelProvider provider)
            : base(provider)
        {
            _provider = provider;
        }

        #endregion

        /// <summary>Clears the current view using a specific <see cref="T:System.Drawing.NativeColor"/>.</summary>
        /// <param name="color">The <see cref="T:System.Drawing.NativeColor"/>.</param>
        public void Clear(NativeColor color)
        {
            // TODO: Unit testing
            int targetX = GetTargetX;
            int targetY = GetTargetY;

            var view = View;

            for (int x = view.X; x < targetX; ++x)
            {
                for (int y = view.Y; y < targetY; ++y)
                {
                    _provider.SetPixel(x, y, color);
                }
            }
        }
    }
}
