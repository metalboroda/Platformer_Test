using UnityEngine;

namespace Assets.__Game.Scripts.Audio
{
  [CreateAssetMenu(menuName = "Audio/VFXAudio")]
  public class VFXAudioSO : ScriptableObject
  {
    [SerializeField] private AudioClip sound;

    public AudioClip Sound() { return sound; }
  }
}