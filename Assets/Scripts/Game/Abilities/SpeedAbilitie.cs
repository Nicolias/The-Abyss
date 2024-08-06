using System;
using UnityEngine;

public class SpeedAbilitie : AbstractAbilitie
{
    [SerializeField] private HoleMovement _movement;
    [SerializeField] private float _speedFactor;

    protected override AbstractItemModel Model { get; set; }

    protected override event Action EffectEnd;

    public void Initialize()
    {
       // Model = speedUpAbilityModel;
        OnInitialized();
    }

    protected override void Enable()
    {
        _movement.AddSpeed(_speedFactor);
    }

    protected override void Disable()
    {
        _movement.RemoveSpeed(_speedFactor);

        EffectEnd?.Invoke();
    }
}
