using ScalingSystem;
using UnityEngine;

public abstract class AbilityVisitor : MonoBehaviour
{
    [SerializeField] private HoleMovement _movement;
    [SerializeField] private Timer _timer;
    [SerializeField] private ScalingObject _scalingObject;

    protected HoleMovement Movement => _movement;

    protected Timer Timer => _timer;

    protected ScalingObject ScalingObject => _scalingObject;

    public void Visit(ItemData item)
    {
        item.Accept(this);
    }

    public abstract void Visit(FreezTime freezTime);

    public abstract void Visit(ScaleUp scaleUp);

    public abstract void Visit(SpeedUp speedUp);
}