using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;

public class LdaImmediate : IInstruction
{
    public OpCode OpCode => OpCode.LDA_IM;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        var value = cpu.FetchByte(memory);
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.LDA_ABS;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaAbsoluteX : IInstruction
{
    public OpCode OpCode => OpCode.LDA_ABSX;
    public int RequiredCycles { get; private set; } = 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressX(memory, out var didCrossPage);
        RequiredCycles = didCrossPage ? 5 : 4;
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaAbsoluteY : IInstruction
{
    public OpCode OpCode => OpCode.LDA_ABSY;
    public int RequiredCycles { get; private set; } = 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressY(memory, out var didCrossPage);
        RequiredCycles = didCrossPage ? 5 : 4;
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaIndirectX : IInstruction
{
    public OpCode OpCode => OpCode.LDA_INDX;
    public int RequiredCycles => 6;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAddressIndirectX(memory);
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaIndirectY : IInstruction
{
    public OpCode OpCode => OpCode.LDA_INDY;
    public int RequiredCycles { get; private set; } = 5;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAddressIndirectY(memory, out var didCrossPage);
        RequiredCycles = didCrossPage ? 6 : 5;
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.LDA_ZP;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}

public class LdaZeroPageX : IInstruction
{
    public OpCode OpCode => OpCode.LDA_ZPX;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressX(memory);
        var value = memory[address];
        cpu.RegisterA = value;
        cpu.UpdateZeroFlag(value);
        cpu.UpdateNegativeFlag(value);
    }
}
