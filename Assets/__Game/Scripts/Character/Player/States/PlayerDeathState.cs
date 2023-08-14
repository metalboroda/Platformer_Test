using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Character.Player.States
{
  public class PlayerDeathState : State
  {
    public PlayerDeathState(PlayerController playerController)
    {
      _playerController = playerController;
    }

    private PlayerController _playerController;
    private PlayerHandler _playerHandler;

    public override void Enter()
    {
      Init();
      _playerHandler.DestroyCharacter(0);
    }

    private void Init()
    {
      _playerHandler = _playerController.PlayerHandler;
    }
  }
}