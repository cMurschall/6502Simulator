using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions
{
    public class TyaTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Tya_TransfersValueFromRegisterYtoRegisterA()
        {
            TransferHelper.TestTransferRegister(OpCode.TYA, nameof(Cpu.RegisterY), nameof(Cpu.RegisterA), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Tya_AffectsZeroFlag()
        {
            TransferHelper.TestTransferRegisterAffectsZeroFlag(OpCode.TYA, nameof(Cpu.RegisterY), nameof(Cpu.RegisterA), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Tya_AffectsNegativeFlag()
        {
            TransferHelper.TestTransferRegisterAffectsNegativeFlag(OpCode.TYA, nameof(Cpu.RegisterY), nameof(Cpu.RegisterA), Cpu, Memory);
        }

    }
}
