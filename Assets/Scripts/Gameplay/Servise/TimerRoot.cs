using Scripts.Gameplay.UI.Sliders;
using UnityEngine;

public class TimerRoot : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TimerSlider _timerTimerSlider;

    public Timer Timer => _timer;

    public void Initialize(int timeValue)
    {
        _timer.Initialize(timeValue);
        _timerTimerSlider.Initialize(_timer);
    }
}