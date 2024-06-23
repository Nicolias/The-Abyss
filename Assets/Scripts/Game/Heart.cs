using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private List<Transform> _positionsTransform;

    private System.Random _random = new();

    public List<Vector3> GetPositions()
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i = _positionsTransform.Count - 1; i >= 1; i--)
        {
            int j = _random.Next(i + 1);
            // обменять значения data[j] и data[i]
            var temp = _positionsTransform[j];
            _positionsTransform[j] = _positionsTransform[i];
            _positionsTransform[i] = temp;
        }

        _positionsTransform.ForEach(positionTransform => positions.Add(positionTransform.position));

        return positions;
    }
}