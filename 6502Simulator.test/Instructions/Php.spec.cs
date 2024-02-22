using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions;

public class PhpTest : CpuTestBase
{

    [Test]
    public void Pha_TransfersProcessorStatusToStack()
    {
        TransferHelper.TestTransferToStack(OpCode.PHP, nameof(Cpu.ProcessorStatus), Cpu, Memory);
    }
}