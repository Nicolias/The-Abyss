using Scripts.Gameplay.Hole;
using Scripts.Gameplay.Hole.ScaleSystem;
using Scripts.Gameplay.UI.Serivise;
using Scripts.Menu.ShopSystem.Items;

namespace Scripts.Gameplay.Abilities
{
    public class AbilityFinisher : AbstractAbilityEffector
    {
        public AbilityFinisher(HoleMovement movement, Timer timer, ScalingObject scalingObject) 
            : base(movement, timer, scalingObject)
        {
        }

        public override void FreezTime()
        {
            Timer.UnPaus();
        }

        public override void ChangeScale(ScaleUp scaleUp)
        {
            ScalingObject.Unscale(scaleUp.Value);
        }

        public override void ChangeSpeed(SpeedUp speedUp)
        {
            Movement.RemoveSpeed(speedUp.Value);
        }
    }
}