using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private List<Transform> _positionsTransform;

    private System.Random _random = new();

    private int[,] _heartMap = new int[,]
   {
         { 0,0,0,2,2,2,2,2,0,0,0,0,2,2,2,2,2,0,0,0 },
         { 0,0,2,2,1,1,1,2,2,0,0,2,2,1,1,1,2,2,0,0 },
         { 0,2,2,1,1,1,1,1,2,2,2,2,1,1,1,1,1,2,2,0 },
         { 2,2,1,1,1,1,1,1,1,2,2,1,1,1,1,1,1,1,2,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2 },
         { 2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2 },
         { 0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0 },
         { 0,0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,0 },
         { 0,0,0,2,2,1,1,1,1,1,1,1,1,1,1,2,2,0,0,0 },
         { 0,0,0,0,2,2,1,1,1,1,1,1,1,1,2,2,0,0,0,0 },
         { 0,0,0,0,0,2,2,1,1,1,1,1,1,2,2,0,0,0,0,0 },
         { 0,0,0,0,0,0,2,2,1,1,1,1,2,2,0,0,0,0,0,0 },
         { 0,0,0,0,0,0,0,2,2,1,1,2,2,0,0,0,0,0,0,0 },
         { 0,0,0,0,0,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0 },
   };

    public List<Vector3> GetPositions()
    {
        List<Vector3> positions = new List<Vector3>();

        for (int i = _positionsTransform.Count - 1; i >= 1; i--)
        {
            int j = _random.Next(i + 1);
            var temp = _positionsTransform[j];
            _positionsTransform[j] = _positionsTransform[i];
            _positionsTransform[i] = temp;
        }

        _positionsTransform.ForEach(positionTransform => positions.Add(positionTransform.position));

        return positions;
    }
}