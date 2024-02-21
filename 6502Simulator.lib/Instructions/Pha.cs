namespace m6502Simulator.lib.Instructions;

public class Pha : IInstruction
{
    public OpCode OpCode => OpCode.PHA;
    public int RequiredCycles => 3;
    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.PushByteOnStack(cpu.RegisterA, memory);
    }
}