using NUnit.Framework;
using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;

namespace m6502Simulator.test.Instructions;

public class LdxTest : CpuTestBase
{

    [Test]
    [Repeat(100)]
    public void Ldx_Immediate_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDX_IM, AddressMode.Immediate, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_Immediate_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_IM, AddressMode.Immediate, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_Immediate_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_IM, AddressMode.Immediate, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_Absolute_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_Absolute_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_Absolute_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ABS, AddressMode.Absolute, nameof(Cpu.RegisterX), Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Ldx_AbsoluteY_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDX_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_AbsoluteY_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_AbsoluteY_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterX), Cpu, Memory);
    }


    [Test]
    [Repeat(100)]
    public void Ldx_ZeroPage_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_ZeroPage_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_ZeroPage_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_ZeroPageY_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_ZeroPageY_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Ldx_ZeroPageY_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDX_ZPY, AddressMode.ZeroPageY, nameof(Cpu.RegisterX), Cpu, Memory);
    }



}