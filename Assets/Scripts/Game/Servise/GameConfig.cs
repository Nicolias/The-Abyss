using System;

[Serializable]
public class GameConfig
{
    public int CubsCount { get; private set; } = 100;
    public int TimerValue { get; private set; } = 50;

    public AbilitiesConfig Abilities { get; private set; }

    public GameConfig(AbilitiesConfig abilities)
    {
        if (abilities == null)
            throw new NullReferenceException();

        Abilities = abilities;
    }
}
