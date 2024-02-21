namespace m6502Simulator.lib.Instructions;

public class Php : IInstruction
{
    public OpCode OpCode => OpCode.PHP;
    public int RequiredCycles => 3;
    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.PushByteOnStack(cpu.Flag.ProcessorStatus, memory);
    }
}