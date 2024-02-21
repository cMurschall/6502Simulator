using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Runtime.InteropServices;
using m6502Simulator.lib.Instructions;

namespace m6502Simulator.lib;


public static class CpuExtensions
{
    public static ushort GetZeroPageAddress(this Cpu cpu, Memory memory)
    {
        ushort address = cpu.FetchByte(memory);
        return address;
    }

    public static ushort GetZeroPageAddressX(this Cpu cpu, Memory memory)
    {
        ushort address = cpu.FetchByte(memory);
        address += cpu.RegisterX;

        return address;
    }


    public static ushort GetZeroPageAddressY(this Cpu cpu, Memory memory)
    {
        ushort address = cpu.FetchByte(memory);
        address += cpu.RegisterY;

        return address;
    }



    public static ushort GetAbsoluteAddress(this Cpu cpu, Memory memory)
    {
        ushort address = cpu.FetchWord(memory);
        return address;
    }



    public static ushort GetAbsoluteAddressX(this Cpu cpu, Memory memory, out bool didCrossPage)
    {
        ushort address = cpu.FetchWord(memory);
        var absAddressX = (ushort)(address + cpu.RegisterX);
        didCrossPage = DidCrossPage(address, absAddressX);
        return absAddressX;
    }



    public static ushort GetAbsoluteAddressY(this Cpu cpu, Memory memory, out bool didCrossPage)
    {
        ushort address = cpu.FetchWord(memory);
        var absAddressY = (ushort)(address + cpu.RegisterY);
        didCrossPage = DidCrossPage(address, absAddressY);
        return absAddressY;
    }



    public static ushort GetAddressIndirectX(this Cpu cpu, Memory memory)
    {
        ushort zeroPageAddress = cpu.FetchByte(memory);
        var zeroPageAddressX = (ushort)(zeroPageAddress + cpu.RegisterX);

        var effectiveAddress = cpu.ReadWord(zeroPageAddressX, memory);
        return effectiveAddress;
    }





    public static ushort GetAddressIndirectY(this Cpu cpu, Memory memory, out bool didCrossPage)
    {
        ushort zeroPageAddress = cpu.FetchByte(memory);
        var effectiveAddress = cpu.ReadWord(zeroPageAddress, memory);

        var address = (ushort)(effectiveAddress + cpu.RegisterY);

        didCrossPage = DidCrossPage(address ,effectiveAddress);
        return address;
    }


    private static bool DidCrossPage(ushort startAddress, ushort endAddress) => (startAddress ^ endAddress) >> 8 != 0;



    public static void UpdateZeroFlag(this Cpu cpu, byte affectedRegister)
    {
        cpu.Flag.Zero = (affectedRegister == 0);
    }
    public static void UpdateNegativeFlag(this Cpu cpu, byte affectedRegister)
    {
        cpu.Flag.Negative = (affectedRegister & CpuConstants.NegativeFlagBit) > 0;
    }

}

