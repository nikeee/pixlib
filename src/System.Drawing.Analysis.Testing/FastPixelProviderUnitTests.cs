using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class FastPixelProviderTests
    {
        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Fast")]
        public void GetPixelFast()
        {
            GetPixelFastNoPixelFormat();
            GetPixelFast(PixelFormat.Format32bppArgb);
            GetPixelFast(PixelFormat.Format32bppPArgb);
            GetPixelFast(PixelFormat.Format48bppRgb);
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
                            var expected =Color.FromDrawingColor( testBitmapUnlocked.GetPixel(x, y));
                            var actual = fast.GetPixel(x, y);
                            Assert.AreEqual<Color>(expected, actual);
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
                            var expected = Color.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actual = fast.GetPixel(x, y);
                            Assert.AreEqual<Color>(expected, actual);
                        }
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Fast")]
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
                            var expected = Color.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actual = fast.GetPixel(x, y);
                            Assert.AreEqual<Color>(expected, actual);
                        }
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Fast")]
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
                            Color expected = TestingHelper.GetRandomColor();
                            testBitmapUnlocked.SetPixel(x, y, expected.ToDrawingColor());
                            fast.SetPixel(x, y, expected);

                            var actualNative = Color.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actualFast = fast.GetPixel(x, y);
                            Assert.AreEqual<Color>(expected, actualNative);
                            Assert.AreEqual<Color>(expected, actualFast);
                        }
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Fast")]
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
                            Color expected = TestingHelper.GetRandomColor();
                            testBitmapUnlocked.SetPixel(x, y, expected.ToDrawingColor());
                            fast.SetPixel(x, y, expected);

                            var actualNative = Color.FromDrawingColor(testBitmapUnlocked.GetPixel(x, y));
                            var actualFast = fast.GetPixel(x, y);
                            Assert.AreEqual<Color>(expected, actualNative);
                            Assert.AreEqual<Color>(expected, actualFast);
                        }
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Fast")]
        public void SwapPixelFast()
        {
            for (int i = 0; i < 20; i++)
            {
                SwapPixelInternal();
            }
        }


        private void SwapPixelInternal()
        {
            using(var testBitmap = TestingHelper.GetTestBitmap())
            using (var fast = new FastBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = fast.GetPixel(x, y);
                        var actual = fast.SwapPixel(x, y, TestingHelper.GetRandomColor());
                        Assert.AreEqual<Color>(expected, actual);
                    }
                }
            }
        }
    }
}