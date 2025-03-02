using System;
using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    [SerializeField] private SoundObject _soundObject;

    public event Action<Cub> Detected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cub cub))
        {
            Detected?.Invoke(cub);
            _soundObject.PlaySound();
        }
    }
}
