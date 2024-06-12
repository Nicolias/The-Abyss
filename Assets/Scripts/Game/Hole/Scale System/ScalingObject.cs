using DG.Tweening;
using System;
using UnityEngine;

namespace ScalingSystem
{
    public class ScalingObject : MonoBehaviour
    {
        [SerializeField] private HoleCollider _holeCollider;
        [SerializeField] private ScalerProgressBar _progressBar;
        [SerializeField] private Vector3 _scaleFactor = new Vector3(0.3f, 0.3f, 0.3f);
        
        private Scaler _scaler;
        private Transform _selfTransform;

        private float _scalingDuration = 3f;

        private void Awake()
        {
            _selfTransform = transform;
            _scaler = new Scaler(_holeCollider, this, _progressBar, _scaleFactor);
        }

        private void OnEnable()
        {
            _scaler.Enable();
        }

        private void OnDisable()
        {
            _scaler.Disable();
        }

        public void Scale(Vector3 scaleFactor)
        {

            _selfTransform.DOScale(_selfTransform.localScale + scaleFactor, _scalingDuration);
        }

        public void Unscale(Vector3 scaleFactor)
        {
            _selfTransform.DOScale(_selfTransform.localScale - scaleFactor, _scalingDuration);
        }
    }
}