using Assets.__Game.Scripts.StateMachine;

namespace Assets.__Game.Scripts.Managers.GameManagerStates
{
  public class GameVictoryState : State
  {
    public GameVictoryState(GameManager gameManager)
    {
      _gameManager = gameManager;
    }

    private GameManager _gameManager;
  }
}