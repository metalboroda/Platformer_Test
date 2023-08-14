using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Inventory;
using Assets.__Game.Scripts.ScriptableObjects;
using Lean.Pool;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Items
{
  public class Item : CollectibleRoot
  {
    [SerializeField] private ItemSO itemSO;

    [Inject] private InventoryManager _inventoryManager;

    protected override void Awake()
    {
      base.Awake();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
      if (((1 << collision.gameObject.layer) & collisionLayer) != 0 && collision.GetComponent<PlayerController>())
      {
        Collect();
      }
    }

    public override void Collect()
    {
      _inventoryManager.AddItem(itemSO);

      float colliderMagnitude = Mathf.Max(_collider.size.x, _collider.size.y);

      GameObject spawnedVfx = LeanPool.Spawn(collectVFXPrefab, transform.position, transform.rotation);

      spawnedVfx.transform.localScale = Vector3.one * colliderMagnitude;

      Destroy(gameObject);
    }
  }
}