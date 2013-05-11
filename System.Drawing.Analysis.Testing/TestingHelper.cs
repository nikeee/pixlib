namespace System.Drawing.Analysis.Testing
{
    internal static class TestingHelper
    {
        private const string RelativeTestImagePath = "..\\..\\Resources\\testImage.png";

        public static Bitmap GetTestBitmap()
        {
            return new Bitmap(RelativeTestImagePath);
        }
    }
}