using System;
using IJunior.TypedScenes;
using Reflex.Attributes;
using Scripts.Gameplay.Abilities;
using Scripts.Gameplay.Cubs;
using Scripts.Gameplay.UI.Panels;
using Scripts.Menu.Leaderboard;
using Scripts.Servises;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class EntryPoint : MonoBehaviour, ISceneLoadHandler<GameConfig>
    {
        [SerializeField] private CubsRoot _cubsRoot;
        [SerializeField] private AbilityRouter _abilityRouter;
        [SerializeField] private TimerRoot _timerRoot;

        [SerializeField] private GameFinisher _gameFinisher;
        [SerializeField] private CoroutineServise _coroutineServise;

        [SerializeField] private EndGamePanel _endGamePanel;

        [SerializeField] private Locolization _localization;

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

            _localization.Initialize();
        }

        private void Awake()
        {
            SetUp();
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
}