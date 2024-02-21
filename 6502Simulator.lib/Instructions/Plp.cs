namespace m6502Simulator.lib.Instructions;

public class Plp : IInstruction
{
    public OpCode OpCode => OpCode.PLP;
    public int RequiredCycles => 4;
    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.ProcessorStatus = cpu.PopByteFromStack(memory);
    }
}