using System;

namespace SliderViewNameSpace
{
    public interface IChangable
    {
        public int MaxValue { get; }

        public event Action<float> Changed;
    }
}