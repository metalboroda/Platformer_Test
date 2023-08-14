using UnityEngine;

namespace Assets.__Game.Scripts.Character.Enemy
{
  public class EnemyAudioHandler : CharacterAudioHandler
  {
    private EnemyHandler _enemyHandler;

    private void Awake()
    {
      audioSource = GetComponent<AudioSource>();
    }

    public void Init(EnemyHandler enemyHandler)
    {
      _enemyHandler = enemyHandler;

      _enemyHandler.OnDamage += DamageSound;
    }

    private void OnDestroy()
    {
      _enemyHandler.OnDamage -= DamageSound;
    }

    protected override void DamageSound()
    {
      if (audioSource.enabled)
        audioSource.PlayOneShot(characterAudioSO.Damage());
    }
  }
}