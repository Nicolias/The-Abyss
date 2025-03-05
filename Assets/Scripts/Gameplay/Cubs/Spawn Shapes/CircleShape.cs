using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.Cubs.SpawnShapes
{
    public class CircleShape : AbstractSpawnShape
    {
        [SerializeField] private List<Transform> _points;

        public override List<Vector3> GetPositions(int count, Vector3 firstSpawnPosition)
        {
            List<Vector3> positions = new List<Vector3>();

            foreach (Transform transform in _points)
                positions.Add(transform.position);

            return positions;
        }
    }
}