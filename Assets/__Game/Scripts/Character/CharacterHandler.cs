using Assets.__Game.Scripts.Interfaces;
using UnityEngine;

namespace Assets.__Game.Scripts.Character
{
  public abstract class CharacterHandler : MonoBehaviour, IDamageable
  {
    [SerializeField] protected int health = 1;
    [field: SerializeField] public int Power { get; private set; } = 1;

    [Header("VFX")]
    [SerializeField] protected GameObject deathVfx;

    protected BoxCollider2D _boxCollider;
    protected Rigidbody2D _rigidbody;

    public virtual void Awake()
    {
      _boxCollider = GetComponent<BoxCollider2D>();
      _rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Damage(int damage)
    {
    }

    public virtual void Death()
    {
    }

    public virtual void DestroyCharacter(float delay)
    {
      Destroy(gameObject, delay);
    }

    public virtual void DisableAllToDeath()
    {
    }
  }
}