using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;




public class StaAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.STA_ABS;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        memory[address] = cpu.RegisterA;
    }
}


public class StaAbsoluteX : IInstruction
{
    public OpCode OpCode => OpCode.STA_ABSX;
    public int RequiredCycles => 5;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressX(memory, out _);
        memory[address] = cpu.RegisterA;
    }
}


public class StaAbsoluteY : IInstruction
{
    public OpCode OpCode => OpCode.STA_ABSY;
    public int RequiredCycles => 5;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddressY(memory, out _);
        memory[address] = cpu.RegisterA;
    }
}



public class StaZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.STA_ZP;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        memory[address] = cpu.RegisterA;
    }
}




public class StaZeroPageX : IInstruction
{
    public OpCode OpCode => OpCode.STA_ZPX;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressX(memory);
        memory[address] = cpu.RegisterA;
    }
}





public class StaIndirectX : IInstruction
{
    public OpCode OpCode => OpCode.STA_INDX;
    public int RequiredCycles => 6;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAddressIndirectX(memory);
        memory[address] = cpu.RegisterA;
    }
}



public class StaIndirectY : IInstruction
{
    public OpCode OpCode => OpCode.STA_INDY;
    public int RequiredCycles => 6;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAddressIndirectY(memory, out _);
        memory[address] = cpu.RegisterA;
    }
}