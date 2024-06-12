using System;
using UnityEngine;

public class SpeedAbilitie : AbstractAbilitie
{
    [SerializeField] private HoleMovement _movement;
    [SerializeField] private float _speedFactor;

    protected override event Action EffectEnd;

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
