using System.Drawing.Analysis.Manipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class DefaultScannerTests
    {
        [TestMethod]
        [TestCategory("Scanner")]
        [TestCategory("DefaultScanner")]
        public void TestSimple()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using(var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);
            }
        }

        [TestMethod]
        [TestCategory("Scanner")]
        [TestCategory("DefaultScanner")]
        public void TestSimpleAny()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using(var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);

                bool expected = true; // there is exactly one white pixel
                bool actual = scanner.Any(Color.White);

                Assert.AreEqual(expected, actual);

            }
        }
    }
}