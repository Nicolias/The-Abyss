using Scripts.Gameplay.Abilities;
using UnityEngine;

namespace Scripts.Menu.ShopSystem.Items
{
    [CreateAssetMenu(fileName = "Scale Up", menuName = "Item/ScaleUp")]
    public class ScaleUp : ItemData
    {
        [field: SerializeField] public Vector3 Value { get; private set; }

        public override void Accept(AbilityVisitor abilityVisitor)
        {
            abilityVisitor.Visit(this);
        }
    }
}