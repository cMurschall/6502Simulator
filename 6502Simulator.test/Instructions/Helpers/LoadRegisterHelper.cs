using m6502Simulator.lib;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions.Helpers;

public static class LoadRegisterHelper
{

    public static void TestLoadRegister(OpCode upCodeToTest, AddressMode addressMode, string registerToTest, Cpu cpu, Memory memory)
    {
        memory[0xFFFC] = (byte)upCodeToTest;
        cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

        var testValue = Random.Shared.NextByte();
        Helper.WriteValue(testValue, cpu, memory, addressMode);

        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerToTest)?.GetValue(cpu);

        Assert.That(registerValue, Is.EqualTo(testValue));
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }

    public static void TestLoadRegisterAffectsZeroFlag(OpCode upCodeToTest, AddressMode addressMode, string registerToTest, Cpu cpu, Memory memory)
    {
        memory[0xFFFC] = (byte)upCodeToTest;
        byte testValue = 0;

        Helper.WriteValue(testValue, cpu, memory, addressMode);

        cpu.Flag.Zero = false;
        cpu.Flag.Negative = true;

        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerToTest)?.GetValue(cpu);
        Assert.Multiple(() =>
        {
            Assert.That(registerValue, Is.EqualTo(testValue));
            Assert.That(cpu.Flag.Zero, Is.True);
            Assert.That(cpu.Flag.Negative, Is.False);
        });
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }

    public static void TestLoadRegisterAffectsNegativeFlag(OpCode upCodeToTest, AddressMode addressMode, string registerToTest, Cpu cpu, Memory memory)
    {
        memory[0xFFFC] = (byte)upCodeToTest;
        byte testValue = 0b1000_0000;

        Helper.WriteValue(testValue, cpu, memory, addressMode);

        cpu.Flag.Zero = true;
        cpu.Flag.Negative = false;

        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerToTest)?.GetValue(cpu);
        Assert.Multiple(() =>
        {
            Assert.That(registerValue, Is.EqualTo(testValue));
            Assert.That(cpu.Flag.Zero, Is.False);
            Assert.That(cpu.Flag.Negative, Is.True);
        });
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }

    private static void VerifyUnmodifiedFlagsFromLoadRegister(Cpu cpuBefore, Cpu cpu)
    {
        Assert.Multiple(() =>
        {
            Assert.That(cpuBefore.Flag.Carry, Is.EqualTo(cpu.Flag.Carry));
            Assert.That(cpuBefore.Flag.InterruptDisable, Is.EqualTo(cpu.Flag.InterruptDisable));
            Assert.That(cpuBefore.Flag.DecimalMode, Is.EqualTo(cpu.Flag.DecimalMode));
            Assert.That(cpuBefore.Flag.BreakMode, Is.EqualTo(cpu.Flag.BreakMode));
            Assert.That(cpuBefore.Flag.Overflow, Is.EqualTo(cpu.Flag.Overflow));
        });
    }

}