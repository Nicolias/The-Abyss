using System;
using System.Collections;
using SliderViewNameSpace;
using UnityEngine;

public class Timer : MonoBehaviour, IChangable
{
    private bool _isPause;

    private Coroutine _currentTimer;

    public int MaxValue { get; private set; }

    public event Action<float> Changed;
    public event Action Finished;

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

    public void Pause()
    {
        _isPause = true;
    }

    public void UnPause()
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
}
