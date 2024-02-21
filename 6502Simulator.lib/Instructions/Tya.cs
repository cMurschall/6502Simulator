using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;

public class Tya : IInstruction
{
    public OpCode OpCode => OpCode.TYA;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterA = cpu.RegisterY;
        cpu.UpdateZeroFlag(cpu.RegisterA);
        cpu.UpdateNegativeFlag(cpu.RegisterA);
    }
}