using System;
using System.Collections;
using SliderViewNameSpace;
using UnityEngine;

public class Timer : MonoBehaviour, IChangable
{
    private bool _isPause;

    public int MaxValue { get; private set; }
    public event Action<float> Changed;

    public void Initialize(int maxTime)
    {
        MaxValue = maxTime;
        
        StartCoroutine(PlayTimer());
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
    }
}
