namespace System.Drawing.Analysis.Manipulation
{
    public class DefaultReplacer : DefaultScanner, IPixelReplacer
    {
        private IPixelProvider _provider;

        #region Ctors

        public DefaultReplacer(IPixelProvider provider)
            : base(provider)
        {
            _provider = provider;
        }

        #endregion

        public void Clear(Color color)
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