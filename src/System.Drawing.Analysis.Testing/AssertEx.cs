using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Drawing.Analysis.Testing
{
    public class AssertEx
    {
        public static void AreEqual<T>(T expected, T actual)
        {
            NUnit.Framework.Assert.AreEqual(expected, actual);
        }
    }
}
