using System.Drawing.Imaging;

namespace System.Drawing.Analysis.Testing
{
    internal static class TestingHelper
    {
        private const string TestImageExtension = ".png";
        private const string RelativeResourcesPath = "..\\..\\Resources\\";

        private const string RelativeTestImagePath = RelativeResourcesPath + "testImage" + TestImageExtension;
        private const string RelativeTestImage2Path = RelativeResourcesPath + "testImage2" + TestImageExtension;
        private const string RelativeTolerancePath = RelativeResourcesPath + "tolreanceTest" + TestImageExtension;

        private static readonly Random Random = new Random();

        public static Bitmap GetTestBitmap()
        {
            return new Bitmap(RelativeTestImagePath);
        }
        public static Bitmap GetTestBitmap(PixelFormat format)
        {
            using (var orig = GetTestBitmap())
            {
                var clone = new Bitmap(orig.Width, orig.Height, format);
                using (var g = Graphics.FromImage(clone))
                    g.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                return clone;
            }
        }

        public static Bitmap GetTestBitmap2()
        {
            return new Bitmap(RelativeTestImage2Path);
        }
        public static Bitmap GetToleranceBitmap()
        {
            return new Bitmap(RelativeTolerancePath);
        }

        public static Color GetRandomColor()
        {
            var buffer = Random.Next(int.MaxValue);
            return new Color(buffer);
        }

        public static bool GetRandomBool()
        {
            return Random.Next(0, 2) == 1;
        }
    }
}
