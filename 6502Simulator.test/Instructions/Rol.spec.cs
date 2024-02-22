using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;

namespace m6502Simulator.test.Instructions;

public class RolTEst : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void Rol_Accumulator_CanCanShiftOutCarryFlag()
    {
        RotateLeftHelper.TestCanShiftOutCarryFlag(OpCode.ROL, AddressMode.Accumulator, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_Accumulator_CanShiftABitIntoTheCarryFlag()
    {
        RotateLeftHelper.TestCanShiftABitIntoTheCarryFlag(OpCode.ROL, AddressMode.Accumulator, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_Accumulator_TestCanShiftToNegative()
    {
        RotateLeftHelper.TestCanShiftToNegative(OpCode.ROL, AddressMode.Accumulator, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_Accumulator_CanShiftZeroWithNoCarry()
    {
        RotateLeftHelper.TestCanShiftZeroWithNoCarry(OpCode.ROL, AddressMode.Accumulator, Cpu, Memory);
    }









    [Test]
    [Repeat(100)]
    public void Rol_Absolute_CanCanShiftOutCarryFlag()
    {
        RotateLeftHelper.TestCanShiftOutCarryFlag(OpCode.ROL_ABS, AddressMode.Absolute, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_Absolute_CanShiftABitIntoTheCarryFlag()
    {
        RotateLeftHelper.TestCanShiftABitIntoTheCarryFlag(OpCode.ROL_ABS, AddressMode.Absolute, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_Absolute_TestCanShiftToNegative()
    {
        RotateLeftHelper.TestCanShiftToNegative(OpCode.ROL_ABS, AddressMode.Absolute, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_Absolute_CanShiftZeroWithNoCarry()
    {
        RotateLeftHelper.TestCanShiftZeroWithNoCarry(OpCode.ROL_ABS, AddressMode.Absolute, Cpu, Memory);
    }









    [Test]
    [Repeat(100)]
    public void Rol_AbsoluteX_CanCanShiftOutCarryFlag()
    {
        RotateLeftHelper.TestCanShiftOutCarryFlag(OpCode.ROL_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_AbsoluteX_CanShiftABitIntoTheCarryFlag()
    {
        RotateLeftHelper.TestCanShiftABitIntoTheCarryFlag(OpCode.ROL_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_AbsoluteX_TestCanShiftToNegative()
    {
        RotateLeftHelper.TestCanShiftToNegative(OpCode.ROL_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_AbsoluteX_CanShiftZeroWithNoCarry()
    {
        RotateLeftHelper.TestCanShiftZeroWithNoCarry(OpCode.ROL_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
    }










    [Test]
    [Repeat(100)]
    public void Rol_ZeroPage_CanCanShiftOutCarryFlag()
    {
        RotateLeftHelper.TestCanShiftOutCarryFlag(OpCode.ROL_ZP, AddressMode.ZeroPage, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_ZeroPage_CanShiftABitIntoTheCarryFlag()
    {
        RotateLeftHelper.TestCanShiftABitIntoTheCarryFlag(OpCode.ROL_ZP, AddressMode.ZeroPage, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_ZeroPage_TestCanShiftToNegative()
    {
        RotateLeftHelper.TestCanShiftToNegative(OpCode.ROL_ZP, AddressMode.ZeroPage, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_ZeroPage_CanShiftZeroWithNoCarry()
    {
        RotateLeftHelper.TestCanShiftZeroWithNoCarry(OpCode.ROL_ZP, AddressMode.ZeroPage, Cpu, Memory);
    }









    [Test]
    [Repeat(100)]
    public void Rol_ZeroPageX_CanCanShiftOutCarryFlag()
    {
        RotateLeftHelper.TestCanShiftOutCarryFlag(OpCode.ROL_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_ZeroPageX_CanShiftABitIntoTheCarryFlag()
    {
        RotateLeftHelper.TestCanShiftABitIntoTheCarryFlag(OpCode.ROL_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_ZeroPageX_TestCanShiftToNegative()
    {
        RotateLeftHelper.TestCanShiftToNegative(OpCode.ROL_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Rol_ZeroPageX_CanShiftZeroWithNoCarry()
    {
        RotateLeftHelper.TestCanShiftZeroWithNoCarry(OpCode.ROL_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
    }





}