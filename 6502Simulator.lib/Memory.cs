namespace m6502Simulator.lib;

public class Memory
{
    private const byte _defaultByte = 0;

    public const int MaxMemory = 1024 * 64;

    public byte[] Data { get; } = Enumerable.Repeat(_defaultByte, MaxMemory).ToArray();


    public void Reset()
    {
        for (var i = 0; i < Data.Length; i++)
        {
            Data[i] = _defaultByte;
        }
    }


    public byte this[int index]
    {
        get => Data[Math.Clamp(index, 0, Data.Length - 1)];
        set => Data[Math.Clamp(index, 0, Data.Length - 1)] = value;
    }

}