using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class FastPixelProviderTests
    {
        [TestMethod]
        public void GetPixel()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var testBitmapUnlocked = TestingHelper.GetTestBitmap())
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
}