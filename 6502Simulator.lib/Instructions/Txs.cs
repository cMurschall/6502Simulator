namespace m6502Simulator.lib.Instructions;

public class Txs : IInstruction
{
    public OpCode OpCode => OpCode.TXS;
    public int RequiredCycles => 2;

    public void Execute(Cpu cpu, Memory memory)
    {
        cpu.StackPointer = cpu.RegisterX;
        cpu.UpdateZeroFlag(cpu.StackPointer);
        cpu.UpdateNegativeFlag(cpu.StackPointer);
    }
}