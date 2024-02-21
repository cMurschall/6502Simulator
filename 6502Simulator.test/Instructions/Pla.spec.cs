using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions
{
    public class PlaTest : CpuTestBase
    {

        [Test]
        public void Pla_PullsAccumulatorFromStack()
        {
            TransferHelper.TestTransferFromStack(OpCode.PLA, nameof(Cpu.RegisterA), Cpu, Memory);
        }


        [Test]
        public void Pla_AffectsZeroFlag()
        {
            TransferHelper.TestTransferFromStackAffectsZeroFlag(OpCode.PLA, nameof(Cpu.RegisterA), Cpu, Memory);
        }


        [Test]
        public void Pla_AffectsNegativeFlag()
        {
            TransferHelper.TestTransferFromStackAffectsNegativeFlag(OpCode.PLA, nameof(Cpu.RegisterA), Cpu, Memory);
        }
    }
}
