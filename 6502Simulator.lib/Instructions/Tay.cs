using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;

public class Tay : IInstruction
{
    public OpCode OpCode => OpCode.TAY;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterY = cpu.RegisterA;
        cpu.UpdateZeroFlag(cpu.RegisterY);
        cpu.UpdateNegativeFlag(cpu.RegisterY);
    }
}