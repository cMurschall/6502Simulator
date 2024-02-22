using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;




internal static class LsrHelper
{
    public static byte LogicalShiftRight(byte operand, Cpu cpu)
    {
        cpu.Flag.Carry = (operand & CpuConstants.CarryFlagBit) != 0;
        var result = (byte)(operand >> 1);
        cpu.UpdateZeroFlag(result);
        cpu.UpdateNegativeFlag(result);
        return result;
    }
}


public class Lsr : IInstruction
{
    public OpCode OpCode => OpCode.LSR;
    public int RequiredCycles => 2;
    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterA = LsrHelper.LogicalShiftRight(cpu.RegisterA, cpu);
    }
}




public class LsrAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.LSR_ABS;
    public int RequiredCycles => 6;
    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        memory[address] = LsrHelper.LogicalShiftRight(memory[address], cpu);
    }
}


public class LsrAbsoluteX : IInstruction
{
    public OpCode OpCode => OpCode.LSR_ABSX;
    public int RequiredCycles => 7;
    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressX(memory, out _);
        memory[address] = LsrHelper.LogicalShiftRight(memory[address], cpu);
    }
}

public class LsrZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.LSR_ZP;
    public int RequiredCycles => 5;
    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        memory[address] = LsrHelper.LogicalShiftRight(memory[address], cpu);
    }
}


public class LsrZeroPageX : IInstruction
{
    public OpCode OpCode => OpCode.LSR_ZPX;
    public int RequiredCycles => 6;
    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressX(memory);
        memory[address] = LsrHelper.LogicalShiftRight(memory[address], cpu);
    }
}