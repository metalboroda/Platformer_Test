using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Inventory;
using Assets.__Game.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Level
{
  public class Door : MonoBehaviour
  {
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private GameObject activePart;

    [Header("Audio")]
    [SerializeField] private AudioClip openSound;

    private AudioSource _audioSource;

    [Inject] private InventoryManager _inventoryManager;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.GetComponent<PlayerController>())
      {
        CheckItem();
      }
    }

    private void CheckItem()
    {
      var itemList = _inventoryManager.ItemSOs;

      foreach (var item in itemList)
      {
        if (item == itemSO)
        {
          OpenTheDoor();
          return;
        }
      }
    }

    private void OpenTheDoor()
    {
      activePart.SetActive(false);

      _audioSource.PlayOneShot(openSound);

      _inventoryManager.RemoveItem(itemSO);
      _inventoryManager.ListItems();
    }
  }
}