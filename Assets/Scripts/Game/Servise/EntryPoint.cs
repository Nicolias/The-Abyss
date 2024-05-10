using IJunior.TypedScenes;
using SliderViewNameSpace;
using UnityEngine;

public class EntryPoint : MonoBehaviour, ISceneLoadHandler<GameConfig>
{
    [SerializeField] private CubsCounter _cubsCounter;
    [SerializeField] private SmoothSliderView _fillCubsSlider;
    
    [SerializeField] private Timer _timer;
    [SerializeField] private TimerSlider _timerTimerSlider;

    [SerializeField] private CubsSpawner _cubsSpawner;

    public void OnSceneLoaded(GameConfig argument)
    {
        _cubsCounter.Initialize(argument.CubsCount);
        _fillCubsSlider.Initialize(_cubsCounter);

        _timer.Initialize(argument.TimerValue);
        _timerTimerSlider.Initialize(_timer);

        _cubsSpawner.Spawn(argument.CubsCount);
    }
}
