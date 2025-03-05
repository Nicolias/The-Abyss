using Scripts.Gameplay.Cubs.SpawnShapes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameplay.Cubs
{
    public class CubsSpawner : MonoBehaviour
    {
        [SerializeField] private Cub _template;

        [SerializeField] private Vector3 _firstCubSpawnPosition;

        private Transform _transform;

        private void OnValidate()
        {
            if (transform == null)
                return;

            _transform = transform;
        }

        public void Spawn(int count, AbstractSpawnShape spawnShape)
        {
            List<Vector3> spawnPoints = spawnShape.GetPositions(count, _firstCubSpawnPosition);

            if (spawnPoints.Count != count)
                throw new InvalidProgramException();

            foreach (Vector3 spawnPoint in spawnPoints)
            {
                Cub cub = Instantiate(_template, spawnPoint, Quaternion.identity, _transform);
                cub.Enable();
            }
        }
    }
}