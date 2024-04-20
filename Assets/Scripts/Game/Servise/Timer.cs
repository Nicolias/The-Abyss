using System;
using System.Collections;
using SliderViewNameSpace;
using UnityEngine;

public class Timer : MonoBehaviour, IChangable
{
    public int MaxValue { get; private set; }
    public event Action<float> Changed;

    public void Initialize(int maxTime)
    {
        MaxValue = maxTime;
        
        StartCoroutine(PlayTimer());
    }

    private IEnumerator PlayTimer()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
        int timeLeft = MaxValue;
        
        while (timeLeft > 0)
        {
            yield return waitForSeconds;
            timeLeft--;

            Changed?.Invoke(timeLeft);
        }
    }
}
