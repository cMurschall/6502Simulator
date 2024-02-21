namespace m6502Simulator.lib.Instructions;

public class Txa : IInstruction
{
    public OpCode OpCode => OpCode.TXA;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterA = cpu.RegisterX;
        cpu.UpdateZeroFlag(cpu.RegisterA);
        cpu.UpdateNegativeFlag(cpu.RegisterA);
    }
}