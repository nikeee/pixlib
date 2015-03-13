using System.Drawing.Analysis.Manipulation;
using NUnit.Framework;

namespace System.Drawing.Analysis.Testing
{
    [TestFixture]
    public class MiscTests
    {
        // Tests removed due to issues with mono/travis
        //[Test]
        [Category("Environment")]
        public void CheckVirtualScreen()
        {
            Assert.AreEqual(Windows.Forms.SystemInformation.VirtualScreen, Environment.VirtualScreen);
        }

        // Tests removed due to issues with mono/travis
        //[Test]
        [Category("Environment")]
        public void CheckPrimaryMonitorSize()
        {
            Assert.AreEqual(Windows.Forms.SystemInformation.PrimaryMonitorSize, Environment.PrimaryMonitorSize);
        }

        [Test]
        [Category("GdiConstants")]
        public void CheckGdiContants()
        {
            // To implement
            // Assert.AreEqual(NativeColor.FromArgb(0xFF, 0xD, 0xB, 0xC), System.Drawing.Analysis.GdiConstants.CopyFromScreenBugFixColor);
        }

        //[Test]
        //[Category("GdiConstants")]
        //public void UnionTest()
        //{
        //    // No explicit layout for generic types :<
        //    Union<byte, sbyte> ub = new Union<byte, sbyte>();
        //    ub.Value1 = 0xFF;
        //    Assert.AreEqual(-1, ub.Value2);
        //}

        //[Test]
        //[Category("Checked/Unchecked")]
        //public void Checked()
        //{
        //    checked
        //    {
        //        for (int x = 0; x < 20; x++)
        //        {
        //            int j = 0;
        //            for (int i = 0; i < int.MaxValue / 2; i++)
        //            {
        //                j = i * 2;
        //            }
        //        }
        //    }
        //}

        //[Test]
        //[Category("Checked/Unchecked")]
        //public void Unchecked()
        //{
        //    unchecked
        //    {
        //        for (int x = 0; x < 20; x++)
        //        {

        //            int j = 0;
        //            for (int i = 0; i < int.MaxValue / 2; i++)
        //            {
        //                j = i * 2;
        //            }
        //        }
        //    }
        //}
    }
}
