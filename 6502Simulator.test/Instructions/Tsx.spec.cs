using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions;

public class TsxTest : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void Tay_TransfersValueFromStackPointerToRegisterX()
    {
        TransferHelper.TestTransferRegister(OpCode.TSX, nameof(Cpu.StackPointer), nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Tsx_AffectsZeroFlag()
    {
        TransferHelper.TestTransferRegisterAffectsZeroFlag(OpCode.TSX, nameof(Cpu.StackPointer), nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Tsx_AffectsNegativeFlag()
    {
        TransferHelper.TestTransferRegisterAffectsNegativeFlag(OpCode.TSX, nameof(Cpu.StackPointer), nameof(Cpu.RegisterX), Cpu, Memory);
    }

}