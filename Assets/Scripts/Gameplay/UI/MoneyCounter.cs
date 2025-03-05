using System;
using Scripts.Gameplay.Cubs;
using Scripts.Gameplay.Hole;
using UnityEngine;

namespace Scripts.Gameplay.UI
{
    public class MoneyCounter : MonoBehaviour
    {
        private const int MoneyPerCub = 1;

        [SerializeField] private HoleCollider _holeCollider;

        public int Amount { get; private set; }

        public event Action Changed;

        private void OnEnable()
        {
            _holeCollider.Detected += OnDetected;
        }

        private void OnDisable()
        {
            _holeCollider.Detected -= OnDetected;
        }

        private void OnDetected(Cub cub)
        {
            Amount += MoneyPerCub;
            Changed?.Invoke();
        }
    }
}