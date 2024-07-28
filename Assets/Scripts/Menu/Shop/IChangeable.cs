using System;

public interface IChangeable
{
    public int Value { get; }

    public event Action Changed;
}