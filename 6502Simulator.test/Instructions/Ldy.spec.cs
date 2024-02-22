using NUnit.Framework;
using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;

namespace m6502Simulator.test.Instructions;

public class LdyTest : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void LDY_Immediate_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDY_IM, AddressMode.Immediate, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_Immediate_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_IM, AddressMode.Immediate, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_Immediate_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_IM, AddressMode.Immediate, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_Absolute_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_Absolute_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_Absolute_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ABS, AddressMode.Absolute, nameof(Cpu.RegisterY), Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void LDY_AbsoluteX_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDY_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_AbsoluteX_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_AbsoluteX_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterY), Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void LDY_ZeroPage_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_ZeroPage_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_ZeroPage_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_ZeroPageY_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_ZeroPageY_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void LDY_ZeroPageY_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDY_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterY), Cpu, Memory);
    }

}