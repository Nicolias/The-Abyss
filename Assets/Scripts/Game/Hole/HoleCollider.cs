using System;
using UnityEngine;

public class HoleCollider : MonoBehaviour
{
    public event Action<Cub> Detected;

   private void OnCollisionEnter(Collision collision)
   {
       if (collision.gameObject.TryGetComponent(out Cub cub))
           Detected?.Invoke(cub);
   }
}
