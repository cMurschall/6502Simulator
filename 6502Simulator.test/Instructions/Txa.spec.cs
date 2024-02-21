using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions
{
    public class TxaTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Txa_TransfersValueFromStackPointerToRegisterX()
        {
            TransferHelper.TestTransferRegister(OpCode.TXA, nameof(Cpu.RegisterX), nameof(Cpu.RegisterA), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Txa_AffectsZeroFlag()
        {
            TransferHelper.TestTransferRegisterAffectsZeroFlag(OpCode.TXA, nameof(Cpu.RegisterX), nameof(Cpu.RegisterA), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Txa_AffectsNegativeFlag()
        {
            TransferHelper.TestTransferRegisterAffectsNegativeFlag(OpCode.TXA, nameof(Cpu.RegisterX), nameof(Cpu.RegisterA), Cpu, Memory);
        }

    }
}
