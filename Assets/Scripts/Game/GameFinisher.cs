using System;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private FinalAnimation _finalAnimation;
    [SerializeField] private GameObject _ui;

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
        _cubsCounter.Changed += OnChanged;
        _timer.Finished += FinishGame;
        _finalAnimation.Complete += OnComplete;
    }

    public void Disable()
    {
        _cubsCounter.Changed -= OnChanged;
        _timer.Finished -= FinishGame;
        _finalAnimation.Complete -= OnComplete;
    }

    private void OnChanged(float currentCubs)
    {
        if (currentCubs != _cubsCounter.MaxValue)
            return;

        FinishGame();
    }

    private void FinishGame()
    {
        _timer.Reset();
        _finalAnimation.Show(_cubsCounter.CollectedCubs);
        _ui.SetActive(false);
    }

    private void OnComplete()
    {
        IJunior.TypedScenes.Menu.Load(_cubsCounter.Value);
    }
}