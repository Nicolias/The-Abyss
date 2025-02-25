using System.Collections.Generic;
using UnityEngine;

public class SquareShape : SpawnShape
{
    [SerializeField] private float _xSpacing;
    [SerializeField] private int _ySpacing;

    private int _cubsCountPerRow = 6;

    public override List<Vector3> GetPositions(int count, Vector3 firstSpawnPosition)
    {
        List<Vector3> points = new List<Vector3>();

        int cubsCountPerColumn = count / _cubsCountPerRow;
        Vector3 spawnPosition = firstSpawnPosition;

        for (int i = 0; i < cubsCountPerColumn; i++)
        {
            for (int j = 0; j < _cubsCountPerRow; j++)
            {
                Vector3 point = new Vector3(spawnPosition.x, firstSpawnPosition.y, spawnPosition.z);
                spawnPosition.x += _xSpacing;

                points.Add(point);
            }

            spawnPosition.x = firstSpawnPosition.x;
            spawnPosition.z += _ySpacing;
        }

        return points;
    }
}
