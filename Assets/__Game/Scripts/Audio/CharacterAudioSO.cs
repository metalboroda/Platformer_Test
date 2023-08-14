using UnityEngine;

namespace Assets.__Game.Scripts.Audio
{
  [CreateAssetMenu(menuName = "Audio/CharacterAudio")]
  public class CharacterAudioSO : ScriptableObject
  {
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip jumpSecond;
    [SerializeField] private AudioClip damage;

    public AudioClip Jump() { return jump; }

    public AudioClip JumpSecond() { return jumpSecond; }

    public AudioClip Damage() { return damage; }
  }
}