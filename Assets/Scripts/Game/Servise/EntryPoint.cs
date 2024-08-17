using IJunior.TypedScenes;
using System;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour, ISceneLoadHandler<GameConfig>
{
    [SerializeField] private CubsRoot _cubsRoot;
    [SerializeField] private AbilitiesRoot _abilitiesRoot;
    [SerializeField] private TimerRoot _timerRoot;

    [SerializeField] private GameFinisher _gameFinisher;
    [SerializeField] private CoroutineServise _coroutineServise;

    private GameConfig _gameConfig;

    public void OnSceneLoaded(GameConfig argument)
    {
        if (argument == null)
            throw new NullReferenceException();

        _gameConfig = argument;
    }

    private void Awake()
    {
        _cubsRoot.Initialize(_gameConfig.CubsCount);
        _timerRoot.Initialize(_gameConfig.TimerValue);
        _abilitiesRoot.Initialize(_gameConfig.Abilities, _coroutineServise);

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