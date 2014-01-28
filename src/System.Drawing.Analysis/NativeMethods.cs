using System.Runtime.InteropServices;

namespace System.Drawing.Analysis
{
    internal static class NativeMethods
    {
        private const string User32 = "user32.dll";

        [DllImport(User32, ExactSpelling = true)]
        internal static extern int GetSystemMetrics(NativeTypes.SystemMetrics smIndex);
    }
}
