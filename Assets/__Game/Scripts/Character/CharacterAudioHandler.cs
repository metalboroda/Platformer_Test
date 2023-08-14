using Assets.__Game.Scripts.Audio;
using UnityEngine;

namespace Assets.__Game.Scripts.Character
{
  public class CharacterAudioHandler : MonoBehaviour
  {
    [SerializeField] protected CharacterAudioSO characterAudioSO;

    protected AudioSource audioSource;

    protected virtual void DamageSound()
    {
    }

    protected virtual void DeathSound()
    {
    }
  }
}