namespace m6502Simulator.lib.Instructions;

public class Tax : IInstruction
{
    public OpCode OpCode => OpCode.TAX;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterX = cpu.RegisterA;
        cpu.UpdateZeroFlag(cpu.RegisterX);
        cpu.UpdateNegativeFlag(cpu.RegisterX);
    }
}