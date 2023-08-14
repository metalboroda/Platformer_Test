using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerMovementState : State
  {
    public PlayerMovementState(PlayerController playerController)
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
      Animation();
      _playerHandler.IsCanMkaDamage(false);
    }

    public override void Update()
    {
      GroundCheck();
      AnimationBlend();
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

      _playerMovement.ResetJumpCounter();
    }

    private void GroundCheck()
    {
      _playerMovement.Rigidbody2D.gravityScale = _playerMovement.MovementGravityScale;

      if (!_playerMovement.IsGrounded)
      {
        _playerController.StateMachineController.ChangeState(new PlayerInAirState(_playerController));
      }
    }

    private void Animation()
    {
      _playerAnimation.MovementAnim();
    }

    private void AnimationBlend()
    {
      _playerAnimation.MovementBlend(_playerMovement.Rigidbody2D.velocity.x);
    }
  }
}