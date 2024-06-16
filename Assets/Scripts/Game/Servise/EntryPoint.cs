using IJunior.TypedScenes;
using SliderViewNameSpace;
using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour, ISceneLoadHandler<GameConfig>
{
    [SerializeField] private CubsRoot _cubsRoot;
    [SerializeField] private AbilitiesRoot _abilitiesRoot;
    
    [SerializeField] private Timer _timer;
    [SerializeField] private TimerSlider _timerTimerSlider;

    public void OnSceneLoaded(GameConfig argument)
    {
        if (argument == null)
            throw new NullReferenceException();

        _cubsRoot.Initialize(argument.CubsCount);
        _abilitiesRoot.Initialize(argument.Abilities);

        _timer.Initialize(argument.TimerValue);
        _timerTimerSlider.Initialize(_timer);
    }
}