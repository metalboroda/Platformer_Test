using Assets.__Game.Scripts.Character.Enemy.States;
using Lean.Pool;
using System;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Enemy
{
  public class EnemyHandler : CharacterHandler
  {
    public event Action OnDamage;

    public event Action OnDeath;

    private EnemyController _enemyController;

    public override void Awake()
    {
      base.Awake();
    }

    public void Init(EnemyController enemyController)
    {
      _enemyController = enemyController;
    }

    public override void Damage(int damage)
    {
      health -= damage;
      Death();

      OnDamage?.Invoke();
    }

    public override void Death()
    {
      if (health <= 0)
      {
        health = 0;

        float colliderMagnitude = Mathf.Max(_boxCollider.size.x, _boxCollider.size.y);

        GameObject spawnedVfx = LeanPool.Spawn(deathVfx, transform.position, transform.rotation);

        spawnedVfx.transform.localScale = Vector3.one * colliderMagnitude;

        OnDeath?.Invoke();

        _enemyController.StateMachineController.ChangeState(new EnemyDeathState(_enemyController));
      }
    }
  }
}