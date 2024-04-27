using DG.Tweening;
using UnityEngine;

namespace ScalingSystem
{
    public class ScalingObject : MonoBehaviour
    {
        [SerializeField] private HoleCollider _holeCollider;
        [SerializeField] private ScalerProgressBar _progressBar;
        
        private Scaler _scaler;
        private Transform _selfTransform;

        private Vector3 _scaleFactor = new Vector3(0.3f, 0.3f, 0.3f);
        private float _calingDuration = 3f;

        private void Awake()
        {
            _selfTransform = transform;
            _scaler = new Scaler(_holeCollider, this, _progressBar);
        }

        private void OnEnable()
        {
            _scaler.Enable();
        }

        private void OnDisable()
        {
            _scaler.Disable();
        }
        
        public void Scale()
        {
            _selfTransform.DOScale(_selfTransform.localScale + _scaleFactor, _calingDuration);
        }
    }
}