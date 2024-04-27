using System;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private HoleCollider _holeCollider;

    private int _moneyPerCub = 1;
    
    public int Amount { get; private set; }

    public event Action Changed;
    
    private void OnEnable()
    {
        _holeCollider.Detected += OnDetected;
    }

    private void OnDisable()
    {
        _holeCollider.Detected -= OnDetected;
    }

    private void OnDetected(Cub cub)
    {
        Amount += _moneyPerCub;
        Changed?.Invoke();
    }
}