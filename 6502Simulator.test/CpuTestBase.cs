using m6502Simulator.lib;
using NUnit.Framework;

namespace m6502Simulator.test;

[TestFixture]
public abstract class CpuTestBase
{
    protected readonly Cpu Cpu = new();
    protected readonly Memory Memory = new();


    [SetUp]
    public void Setup()
    {
        Cpu.Reset(0xFFFC);
        Memory.Reset();
    }

}