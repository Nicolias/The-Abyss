using System;
using DG.Tweening;
using Scripts.Servises;
using UnityEngine;

namespace Scripts.Gameplay.Hole.ScaleSystem
{
    public class ScalingObject : MonoBehaviour
    {
        private const float ScalingDuration = 3f;

        [SerializeField] private HoleCollider _holeCollider;
        [SerializeField] private ScalerProgressBar _progressBar;
        [SerializeField] private Vector3 _scaleFactor = new Vector3(0.3f, 0.3f, 0.3f);

        [SerializeField] private SoundObject _soundObject;

        private Scaler _scaler;
        private Transform _selfTransform;

        public event Action Completed;

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
            _selfTransform.DOScale(_selfTransform.localScale + scaleFactor, ScalingDuration).OnComplete(() => Completed?.Invoke());
            _soundObject.PlaySound();
        }

        public void Unscale(Vector3 scaleFactor)
        {
            _selfTransform.DOScale(_selfTransform.localScale - scaleFactor, ScalingDuration).OnComplete(() => Completed?.Invoke());
        }
    }
}