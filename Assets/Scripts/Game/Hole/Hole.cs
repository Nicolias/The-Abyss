using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    
    private void FixedUpdate()
    {
        if (_transform.hasChanged == false)
            return;

        _transform.hasChanged = false;
        _ground.UpdateCollider(_transform.position, _transform.localScale);
    }
}
