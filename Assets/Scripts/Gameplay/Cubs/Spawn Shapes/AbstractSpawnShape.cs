using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.Cubs.SpawnShapes
{
    public abstract class AbstractSpawnShape : MonoBehaviour
    {
        public abstract List<Vector3> GetPositions(int count, Vector3 firstSpawnPosition);
    }
}