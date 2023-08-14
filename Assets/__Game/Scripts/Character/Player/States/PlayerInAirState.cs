using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerInAirState : State
  {
    public PlayerInAirState(PlayerController playerController)
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
      _playerHandler.IsCanMkaDamage(true);
    }

    public override void Update()
    {
      GroundCheck();
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

    private void GroundCheck()
    {
      _playerMovement.Rigidbody2D.gravityScale = _playerMovement.InAirGravityScale;

      if (_playerMovement.IsGrounded)
      {
        _playerController.StateMachineController.ChangeState(new PlayerMovementState(_playerController));
      }
    }

    private void Animation()
    {
      _playerAnimation.InAirAnim();
    }
  }
}