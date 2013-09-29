using System.Runtime.InteropServices;

namespace System.Drawing.Analysis
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct NativeColor
    {
        [FieldOffset(0)]
        public int Argb;

        [FieldOffset(0)]
        public byte A;

        [FieldOffset(1)]
        public byte R;

        [FieldOffset(2)]
        public byte G;

        [FieldOffset(3)]
        public byte B;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct NativeColorInverse
    {
        [FieldOffset(0)]
        public int Bgra;

        [FieldOffset(0)]
        public byte B;

        [FieldOffset(1)]
        public byte G;

        [FieldOffset(2)]
        public byte R;

        [FieldOffset(3)]
        public byte A;
    }
}
