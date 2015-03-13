using NUnit.Framework;

namespace System.Drawing.Analysis.Testing
{
    [TestFixture]
    public class SlowPixelProviderTests
    {
        [Test]
        [Category("PixelProvider")]
        [Category("Slow")]
        public void GetPixelSlow()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {

                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = NativeColor.FromDrawingColor(testBitmap.GetPixel(x, y));
                        var actual = slow.GetPixel(x, y);
                        AssertEx.AreEqual<NativeColor>(expected, actual);
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Slow")]
        public void GetPixelSlow2()
        {
            var testBitmap = TestingHelper.GetTestBitmap2();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = NativeColor.FromDrawingColor(testBitmap.GetPixel(x, y));
                        var actual = slow.GetPixel(x, y);
                        AssertEx.AreEqual<NativeColor>(expected, actual);
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Slow")]
        public void SetPixelSlow()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        NativeColor expected = TestingHelper.GetRandomColor();
                        slow.SetPixel(x, y, expected);

                        NativeColor actual = slow.GetPixel(x, y);
                        NativeColor actual2 = NativeColor.FromDrawingColor(testBitmap.GetPixel(x, y));

                        AssertEx.AreEqual<NativeColor>(expected, actual2);
                        AssertEx.AreEqual<NativeColor>(expected, actual);
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Slow")]
        public void SetPixelSlow2()
        {
            var testBitmap = TestingHelper.GetTestBitmap2();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        NativeColor expected = TestingHelper.GetRandomColor();
                        slow.SetPixel(x, y, expected);

                        NativeColor actual = slow.GetPixel(x, y);

                        AssertEx.AreEqual<NativeColor>(expected, actual);
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Slow")]
        public void SwapPixelSlow()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        NativeColor c = TestingHelper.GetRandomColor();

                        var expected = slow.GetPixel(x, y);
                        var actual = slow.SwapPixel(x, y, c);
                        AssertEx.AreEqual<NativeColor>(expected, actual);
                    }
                }
            }
        }
    }
}
