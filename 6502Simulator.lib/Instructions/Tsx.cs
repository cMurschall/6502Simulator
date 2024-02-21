namespace m6502Simulator.lib.Instructions;

public class Tsx : IInstruction
{
    public OpCode OpCode => OpCode.TSX;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.RegisterX = cpu.StackPointer;
        cpu.UpdateZeroFlag(cpu.RegisterX);
        cpu.UpdateNegativeFlag(cpu.RegisterX);
    }
}