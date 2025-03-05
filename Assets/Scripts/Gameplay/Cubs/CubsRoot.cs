using System.Collections.Generic;
using Scripts.Gameplay.Cubs.SpawnShapes;
using Scripts.Gameplay.UI.Sliders;
using UnityEngine;

namespace Scripts.Gameplay.Cubs
{
    public class CubsRoot : MonoBehaviour
    {
        [SerializeField] private CubsCounter _cubsCounter;
        [SerializeField] private SmoothSliderView _fillCubsSlider;

        [SerializeField] private CubsSpawner _cubsSpawner;

        [SerializeField] private List<AbstractSpawnShape> _spawnShapes;

        public CubsCounter CubsCounter => _cubsCounter;

        public void Initialize(int cubsCount)
        {
            _cubsCounter.Initialize(cubsCount);
            _fillCubsSlider.Initialize(_cubsCounter);

            _cubsSpawner.Spawn(cubsCount, _spawnShapes[Random.Range(0, _spawnShapes.Count)]);
        }
    }
}