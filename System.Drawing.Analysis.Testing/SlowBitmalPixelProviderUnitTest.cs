using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Analysis;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class SlowBitmapPixelProviderUnitTest
    {
        private const string RelativeTestImagePath = "..\\..\\Resources\\testImage.png";

        [TestMethod]
        public void TestSlowBitmapPixelProvider()
        {
            var testBitmap = new Bitmap(RelativeTestImagePath);

            using(var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {

                for(int x = 0 ; x < testBitmap.Width; ++x)
                    for (int y = 0; y < testBitmap.Height; ++y)
                    {
                        var expected = testBitmap.GetPixel(x, y);
                        var actual = slow.GetPixel(x, y);
                        Assert.AreEqual(expected, actual);
                    }
            }
        }
    }
}
