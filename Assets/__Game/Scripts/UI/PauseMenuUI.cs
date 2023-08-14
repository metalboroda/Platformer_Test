using Assets.__Game.Scripts.Managers.GameManagerStates;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.__Game.Scripts.UI
{
  public class PauseMenuUI : CanvasUI
  {
    [Header("Tabs")]
    [SerializeField] private GameObject menuTab;

    [Header("Menu")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    protected override void Awake()
    {
      base.Awake();
    }

    private void Start()
    {
      resumeButton.onClick.AddListener(ShowHideMenuCanvas);
      restartButton.onClick.AddListener(RestartButtonPressed);
    }

    private void OnDestroy()
    {
      resumeButton.onClick.RemoveListener(ShowHideMenuCanvas);
      restartButton.onClick.RemoveListener(RestartButtonPressed);
    }

    public void ShowHideMenuCanvas(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
      ShowHideMenuCanvas();
    }

    public void ShowHideMenuCanvas()
    {
      if (!_canvas.enabled)
      {
        _canvas.enabled = true;

        _inputController.InputActions.OnFeet.Disable();
        _inputController.InputActions.UI.Enable();

        ShowMenuTab();

        _gameManager.StateMachineController.ChangeState(new GamePauseState(_gameManager));
      }
      else
      {
        _canvas.enabled = false;

        _inputController.InputActions.OnFeet.Enable();
        _inputController.InputActions.UI.Disable();

        HideAllTabs();

        _uIController.EventSystem.SetSelectedGameObject(null);

        _gameManager.StateMachineController.ChangeState(new GamePlayState(_gameManager));
      }
    }

    private void ShowMenuTab()
    {
      HideAllTabs();

      menuTab.SetActive(true);

      _uIController.EventSystem.SetSelectedGameObject(resumeButton.gameObject);
    }

    protected override void RestartButtonPressed()
    {
      base.RestartButtonPressed();
    }

    protected override void HideAllTabs()
    {
      menuTab.SetActive(false);
    }
  }
}