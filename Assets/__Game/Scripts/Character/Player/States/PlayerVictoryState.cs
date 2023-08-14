using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerVictoryState : State
  {
    public PlayerVictoryState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private PlayerController _playerController;
    private PlayerAnimation _playerAnimation;

    public override void Enter()
    {
      Init();
      Animation();
    }

    private void Init()
    {
      _playerAnimation = _playerController.PlayerAnimation;
    }

    private void Animation()
    {
      _playerAnimation.IdleAnim();
    }
  }
}