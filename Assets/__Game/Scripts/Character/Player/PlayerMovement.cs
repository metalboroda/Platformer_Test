using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.Controllers;
using System;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerMovement : MonoBehaviour
  {
    public event Action<int> OnJump;

    [field: SerializeField] public float VelocityLimit { get; private set; } = 75f;

    [field: Header("Movement")]
    [field: SerializeField] public float MovementForce { get; private set; } = 60f;
    [field: SerializeField] public float MovementGravityScale { get; private set; } = 3;

    [field: Header("In air")]
    [field: SerializeField] public float InAirGravityScale { get; private set; } = 8f;

    [field: Header("Jump")]
    [field: SerializeField] public float JumpForce { get; private set; } = 20f;
    [field: SerializeField] public int MaxJumps { get; private set; } = 2;

    [field: Header("Ground check")]
    [field: SerializeField] public Transform GroundCheckTransform { get; private set; }
    [field: SerializeField] public float GroundCheckSize { get; private set; } = 0.1f;
    [field: SerializeField] public LayerMask GroundLayer { get; private set; }

    public bool IsGrounded { get; private set; }

    private int _jumpCount = 0;
    private float _defaultJumpForce;

    public Rigidbody2D Rigidbody2D { get; private set; }
    public Collider2D Collider { get; private set; }

    private PlayerController _playerController;
    [Inject] private InputController _inputController;

    private void Awake()
    {
      Rigidbody2D = GetComponent<Rigidbody2D>();
      Collider = GetComponent<Collider2D>();

      _defaultJumpForce = JumpForce;

      _inputController.OnJumpPressed += Jump;
    }

    public void Init(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private void OnDestroy()
    {
      _inputController.OnJumpPressed -= Jump;
    }

    private void Update()
    {
      GroundCheck();
      LimitJumpVelocity();
    }

    public void GroundCheck()
    {
      IsGrounded = Physics2D.BoxCast(Collider.bounds.center, Collider.bounds.size,
        0f, Vector2.down, GroundCheckSize, GroundLayer);
    }

    public void Movement()
    {
      float moveHorizontal = _inputController.InputVector().x;

      Vector2 movement = new(moveHorizontal * MovementForce, Rigidbody2D.velocity.y);
      Vector2 clampedVelocity = Vector2.ClampMagnitude(Rigidbody2D.velocity + movement, VelocityLimit);
      Vector2 velocityChange = clampedVelocity - Rigidbody2D.velocity;

      Rigidbody2D.AddForce(velocityChange, ForceMode2D.Force);

      // Turn sprite
      if (moveHorizontal < 0)
        transform.rotation = Quaternion.Euler(0, 180, 0);
      else if (moveHorizontal > 0)
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Jump()
    {
      if (_playerController.StateMachineController.CurrentState is PlayerMovementState ||
        _playerController.StateMachineController.CurrentState is PlayerJumpState)
      {
        _jumpCount++;
      }
      else if (_playerController.StateMachineController.PreviousState is PlayerJumpState)
      {
        _jumpCount++;
        JumpForce *= 1.5f;

      }
      else if (_playerController.StateMachineController.CurrentState is PlayerInAirState)
      {
        _jumpCount = MaxJumps;
        JumpForce *= 1.5f;
      }

      if (_jumpCount <= MaxJumps)
        _playerController.StateMachineController.ChangeState(new PlayerJumpState(_playerController));

      OnJump?.Invoke(_jumpCount);
    }

    private void LimitJumpVelocity()
    {
      float newYVelocity = Mathf.Clamp(Rigidbody2D.velocity.y, float.MinValue, VelocityLimit);
      Vector2 newVelocity = new(Rigidbody2D.velocity.x, newYVelocity);

      Rigidbody2D.velocity = newVelocity;
    }

    public void AfterDamageJump()
    {
      _jumpCount = MaxJumps - 1;
      JumpForce = _defaultJumpForce;

      _playerController.StateMachineController.ChangeState(new PlayerJumpState(_playerController));
    }

    public void ResetJumpCounter()
    {
      _jumpCount = 0;
      JumpForce = _defaultJumpForce;
    }
  }
}