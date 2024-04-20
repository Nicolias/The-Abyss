using System;
using SliderViewNameSpace;
using UnityEngine;

public class CubsCounter : MonoBehaviour, IChangable
{
    [SerializeField] private CubsCollector _collector;

    private int _collected = 0;
    
    public int MaxValue { get; private set; }

    public event Action<float> Changed;

    public void Initialize(int cubsCount)
    {
        MaxValue = cubsCount;
    }

    private void OnEnable()
    {
        _collector.Collected += OnCollected;
    }

    private void OnDisabel()
    {
        _collector.Collected -= OnCollected;
    }

    private void OnCollected()
    {
        _collected++;
        Changed?.Invoke(_collected);
    }
}