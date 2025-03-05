using UnityEngine;

namespace Scripts.Gameplay.Cubs
{
    [RequireComponent(typeof(Rigidbody))]
    public class Cub : MonoBehaviour
    {
        private Transform _transform;
        private GameObject _gameObject;
        private Rigidbody _rigidbody;

        public Vector3 Position => _transform.position;

        private void Awake()
        {
            _transform = transform;
            _gameObject = gameObject;
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Enable()
        {
            _rigidbody.isKinematic = false;
        }

        public void Disabel()
        {
            _rigidbody.isKinematic = true;
            _gameObject.SetActive(false);
        }
    }
}