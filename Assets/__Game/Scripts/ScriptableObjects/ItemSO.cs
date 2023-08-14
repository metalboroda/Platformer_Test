using UnityEngine;

namespace Assets.__Game.Scripts.ScriptableObjects
{
  [CreateAssetMenu(menuName = "Item")]
  public class ItemSO : ScriptableObject
  {
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public string ItemName { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
  }
}