using Scripts.Gameplay.UI.Sliders.Text;
using UnityEngine;

namespace Scripts.Gameplay.UI.Sliders
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