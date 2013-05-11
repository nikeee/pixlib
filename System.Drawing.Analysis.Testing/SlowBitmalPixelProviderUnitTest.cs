using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Analysis;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class SlowBitmapPixelProviderUnitTest
    {
        [TestMethod]
        public void TestSlowBitmapPixelProvider()
        {
            var testBitmap = new Bitmap("..\\");

            using(var slow = new SlowBitmapPixelProvider(testBitmap, true))
            {
                
            }

        }
    }
}
