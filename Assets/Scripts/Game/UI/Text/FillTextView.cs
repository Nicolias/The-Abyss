namespace SliderViewNameSpace
{
    public class FillTextView : TextView
    {
        public void Update(float currentValue, float maxValue)
        {
            int currentProcent = (int) (currentValue / maxValue * 100);
            
            Text.text = $"{currentProcent} %";
        }
    }
}