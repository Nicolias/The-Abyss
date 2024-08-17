using System;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private FinalAnimation _finalAnimation;
    [SerializeField] private GameObject _ui;

    [SerializeField] private EndGameAdPanel _endGameAdPanel;

    private Timer _timer;
    private CubsCounter _cubsCounter;

    public void Initialize(Timer timer, CubsCounter cubsCounter)
    {
        if (timer == null)
            throw new ArgumentNullException();

        if (cubsCounter == null)
            throw new ArgumentNullException();

        _timer = timer;
        _cubsCounter = cubsCounter;
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
        _endGameAdPanel.Open(_cubsCounter.Value, ShowFinalAnimation);
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
        IJunior.TypedScenes.Menu.Load(_cubsCounter.Value);
    }
}
