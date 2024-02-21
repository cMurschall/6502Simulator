using System.Collections;
using System.Runtime.InteropServices;

namespace m6502Simulator.lib;

public class StatusFlag
{
    internal BitArray _bits = new(8);

    public byte ProcessorStatus
    {
        get
        {
            var bytes = new byte[1];
            _bits.CopyTo(bytes, 0);
            return bytes[0];
        }
        set => _bits = new BitArray(new []{value});
    }

    public bool Carry
    {
        get => _bits.Get(0);
        set => _bits.Set(0, value);
    }

    public bool Zero
    {
        get => _bits.Get(1);
        set => _bits.Set(1, value);
    }

    public bool InterruptDisable
    {
        get => _bits.Get(2);
        set => _bits.Set(2, value);
    }

    public bool DecimalMode
    {
        get => _bits.Get(3);
        set => _bits.Set(3, value);
    }

    public bool BreakMode
    {
        get => _bits.Get(4);
        set => _bits.Set(4, value);
    }

    public bool Unused
    {
        get => _bits.Get(5);
        set => _bits.Set(5, value);
    }

    public bool Overflow
    {
        get => _bits.Get(6);
        set => _bits.Set(6, value);
    }

    public bool Negative
    {
        get => _bits.Get(7);
        set => _bits.Set(7, value);
    }
}
