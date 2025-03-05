using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private List<Transform> _positionsTransform;

        private readonly System.Random _random = new System.Random();

        public List<Vector3> GetPositions()
        {
            List<Vector3> positions = new List<Vector3>();

            for (int i = _positionsTransform.Count - 1; i >= 1; i--)
            {
                int j = _random.Next(i + 1);

                (_positionsTransform[j], _positionsTransform[i]) = (_positionsTransform[i], _positionsTransform[j]);
            }

            _positionsTransform.ForEach(positionTransform => positions.Add(positionTransform.position));

            return positions;
        }
    }
}