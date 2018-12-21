using System;
using System.Runtime.InteropServices;

namespace GameBoyEmu.CPU
{
    [StructLayout(LayoutKind.Explicit)]
    [Serializable]
    public class Register
    {
        [FieldOffset(0)]
        public ushort Value;

        [FieldOffset(0)]
        public byte Low;

        [FieldOffset(1)]
        public byte High;
    }
}