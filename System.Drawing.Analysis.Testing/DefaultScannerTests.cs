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
            using (var provider = new SlowBitmapPixelProvider(testBitmap))
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
            using (var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);

                bool actual = scanner.Any(Color.White);
                Assert.AreEqual(true, actual);

                actual = scanner.Any(Color.FromArgb(255, 255, 255, 255));
                Assert.AreEqual(true, actual);
            }
        }

        [TestMethod]
        [TestCategory("Scanner")]
        [TestCategory("DefaultScanner")]
        public void TestSimpleForEach()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);
                var counter = 0;
                scanner.ForEach((x, y, c) => ++counter);

                int expected = testBitmap.Width * testBitmap.Height;
                int actual = counter;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("Scanner")]
        [TestCategory("DefaultScanner")]
        public void TestViewForEach()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider)
                                  {
                                      View = new Rectangle(3, 3, 2, 2)
                                  };

                var counter = 0;
                scanner.ForEach((x, y, c) => ++counter);

                int expected = scanner.View.Width * scanner.View.Height;
                int actual = counter;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}