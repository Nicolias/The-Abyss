using System.Collections.Generic;
using UnityEngine;

public class CircleShape : SpawnShape
{
    [SerializeField] private List<Transform> _points;

    public override List<Vector3> GetPositions(int count, Vector3 firstSpawnPosition)
    {
        List<Vector3> positions = new List<Vector3>();

        foreach (Transform t in _points) 
            positions.Add(t.position);

        return positions;
    }
}
