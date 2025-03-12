using System;
using Scripts.Gameplay.Hole;
using Scripts.Gameplay.Hole.ScaleSystem;
using Scripts.Gameplay.UI.Serivise;
using Scripts.Menu.ShopSystem.Items;

namespace Scripts.Gameplay.Abilities
{
    public abstract class AbstractAbilityEffector 
    {
        protected HoleMovement Movement { get; }

        protected Timer Timer { get; }

        protected ScalingObject ScalingObject { get; }

        protected AbstractAbilityEffector(HoleMovement movement, Timer timer, ScalingObject scalingObject)
        {
            if (movement == null)
                throw new NullReferenceException();

            if (timer == null)
                throw new NullReferenceException();

            if (scalingObject == null)
                throw new NullReferenceException();

            Movement = movement;
            Timer = timer;
            ScalingObject = scalingObject;
        }

        public void Visit(ItemData item)
        {
            switch (item)
            {
                case FreezTime freezTime:
                    FreezTime();
                    break;
                case ScaleUp scaleUp:
                    ChangeScale(scaleUp);
                    break;
                case SpeedUp speedUp:
                    ChangeSpeed(speedUp);
                    break;
                default:
                    throw new InvalidProgramException();
            }
        }

        public abstract void FreezTime();

        public abstract void ChangeScale(ScaleUp scaleUp);

        public abstract void ChangeSpeed(SpeedUp speedUp);
    }
}