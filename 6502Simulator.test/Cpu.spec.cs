using System.Diagnostics.Contracts;
using NUnit.Framework;

namespace m6502Simulator.test
{
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
        public void ItWillNotExecuteAnUnknownInstruction()
        {
            Memory[Cpu.ProgramCounter] = 0x02;
            Assert.Throws<Exception>(() => Cpu.ExecuteNextInstruction(Memory));

        }
    }
}