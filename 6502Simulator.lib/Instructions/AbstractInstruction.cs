using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace m6502Simulator.lib.Instructions;

public interface IInstruction
{
    public OpCode OpCode { get; }

    public int RequiredCycles { get; }
    public void Execute(Cpu cpu, Memory memory);

    static IReadOnlyList<IInstruction> GetInstructions()
    {
        return new IInstruction[]
        {
            // lda
            new LdaImmediate(),
            new LdaAbsolute(),
            new LdaAbsoluteX(),
            new LdaAbsoluteY(),
            new LdaZeroPage(),
            new LdaZeroPageX(),
            new LdaIndirectX(),
            new LdaIndirectY(),
            // ldx
            new LdxImmediate(),
            new LdxAbsolute(),
            new LdxAbsoluteY(),
            new LdxZeroPage(),
            new LdxZeroPageY(),
            // ldy
            new LdyImmediate(),
            new LdyAbsolute(),
            new LdyAbsoluteX(),
            new LdyZeroPage(),
            new LdyZeroPageX(),
            // sta
            new StaAbsolute(),
            new StaAbsoluteX(),
            new StaAbsoluteY(),
            new StaZeroPage(),
            new StaZeroPageX(),
            new StaIndirectX(),
            new StaIndirectY(),
            //stx
            new StxAbsolute(),
            new StxZeroPage(),
            new StxZeroPageY(),
            // sty
            new StyAbsolute(),
            new StyZeroPage(),
            new StyZeroPageY(),

            // transfers
            new Tax(),
            new Tay(),
            new Tsx(),
            new Txa(),
            new Txs(),
            new Tya(),
        };
    }
}