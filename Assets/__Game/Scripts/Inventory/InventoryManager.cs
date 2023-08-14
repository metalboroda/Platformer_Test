using Assets.__Game.Scripts.ScriptableObjects;
using Assets.__Game.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.__Game.Scripts.Inventory
{
  public class InventoryManager : MonoBehaviour
  {
    [field: SerializeField] public List<ItemSO> ItemSOs { get; private set; } = new List<ItemSO>();

    [field: Header("")]
    [field: SerializeField] public InventoryUI inventoryUI { get; private set; }
    [field: SerializeField] public GameObject InventoryScrollView { get; private set; }
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private GameObject inventoryItem;

    private void OnEnable()
    {
      ListItems();
    }

    public void AddItem(ItemSO itemSO)
    {
      ItemSOs.Add(itemSO);
    }

    public void RemoveItem(ItemSO itemSO)
    {
      ItemSOs.Remove(itemSO);
    }

    public void ListItems()
    {
      foreach (Transform item in inventoryContent)
      {
        Destroy(item.gameObject);
      }

      foreach (var item in ItemSOs)
      {
        GameObject obj = Instantiate(inventoryItem, inventoryContent);

        var itemIcon = obj.GetComponent<InventoryItem>().itemIcon;
        var itemName = obj.GetComponent<InventoryItem>().itemName;

        itemIcon.sprite = item.Icon;
        itemName.text = item.name;
      }
    }
  }
}