using ScalingSystem;

public class AbilityStarter : AbilityVisitor
{
    public override void Visit(ItemData item)
    {
        Visit((dynamic)item);
    }

    public override void Visit(FreezTime freezTime)
    {
        Timer.Pause();
    }

    public override void Visit(ScaleUp scaleUp)
    {
        ScalingObject.Scale(scaleUp.Value);
    }

    public override void Visit(SpeedUp speedUp)
    {
        Movement.AddSpeed(speedUp.Value);
    }
}
