using System;
using UnityEngine;
using UnityEngine.UI;

namespace ScalingSystem
{
    [RequireComponent(typeof(Image))]
    public class ScalerProgressBar : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        private Image _progressBar;

        private float _maxValue;

        public void Initialize(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException();

            _maxValue = maxValue;
            _progressBar = GetComponent<Image>();
        }

        public void UpdateUI(float currentValue)
        {
            if (currentValue < 0 || currentValue > _maxValue)
                throw new ArgumentOutOfRangeException();

            float fillValue = currentValue / _maxValue;

            _progressBar.fillAmount = fillValue;
        }

        public void Reset()
        {
            _progressBar.fillAmount = 0f;
            _particle.Play();
        }
    }
}