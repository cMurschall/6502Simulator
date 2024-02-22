
using m6502Simulator.lib;
using m6502Simulator.test.Instructions.Helpers;
using NUnit.Framework;

namespace m6502Simulator.test.Instructions;

public class LdaTest : CpuTestBase
{
    [Test]
    [Repeat(100)]
    public void Lda_Immediate_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_IM, AddressMode.Immediate, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_Immediate_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_IM, AddressMode.Immediate, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_Immediate_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_IM, AddressMode.Immediate, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_Absolute_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_ABS, AddressMode.Absolute, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_Absolute_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_ABS, AddressMode.Absolute, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_Absolute_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_ABS, AddressMode.Absolute, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_AbsoluteX_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_AbsoluteX_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_AbsoluteX_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_ABSX, AddressMode.AbsoluteX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_AbsoluteY_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_AbsoluteY_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_AbsoluteY_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_ABSY, AddressMode.AbsoluteY, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_IndirectX_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_INDX, AddressMode.IndirectX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_IndirectX_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_INDX, AddressMode.IndirectX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_IndirectX_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_INDX, AddressMode.IndirectX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_IndirectY_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_INDY, AddressMode.IndirectY, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_IndirectY_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_INDY, AddressMode.IndirectY, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_IndirectY_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_INDY, AddressMode.IndirectY, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_ZeroPage_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_ZeroPage_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_ZeroPage_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_ZP, AddressMode.ZeroPage, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_ZeroPageX_StoresValue()
    {
        LoadRegisterHelper.TestLoadRegister(OpCode.LDA_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_ZeroPageX_AffectsZeroFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsZeroFlag(OpCode.LDA_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterA), Cpu, Memory);
    }

    [Test]
    [Repeat(100)]
    public void Lda_ZeroPageX_StoresValueAffectsNegativeFlag()
    {
        LoadRegisterHelper.TestLoadRegisterAffectsNegativeFlag(OpCode.LDA_ZPX, AddressMode.ZeroPageX, nameof(Cpu.RegisterA), Cpu, Memory);
    }
}