namespace System.Drawing.Analysis.Manipulation
{
    /// <summary>Defines methods that can be used to perform replace operations on pixel data.</summary>
    public interface IPixelReplacer : IPixelScanner
    {
        void Clear(Color color);
    }
}