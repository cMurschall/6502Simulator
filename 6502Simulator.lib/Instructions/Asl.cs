using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;

public class Asl : IInstruction
{
    public OpCode OpCode => OpCode.ASL;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterA = AslHelper.ArithmeticShiftLeft(cpu.RegisterA, cpu);
    }
}

public class AslAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.ASL_ABS;
    public int RequiredCycles => 6;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        memory[address] = AslHelper.ArithmeticShiftLeft(memory[address], cpu);
    }
}

public class AslAbsoluteX : IInstruction
{
    public OpCode OpCode => OpCode.ASL_ABSX;
    public int RequiredCycles => 7;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressX(memory, out _);
        memory[address] = AslHelper.ArithmeticShiftLeft(memory[address], cpu);
    }
}

public class AslZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.ASL_ZP;
    public int RequiredCycles => 5;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        memory[address] = AslHelper.ArithmeticShiftLeft(memory[address], cpu);
    }
}

public class AslZeroPageX : IInstruction
{
    public OpCode OpCode => OpCode.ASL_ZPX;
    public int RequiredCycles => 6;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressX(memory);
        memory[address] = AslHelper.ArithmeticShiftLeft(memory[address], cpu);
    }
}

internal static class AslHelper
{
    internal static byte ArithmeticShiftLeft(byte operand, Cpu cpu)
    {
        cpu.Flag.Carry = (operand & CpuConstants.NegativeFlagBit) != 0;
        var result = (byte)(operand << 1);
        cpu.UpdateZeroFlag(result);
        cpu.UpdateNegativeFlag(result);

        return result;
    }
}
