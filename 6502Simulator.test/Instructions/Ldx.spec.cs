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
    public class Ldx : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Ldx_Immediate_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDX_IM, AddressMode.Immediate, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_Immediate_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_IM, AddressMode.Immediate, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_Immediate_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_IM, AddressMode.Immediate, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_Absolute_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_Absolute_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_Absolute_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Ldx_AbsoluteY_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDX_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_AbsoluteY_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_AbsoluteY_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterX), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Ldx_ZeroPage_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_ZeroPage_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_ZeroPage_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_ZeroPageY_StoresValue()
        {
            Helper.TestLoadRegister(OpCode.LDX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_ZeroPageY_AffectsZeroFlag()
        {
            Helper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Ldx_ZeroPageY_StoresValueAffectsNegativeFlag()
        {
            Helper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
        }



    }
}
