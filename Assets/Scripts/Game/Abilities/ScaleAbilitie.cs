using ScalingSystem;
using System;
using UnityEngine;

public class ScaleAbilitie : AbstractAbilitie
{
    [SerializeField] private ScalingObject _scalingObject;
    [SerializeField] private Vector3 _scaleFactor;

    protected override event Action EffectEnd;

    protected override void Enable()
    {
        _scalingObject.Scale(_scaleFactor);
    }

    protected override void Disable()
    {
        _scalingObject.Completed += OnCompleted;
        _scalingObject.Unscale(_scaleFactor);
    }

    private void OnCompleted()
    {
        _scalingObject.Completed -= OnCompleted;
        EffectEnd?.Invoke();
    }
}
