using System;
using UnityEngine;

public class CubsCollector : MonoBehaviour
{
    public event Action Collected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cub cub))
        {
            Collected?.Invoke();
            cub.gameObject.SetActive(false);
        }
    }
}
