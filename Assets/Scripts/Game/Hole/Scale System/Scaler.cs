using System;
using UnityEngine;

namespace ScalingSystem
{
    public class Scaler
    {
        private HoleCollider _holeCollider;
        private ScalingObject _scalingObject;
        private ScalerProgressBar _visualization;

        private int _currentPoint = 0;
        private int _pointsCountForScale = 10;
        private Vector3 _scaleFactor;

        public Scaler(HoleCollider holeCollider, ScalingObject scalingObject, ScalerProgressBar progressBar, Vector3 scaleFactor)
        {
            if(holeCollider == null)
                throw new ArgumentNullException();
            
            if(scalingObject == null)
                throw new ArgumentNullException();
            
            if(progressBar == null)
                throw new ArgumentNullException();
            
            _holeCollider = holeCollider;
            _scalingObject = scalingObject;
            _visualization = progressBar;
            _scaleFactor = scaleFactor;
        }
        
        public void Enable()
        {
            _holeCollider.Detected += OnDetected;
            _visualization.Initialize(_pointsCountForScale);
        }

        public void Disable()
        {
            _holeCollider.Detected -= OnDetected;
        }

        private void OnDetected(Cub cub)
        {
            _currentPoint++;

            _visualization.UpdateUI(_currentPoint);
            
            if (_currentPoint == _pointsCountForScale)
            {
                _currentPoint = 0;
                _scalingObject.Scale(_scaleFactor);
                _visualization.Reset();
            }
        }
    }
}