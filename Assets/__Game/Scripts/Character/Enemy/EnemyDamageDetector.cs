using Assets.__Game.Scripts.Interfaces;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Enemy
{
  public class EnemyDamageDetector : CharacterDamageDetector
  {
    private EnemyHandler _enemyHandler;

    public void Init(EnemyHandler enemyHandler)
    {
      _enemyHandler = enemyHandler;
    }

    public override void SideCollision(GameObject collidedObject)
    {
      if ((enemyLayer & (1 << collidedObject.layer)) != 0)
      {
        var enemyDamage = collidedObject.GetComponentInParent<IDamageable>();

        if (enemyDamage != null)
        {
          enemyDamage.Damage(_enemyHandler.Power);
        }
      }
    }
  }
}