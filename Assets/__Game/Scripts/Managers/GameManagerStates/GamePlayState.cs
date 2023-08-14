using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Managers.GameManagerStates
{
  public class GamePlayState : State
  {
    public GamePlayState(GameManager gameManager)
    {
      _gameManager = gameManager;
    }

    private GameManager _gameManager;

    public override void Enter()
    {
      Time.timeScale = 1f;
    }
  }
}