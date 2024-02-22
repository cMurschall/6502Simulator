using m6502Simulator.lib;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions.Helpers;

public static class TransferHelper
{



    public static void TestTransferRegister(OpCode upCodeToTest, string registerSource, string registerTarget, Cpu cpu, Memory memory)
    {
        cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

        var testValue = Random.Shared.NextByte(0xFE);
        memory[0xFFFC] = (byte)upCodeToTest;
        memory[0xFFFD] = testValue;

        typeof(Cpu).GetProperty(registerSource)?.SetValue(cpu, testValue);
        typeof(Cpu).GetProperty(registerTarget)?.SetValue(cpu, (byte)0xFF);

        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerTarget)?.GetValue(cpu);

        Assert.That(registerValue, Is.EqualTo(testValue));
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }

    public static void TestTransferRegisterAffectsZeroFlag(OpCode upCodeToTest, string registerSource, string registerTarget, Cpu cpu, Memory memory)
    {


        cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

        byte testValue = 0;
        memory[0xFFFC] = (byte)upCodeToTest;
        memory[0xFFFD] = testValue;

        cpu.Flag.Zero = false;
        cpu.Flag.Negative = true;

        typeof(Cpu).GetProperty(registerSource)?.SetValue(cpu, testValue);
        typeof(Cpu).GetProperty(registerTarget)?.SetValue(cpu, (byte)0xFF);

        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerTarget)?.GetValue(cpu);

        Assert.That(registerValue, Is.EqualTo(testValue));
        Assert.Multiple(() =>
        {
            Assert.That(registerValue, Is.EqualTo(testValue));
            Assert.That(cpu.Flag.Zero, Is.True);
            Assert.That(cpu.Flag.Negative, Is.False);
        });
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }

    public static void TestTransferRegisterAffectsNegativeFlag(OpCode upCodeToTest, string registerSource, string registerTarget, Cpu cpu, Memory memory)
    {

        byte testValue = 0b1000_0000;

        memory[0xFFFC] = (byte)upCodeToTest;
        memory[0xFFFD] = testValue;

        cpu.Flag.Zero = true;
        cpu.Flag.Negative = false;


        typeof(Cpu).GetProperty(registerSource)?.SetValue(cpu, testValue);
        typeof(Cpu).GetProperty(registerTarget)?.SetValue(cpu, (byte)0xFF);



        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerTarget)?.GetValue(cpu);

        Assert.Multiple(() =>
        {
            Assert.That(registerValue, Is.EqualTo(testValue));
            Assert.That(cpu.Flag.Zero, Is.False);
            Assert.That(cpu.Flag.Negative, Is.True);
        });
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }





    public static void TestTransferToStack(OpCode upCodeToTest, string registerSource, Cpu cpu, Memory memory)
    {
        cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

        var testValue = Random.Shared.NextByte(0xFE);
        memory[0xFFFC] = (byte)upCodeToTest;

        typeof(Cpu).GetProperty(registerSource)?.SetValue(cpu, testValue);

        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);


        Assert.That(memory[cpu.StackPointerToAddress() + 1], Is.EqualTo(testValue));
        Assert.That(cpuBefore.Flag.ProcessorStatus, Is.EqualTo(cpu.Flag.ProcessorStatus));
        Assert.That(cpuBefore.StackPointerToAddress(), Is.EqualTo(cpu.StackPointerToAddress() + 1));
    }




    public static void TestTransferFromStack(OpCode upCodeToTest, string registerTarget, Cpu cpu, Memory memory)
    {
        cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

        var testValue = Random.Shared.NextByte();
        cpu.StackPointer = 0xFE;
        memory[0xFFFC] = (byte)upCodeToTest;
        memory[0x01FF] = testValue;

        var cpuBefore = cpu.Clone();

        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerTarget)?.GetValue(cpu);

        Assert.That(registerValue, Is.EqualTo(testValue));
        Assert.That(cpuBefore.StackPointerToAddress(), Is.EqualTo(cpu.StackPointerToAddress() - 1));
    }

    public static void TestTransferFromStackAffectsZeroFlag(OpCode upCodeToTest,  string registerTarget, Cpu cpu, Memory memory)
    {
        cpu.Flag.ProcessorStatus = Random.Shared.NextByte();

        byte testValue = 0;
        cpu.StackPointer = 0xFE;
        memory[0xFFFC] = (byte)upCodeToTest;
        memory[0x01FF] = testValue;

        cpu.Flag.Zero = false;
        cpu.Flag.Negative = true;


        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerTarget)?.GetValue(cpu);

        Assert.That(registerValue, Is.EqualTo(testValue));
        Assert.Multiple(() =>
        {
            Assert.That(registerValue, Is.EqualTo(testValue));
            Assert.That(cpu.Flag.Zero, Is.True);
            Assert.That(cpu.Flag.Negative, Is.False);
        });
        VerifyUnmodifiedFlagsFromLoadRegister(cpuBefore, cpu);
    }

    public static void TestTransferFromStackAffectsNegativeFlag(OpCode upCodeToTest, string registerTarget, Cpu cpu, Memory memory)
    {

        byte testValue = 0b1000_0000;

        cpu.StackPointer = 0xFE;
        memory[0xFFFC] = (byte)upCodeToTest;
        memory[0x01FF] = testValue;

        cpu.Flag.Zero = true;
        cpu.Flag.Negative = false;


        var cpuBefore = cpu.Clone();
        cpu.ExecuteNextInstruction(memory);

        var registerValue = typeof(Cpu).GetProperty(registerTarget)?.GetValue(cpu);

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