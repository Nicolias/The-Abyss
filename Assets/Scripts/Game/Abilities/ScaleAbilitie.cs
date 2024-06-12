using ScalingSystem;
using UnityEngine;

public class ScaleAbilitie : AbstractAbilitie
{
    [SerializeField] private ScalingObject _scalingObject;
    [SerializeField] private Vector3 _scaleFactor;

    protected override void Enable()
    {
        _scalingObject.Scale(_scaleFactor);
    }

    protected override void Disable()
    {
        _scalingObject.Unscale(_scaleFactor);
    }
}
