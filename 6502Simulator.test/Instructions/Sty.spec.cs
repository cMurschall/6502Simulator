using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m6502Simulator.lib;

namespace m6502Simulator.test.Instructions
{
    public class StyTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Sty_Absolute_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Sty_ZeroPage_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
        }



        [Test]
        [Repeat(100)]
        public void Sty_ZeroPageX_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
        }


    }
}
