using System.Drawing.Imaging;

namespace System.Drawing.Analysis.Testing
{
    internal static class TestingHelper
    {
        private const string TestImageExtension = ".png";
        private static readonly string DirectorySeparator = IO.Path.DirectorySeparatorChar.ToString();
        private static readonly string RelativeResourcesPath = string.Format("..{0}..{0}Resources{0}", DirectorySeparator);

        private static readonly string RelativeTestImagePath = RelativeResourcesPath + "testImage" + TestImageExtension;
        private static readonly string RelativeTestImage2Path = RelativeResourcesPath + "testImage2" + TestImageExtension;
        private static readonly string RelativeTolerancePath = RelativeResourcesPath + "tolreanceTest" + TestImageExtension;

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

        public static NativeColor GetRandomColor()
        {
            var buffer = Random.Next(int.MaxValue);
            return new NativeColor(buffer);
        }

        public static bool GetRandomBool()
        {
            return Random.Next(0, 2) == 1;
        }
    }
}
