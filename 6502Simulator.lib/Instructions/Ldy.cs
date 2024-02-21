using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;



public class LdyImmediate : IInstruction
{
    public OpCode OpCode => OpCode.LDY_IM;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        var value = cpu.FetchByte(memory);
        cpu.RegisterY = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdyAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.LDY_ABS;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        var value = memory[address];
        cpu.RegisterY = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}



public class LdyAbsoluteX : IInstruction
{
    public OpCode OpCode => OpCode.LDY_ABSX;
    public int RequiredCycles { get; private set; } = 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressX(memory, out var didCrossPage);
        RequiredCycles = didCrossPage ? 5 : 4;
        var value = memory[address];
        cpu.RegisterY = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}




public class LdyZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.LDY_ZP;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        var value = memory[address];
        cpu.RegisterY = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}





public class LdyZeroPageX : IInstruction
{
    public OpCode OpCode => OpCode.LDY_ZPX;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressX(memory);
        var value = memory[address];
        cpu.RegisterY = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}


