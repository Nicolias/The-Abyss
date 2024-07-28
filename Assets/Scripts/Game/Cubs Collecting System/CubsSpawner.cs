using UnityEngine;

public class CubsSpawner : MonoBehaviour
{
    [SerializeField] private Cub _template;

    [SerializeField] private float _xSpacing;
    [SerializeField] private float _ySpacing;
    [SerializeField] private Vector3 _firstCubSpawnPosition;
    [SerializeField] private int _cubsCountPerRow;

    private Transform _transform;

    private void OnValidate()
    {
        if (transform == null)
            return;

        _transform = transform;
    }

    public void Spawn(int count)
    {
        int cubsCountPerColumn = count / _cubsCountPerRow;

        float xSpawnPosition = _firstCubSpawnPosition.x;
        float ySpawnPosition = _firstCubSpawnPosition.z;

        for (int i = 0; i < cubsCountPerColumn; i++)
        {
            for (int j = 0; j < _cubsCountPerRow; j++)
            {
                Cub cub = Instantiate(_template, new Vector3(xSpawnPosition, _firstCubSpawnPosition.y, ySpawnPosition), Quaternion.identity, _transform);
                cub.Enable();
                xSpawnPosition += _xSpacing;
            }

            xSpawnPosition = _firstCubSpawnPosition.x;
            ySpawnPosition += _ySpacing;
        }
    }
}
