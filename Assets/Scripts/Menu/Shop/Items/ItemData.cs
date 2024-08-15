using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public string ID { get; private set; }
    [field: SerializeField] public int EffectDuration { get; private set; }

    public abstract void Accept(AbilityVisitor abilityVisitor);
}
