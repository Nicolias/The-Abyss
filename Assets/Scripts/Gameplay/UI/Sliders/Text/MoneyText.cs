using UnityEngine;

namespace Scripts.Gameplay.UI.Sliders.Text
{
    public class MoneyText : TextView
    {
        [SerializeField] private MoneyCounter _moneyCounter;

        private void OnEnable()
        {
            OnChanged();
            _moneyCounter.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _moneyCounter.Changed -= OnChanged;
        }

        private void OnChanged()
        {
            Text.text = _moneyCounter.Amount.ToString();
        }
    }
}