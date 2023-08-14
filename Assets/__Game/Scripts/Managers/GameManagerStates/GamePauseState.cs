using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Managers.GameManagerStates
{
  public class GamePauseState : State
  {
    public GamePauseState(GameManager gameManager)
    {
      _gameManager = gameManager;
    }

    private GameManager _gameManager;

    public override void Enter()
    {
      Time.timeScale = 0;
    }

    public override void Exit()
    {
      Time.timeScale = 1;
    }
  }
}