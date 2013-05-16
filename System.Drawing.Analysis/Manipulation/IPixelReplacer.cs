namespace System.Drawing.Analysis.Manipulation
{
    public interface IPixelReplacer : IPixelScanner
    {
        void Clear(Color color);
    }
}