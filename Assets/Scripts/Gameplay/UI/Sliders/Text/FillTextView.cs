namespace Scripts.Gameplay.UI.Sliders.Text
{
    public class FillTextView : TextView
    {
        private const int OneHundredPercent = 100;

        public void UpdateUI(float currentValue, float maxValue)
        {
            int currentProcent = (int)(currentValue / maxValue * OneHundredPercent);

            Text.text = $"{currentProcent} %";
        }
    }
}