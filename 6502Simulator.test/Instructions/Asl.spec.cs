using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.test.Instructions
{
    public class AslTest : CpuTestBase
    {


        [Test]
        [Repeat(100)]
        public void Asl_CanShiftValueOfOne()
        {
            ArithmeticShiftLeftHelper.TestCanShiftValueOfOne(OpCode.ASL, AddressMode.Accumulator, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_CanShiftNegativeValue()
        {
            ArithmeticShiftLeftHelper.TestCanShiftNegativeValue(OpCode.ASL, AddressMode.Accumulator, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_Absolute_CanShiftValueOfOne()
        {
            ArithmeticShiftLeftHelper.TestCanShiftValueOfOne(OpCode.ASL_ABS, AddressMode.Absolute, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_Absolute_CanShiftNegativeValue()
        {
            ArithmeticShiftLeftHelper.TestCanShiftNegativeValue(OpCode.ASL_ABS, AddressMode.Absolute, Cpu, Memory);
        }





        [Test]
        [Repeat(100)]
        public void Asl_AbsoluteX_CanShiftValueOfOne()
        {
            ArithmeticShiftLeftHelper.TestCanShiftValueOfOne(OpCode.ASL_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_AbsoluteX_CanShiftNegativeValue()
        {
            ArithmeticShiftLeftHelper.TestCanShiftNegativeValue(OpCode.ASL_ABSX, AddressMode.AbsoluteX, Cpu, Memory);
        }




        [Test]
        [Repeat(100)]
        public void Asl_ZeroPage_CanShiftValueOfOne()
        {
            ArithmeticShiftLeftHelper.TestCanShiftValueOfOne(OpCode.ASL_ZP, AddressMode.ZeroPage, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_ZeroPage_CanShiftNegativeValue()
        {
            ArithmeticShiftLeftHelper.TestCanShiftNegativeValue(OpCode.ASL_ZP, AddressMode.ZeroPage, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_ZeroPageX_CanShiftValueOfOne()
        {
            ArithmeticShiftLeftHelper.TestCanShiftValueOfOne(OpCode.ASL_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Asl_ZeroPageX_CanShiftNegativeValue()
        {
            ArithmeticShiftLeftHelper.TestCanShiftNegativeValue(OpCode.ASL_ZPX, AddressMode.ZeroPageX, Cpu, Memory);
        }


    }
}
