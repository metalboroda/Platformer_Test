using Assets.__Game.Scripts.Managers;
using Assets.__Game.Scripts.Managers.GameManagerStates;
using Assets.__Game.Scripts.StateMachine;
using Assets.__Game.Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.__Game.Scripts.Controllers
{
  public class UIController : MonoBehaviour
  {
    [field: SerializeField] public EventSystem EventSystem { get; private set; }

    [Header("Menu")]
    [SerializeField] private PauseMenuUI pauseMenuUI;

    [Header("Inventory")]
    [SerializeField] private InventoryUI inventoryUI;

    [Header("Victory")]
    [SerializeField] private VictoryUI victoryUI;

    [Inject] private readonly GameManager _gameManager;
    [Inject] private readonly InputController _inputController;

    private void Start()
    {
      _gameManager.StateMachineController.OnStateUpdated += LoseUnsubscribe;
      _inputController.InputActions.OnFeet.ShowHideMenu.performed += pauseMenuUI.ShowHideMenuCanvas;
      _inputController.InputActions.UI.ShowHideMenu.performed += pauseMenuUI.ShowHideMenuCanvas;
      _inputController.InputActions.OnFeet.Inventory.performed += inventoryUI.ShowHideInventory;
      _gameManager.StateMachineController.OnStateUpdated += GameOver;
    }

    private void OnDestroy()
    {
      _gameManager.StateMachineController.OnStateUpdated -= LoseUnsubscribe;
      _inputController.InputActions.OnFeet.ShowHideMenu.performed -= pauseMenuUI.ShowHideMenuCanvas;
      _inputController.InputActions.UI.ShowHideMenu.performed -= pauseMenuUI.ShowHideMenuCanvas;
      _inputController.InputActions.OnFeet.Inventory.performed -= inventoryUI.ShowHideInventory;
      _gameManager.StateMachineController.OnStateUpdated -= GameOver;
    }

    private void GameOver(State state)
    {
      if (state is GameVictoryState)
        victoryUI.ShowHideGameOverScreen();
      else if (state is GameLoseState)
        StartCoroutine(GameOverRoutine());
    }

    private IEnumerator GameOverRoutine()
    {
      yield return new WaitForSeconds(1f);

      victoryUI.ShowHideGameOverScreen();
    }

    private void LoseUnsubscribe(State state)
    {
      if (state is GameLoseState || state is GameVictoryState)
      {
        _inputController.InputActions.OnFeet.ShowHideMenu.performed -= pauseMenuUI.ShowHideMenuCanvas;
        _inputController.InputActions.UI.ShowHideMenu.performed -= pauseMenuUI.ShowHideMenuCanvas;
        _inputController.InputActions.OnFeet.Inventory.performed -= inventoryUI.ShowHideInventory;
      }
    }
  }
}