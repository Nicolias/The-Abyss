using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameplay.UI.Sliders
{
    [RequireComponent(typeof(Slider))]
    public abstract class AbstractSliderView : MonoBehaviour
    {
        private IChangable _changable;

        protected Slider Slider { get; private set; }

        protected float MaxValue => _changable.MaxValue;

        public void Initialize(IChangable changable)
        {
            _changable = changable;
            _changable.Changed += OnSliderChanged;

            Slider = GetComponent<Slider>();
            Slider.minValue = 0;
            Slider.maxValue = MaxValue;

            OnInitialized();
        }

        private void OnDisable()
        {
            _changable.Changed -= OnSliderChanged;
        }

        protected virtual void OnInitialized() 
        { 
        }

        protected abstract void OnSliderChanged(float currentValue);
    }
}