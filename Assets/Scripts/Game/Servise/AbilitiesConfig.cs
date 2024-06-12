using System;

[Serializable]
public class AbilitiesConfig
{
    public AbilitiesConfig(int speedAbilitieCount, int scaleAbilitieCount, int freezeTimeAbilitieCount)
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

    public int SpeedAbilitieCount { get; private set; }
    public int ScaleAbilitieCount { get; private set; }
    public int FreezeTimeAbilitieCount { get; private set; }
}