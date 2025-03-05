using System;
using Scripts.Gameplay.Cubs;
using Scripts.Gameplay.Hole;
using Scripts.Gameplay.UI.Panels;
using Scripts.Menu.Leaderboard;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class GameFinisher : MonoBehaviour
    {
        [SerializeField] private FinalAnimation _finalAnimation;
        [SerializeField] private GameObject _ui;

        [SerializeField] private StatisticPanel _statisticPanel;
        [SerializeField] private HoleMovement _holeMovement;

        [SerializeField] private EndGamePanel _endGamePanel;

        private Timer _timer;
        private CubsCounter _cubsCounter;
        private LeaderboardReader _leaderboardReader;

        public event Action GameFinished;

        public void Initialize(Timer timer, CubsCounter cubsCounter, LeaderboardReader leaderboardReader)
        {
            if (timer == null)
                throw new ArgumentNullException();

            if (cubsCounter == null)
                throw new ArgumentNullException();

            if (leaderboardReader == null)
                throw new ArgumentNullException();

            _timer = timer;
            _cubsCounter = cubsCounter;
            _leaderboardReader = leaderboardReader;
        }

        public void Enbale()
        {
            _cubsCounter.Changed += OnScoreChanged;
            _timer.Finished += FinishGame;
            _finalAnimation.Complete += OnFinalAnimationComplete;
        }

        public void Disable()
        {
            _cubsCounter.Changed -= OnScoreChanged;
            _timer.Finished -= FinishGame;
            _finalAnimation.Complete -= OnFinalAnimationComplete;
        }

        private void FinishGame()
        {
            _timer.Reset();
            _ui.SetActive(false);
            _statisticPanel.Open(_cubsCounter.Value, _cubsCounter.MaxValue, ShowFinalAnimation);
            _holeMovement.Stop();
        }

        private void ShowFinalAnimation()
        {
            _finalAnimation.Show(_cubsCounter.CollectedCubs);
        }

        private void OnScoreChanged(float currentCubs)
        {
            if (currentCubs != _cubsCounter.MaxValue)
                return;

            FinishGame();
        }

        private void OnFinalAnimationComplete()
        {
            GameFinished?.Invoke();
            _endGamePanel.Open();
            _leaderboardReader.SetPlayerScore(_cubsCounter.Value);
        }
    }
}