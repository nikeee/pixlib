using System.Drawing.Imaging;
using NUnit.Framework;

namespace System.Drawing.Analysis.Testing
{
    [TestFixture]
    public class FastPixelProviderTests
    {
        [Test]
        [Category("PixelProvider")]
        [Category("Fast")]
        public void GetPixelFast()
        {
            GetPixelFastNoPixelFormat();
            GetPixelFast(PixelFormat.Format32bppArgb);
            GetPixelFast(PixelFormat.Format32bppPArgb);
            //GetPixelFast(PixelFormat.Format48bppRgb);
            GetPixelFast(PixelFormat.Format32bppRgb);
        }

        public void GetPixelFastNoPixelFormat()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap())
            {
                using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                {
                    for (int x = 0; x < testBitmap.Width; ++x)
                    {
                        for (int y = 0; y < testBitmap.Height; ++y)
                        {
                            var expected = NativeColor.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actual = fast.GetPixel(x, y);
                            AssertEx.AreEqual<NativeColor>(expected, actual);
                        }
                    }
                }
            }
        }
        public void GetPixelFast(PixelFormat format)
        {
            var testBitmap = TestingHelper.GetTestBitmap(format);
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap(format))
            {
                using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                {
                    for (int x = 0; x < testBitmap.Width; ++x)
                    {
                        for (int y = 0; y < testBitmap.Height; ++y)
                        {
                            var expected = NativeColor.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actual = fast.GetPixel(x, y);
                            AssertEx.AreEqual<NativeColor>(expected, actual);
                        }
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Fast")]
        public void GetPixelFast2()
        {
            var testBitmap = TestingHelper.GetTestBitmap2();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap2())
            {
                using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                {
                    for (int x = 0; x < testBitmap.Width; ++x)
                    {
                        for (int y = 0; y < testBitmap.Height; ++y)
                        {
                            var expected = NativeColor.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actual = fast.GetPixel(x, y);
                            AssertEx.AreEqual<NativeColor>(expected, actual);
                        }
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Fast")]
        public void SetPixelFast()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap())
            {
                using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                {
                    for (int x = 0; x < testBitmap.Width; ++x)
                    {
                        for (int y = 0; y < testBitmap.Height; ++y)
                        {
                            NativeColor expected = TestingHelper.GetRandomColor();
                            testBitmapUnlocked.SetPixel(x, y, expected.ToDrawingColor());
                            fast.SetPixel(x, y, expected);

                            var actualNative = NativeColor.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actualFast = fast.GetPixel(x, y);
                            AssertEx.AreEqual<NativeColor>(expected, actualNative);
                            AssertEx.AreEqual<NativeColor>(expected, actualFast);
                        }
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Fast")]
        public void SetPixelFast2()
        {
            var testBitmap = TestingHelper.GetTestBitmap2();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap2())
            {
                using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                {
                    for (int x = 0; x < testBitmap.Width; ++x)
                    {
                        for (int y = 0; y < testBitmap.Height; ++y)
                        {
                            NativeColor expected = TestingHelper.GetRandomColor();
                            testBitmapUnlocked.SetPixel(x, y, expected.ToDrawingColor());
                            fast.SetPixel(x, y, expected);

                            var actualNative = NativeColor.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actualFast = fast.GetPixel(x, y);
                            AssertEx.AreEqual<NativeColor>(expected, actualNative);
                            AssertEx.AreEqual<NativeColor>(expected, actualFast);
                        }
                    }
                }
            }
        }

        [Test]
        [Category("PixelProvider")]
        [Category("Fast")]
        public void SwapPixelFast()
        {
            for (int i = 0; i < 20; i++)
            {
                SwapPixelInternal();
            }
        }


        private void SwapPixelInternal()
        {
            using (var testBitmap = TestingHelper.GetTestBitmap())
            using (var fast = new FastBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = fast.GetPixel(x, y);
                        var actual = fast.SwapPixel(x, y, TestingHelper.GetRandomColor());
                        AssertEx.AreEqual<NativeColor>(expected, actual);
                    }
                }
            }
        }
    }
}
