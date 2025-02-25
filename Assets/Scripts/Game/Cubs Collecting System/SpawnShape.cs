using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnShape : MonoBehaviour
{
    public abstract List<Vector3> GetPositions(int count, Vector3 firstSpawnPosition);
}
