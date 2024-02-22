using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions;

public class TxsTest : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void Txs_TransfersValueFromRegisterXtoStackPointer()
    {
        TransferHelper.TestTransferRegister(OpCode.TXS, nameof(Cpu.RegisterX), nameof(Cpu.StackPointer), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Txs_AffectsZeroFlag()
    {
        TransferHelper.TestTransferRegisterAffectsZeroFlag(OpCode.TXS, nameof(Cpu.RegisterX), nameof(Cpu.StackPointer), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Txs_AffectsNegativeFlag()
    {
        TransferHelper.TestTransferRegisterAffectsNegativeFlag(OpCode.TXS, nameof(Cpu.RegisterX), nameof(Cpu.StackPointer), Cpu, Memory);
    }

}