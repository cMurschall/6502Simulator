using m6502Simulator.test;
using m6502Simulator.test.Instructions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;

namespace _6502Simulator.test.Instructions
{
    public class LdyTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void LDY_Immediate_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDY_IM, AddressMode.Immediate, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_Immediate_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_IM, AddressMode.Immediate, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_Immediate_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_IM, AddressMode.Immediate, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_Absolute_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_Absolute_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_Absolute_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void LDY_AbsoluteX_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDY_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_AbsoluteX_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_AbsoluteX_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterY), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void LDY_ZeroPage_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_ZeroPage_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_ZeroPage_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_ZeroPageY_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_ZeroPageY_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void LDY_ZeroPageY_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
        }

    }
}
