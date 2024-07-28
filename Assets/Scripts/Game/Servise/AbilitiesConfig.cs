using System;
using UnityEngine;

public class AbilitiesConfig : IAbilitiesContainer
{
    private SaveLoader _saveLoader;

    public int SpeedAbilitieCount { get; private set; }
    public int ScaleAbilitieCount { get; private set; }
    public int FreezeTimeAbilitieCount { get; private set; }

    public AbilitiesConfig(SaveLoader saveLoader)
    {
        _saveLoader = saveLoader;

        SpeedAbilitieCount = saveLoader.LoadOrDefault(nameof(SpeedAbilitieCount));
        ScaleAbilitieCount = saveLoader.LoadOrDefault(nameof(ScaleAbilitieCount));
        FreezeTimeAbilitieCount = saveLoader.LoadOrDefault(nameof(FreezeTimeAbilitieCount));
    }

    public void Add(AbstractItem item, int amount)
    {
        Add((dynamic)item, amount);
    }

    private void Add(SpeedItem speedTime, int amount)
    {
        if(amount < 0) 
            throw new ArgumentOutOfRangeException();

        SpeedAbilitieCount += amount;
    }

    private void Add(FreezeTimeItem freezeTimeItem, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException();

        FreezeTimeAbilitieCount += amount;
    }

    private void Add(ScaleItem scaleItem, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException();

        ScaleAbilitieCount += amount;
    }
}

public interface IAbilitiesContainer
{
    void Add(AbstractItem item, int amount);
}