using UnityEngine;

namespace SliderViewNameSpace
{
    public class TimerSlider : AbstractSliderView
    {
        [SerializeField] private TimerText _textVisualization;

        protected override void OnInitialized()
        {
            Slider.value = MaxValue;
            _textVisualization.UpdateUI(MaxValue);
        }

        protected override void OnSliderChanged(float currentValue)
        {
            Slider.value = currentValue;
            _textVisualization.UpdateUI(currentValue);
        }
    }
}