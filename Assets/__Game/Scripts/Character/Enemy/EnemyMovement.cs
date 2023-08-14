using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Enemy
{
  public class EnemyMovement : MonoBehaviour
  {
    [SerializeField] private float moveVelocity = 8f;
    [SerializeField] private float stoppingDistance = 1f;
    [SerializeField] private float stoppingDelayMin;
    [SerializeField] private float stoppingDelayMax;

    public Rigidbody2D Rigidbody { get; private set; }

    private List<Transform> _patrolPoints = new();
    private int _currentPatrolIndex = 0;
    private bool _isMoving = false;

    private void Awake()
    {
      Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetPatrolPoints(List<Transform> points)
    {
      _patrolPoints = points;
    }

    public void Movement()
    {
      StartCoroutine(MovementRoutine());
    }

    private IEnumerator MovementRoutine()
    {
      while (_patrolPoints.Count > 0)
      {
        Transform targetPoint = _patrolPoints[_currentPatrolIndex];
        float distance = Vector2.Distance(transform.position, targetPoint.position);

        if (distance > stoppingDistance)
        {
          Vector2 direction = (targetPoint.position - transform.position).normalized;
          Rigidbody.velocity = direction * moveVelocity;

          // Flip model
          if (direction.x > 0)
          {
            transform.rotation = Quaternion.Euler(0, 180, 0);
          }
          else if (direction.x < 0)
          {
            transform.rotation = Quaternion.Euler(0, 0, 0);
          }

          if (!_isMoving)
          {
            _isMoving = true;
          }
        }
        else
        {
          Rigidbody.velocity = Vector2.zero;

          if (_isMoving)
          {
            _isMoving = false;

            float stoppingDelay = Random.Range(stoppingDelayMin, stoppingDelayMax);

            yield return new WaitForSeconds(stoppingDelay);

            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
          }
        }

        yield return null;
      }
    }
  }
}