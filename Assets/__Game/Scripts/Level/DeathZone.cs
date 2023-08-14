using Assets.__Game.Scripts.Interfaces;
using UnityEngine;

namespace Assets.__Game.Scripts.Level
{
  public class DeathZone : MonoBehaviour
  {
    [SerializeField] private int killingPower = 999;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.TryGetComponent(out IDamageable damageable))
        damageable.Damage(killingPower);
    }
  }
}