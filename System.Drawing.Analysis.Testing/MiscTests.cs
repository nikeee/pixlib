using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        [TestCategory("Environment")]
        public void CheckVirtualScreen()
        {
            Assert.AreEqual(Windows.Forms.SystemInformation.VirtualScreen, Environment.VirtualScreen);
        }

        [TestMethod]
        [TestCategory("Environment")]
        public void CheckPrimaryMonitorSize()
        {
            Assert.AreEqual(Windows.Forms.SystemInformation.PrimaryMonitorSize, Environment.PrimaryMonitorSize);
        }

        [TestMethod]
        [TestCategory("GdiConstants")]
        public void CheckGdiContants()
        {
            // To implement
            // Assert.AreEqual(Color.FromArgb(0xFF, 0xD, 0xB, 0xC), System.Drawing.Analysis.GdiConstants.CopyFromScreenBugFixColor);
        }

        //[TestMethod]
        //[TestCategory("Checked/Unchecked")]
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

        //[TestMethod]
        //[TestCategory("Checked/Unchecked")]
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