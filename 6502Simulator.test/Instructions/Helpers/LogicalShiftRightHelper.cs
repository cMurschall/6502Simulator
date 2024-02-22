using m6502Simulator.lib;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions.Helpers;

public static class LogicalShiftRightHelper
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

        Assert.That(addressMode == AddressMode.Accumulator ? cpu.RegisterA : memory[targetAddress], Is.EqualTo(0));

        Assert.That(cpu.Flag.Carry, Is.True);
        Assert.That(cpu.Flag.Zero, Is.True);
        VerifyUnmodifiedFlags(cpuBefore, cpu);
    }


    public static void TestCanShiftZeroToCarryFlag(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
    {
        cpu.Flag.Carry = true;
        cpu.Flag.Negative = true;
        cpu.Flag.Zero = true;

        var targetAddress = Helper.WriteValue(8, cpu, memory, addressMode);
        memory[0xFFFC] = (byte)upCodeToTest;



        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        Assert.That(addressMode == AddressMode.Accumulator ? cpu.RegisterA : memory[targetAddress], Is.EqualTo(4));

        Assert.That(cpu.Flag.Carry, Is.False);
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
            Assert.That(cpuBefore.Flag.Negative, Is.False);
        });
    }
}