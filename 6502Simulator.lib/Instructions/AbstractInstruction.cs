using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;

public interface IInstruction
{
    public OpCode OpCode { get; }

    public int RequiredCycles { get; }
    public void Execute(Cpu cpu, Memory memory);

    static IReadOnlyList<IInstruction> GetInstructions()
    {
        return new IInstruction[]
        {
            // lda
            new LdaImmediate(),
            new LdaAbsolute(),
            new LdaAbsoluteX(),
            new LdaAbsoluteY(),
            new LdaZeroPage(),
            new LdaZeroPageX(),
            new LdaIndirectX(),
            new LdaIndirectY(),

            // ldx
            new LdxImmediate(),
            new LdxAbsolute(),
            new LdxAbsoluteY(),
            new LdxZeroPage(),
            new LdxZeroPageY(),
        };
    }
}



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
