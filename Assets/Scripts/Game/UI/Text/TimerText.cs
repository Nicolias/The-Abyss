using System;

namespace SliderViewNameSpace
{
    public class TimerText : TextView
    {
        public void Update(float secondsLeft)
        {
            TimeSpan timeLeft = TimeSpan.FromSeconds(secondsLeft);
            
            Text.text = $"{timeLeft.Minutes} : {timeLeft.Seconds}";
        }
    }
}