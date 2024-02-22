using System.Diagnostics.Contracts;
using System.Formats.Asn1;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test;

public class CpuTests : CpuTestBase
{

    [Test]
    public void ItWritesAByte()
    {
        byte value = 0x11;
        ushort address = 0x0042;
        Cpu.WriteByte(value, address, Memory);
        var readBack = Cpu.ReadByte(address, Memory);
        Assert.That(readBack, Is.EqualTo(value));
    }


    [Test]
    public void ItWritesAWord()
    {
        ushort value = byte.MaxValue + 100;
        ushort address = 0x0042;
        Cpu.WriteWord(value, address, Memory);
        var readBack = Cpu.ReadWord(address, Memory);
        Assert.That(value, Is.EqualTo(readBack));
    }


    [Test]
    public void ItPushesByteToStack()
    {
        var valueA = Random.Shared.NextByte();
        var valueB = Random.Shared.NextByte();

        Cpu.PushByteOnStack(valueA, Memory);
        Cpu.PushByteOnStack(valueB, Memory);

        var readBackB = Cpu.PopByteFromStack(Memory);
        Assert.That(valueB, Is.EqualTo(readBackB));

        var readBackA = Cpu.PopByteFromStack(Memory);
        Assert.That(valueA, Is.EqualTo(readBackA));
    }


    [Test]
    public void ItPushesWordToStack()
    {
        var valueA = Random.Shared.NextWord();
        var valueB = Random.Shared.NextWord();

        Cpu.PushWordOnStack(valueA, Memory);
        Cpu.PushWordOnStack(valueB, Memory);

        var readBackB = Cpu.PopWordFromStack(Memory);
        Assert.That(valueB, Is.EqualTo(readBackB));

        var readBackA = Cpu.PopWordFromStack(Memory);
        Assert.That(valueA, Is.EqualTo(readBackA));
    }




    [Test]
    public void ItWillNotExecuteAnUnknownInstruction()
    {
        Memory[Cpu.ProgramCounter] = 0x02;
        Assert.Throws<Exception>(() => Cpu.ExecuteNextInstruction(Memory));

    }


    [TestCase(0xFF, -1)]
    [TestCase(0xAA, -86)]
    [TestCase(0x01, 1)]
    public void ItConvertsToSignedByte(byte memoryByte, sbyte asSignedExpected)
    {
        Memory[Cpu.ProgramCounter] = memoryByte;
        var asSigned = Cpu.FetchSByte(Memory);
        Assert.That(asSigned, Is.EqualTo(asSignedExpected));
    }
}