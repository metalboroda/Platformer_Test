using Assets.__Game.Scripts.Controllers;
using Assets.__Game.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.UI
{
  public class CanvasUI : MonoBehaviour
  {
    protected Canvas _canvas;

    [Inject] protected readonly GameManager _gameManager;
    [Inject] protected readonly InputController _inputController;
    [Inject] protected readonly UIController _uIController;
    [Inject] protected readonly SceneController _sceneController;

    protected virtual void Awake()
    {
      _canvas = GetComponent<Canvas>();
    }

    protected virtual void RestartButtonPressed()
    {
      _sceneController.ResetartCurrentScene();
    }

    protected virtual void HideAllTabs()
    {
    }
  }
}