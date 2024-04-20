using SliderViewNameSpace;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private CubsCounter _cubsCounter;
    [SerializeField] private SmoothSliderView _fillCubsSlider;
    
    [SerializeField] private Timer _timer;
    [SerializeField] private TimerSlider _timerTimerSlider;

    private void Start()
    {
        _cubsCounter.Initialize(10);
        _fillCubsSlider.Initialize(_cubsCounter);

        _timer.Initialize(30);
        _timerTimerSlider.Initialize(_timer);
    }
}
