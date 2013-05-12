namespace System.Drawing.Analysis.Testing
{
    internal static class TestingHelper
    {
        private const string TestImageExtension = ".bmp";
        private const string RelativeResourcesPath = "..\\..\\Resources\\";
        private const string RelativeTestImagePath = RelativeResourcesPath + "testImage" + TestImageExtension;
        private const string RelativeTestImage2Path = RelativeResourcesPath + "testImage2" + TestImageExtension;

        private static readonly Random Random = new Random();

        public static Bitmap GetTestBitmap()
        {
            return new Bitmap(RelativeTestImagePath);
        }
        public static Bitmap GetTestBitmap2()
        {
            return new Bitmap(RelativeTestImage2Path);
        }

        public static Color GetRandomColor()
        {
            return Color.FromArgb((byte)255, (byte)Random.Next(0, 255), (byte)Random.Next(0, 255), (byte)Random.Next(0, 255));
        }
    }
}