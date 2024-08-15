using ScalingSystem;
using UnityEngine;

public abstract class AbilityVisitor : MonoBehaviour
{
    [SerializeField] protected HoleMovement Movement;
    [SerializeField] protected Timer Timer;
    [SerializeField] protected ScalingObject ScalingObject;

    public void Visit(ItemData item)
    {
        item.Accept(this);
    }

    public abstract void Visit(FreezTime freezTime);
    public abstract void Visit(ScaleUp scaleUp);
    public abstract void Visit(SpeedUp speedUp);
}