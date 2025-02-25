using System;
using System.Collections;
using Reflex.Attributes;
using SliderViewNameSpace;
using UnityEngine;

public class Timer : MonoBehaviour, IChangable, IPausableObject
{
    private bool _isPause;

    private Coroutine _currentTimer;
    private PausServise _pauseServise;

    public int MaxValue { get; private set; }

    public event Action<float> Changed;
    public event Action Finished;

    [Inject]
    public void Construct(PausServise pausServise)
    {
        _pauseServise = pausServise;
        _pauseServise.Add(this);
    }

    public void Initialize(int maxTime)
    {
        MaxValue = maxTime;

        _currentTimer = StartCoroutine(PlayTimer());
    }

    public void Reset()
    {
        StopCoroutine(_currentTimer);
        _isPause = false;
    }

    public void Paus()
    {
        _isPause = true;
    }

    public void UnPaus()
    {
        _isPause = false;
    }

    private IEnumerator PlayTimer()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
        int timeLeft = MaxValue;

        while (timeLeft > 0)
        {
            if (_isPause)
            {
                yield return null;
            }
            else
            {
                Changed?.Invoke(timeLeft);

                yield return waitForSeconds;
                timeLeft--;
            }
        }

        Finished?.Invoke();
    }

    private void OnBackgroundChanged(bool inBackground)
    {
        _isPause = inBackground;
    }
}
