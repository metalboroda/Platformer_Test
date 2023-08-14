using UnityEngine;

namespace Assets.__Game.Scripts.Animation
{
  [CreateAssetMenu(menuName = "Animation/AnimationHashes")]
  public class AnimationHashSO : ScriptableObject
  {
    [field: SerializeField] public string Idle { get; private set; }
    [field: SerializeField] public string Movement { get; private set; }
    [field: SerializeField] public string MovementBlend { get; private set; }
    [field: SerializeField] public string InAir { get; private set; }
    [field: SerializeField] public string Jump { get; private set; }
    [field: SerializeField] public string Hit { get; private set; }
    [field: SerializeField] public string Death { get; private set; }
  }
}