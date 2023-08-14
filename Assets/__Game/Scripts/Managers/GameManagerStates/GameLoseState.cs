using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Managers.GameManagerStates
{
  public class GameLoseState : State
  {
    public GameLoseState(GameManager gameManager)
    {
      _gameManager = gameManager;
    }

    private GameManager _gameManager;

    public override void Enter()
    {
      Debug.Log("GameLoseState");
    }
  }
}