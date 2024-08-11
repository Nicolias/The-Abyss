using UnityEngine;

[CreateAssetMenu(fileName = "Speed Up", menuName = "Item/SpeedUp")]
public class SpeedUp : ItemData
{
    [field: SerializeField] public float Value { get; private set; }
}