using System;

public class WalletModel : IChangeable
{
    public int Value { get; private set; }

    public event Action Changed;

    public void Accure(int value)
    {
        if (Value < 0)
            throw new ArgumentOutOfRangeException();

        Value += value;
        Changed?.Invoke();
    }

    public void Spent(int value)
    {
        if (Value < 0)
            throw new ArgumentOutOfRangeException();

        Value -= value;
        Changed?.Invoke();
    }
}
