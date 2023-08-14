using Assets.__Game.Scripts.Controllers;
using Assets.__Game.Scripts.Inventory;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.UI
{
  public class InventoryUI : MonoBehaviour
  {
    [Header("Animation")]
    [SerializeField] private float openCloseDuration = 0.15f;

    [Header("")]
    [SerializeField] private GameObject scrollView;

    private Vector3 _defaultPosition;

    private Canvas _canvas;

    [Inject] private InventoryManager _inventoryManager;
    [Inject] private UISoundController _uISoundController;

    private void Awake()
    {
      _canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
      _defaultPosition = scrollView.transform.position;

      HideInventory();
    }

    private void HideInventory()
    {
      scrollView.transform.DOMoveX(3000, openCloseDuration).OnComplete(() =>
      {
        _canvas.enabled = false;
      });
    }

    public void ShowHideInventory(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
      if (!_canvas.enabled)
      {
        scrollView.SetActive(true);
        _canvas.enabled = true;

        _inventoryManager.ListItems();

        _uISoundController.OpenInventorySound();

        scrollView.transform.DOMoveX(_defaultPosition.x, openCloseDuration);
      }
      else
      {
        _uISoundController.CloseInventorySound();

        scrollView.transform.DOMoveX(3000, openCloseDuration).OnComplete(() =>
        {
          scrollView.SetActive(false);
          _canvas.enabled = false;
        });
      }
    }
  }
}