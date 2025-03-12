using Scripts.Gameplay.Hole;
using Scripts.Gameplay.Hole.ScaleSystem;
using Scripts.Gameplay.UI.Serivise;
using Scripts.Menu.ShopSystem.Items;

namespace Scripts.Gameplay.Abilities
{
    public class AbilityStarter : AbstractAbilityEffector
    {
        public AbilityStarter(HoleMovement movement, Timer timer, ScalingObject scalingObject) 
            : base(movement, timer, scalingObject)
        {
        }

        public override void FreezTime()
        {
            Timer.Paus();
        }

        public override void ChangeScale(ScaleUp scaleUp)
        {
            ScalingObject.Scale(scaleUp.Value);
        }

        public override void ChangeSpeed(SpeedUp speedUp)
        {
            Movement.AddSpeed(speedUp.Value);
        }
    }
}