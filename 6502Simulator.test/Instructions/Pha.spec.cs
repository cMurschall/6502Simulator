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
    public class PhaTest : CpuTestBase
    {

        [Test]
        public void Pha_TransfersRegisterAToStack()
        {
            TransferHelper.TestTransferToStack(OpCode.PHA, nameof(Cpu.RegisterA), Cpu, Memory);
        }
    }
}
