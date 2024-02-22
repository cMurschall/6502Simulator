using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions;

public class TaxTest : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void Tax_TransfersValueFromAccumulatorToRegisterX()
    {
        TransferHelper.TestTransferRegister(OpCode.TAX, nameof(Cpu.RegisterA), nameof(Cpu.RegisterX), Cpu, Memory);

    }

    [Test]
    [Repeat(100)]
    public void Tax_AffectsZeroFlag()
    {
        TransferHelper.TestTransferRegisterAffectsZeroFlag(OpCode.TAX, nameof(Cpu.RegisterA), nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Tax_AffectsNegativeFlag()
    {
        TransferHelper.TestTransferRegisterAffectsNegativeFlag(OpCode.TAX, nameof(Cpu.RegisterA), nameof(Cpu.RegisterX), Cpu, Memory);
    }

}