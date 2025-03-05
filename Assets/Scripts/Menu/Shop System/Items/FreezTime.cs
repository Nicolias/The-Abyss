using Scripts.Gameplay.Abilities;
using UnityEngine;

namespace Scripts.Menu.ShopSystem.Items
{
    [CreateAssetMenu(fileName = "Freez Time", menuName = "Item/FreezTime")]
    public class FreezTime : ItemData
    {
        public override void Accept(AbilityVisitor abilityVisitor)
        {
            abilityVisitor.Visit(this);
        }
    }
}
