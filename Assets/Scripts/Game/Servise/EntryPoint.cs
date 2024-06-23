using IJunior.TypedScenes;
using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour, ISceneLoadHandler<GameConfig>
{
    [SerializeField] private CubsRoot _cubsRoot;
    [SerializeField] private AbilitiesRoot _abilitiesRoot;
    [SerializeField] private TimerRoot _timerRoot;

    [SerializeField] private GameFinisher _gameFinisher;

    public void OnSceneLoaded(GameConfig argument)
    {
        if (argument == null)
            throw new NullReferenceException();

        _cubsRoot.Initialize(argument.CubsCount);
        _timerRoot.Initialize(argument.TimerValue);
        _abilitiesRoot.Initialize(argument.Abilities);

        _gameFinisher.Initialize(_timerRoot.Timer, _cubsRoot.CubsCounter);
    }

    private void OnEnable()
    {
        _gameFinisher.Enbale();
    }

    private void OnDisable()
    {
        _gameFinisher.Disable();
    }
}