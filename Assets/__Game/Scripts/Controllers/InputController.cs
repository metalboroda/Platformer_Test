using System;
using UnityEngine;

namespace Assets.__Game.Scripts.Controllers
{
  public class InputController : MonoBehaviour
  {
    public event Action OnJumpPressed;
    public event Action OnInventoryPressed;

    public PlayerActions InputActions { get; private set; }

    private void Awake()
    {
      InputActions = new();

      InputActions.OnFeet.Enable();

      InputActions.OnFeet.Jump.performed += Jump;
      InputActions.OnFeet.Inventory.performed += Inventory;
    }

    private void OnDestroy()
    {
      InputActions.OnFeet.Jump.performed -= Jump;
      InputActions.OnFeet.Inventory.performed -= Inventory;
    }

    public Vector2 InputVector()
    {
      return InputActions.OnFeet.Movement.ReadValue<Vector2>();
    }

    private void Jump(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
      OnJumpPressed?.Invoke();
    }

    private void Inventory(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
      OnInventoryPressed?.Invoke();
    }
  }
}