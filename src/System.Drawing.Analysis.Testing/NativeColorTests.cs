using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class NativeColorTests
    {

        [TestMethod]
        [TestCategory("NativeColor")]
        [TestCategory("Color")]
        public void ToArgb()
        {
            var nc = new NativeColor(255, 0, 0, 0);
            int actual = nc.ToArgb();
            var c = Color.FromArgb(255, 0, 0, 0);
            int expected = c.ToArgb();
            Assert.AreEqual<int>(expected, actual);

            nc = new NativeColor(1, 2, 3, 4);
            actual = nc.ToArgb();
            c = Color.FromArgb(1, 2, 3, 4);
            expected = c.ToArgb();
            Assert.AreEqual<int>(expected, actual);

            nc = new NativeColor(255, 255, 255, 255);
            actual = nc.ToArgb();
            c = Color.FromArgb(255, 255, 255, 255);
            expected = c.ToArgb();
            Assert.AreEqual<int>(expected, actual);

            nc = new NativeColor(0, 255, 255, 255);
            actual = nc.ToArgb();
            c = Color.FromArgb(0, 255, 255, 255);
            expected = c.ToArgb();
            Assert.AreEqual<int>(expected, actual);

            nc = new NativeColor(255, 0, 0, 0);
            actual = nc.ToArgb();
            c = Color.FromArgb(255, 0, 0, 0);
            expected = c.ToArgb();
            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        [TestCategory("NativeColor")]
        [TestCategory("Color")]
        public void Colors()
        {
            var actual = Analysis.Colors.Black;
            var expected = new NativeColor(255,0,0,0);
            Assert.AreEqual<NativeColor>(expected, actual);

            actual = Analysis.Colors.Blue;
            expected = new NativeColor(255, 0, 0, 255);
            Assert.AreEqual<NativeColor>(expected, actual);

            actual = Analysis.Colors.Green;
            expected = new NativeColor(255, 0, 255, 0);
            Assert.AreEqual<NativeColor>(expected, actual);

            actual = Analysis.Colors.Red;
            expected = new NativeColor(255, 255, 0, 0);
            Assert.AreEqual<NativeColor>(expected, actual);

            actual = Analysis.Colors.Transparent;
            expected = new NativeColor(0, 0, 0, 0);
            Assert.AreEqual<NativeColor>(expected, actual);

            actual = Analysis.Colors.White;
            expected = new NativeColor(255, 255, 255, 255);
            Assert.AreEqual<NativeColor>(expected, actual);
        }
    }
}
