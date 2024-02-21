using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;


public class LdxImmediate : IInstruction
{
    public OpCode OpCode => OpCode.LDX_IM;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        var value = cpu.FetchByte(memory);
        cpu.RegisterX = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdxAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.LDX_ABS;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        var value = memory[address];
        cpu.RegisterX = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdxAbsoluteY : IInstruction
{
    public OpCode OpCode => OpCode.LDX_ABSY;
    public int RequiredCycles { get; set; } = 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressY(memory, out var didCrossPage);
        RequiredCycles = didCrossPage ? 5 : 4;
        var value = memory[address];
        cpu.RegisterX = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}




public class LdxZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.LDX_ZP;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        var value = memory[address];
        cpu.RegisterX = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}


public class LdxZeroPageY : IInstruction
{
    public OpCode OpCode => OpCode.LDX_ZPY;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressY(memory);
        var value = memory[address];
        cpu.RegisterX = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}