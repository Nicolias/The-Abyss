using System;

namespace ScalingSystem
{
    public class Scaler
    {
        private CubsCollector _cubsCollector;
        private ScalingObject _scalingObject;
        private ScalerProgressBar _visualization;

        private int _currentPoint = 0;
        private int _pointsCountForScale = 10;

        public Scaler(CubsCollector cubsCollector, ScalingObject scalingObject, ScalerProgressBar progressBar)
        {
            if(cubsCollector == null)
                throw new ArgumentNullException();
            
            if(scalingObject == null)
                throw new ArgumentNullException();
            
            if(progressBar == null)
                throw new ArgumentNullException();
            
            _cubsCollector = cubsCollector;
            _scalingObject = scalingObject;
            _visualization = progressBar;
        }
        
        public void Enable()
        {
            _cubsCollector.Collected += OnCollected;
            _visualization.Initialize(_pointsCountForScale);
        }

        public void Disable()
        {
            _cubsCollector.Collected -= OnCollected;
        }

        private void OnCollected()
        {
            _currentPoint++;

            _visualization.Update(_currentPoint);
            
            if (_currentPoint == _pointsCountForScale)
            {
                _currentPoint = 0;
                _scalingObject.Scale();
                _visualization.Reset();
            }
        }
    }
}