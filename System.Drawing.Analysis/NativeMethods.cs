using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Drawing.Analysis
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(NativeTypes.SystemMetrics smIndex);
    }
}
