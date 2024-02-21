using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;



public class StxAbsolute : IInstruction
{
    public OpCode OpCode => OpCode.STX_ABS;
    public int RequiredCycles => 4;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetAbsoluteAddress(memory);
        memory[address] = cpu.RegisterX;
    }
}




public class StxZeroPage : IInstruction
{
    public OpCode OpCode => OpCode.STX_ZP;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddress(memory);
        memory[address] = cpu.RegisterX;
    }
}




public class StxZeroPageY : IInstruction
{
    public OpCode OpCode => OpCode.STX_ZPY;
    public int RequiredCycles => 3;

    public void Execute(Cpu cpu, Memory memory)
    {
        var address = cpu.GetZeroPageAddressY(memory);
        memory[address] = cpu.RegisterX;
    }
}


