using m6502Simulator.lib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.test.Instructions.Helpers
{
    public static class StoreHelper
    {

        public static void TestStoreRegister(OpCode upCodeToTest, AddressMode addressMode, string registerToTest, Cpu cpu, Memory memory)
        {
            memory[0xFFFC] = (byte)upCodeToTest;
            cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

            var testValue = Random.Shared.NextByte(0xFA);
            typeof(Cpu).GetProperty(registerToTest)?.SetValue(cpu, testValue);

            // we write something in the memory, but we only want the produced address
            // so we can check at the updated memory address
            var writtenAddress = Helper.WriteValue((byte)(testValue + 1), cpu, memory, addressMode);

            var cpuBefore = cpu;
            cpu.ExecuteNextInstruction(memory);

            var registerValueAfter = typeof(Cpu).GetProperty(registerToTest)?.GetValue(cpu);
            Assert.That(registerValueAfter, Is.EqualTo(testValue));
            Assert.That(memory[writtenAddress], Is.EqualTo(testValue));
            Assert.That(cpuBefore.Flag.ProcessorStatus, Is.EqualTo(cpu.Flag.ProcessorStatus));
        }
    }
}
