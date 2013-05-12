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
            var buffer = new byte[4];
            Random.NextBytes(buffer);
            buffer[0] = 255;
            return Color.FromArgb(buffer[0], buffer[1], buffer[2], buffer[3]);
        }

        public static bool GetRandomBool()
        {
            return Random.Next(0, 2) == 1;
        }
    }
}