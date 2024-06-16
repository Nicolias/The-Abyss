using System;
using UnityEngine;

public class AbilitiesConfig : IAbilitiesContainer
{
    public int SpeedAbilitieCount { get; private set; }
    public int ScaleAbilitieCount { get; private set; }
    public int FreezeTimeAbilitieCount { get; private set; }

    public void Initialize(int speedAbilitieCount, int scaleAbilitieCount, int freezeTimeAbilitieCount)
    {
        if (speedAbilitieCount < 0)
            throw new ArgumentOutOfRangeException();

        if (scaleAbilitieCount < 0)
            throw new ArgumentOutOfRangeException();

        if (freezeTimeAbilitieCount < 0)
            throw new ArgumentOutOfRangeException();

        SpeedAbilitieCount = speedAbilitieCount;
        ScaleAbilitieCount = scaleAbilitieCount;
        FreezeTimeAbilitieCount = freezeTimeAbilitieCount;
    }

    public void Add(AbstractItem item, int amount)
    {
        Add((dynamic)item, amount);

        Debug.Log(SpeedAbilitieCount);
        Debug.Log(ScaleAbilitieCount);
        Debug.Log(FreezeTimeAbilitieCount);
    }

    private void Add(SpeedItem freezeTimeItem, int amount)
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

    private void Add(ScaleItem freezeTimeItem, int amount)
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