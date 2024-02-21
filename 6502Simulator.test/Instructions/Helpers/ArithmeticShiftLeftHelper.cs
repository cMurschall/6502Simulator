using m6502Simulator.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions.Helpers
{
    public static class ArithmeticShiftLeftHelper
    {
        public static void TestCanShiftValueOfOne(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
        {
            cpu.Flag.Carry = true;
            cpu.Flag.Negative = true;
            cpu.Flag.Zero = true;

            var targetAddress = Helper.WriteValue(1, cpu, memory, addressMode);
            memory[0xFFFC] = (byte)upCodeToTest;



            var cpuBefore = cpu.Clone();
            cpu.ExecuteNextInstruction(memory);

            if (addressMode == AddressMode.Accumulator)
            {
                Assert.That(cpu.RegisterA, Is.EqualTo(2));
            }
            else
            {
                Assert.That(memory[targetAddress], Is.EqualTo(2));
            }

            Assert.That(cpu.Flag.Carry, Is.False);
            Assert.That(cpu.Flag.Negative, Is.False);
            Assert.That(cpu.Flag.Zero, Is.False);
            VerifyUnmodifiedFlags(cpuBefore, cpu);
        }


        public static void TestCanShiftNegativeValue(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
        {
            cpu.Flag.Carry = false;
            cpu.Flag.Negative = false;
            cpu.Flag.Zero = true;


            var targetAddress = Helper.WriteValue(0b11000010, cpu, memory, addressMode);
            memory[0xFFFC] = (byte)upCodeToTest;



            var cpuBefore = cpu.Clone();
            cpu.ExecuteNextInstruction(memory);

            if (addressMode == AddressMode.Accumulator)
            {
                Assert.That(cpu.RegisterA, Is.EqualTo(0b10000100));
            }
            else
            {
                Assert.That(memory[targetAddress], Is.EqualTo(0b10000100));
            }
            Assert.That(cpu.Flag.Carry, Is.True);
            Assert.That(cpu.Flag.Negative, Is.True);
            Assert.That(cpu.Flag.Zero, Is.False);
            VerifyUnmodifiedFlags(cpuBefore, cpu);
        }






        private static void VerifyUnmodifiedFlags(Cpu cpuBefore, Cpu cpu)
        {
            Assert.Multiple(() =>
            {
                Assert.That(cpuBefore.Flag.InterruptDisable, Is.EqualTo(cpu.Flag.InterruptDisable));
                Assert.That(cpuBefore.Flag.DecimalMode, Is.EqualTo(cpu.Flag.DecimalMode));
                Assert.That(cpuBefore.Flag.BreakMode, Is.EqualTo(cpu.Flag.BreakMode));
                Assert.That(cpuBefore.Flag.Overflow, Is.EqualTo(cpu.Flag.Overflow));
            });
        }
    }
}
