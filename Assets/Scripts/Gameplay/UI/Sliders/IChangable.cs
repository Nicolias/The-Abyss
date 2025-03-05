using System;

namespace Scripts.Gameplay.UI.Sliders
{
    public interface IChangable
    {
        public int MaxValue { get; }

        public event Action<float> Changed;
    }
}