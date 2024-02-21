namespace m6502Simulator.lib.Instructions;

public class Pla : IInstruction
{
    public OpCode OpCode => OpCode.PLA;
    public int RequiredCycles => 4;
    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterA = cpu.PopByteFromStack(memory);
        cpu.UpdateZeroFlag(cpu.RegisterA);
        cpu.UpdateNegativeFlag(cpu.RegisterA);
    }
}