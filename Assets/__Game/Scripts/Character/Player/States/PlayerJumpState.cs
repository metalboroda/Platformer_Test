using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerJumpState : State
  {
    public PlayerJumpState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private PlayerController _playerController;
    private PlayerHandler _playerHandler;
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;

    public override void Enter()
    {
      Init();
      Jump();
      Animation();
    }

    public override void Update()
    {
      //GroundCheck();
      CheckJumpVelocity();
    }

    public override void FixedUpdate()
    {
      _playerMovement.Movement();
    }

    private void Init()
    {
      _playerHandler = _playerController.PlayerHandler;
      _playerMovement = _playerController.PlayerMovement;
      _playerAnimation = _playerController.PlayerAnimation;
    }

    private void Jump()
    {
      _playerMovement.Rigidbody2D.AddForce(Vector2.up * _playerMovement.JumpForce, ForceMode2D.Impulse);
    }

    private void CheckJumpVelocity()
    {
      if (_playerMovement.Rigidbody2D.velocity.y <= 0f)
      {
        _playerController.StateMachineController.ChangeState(new PlayerInAirState(_playerController));
      }
    }

    private void Animation()
    {
      _playerAnimation.JumpAnim();
    }
  }
}