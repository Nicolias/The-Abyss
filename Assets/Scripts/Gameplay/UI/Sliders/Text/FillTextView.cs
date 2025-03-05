namespace Scripts.Gameplay.UI.Sliders.Text
{
    public class FillTextView : TextView
    {
        public void UpdateUI(float currentValue, float maxValue)
        {
            int currentProcent = (int)(currentValue / maxValue * 100);

            Text.text = $"{currentProcent} %";
        }
    }
}