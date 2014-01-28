namespace System.Drawing.Analysis
{
    /// <summary>Provides information about the current system environment.</summary>
    public static class Environment
    {
        /// <summary>Gets the bounds of the virtual screen.</summary>
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

        /// <summary>Gets a value indicating whether the current system uses a multi-monitor setup.</summary>
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

        /// <summary>Gets the bounds of the primary screen.</summary>
        public static Size PrimaryMonitorSize
        {
            get
            {
                return new Size(
                        NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CXSCREEN),
                        NativeMethods.GetSystemMetrics(NativeTypes.SystemMetrics.CYSCREEN)
                    );
            }
        }
    }
}
