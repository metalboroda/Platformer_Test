using UnityEngine;
using UnityEngine.UI;

namespace Assets.__Game.Scripts.UI
{
  public class VictoryUI : CanvasUI
  {
    [Header("Buttons")]
    [SerializeField] private Button restartButton;

    protected override void Awake()
    {
      base.Awake();
    }

    private void Start()
    {
      restartButton.onClick.AddListener(RestartButtonPressed);
    }

    private void OnDestroy()
    {
      restartButton.onClick.RemoveListener(RestartButtonPressed);
    }

    public void ShowHideGameOverScreen()
    {
      if (!_canvas.enabled)
      {
        _canvas.enabled = true;

        _uIController.EventSystem.SetSelectedGameObject(restartButton.gameObject);
      }
    }

    protected override void RestartButtonPressed()
    {
      base.RestartButtonPressed();
    }
  }
}