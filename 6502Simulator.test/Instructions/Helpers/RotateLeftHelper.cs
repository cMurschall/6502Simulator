using m6502Simulator.lib;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions.Helpers;

public static class RotateLeftHelper
{
    public static void TestCanShiftOutCarryFlag(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
    {
        cpu.Flag.Carry = true;
        cpu.Flag.Negative = true;
        cpu.Flag.Zero = false;

        var targetAddress = Helper.WriteValue(0b0000_0000, cpu, memory, addressMode);
        memory[0xFFFC] = (byte)upCodeToTest;



        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        Assert.That(addressMode == AddressMode.Accumulator ? cpu.RegisterA : memory[targetAddress], Is.EqualTo(0b0000_0001));

        Assert.That(cpu.Flag.Carry, Is.False);
        Assert.That(cpu.Flag.Negative, Is.False);
        Assert.That(cpu.Flag.Zero, Is.False);
        VerifyUnmodifiedFlags(cpuBefore, cpu);
    }


    public static void TestCanShiftABitIntoTheCarryFlag(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
    {
        cpu.Flag.Carry = false;
        cpu.Flag.Negative = true;
        cpu.Flag.Zero = false;

        var targetAddress = Helper.WriteValue(0b1000_0000, cpu, memory, addressMode);
        memory[0xFFFC] = (byte)upCodeToTest;



        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        Assert.That(addressMode == AddressMode.Accumulator ? cpu.RegisterA : memory[targetAddress], Is.EqualTo(0b0000_0000));

        Assert.That(cpu.Flag.Carry, Is.True);
        Assert.That(cpu.Flag.Negative, Is.False);
        Assert.That(cpu.Flag.Zero, Is.True);
        VerifyUnmodifiedFlags(cpuBefore, cpu);
    }





    public static void TestCanShiftZeroWithNoCarry(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
    {
        cpu.Flag.Carry = false;
        cpu.Flag.Negative = true;
        cpu.Flag.Zero = false;

        var targetAddress = Helper.WriteValue(0b00000000, cpu, memory, addressMode);
        memory[0xFFFC] = (byte)upCodeToTest;



        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        Assert.That(addressMode == AddressMode.Accumulator ? cpu.RegisterA : memory[targetAddress], Is.EqualTo(0b00000000));

        Assert.That(cpu.Flag.Carry, Is.False);
        Assert.That(cpu.Flag.Negative, Is.False);
        Assert.That(cpu.Flag.Zero, Is.True);
        VerifyUnmodifiedFlags(cpuBefore, cpu);
    }



    public static void TestCanShiftToNegative(OpCode upCodeToTest, AddressMode addressMode, Cpu cpu, Memory memory)
    {
        cpu.Flag.Carry = true;
        cpu.Flag.Negative = false;
        cpu.Flag.Zero = true;

        var targetAddress = Helper.WriteValue(0b0100_0011, cpu, memory, addressMode);
        memory[0xFFFC] = (byte)upCodeToTest;



        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        Assert.That(addressMode == AddressMode.Accumulator ? cpu.RegisterA : memory[targetAddress], Is.EqualTo(0b1000_0111));

        Assert.That(cpu.Flag.Carry, Is.False);
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