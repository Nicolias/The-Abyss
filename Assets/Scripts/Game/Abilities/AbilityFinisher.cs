using ScalingSystem;

public class AbilityFinisher : AbilityVisitor
{
    public override void Visit(FreezTime freezTime)
    {
        Timer.Play();
    }

    public override void Visit(ScaleUp scaleUp)
    {
        ScalingObject.Unscale(scaleUp.Value);
    }

    public override void Visit(SpeedUp speedUp)
    {
        Movement.RemoveSpeed(speedUp.Value);
    }
}