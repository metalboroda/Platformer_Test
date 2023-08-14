using Assets.__Game.Scripts.Character.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.__Game.Scripts.Level
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private GameObject enemyPrefab;

    [Header("")]
    [SerializeField] private bool isNeedToPatrol;
    [SerializeField] private List<Transform> patrolPoints = new();

    private void Start()
    {
      SpawnEnemy();
    }

    private void SpawnEnemy()
    {
      var spawnedEnemyMovement = Instantiate(enemyPrefab, transform.position, transform.rotation).GetComponent<EnemyMovement>();

      if (isNeedToPatrol)
        spawnedEnemyMovement.SetPatrolPoints(patrolPoints);
    }
  }
}