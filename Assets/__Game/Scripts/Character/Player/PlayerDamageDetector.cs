using Assets.__Game.Scripts.Interfaces;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerDamageDetector : CharacterDamageDetector
  {
    private PlayerHandler _playerHandler;
    private PlayerMovement _playerMovement;

    public void Init(PlayerHandler playerHandler, PlayerMovement playerMovement)
    {
      _playerHandler = playerHandler;
      _playerMovement = playerMovement;
    }

    public override void BottomCollision(GameObject collidedObject)
    {
      if (!_playerHandler.IsCanMakeDamage) return;

      if ((enemyLayer & (1 << collidedObject.layer)) != 0)
      {
        var enemyDamage = collidedObject.GetComponentInParent<IDamageable>();

        if (enemyDamage != null)
        {
          enemyDamage.Damage(_playerHandler.Power);
          _playerMovement.AfterDamageJump();
        }
      }
    }
  }
}