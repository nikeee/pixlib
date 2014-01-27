using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing.Analysis
{
    public struct Color
    {
        [FieldOffset(0)]
        private byte _b;

        [FieldOffset(1)]
        private byte _g;

        [FieldOffset(2)]
        private byte _r;

        [FieldOffset(3)]
        private byte _a;

        [FieldOffset(0)]
        private int _bgra;

        public byte A { get { return _a; } set { _a = value; } }
        public byte R { get { return _r; } set { _r = value; } }
        public byte G { get { return _g; } set { _g = value; } }
        public byte B { get { return _b; } set { _b = value; } }
        public int Bgra { get { return _bgra; } set { _bgra = value; } }
    }
}
