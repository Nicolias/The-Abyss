using System;

namespace SliderViewNameSpace
{
    public class TimerText : TextView
    {
        public void UpdateUI(float secondsLeft)
        {
            TimeSpan timeLeft = TimeSpan.FromSeconds(secondsLeft);

            Text.text = timeLeft.ToString(@"mm\:ss");
        }
    }
}