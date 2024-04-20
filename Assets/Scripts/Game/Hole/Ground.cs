using UnityEngine;

public class Ground : MonoBehaviour
{
    private const int HoleColliderResolution = 20;

    [SerializeField] private Transform _groundModel;
    [SerializeField] private MeshCollider _meshCollider;
    [SerializeField] private PolygonCollider2D _ground2DCollider;
    [SerializeField] private PolygonCollider2D _hole2DCollider;
    [SerializeField] private float _colliderHoleScaleModifier = 0.5f;

    private void Awake()
    {
        _meshCollider.transform.position -= new Vector3(transform.position.x, 0, transform.position.y);

        SetupGroundCollider();
        SetupHoleCollider();
    }

    public void UpdateCollider(Vector3 holePosition, Vector3 holeScale)
    {
        _meshCollider.sharedMesh = GenerateMesh(holePosition, holeScale);
    }

    private Mesh GenerateMesh(Vector3 holePosition, Vector3 holeScale)
    {
        _hole2DCollider.transform.position = new Vector2(holePosition.x, holePosition.z);
        _hole2DCollider.transform.localScale = new Vector2(holeScale.x, holeScale.z) * _colliderHoleScaleModifier;

        Vector2[] pointPositions = _hole2DCollider.GetPath(0);

        for (int i = 0; i < pointPositions.Length; i++)
            pointPositions[i] = _ground2DCollider.transform.InverseTransformPoint(_hole2DCollider.transform.TransformPoint(pointPositions[i]));

        _ground2DCollider.pathCount = 2;
        _ground2DCollider.SetPath(1, pointPositions);

        return _ground2DCollider.CreateMesh(true, true);
    }

    private void SetupHoleCollider()
    {
        var points = new Vector2[HoleColliderResolution];
        float radius = 1f;

        for (int i = 0; i < HoleColliderResolution; i++)
        {
            float angle = 2 * Mathf.PI * i / HoleColliderResolution;
            points[i] = new Vector2(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle));
        }

        _hole2DCollider.SetPath(0, points);
    }

    private void SetupGroundCollider()
    {
        var groundModelHalfScale = new Vector2(_groundModel.localScale.x, _groundModel.localScale.z) / 2;

        var points = new Vector2[]
        {
            new Vector2(groundModelHalfScale.x, groundModelHalfScale.y),
            new Vector2(-groundModelHalfScale.x, groundModelHalfScale.y),
            new Vector2(-groundModelHalfScale.x, -groundModelHalfScale.y),
            new Vector2(groundModelHalfScale.x, -groundModelHalfScale.y),
        };

        _ground2DCollider.SetPath(0, points);
        _meshCollider.sharedMesh = _ground2DCollider.CreateMesh(true, true);
    }
}
