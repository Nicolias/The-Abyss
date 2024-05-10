using System;

[Serializable]
public class GameConfig
{
    public int CubsCount { get; private set; } = 100;
    public int TimerValue { get; private set; } = 50;
}