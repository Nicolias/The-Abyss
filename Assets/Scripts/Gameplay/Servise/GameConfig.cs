using System;

[Serializable]
public class GameConfig
{
    public int CubsCount { get; private set; } = 174;
    public int TimerValue { get; private set; } = 20;

    public AbilitiesConfig Abilities { get; private set; }

    public GameConfig(AbilitiesConfig abilities)
    {
        if (abilities == null)
            throw new NullReferenceException();

        Abilities = abilities;
    }
}
