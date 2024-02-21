using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;


public class StyAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.STY_ABS;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        memory[address] = cpu.RegisterY;
    }
}



public class StyZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.STY_ZP;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        memory[address] = cpu.RegisterY;
    }
}




public class StyZeroPageY : IInstruction
{
    public OpCode OpCode => OpCode.STY_ZPX;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressX(memory);
        memory[address] = cpu.RegisterY;
    }
}

