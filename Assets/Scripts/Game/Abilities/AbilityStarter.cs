using ScalingSystem;

public class AbilityStarter : AbilityVisitor
{
    public override void Visit(FreezTime freezTime)
    {
        Timer.Paus();
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
