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
                
            }
        }
    }
}
