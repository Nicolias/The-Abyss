using System;
using System.Collections;
using System.Collections.Generic;
using SliderViewNameSpace;
using UnityEngine;

public class CubsCounter : MonoBehaviour, IChangable
{
    [SerializeField] private HoleCollider _holeCollider;

    private List<Cub> _collectedCubs = new List<Cub>();
    
    public IEnumerable<Cub> CollectedCubs => _collectedCubs;

    public int Value => _collectedCubs.Count;
    public int MaxValue { get; private set; }

    public event Action<float> Changed;

    public void Initialize(int cubsCount)
    {
        _collectedCubs.Clear();
        MaxValue = cubsCount;
    }

    private void OnEnable()
    {
        _holeCollider.Detected += OnCollected;
    }

    private void OnDisable()
    {
        _holeCollider.Detected -= OnCollected;
    }

    private void OnCollected(Cub cub)
    {
        cub.Disabel();
        _collectedCubs.Add(cub);
        Changed?.Invoke(_collectedCubs.Count);
    }
}