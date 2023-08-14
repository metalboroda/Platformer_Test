using UnityEngine;

namespace Assets.__Game.Scripts.VFX
{
  public class VFXAudio : MonoBehaviour
  {
    [SerializeField] private bool isPoollable;
    [SerializeField] private AudioClip audioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
      if (isPoollable)
        PlaySound();
    }

    private void Start()
    {
      if (!isPoollable)
        PlaySound();
    }

    private void PlaySound()
    {
      _audioSource.PlayOneShot(audioClip);
    }
  }
}