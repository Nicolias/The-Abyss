using System;
using UnityEngine;

namespace ScalingSystem
{
    public class Scaler
    {
        private const int PointsCountForScale = 20;

        private readonly HoleCollider _holeCollider;
        private readonly ScalingObject _scalingObject;
        private readonly ScalerProgressBar _visualization;

        private readonly Vector3 _scaleFactor;

        private int _currentPointsCount = 0;

        public Scaler(HoleCollider holeCollider, ScalingObject scalingObject, ScalerProgressBar progressBar, Vector3 scaleFactor)
        {
            if (holeCollider == null)
                throw new ArgumentNullException();

            if (scalingObject == null)
                throw new ArgumentNullException();

            if (progressBar == null)
                throw new ArgumentNullException();

            _holeCollider = holeCollider;
            _scalingObject = scalingObject;
            _visualization = progressBar;
            _scaleFactor = scaleFactor;
        }
       
        public void Enable()
        {
            _holeCollider.Detected += OnDetected;
            _visualization.Initialize(PointsCountForScale);
        }

        public void Disable()
        {
            _holeCollider.Detected -= OnDetected;
        }

        private void OnDetected(Cub cub)
        {
            _currentPointsCount++;

            _visualization.UpdateUI(_currentPointsCount);

            if (_currentPointsCount == PointsCountForScale)
            {
                _currentPointsCount = 0;
                _scalingObject.Scale(_scaleFactor);
                _visualization.Reset();
            }
        }
    }
}