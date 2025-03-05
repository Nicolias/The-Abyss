using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.Cubs.SpawnShapes
{
    public class TriangleShape : AbstractSpawnShape
    {
        [SerializeField] private float _xSpacing;
        [SerializeField] private int _ySpacing;

        public override List<Vector3> GetPositions(int count, Vector3 firstSpawnPosition)
        {
            List<Vector3> positions = new List<Vector3>();

            float currentY = firstSpawnPosition.z;

            int pointsLeft = count;
            int pointsPerRowRight = 1;
            int pointsPerRowLeft = 1;

            while (pointsLeft != 0)
            {
                float currentX = firstSpawnPosition.x;

                for (int i = 0; i < pointsPerRowRight; i++)
                {
                    positions.Add(new Vector3(currentX, firstSpawnPosition.y, currentY));
                    currentX += _xSpacing;
                    pointsLeft--;
                }

                currentX = firstSpawnPosition.x;

                for (int i = 0; i < pointsPerRowLeft; i++)
                {
                    currentX -= _xSpacing;
                    positions.Add(new Vector3(currentX, firstSpawnPosition.y, currentY));
                    pointsLeft--;
                }

                currentY += _ySpacing;
                pointsPerRowRight++;
                pointsPerRowLeft++;

                if (pointsPerRowRight + pointsPerRowLeft > pointsLeft)
                {
                    pointsPerRowLeft = pointsLeft / 2;
                    pointsPerRowRight = pointsLeft - pointsPerRowLeft;
                }
            }

            return positions;
        }
    }
}