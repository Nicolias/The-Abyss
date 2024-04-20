using UnityEngine;

namespace SliderViewNameSpace
{
    public class TimerSlider : AbstractSliderView
    {
        [SerializeField] private TimerText _textVisualization;

        protected override void OnInitialized()
        {
            Slider.value = MaxValue;
            _textVisualization.Update(MaxValue);
        }

        protected override void OnSliderChanged(float currentValue)
        {
            Slider.value = currentValue;
            _textVisualization.Update(currentValue);
        }
    }
}