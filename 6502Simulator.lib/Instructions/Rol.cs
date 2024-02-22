using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;



public class Rol : IInstruction
{
    public OpCode OpCode => OpCode.ROL;
    public int RequiredCycles => 2;
    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterA = RolHelper.RotateLeft(cpu.RegisterA, cpu);
    }
}





public class RolAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.ROL_ABS;
    public int RequiredCycles => 6;
    public void Execute(Cpu cpu, Memory memory)
    {
        ushort address = cpu.GetAbsoluteAddress(memory);
        memory[address] = RolHelper.RotateLeft(memory[address], cpu);
    }
}


public class RolAbsoluteX : IInstruction
{
    public OpCode OpCode => OpCode.ROL_ABSX;
    public int RequiredCycles => 7;
    public void Execute(Cpu cpu, Memory memory)
    {
        ushort address = cpu.GetAbsoluteAddressX(memory, out _);
        memory[address] = RolHelper.RotateLeft(memory[address], cpu);
    }
}


public class RolZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.ROL_ZP;
    public int RequiredCycles => 5;
    public void Execute(Cpu cpu, Memory memory)
    {
        ushort address = cpu.GetZeroPageAddress(memory);
        memory[address] = RolHelper.RotateLeft(memory[address], cpu);
    }
}



public class RolZeroPageX : IInstruction
{
    public OpCode OpCode => OpCode.ROL_ZPX;
    public int RequiredCycles => 6;
    public void Execute(Cpu cpu, Memory memory)
    {
        ushort address = cpu.GetZeroPageAddressX(memory);
        memory[address] = RolHelper.RotateLeft(memory[address], cpu);
    }
}





public static class RolHelper
{
    public static byte RotateLeft(byte operand, Cpu cpu)
    {
        byte carryBit = cpu.Flag.Carry ? CpuConstants.CarryFlagBit : (byte)0;
        cpu.Flag.Carry = (operand & CpuConstants.NegativeFlagBit) != 0;

        byte result = (byte)(operand << 1);
        result |= carryBit;
        cpu.UpdateNegativeFlag(result);
        cpu.UpdateZeroFlag(result);

        return result;
    }
}