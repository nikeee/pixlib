namespace System.Drawing.Analysis
{
    public static class Environment
    {
        public static Rectangle VirtualScreen
        {
            get
            {
                if (IsMultiMonitorSupported)
                {
                    return new Rectangle(
                            NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.XVIRTUALSCREEN),
                            NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.YVIRTUALSCREEN),
                            NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CXVIRTUALSCREEN),
                            NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CYVIRTUALSCREEN)
                        );
                }
                Size s = PrimaryMonitorSize;
                return new Rectangle(0, 0, s.Width, s.Height);
            }
        }


        private static bool _multiMonitorSupportInitialized;
        private static bool _isMultiMonitorSupported;
        public static bool IsMultiMonitorSupported
        {
            get
            {
                if (!_multiMonitorSupportInitialized)
                {
                    _isMultiMonitorSupported = NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CMONITORS) != 0;
                    _multiMonitorSupportInitialized = true;
                }
                return _isMultiMonitorSupported;
            }
        }

        public static Size PrimaryMonitorSize
        {
            get
            {
                return new Size(NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CXSCREEN), NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CYSCREEN));
            }
        }
    }
}