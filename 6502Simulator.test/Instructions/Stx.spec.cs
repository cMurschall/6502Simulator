using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;
using m6502Simulator.lib;

namespace m6502Simulator.test.Instructions
{
    public class StxTest : CpuTestBase
    {

        [Test]
        [Repeat(100)]
        public void Stx_Absolute_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
        }


        [Test]
        [Repeat(100)]
        public void Stx_ZeroPage_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
        }



        [Test]
        [Repeat(100)]
        public void Stx_ZeroPageY_StoresValue()
        {
            StoreHelper.TestStoreRegister(OpCode.STX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
        }


    }
}
