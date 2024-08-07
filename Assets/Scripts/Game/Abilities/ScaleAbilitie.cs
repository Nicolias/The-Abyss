using ScalingSystem;
using System;
using UnityEngine;

public class ScaleAbilitie : AbilityView
{
    [SerializeField] private ScalingObject _scalingObject;
    [SerializeField] private Vector3 _scaleFactor;

    //protected override ItemModel Model { get; set; }

    protected override event Action EffectEnd;

    public void Initialize()
    {
        //Model = scaleUpAbilityModel;
       // UpdateCounText();
    }

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
