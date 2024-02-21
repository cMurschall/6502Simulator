using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;
using NUnit.Framework;

namespace m6502Simulator.test
{
    [TestFixture]
    public class StatusFlagTest
    {
        [Test]
        public void StructIsDefaultZero()
        {
            var flag = new StatusFlag();

            Assert.That(flag.ProcessorStatus, Is.EqualTo(0));
            Assert.That(flag.Carry, Is.False);
            Assert.That(flag.Zero, Is.False);
            Assert.That(flag.InterruptDisable, Is.False);
            Assert.That(flag.DecimalMode, Is.False);
            Assert.That(flag.BreakMode, Is.False);
            Assert.That(flag.Unused, Is.False);
            Assert.That(flag.Overflow, Is.False);
            Assert.That(flag.Negative, Is.False);

        }

        [Test]
        public void StructCanAllBeEnabledByProcessorStatus()
        {
            var flag = new StatusFlag
            {
                ProcessorStatus = 0xFF
            };

            Assert.That(flag.Carry, Is.True);
            Assert.That(flag.Zero, Is.True);
            Assert.That(flag.InterruptDisable, Is.True);
            Assert.That(flag.DecimalMode, Is.True);
            Assert.That(flag.BreakMode, Is.True);
            Assert.That(flag.Unused, Is.True);
            Assert.That(flag.Overflow, Is.True);
            Assert.That(flag.Negative, Is.True);
        }

        [Test]
        public void StructCanBeEnabledByProcessorStatus()
        {
            var flag = new StatusFlag
            {
                ProcessorStatus = 0xAA
            };

            Assert.That(flag.Carry, Is.False);
            Assert.That(flag.Zero, Is.True);
            Assert.That(flag.InterruptDisable, Is.False);
            Assert.That(flag.DecimalMode, Is.True);
            Assert.That(flag.BreakMode, Is.False);
            Assert.That(flag.Unused, Is.True);
            Assert.That(flag.Overflow, Is.False);
            Assert.That(flag.Negative, Is.True);
        }

        [Test]
        public void StructByteRepresentsValues()
        {
            var flag = new StatusFlag
            {
                Carry = true,
                Zero = false,
                InterruptDisable = true,
                DecimalMode = false,
                BreakMode = true,
                Unused = false,
                Overflow = true,
                Negative = false
            };

            Assert.That(flag.ProcessorStatus, Is.EqualTo(0x55));

            flag.Negative = true;
            Assert.That(flag.ProcessorStatus, Is.EqualTo(0xD5));
        }
    }
}
