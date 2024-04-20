using System;
using UnityEngine;

namespace ScalingSystem
{
    public class ScalerProgressBar : MonoBehaviour
    {
        private int _maxValue;
        
        public void Initialize(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException();
            
            _maxValue = maxValue;
        }

        public void Update(int currentValue)
        {
            
        }
    }
}