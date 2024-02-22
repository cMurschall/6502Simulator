using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;

namespace m6502Simulator.test.Instructions;

public class LsrTest : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void Lsr_CanShiftValueOfOne()
    {
        LogicalShiftRightHelper.TestCanShiftValueOfOne(OpCode.LSR, AddressMode.Accumulator, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Lsr_CanShiftNegativeValue()
    {
        LogicalShiftRightHelper.TestCanShiftZeroToCarryFlag(OpCode.LSR, AddressMode.Accumulator, Cpu, Memory);
    }




    [Test]
    [Repeat(100)]
    public void Lsr_Absolute_CanShiftValueOfOne()
    {
        LogicalShiftRightHelper.TestCanShiftValueOfOne(OpCode.LSR_ABS, AddressMode.Absolute, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Lsr_Absolute_CanShiftNegativeValue()
    {
        LogicalShiftRightHelper.TestCanShiftZeroToCarryFlag(OpCode.LSR_ABS, AddressMode.Absolute, Cpu, Memory);
    }





    [Test]
    [Repeat(100)]
    public void Lsr_AbsoluteX_CanShiftValueOfOne()
    {
        LogicalShiftRightHelper.TestCanShiftValueOfOne(OpCode.LSR_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Lsr_AbsoluteX_CanShiftNegativeValue()
    {
        LogicalShiftRightHelper.TestCanShiftZeroToCarryFlag(OpCode.LSR_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
    }



    [Test]
    [Repeat(100)]
    public void Lsr_ZeroPage_CanShiftValueOfOne()
    {
        LogicalShiftRightHelper.TestCanShiftValueOfOne(OpCode.LSR_ZP, AddressMode.ZeroPage, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Lsr_ZeroPage_CanShiftNegativeValue()
    {
        LogicalShiftRightHelper.TestCanShiftZeroToCarryFlag(OpCode.LSR_ZP, AddressMode.ZeroPage, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Lsr_ZeroPageX_CanShiftValueOfOne()
    {
        LogicalShiftRightHelper.TestCanShiftValueOfOne(OpCode.LSR_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Lsr_ZeroPageX_CanShiftNegativeValue()
    {
        LogicalShiftRightHelper.TestCanShiftZeroToCarryFlag(OpCode.LSR_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
    }

}