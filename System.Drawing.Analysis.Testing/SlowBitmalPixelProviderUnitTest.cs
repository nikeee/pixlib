using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class SlowPixelProviderTests
    {
        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Slow")]
        public void GetPixelSlow()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {

                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = testBitmap.GetPixel(x, y);
                        var actual = slow.GetPixel(x, y);
                        Assert.AreEqual(expected, actual);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Slow")]
        public void GetPixelSlow2()
        {
            var testBitmap = TestingHelper.GetTestBitmap2();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {

                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = testBitmap.GetPixel(x, y);
                        var actual = slow.GetPixel(x, y);
                        Assert.AreEqual(expected, actual);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Slow")]
        public void SetPixelSlow()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        Color expected = TestingHelper.GetRandomColor();
                        slow.SetPixel(x, y, expected);

                        Color actual = slow.GetPixel(x, y);

                        Assert.AreEqual(expected, actual);
                    }
                }
            }
        }

        [TestMethod]
        [TestCategory("PixelProvider")]
        [TestCategory("Slow")]
        public void SetPixelSlow2()
        {
            var testBitmap = TestingHelper.GetTestBitmap2();
            using (var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                for (int x = 0; x < testBitmap.Width; ++x)
                {
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        Color expected = TestingHelper.GetRandomColor();
                        slow.SetPixel(x, y, expected);
                        
                        Color actual = slow.GetPixel(x, y);

                        Assert.AreEqual(expected, actual);
                    }
                }
            }
        }
    }
}