using IJunior.TypedScenes;
using Reflex.Attributes;
using System;
using UnityEngine;

public class EntryPoint : MonoBehaviour, ISceneLoadHandler<GameConfig>
{
    [SerializeField] private CubsRoot _cubsRoot;
    [SerializeField] private AbilityRouter _abilityRouter;
    [SerializeField] private TimerRoot _timerRoot;

    [SerializeField] private GameFinisher _gameFinisher;
    [SerializeField] private CoroutineServise _coroutineServise;

    private GameConfig _gameConfig;
    private SoundConfig _soundConfig;

    [Inject]
    public void Construct(SoundConfig soundConfig)
    {
        _soundConfig = soundConfig;
    }

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
        _abilityRouter.Initialize(_gameConfig.Abilities.Items, _coroutineServise, _soundConfig);

        _gameFinisher.Initialize(_timerRoot.Timer, _cubsRoot.CubsCounter);
    }

    private void OnEnable()
    {
        _gameFinisher.Enbale();
        _abilityRouter.Enable();
    }

    private void OnDisable()
    {
        _gameFinisher.Disable();
        _abilityRouter.Disable();
    }
}