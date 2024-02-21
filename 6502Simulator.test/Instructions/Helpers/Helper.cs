using m6502Simulator.lib;

namespace m6502Simulator.test.Instructions.Helpers;


public enum AddressMode
{
    Accumulator,
    Immediate,
    Absolute,
    AbsoluteX,
    AbsoluteY,
    ZeroPage,
    ZeroPageX,
    ZeroPageY,
    IndirectX,
    IndirectY
}



public static class Helper
{



    public static byte NextByte(this Random r)
    {
        return Convert.ToByte(r.Next(byte.MinValue, byte.MaxValue));
    }

    public static byte NextByte(this Random r, byte max)
    {
        return Convert.ToByte(r.Next(byte.MinValue, max));
    }

    public static ushort NextWord(this Random r)
    {
        return Convert.ToUInt16(r.Next(ushort.MinValue, ushort.MaxValue));
    }

    public static ushort WriteValue(byte value, Cpu cpu, Memory memory, AddressMode addressMode, ushort startAddress = 0xFFFD)
    {
        return addressMode switch
        {
            AddressMode.Accumulator => WriteAccumulatorValue(value, cpu),
            AddressMode.Immediate => WriteImmediateValue(value, memory, startAddress),
            AddressMode.Absolute => WriteAbsoluteValue(value, memory, startAddress),
            AddressMode.AbsoluteX => WriteAbsoluteXValue(value, cpu, memory, startAddress),
            AddressMode.AbsoluteY => WriteAbsoluteYValue(value, cpu, memory, startAddress),
            AddressMode.ZeroPage => WriteZeroPageValue(value, memory, startAddress),
            AddressMode.ZeroPageX => WriteZeroPageXValue(value, cpu, memory, startAddress),
            AddressMode.ZeroPageY => WriteZeroPageYValue(value, cpu, memory, startAddress),
            AddressMode.IndirectX => WriteIndirectXValue(value, cpu, memory, startAddress),
            AddressMode.IndirectY => WriteIndirectYValue(value, cpu, memory, startAddress),
            _ => throw new ArgumentOutOfRangeException(nameof(addressMode), addressMode, null)
        };
    }

    private static ushort WriteAccumulatorValue(byte value, Cpu cpu)
    {
        cpu.RegisterA = value;
        return cpu.RegisterA;
    }
    private static ushort WriteImmediateValue(byte value, Memory memory, ushort startAddress)
    {
        memory[startAddress] = value;
        return startAddress;
    }

    private static ushort WriteAbsoluteValue(byte value, Memory memory, ushort startAddress)
    {
        memory[startAddress + 0] = 0x80;
        memory[startAddress + 1] = 0x44;
        memory[0x4480] = value;
        return 0x4480;
    }

    private static ushort WriteAbsoluteXValue(byte value, Cpu cpu, Memory memory, ushort startAddress)
    {
        var offsetRegisterX = Random.Shared.NextByte();
        cpu.RegisterX = offsetRegisterX;
        memory[startAddress + 0] = 0x80;
        memory[startAddress + 1] = 0x44;
        memory[0x4480 + offsetRegisterX] = value;
        return (ushort)(offsetRegisterX + 0x4480);
    }

    private static ushort WriteZeroPageValue(byte value, Memory memory, ushort startAddress)
    {
        var zeroPageAddress = Random.Shared.NextByte();
        memory[startAddress] = zeroPageAddress;
        memory[zeroPageAddress] = value;
        return zeroPageAddress;
    }

    private static ushort WriteZeroPageXValue(byte value, Cpu cpu, Memory memory, ushort startAddress)
    {
        var zeroPageAddress = Random.Shared.NextByte();
        cpu.RegisterX = Random.Shared.NextByte();
        memory[startAddress] = zeroPageAddress;
        memory[zeroPageAddress + cpu.RegisterX] = value;
        return (ushort)(zeroPageAddress + cpu.RegisterX);
    }

    private static ushort WriteZeroPageYValue(byte value, Cpu cpu, Memory memory, ushort startAddress)
    {
        var zeroPageAddress = Random.Shared.NextByte();
        cpu.RegisterY = Random.Shared.NextByte();
        memory[startAddress] = zeroPageAddress;
        memory[zeroPageAddress + cpu.RegisterY] = value;
        return (ushort)(zeroPageAddress + cpu.RegisterY);
    }

    private static ushort WriteAbsoluteYValue(byte value, Cpu cpu, Memory memory, ushort startAddress)
    {
        cpu.RegisterY = Random.Shared.NextByte();
        memory[Convert.ToUInt16(startAddress + 0)] = 0x80;
        memory[Convert.ToUInt16(startAddress + 1)] = 0x44;
        memory[Convert.ToUInt16(0x4480 + cpu.RegisterY)] = value;
        return (ushort)(0x4480 + cpu.RegisterY);
    }

    private static ushort WriteIndirectXValue(byte value, Cpu cpu, Memory memory, ushort startAddress)
    {
        var zeroPageAddress = Random.Shared.NextByte();
        cpu.RegisterX = Random.Shared.NextByte();
        memory[startAddress] = zeroPageAddress;
        memory[Convert.ToUInt16(zeroPageAddress + cpu.RegisterX + 0)] = 0x44;
        memory[Convert.ToUInt16(zeroPageAddress + cpu.RegisterX + 1)] = 0x80;
        memory[Convert.ToUInt16(0x8044)] = value;
        return 0x8044;
    }

    private static ushort WriteIndirectYValue(byte value, Cpu cpu, Memory memory, ushort startAddress)
    {
        var zeroPageAddress = Random.Shared.NextByte();
        cpu.RegisterY = Random.Shared.NextByte();
        memory[startAddress] = zeroPageAddress;
        memory[zeroPageAddress + 0] = 0x44;
        memory[zeroPageAddress + 1] = 0x80;
        memory[0x8044 + cpu.RegisterY] = value;
        return (ushort)(0x8044 + cpu.RegisterY);
    }
}