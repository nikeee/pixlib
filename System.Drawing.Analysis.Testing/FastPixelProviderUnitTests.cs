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
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap())
            {
                using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                {
                    for (int x = 0; x < testBitmap.Width; ++x)
                    {
                        for (int y = 0; y < testBitmap.Height; ++y)
                        {
                            var expected = testBitmapUnlocked.GetPixel(x, y);
                            var actual = fast.GetPixel(x, y);
                            Assert.AreEqual(expected, actual);
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
                            var expected = testBitmapUnlocked.GetPixel(x, y);
                            var actual = fast.GetPixel(x, y);
                            Assert.AreEqual(expected, actual);
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
                            testBitmapUnlocked.SetPixel(x, y, expected);
                            fast.SetPixel(x, y, expected);

                            var actualNative = testBitmapUnlocked.GetPixel(x, y);
                            var actualFast = fast.GetPixel(x, y);
                            Assert.AreEqual(expected, actualNative);
                            Assert.AreEqual(expected, actualFast);
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
                            testBitmapUnlocked.SetPixel(x, y, expected);
                            fast.SetPixel(x, y, expected);

                            var actualNative = testBitmapUnlocked.GetPixel(x, y);
                            var actualFast = fast.GetPixel(x, y);
                            Assert.AreEqual(expected, actualNative);
                            Assert.AreEqual(expected, actualFast);
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
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap())
            {
                using (var slow = new SlowBitmapPixelProvider(testBitmapUnlocked, true))
                {
                    using (var fast = new FastBitmapPixelProvider(testBitmap, true))
                    {
                        for (int x = 0; x < testBitmap.Width; ++x)
                        {
                            for (int y = 0; y < testBitmap.Height; ++y)
                            {
                                Color c = TestingHelper.GetRandomColor();

                                var expected = fast.GetPixel(x, y);
                                var actual = fast.SwapPixel(x, y, c);
                                Assert.AreEqual(expected, actual);
                            }
                        }
                    }
                }
            }
        }
    }
}