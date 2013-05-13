using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class Misc
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
    }
}