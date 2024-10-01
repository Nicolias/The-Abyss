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

    [SerializeField] private EndGamePanel _endGamePanel;

    private GameConfig _gameConfig;
    private AdServise _adServise;
    private LeaderboardReader _leaderboardReader;

    [Inject]
    public void Construct(AdServise adServise, LeaderboardReader leaderboardReader)
    {
        _adServise = adServise;
        _leaderboardReader = leaderboardReader;
    }

    public void OnSceneLoaded(GameConfig argument)
    {
        if (argument == null)
            throw new NullReferenceException();

        _gameConfig = argument;
    }

    private void Awake()
    {
        Reset();
    }

    private void OnEnable()
    {
        _gameFinisher.GameFinished += Disable;
    }

    private void OnDisable()
    {
        _gameFinisher.GameFinished -= Disable;
    }

    public void Reset()
    {
        _adServise.ShowInterstation(SetUp);
    }

    private void SetUp()
    {
        _cubsRoot.Initialize(_gameConfig.CubsCount);
        _timerRoot.Initialize(_gameConfig.TimerValue);
        _abilityRouter.Initialize(_gameConfig.Abilities.Items, _coroutineServise);

        _gameFinisher.Initialize(_timerRoot.Timer, _cubsRoot.CubsCounter, _leaderboardReader);

        _endGamePanel.Initialize(_gameConfig);

        Enable();
    }

    private void Enable()
    {
        _gameFinisher.Enbale();
        _abilityRouter.Enable();
    }

    private void Disable()
    {
        _gameFinisher.Disable();
        _abilityRouter.Disable();
    }
}