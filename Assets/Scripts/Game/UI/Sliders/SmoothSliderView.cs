using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SliderViewNameSpace
{
    [RequireComponent(typeof(Slider))]
    public sealed class SmoothSliderView : AbstractSliderView
    {
        [SerializeField] private FillTextView _textVisualization;
        [SerializeField] private float _fillSpeed;

        private Coroutine _fillHealthBar;

        protected override void OnInitialized()
        {
            Slider.value = 0;
        }

        protected override void OnSliderChanged(float currentValue)
        {
            if (_fillHealthBar != null)
                StopCoroutine(_fillHealthBar);

            _textVisualization.UpdateUI(currentValue, MaxValue);

            _fillHealthBar = StartCoroutine(FillHealthBar(currentValue));
        }

        private IEnumerator FillHealthBar(float currentHealth)
        {
            float currentHealthNormolized = currentHealth / MaxValue;

            while (Slider.normalizedValue != currentHealthNormolized)
            {
                Slider.normalizedValue = Mathf.MoveTowards
                (
                    Slider.normalizedValue,
                    currentHealthNormolized,
                    _fillSpeed * Time.deltaTime
                );

                yield return null;
            }
        }
    }
}