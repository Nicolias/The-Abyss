using SliderViewNameSpace;
using UnityEngine;

public class CubsRoot : MonoBehaviour
{
    [SerializeField] private CubsCounter _cubsCounter;
    [SerializeField] private SmoothSliderView _fillCubsSlider;

    [SerializeField] private CubsSpawner _cubsSpawner;

    public void Initialize(int cubsCount)
    {
        _cubsCounter.Initialize(cubsCount);
        _fillCubsSlider.Initialize(_cubsCounter);

        _cubsSpawner.Spawn(cubsCount);
    }
}
