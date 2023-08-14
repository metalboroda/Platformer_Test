using UnityEngine;

namespace Assets.__Game.Scripts.Items
{
  public abstract class CollectibleRoot : MonoBehaviour, ICollectible
  {
    [SerializeField] protected LayerMask collisionLayer;

    [Header("VFX")]
    [SerializeField] protected GameObject collectVFXPrefab;

    protected BoxCollider2D _collider;

    protected virtual void Awake()
    {
      _collider = GetComponent<BoxCollider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public virtual void Collect()
    {
    }
  }
}