using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System.Drawing.Analysis
{
    internal static class NativeMethods
    {
        private const string User32 = "user32.dll";

        [DllImport(User32, ExactSpelling = true)]
        internal static extern int GetSystemMetrics(NativeTypes.SystemMetrics smIndex);
    }
}