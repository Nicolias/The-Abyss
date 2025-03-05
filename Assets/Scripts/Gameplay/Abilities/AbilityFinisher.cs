using Scripts.Menu.ShopSystem.Items;

namespace Scripts.Gameplay.Abilities
{
    public class AbilityFinisher : AbilityVisitor
    {
        public override void Visit(FreezTime freezTime)
        {
            Timer.UnPaus();
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
}