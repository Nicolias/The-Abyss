using System.Collections.Generic;
using UnityEngine;

public class Liner : MonoBehaviour
{
    [SerializeField] private List<Transform> _objects = new List<Transform>();

    private void OnValidate()
    {
        Vector3 currentPosition = transform.position;

        foreach (Transform t in _objects)
        {
            currentPosition = new Vector3(currentPosition.x + 2, currentPosition.y, currentPosition.z);

            t.position = currentPosition;
        }
    }
}
