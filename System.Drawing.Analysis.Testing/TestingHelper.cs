namespace System.Drawing.Analysis.Testing
{
    internal static class TestingHelper
    {
        private const string RelativeResourcesPath = "..\\..\\Resources\\";
        private const string RelativeTestImagePath = RelativeResourcesPath + "testImage.png";
        private const string RelativeTestImage2Path = RelativeResourcesPath + "testImage2.png";

        public static Bitmap GetTestBitmap()
        {
            return new Bitmap(RelativeTestImagePath);
        }
        public static Bitmap GetTestBitmap2()
        {
            return new Bitmap(RelativeTestImage2Path);
        }
    }
}