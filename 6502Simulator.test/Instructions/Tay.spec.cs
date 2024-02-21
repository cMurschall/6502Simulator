using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions
{
    public class TayTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Tay_TransfersValueFromAccumulatorToRegisterY()
        {
            TransferHelper.TestTransferRegister(OpCode.TAY, nameof(Cpu.RegisterA), nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Tay_AffectsZeroFlag()
        {
            TransferHelper.TestTransferRegisterAffectsZeroFlag(OpCode.TAY, nameof(Cpu.RegisterA), nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Tay_AffectsNegativeFlag()
        {
            TransferHelper.TestTransferRegisterAffectsNegativeFlag(OpCode.TAY, nameof(Cpu.RegisterA), nameof(Cpu.RegisterY), Cpu, Memory);
        }

    }
}
