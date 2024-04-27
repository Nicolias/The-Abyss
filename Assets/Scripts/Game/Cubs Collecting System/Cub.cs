using UnityEngine;

public class Cub : MonoBehaviour
{
    private Transform _transform;
    private GameObject _gameObject;
    
    public Vector3 Position => _transform.position;

    private void Awake()
    {
        _transform = transform;
        _gameObject = gameObject;
    }

    public void Enable()
    {
        _gameObject.SetActive(true);
    }
    
    public void Disabel()
    {
        _gameObject.SetActive(false);
    }
}
