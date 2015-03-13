using System.Drawing.Analysis.Manipulation;
using System.Linq;
using NUnit.Framework;

namespace System.Drawing.Analysis.Testing
{
    [TestFixture]
    public class DefaultScannerTests
    {
        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
        public void TestSimple()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);
            }
        }

        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
        public void TestSimpleAny()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);

                bool actual = scanner.Any(Colors.White);
                Assert.AreEqual(true, actual);

                actual = scanner.Any(new NativeColor(255, 255, 255, 255));
                Assert.AreEqual(true, actual);
            }
        }

        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
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

        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
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

        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
        public void TestSimpleFindPixels()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap, false))
            {
                var scanner = new DefaultScanner(provider);

                var iterator = scanner.FindPixels(Colors.White);
                int counter = 0;
                foreach (var pixel in iterator)
                {
                    Assert.AreEqual(4, pixel.X);
                    Assert.AreEqual(8, pixel.Y);
                    ++counter;
                }
                Assert.AreEqual(1, counter);
            }

            using (var provider = new SlowBitmapPixelProvider(testBitmap))
            {
                var scanner = new DefaultScanner(provider);

                var iterator = scanner.FindPixels(Colors.Black);
                int counter = iterator.Count();
                Assert.AreEqual(18, counter); // There are exactly 18 Black pixels
            }
        }

        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
        public void TestSimpleCount()
        {
            var testBitmap = TestingHelper.GetTestBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap, false))
            {
                var scanner = new DefaultScanner(provider);

                int count = scanner.Count();
                Assert.AreEqual(testBitmap.Width * testBitmap.Height, count);

                count = scanner.Count(Colors.Black);
                Assert.AreEqual(18, count); // There are exactly 18 Black pixels

                int trues = 0;

                count = scanner.Count((x, y, c) =>
                                          {
                                              if (TestingHelper.GetRandomBool())
                                              {
                                                  ++trues;
                                                  return true;
                                              }
                                              return false;
                                          });
                Assert.AreEqual(trues, count);
            }
        }

        [Test]
        [Category("Scanner")]
        [Category("DefaultScanner")]
        public void TestSimpleTolerance()
        {
            var testBitmap = TestingHelper.GetToleranceBitmap();
            using (var provider = new SlowBitmapPixelProvider(testBitmap, false))
            {
                var scanner = new DefaultScanner(provider);
                bool actual = scanner.Any(new NativeColor(255, 100, 100, 100), new ColorTolerance(60, true));
                Assert.AreEqual(true, actual);

                actual = scanner.Any(new NativeColor(255, 100, 100, 100), new ColorTolerance(60, false));
                Assert.AreEqual(true, actual);

                actual = scanner.Any(new NativeColor(255, 100, 100, 100), new ColorTolerance(30, true));
                Assert.AreEqual(false, actual);

                actual = scanner.Any(new NativeColor(255, 100, 100, 100), new ColorTolerance(30, false));
                Assert.AreEqual(false, actual);
            }
        }
    }
}
