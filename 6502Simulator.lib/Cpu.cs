using System;
using System.Collections.ObjectModel;
using m6502Simulator.lib.Instructions;

namespace m6502Simulator.lib;

public class CpuConstants
{
    public static byte CarryFlagBit = 0b00000001;
    public static byte ZeroFlagBit = 0b00000010;
    public static byte InterruptDisableFlagBit = 0b00000100;
    public static byte DecimalModeFlagBit = 0b00001000;
    public static byte BreakModeFlagBit = 0b00010000;
    public static byte UnusedFlagBit = 0b00100000;
    public static byte OverflowFlagBit = 0b01000000;
    public static byte NegativeFlagBit = 0b10000000;
}


public class Cpu
{

    public ushort ProgramCounter { get; set; }
    public byte StackPointer { get; set; }

    public byte RegisterA { get; set; }
    public byte RegisterX { get; set; }
    public byte RegisterY { get; set; }


    public byte ProcessorStatus
    {
        get => Flag.ProcessorStatus;
        set => Flag.ProcessorStatus = value;
    }

    public StatusFlag Flag { get; set; } = new();

    public void Reset(ushort resetVector)
    {
        ProgramCounter = resetVector;
        StackPointer = 0xFF;
        ProcessorStatus = 0;
        RegisterA = RegisterX = RegisterY = 0;
    }

    public byte FetchByte(Memory memory)
    {
        var data = memory[ProgramCounter];
        ProgramCounter++;
        return data;
    }

    public sbyte FetchSByte(Memory memory)
    {
        return (sbyte)FetchByte(memory);
    }

    public ushort FetchWord(Memory memory)
    {
        var first = FetchByte(memory);
        var second = FetchByte(memory);

        return BitConverter.ToUInt16(new[] { first, second });
    }

    public byte ReadByte(ushort address, Memory memory)
    {
        var data = memory[address];
        return data;
    }

    public ushort ReadWord(ushort address, Memory memory)
    {
        var first = ReadByte(address, memory);
        var second = ReadByte((ushort)(address + 1), memory);

        return BitConverter.ToUInt16(new[] { first, second });
    }

    public void WriteByte(byte value, ushort address, Memory memory)
    {
        memory[address] = value;
    }

    public void WriteWord(ushort value, ushort address, Memory memory)
    {
        memory[address] = (byte)(value & 0xFF);
        memory[address + 1] = (byte)(value >> 8);
    }

    public void PushWordOnStack(ushort value, Memory memory)
    {
        // high byte first
        WriteByte((byte)(value >> 8), StackPointerToAddress(), memory);
        StackPointer--;

        // low byte
        WriteByte((byte)(value & 0xFF), StackPointerToAddress(), memory);
        StackPointer--;
    }

    public void PushByteOnStack(byte value, Memory memory)
    {
        WriteByte(value, StackPointerToAddress(), memory);
        StackPointer--;
    }

    public ushort PopWordFromStack(Memory memory)
    {
        var stackPointerAddress = StackPointerToAddress();
        var value = ReadWord((ushort)(stackPointerAddress + 1), memory);
        StackPointer += 2;

        return value;
    }

    public byte PopByteFromStack(Memory memory)
    {
        StackPointer++;

        var stackPointerAddress = StackPointerToAddress();
        var value = memory[stackPointerAddress];

        return value;
    }

    public ushort StackPointerToAddress()
    {
        return (ushort)(0x100 | StackPointer);
    }


    public int ExecuteNextInstruction(Memory memory)
    {
        byte instructionByte = FetchByte(memory);
        var instruction = GetInstruction(instructionByte);
        instruction.Execute(this, memory);
        return instruction.RequiredCycles;
    }




    private IInstruction GetInstruction(byte instructionByte)
    {
        var instructions = IInstruction.GetInstructions();

        var instruction = instructions.FirstOrDefault(x => instructionByte == (byte)x.OpCode);
        if (instruction is not null)
        {
            return instruction;
        }

        throw new Exception($"Could not find an instruction for 0x{instructionByte:X2}.");
    }


    public Cpu Clone() => (Cpu) this.MemberwiseClone();
}
