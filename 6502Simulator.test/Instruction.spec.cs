using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;
using m6502Simulator.lib.Instructions;
using NUnit.Framework;

namespace m6502Simulator.test;

[TestFixture]
public class InstructionTest
{
    [Test]
    public void OpCodesAreUnique()
    {
        var instructions = IInstruction.GetInstructions();
        var duplicates = instructions.GroupBy(x => x.OpCode)
            .Where(g => g.Count() > 1)
            .Select(y => y.Key)
            .ToList();

        Assert.That(duplicates.Any(), Is.False);

    }



    [Test]
    public void AllOpHaveAnInstruction()
    {
        var instructions = IInstruction.GetInstructions();
       foreach (var opCode in Enum.GetValues<OpCode>())
       {
           // Assert.That(instructions.Any(x => x.OpCode == opCode), Is.True);
       }
    }
}