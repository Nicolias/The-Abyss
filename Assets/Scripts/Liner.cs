using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Liner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _objects = new List<Transform>();

        private void OnValidate()
        {
            Vector3 currentPosition = transform.position;

            foreach (Transform transform in _objects)
            {
                currentPosition = new Vector3(currentPosition.x + 2, currentPosition.y, currentPosition.z);

                transform.position = currentPosition;
            }
        }
    }
}