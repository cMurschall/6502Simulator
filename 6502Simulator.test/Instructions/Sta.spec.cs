using NUnit.Framework;
using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;

namespace m6502Simulator.test.Instructions
{
    public class StaTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Sta_Absolute_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_ABS, AddressMode.Absolute, nameof(Cpu.RegisterA), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Sta_AbsoluteX_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterA), Cpu, Memory);
        }

        [Test]
        [Repeat(100)]
        public void Sta_AbsoluteY_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterA), Cpu, Memory);
        }



        [Test]
        [Repeat(100)]
        public void Sta_ZeroPage_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterA), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Sta_ZeroPageX_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterA), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Sta_IndirectX_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_INDX, AddressMode.IndirectX, nameof(Cpu.RegisterA), Cpu, Memory);
        }



        [Test]
        [Repeat(100)]
        public void Sta_IndirectY_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STA_INDY, AddressMode.IndirectY, nameof(Cpu.RegisterA), Cpu, Memory);
        }

    }
}
