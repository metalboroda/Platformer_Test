using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerAudioHandler : CharacterAudioHandler
  {
    private PlayerMovement _playerMovement;
    private PlayerDamageDetector _playerDamageDetector;

    private void Awake()
    {
      audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
      _playerMovement.OnJump -= PlayJumpSound;
    }

    public void Init(PlayerMovement playerMovement, PlayerDamageDetector playerDamageDetector)
    {
      _playerMovement = playerMovement;
      _playerDamageDetector = playerDamageDetector;

      _playerMovement.OnJump += PlayJumpSound;
    }

    private void PlayJumpSound(int obj)
    {
      if (obj == 1)
        audioSource.PlayOneShot(characterAudioSO.Jump());

      if (obj == _playerMovement.MaxJumps)
        audioSource.PlayOneShot(characterAudioSO.JumpSecond());
    }
  }
}