using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Drawing.Analysis.Testing
{
    [TestClass]
    public class EnvironmentTests
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
    }
}