using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item")]
public class ItemData : ScriptableObject
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public string ID { get; private set; }
}
