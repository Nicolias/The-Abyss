using System;
using SliderViewNameSpace;
using UnityEngine;

public class CubsCounter : MonoBehaviour, IChangable
{
    [SerializeField] private HoleCollider _holeCollider;

    private int _collected = 0;
    
    public int MaxValue { get; private set; }

    public event Action<float> Changed;

    public void Initialize(int cubsCount)
    {
        MaxValue = cubsCount;
    }

    private void OnEnable()
    {
        _holeCollider.Detected += OnCollected;
    }

    private void OnDisabel()
    {
        _holeCollider.Detected -= OnCollected;
    }

    private void OnCollected(Cub cub)
    {
        cub.Disabel();
        _collected++;
        Changed?.Invoke(_collected);
    }
}