using Assets.__Game.Scripts.Managers.GameManagerStates;
using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Managers
{
  public class GameManager : MonoBehaviour
  {
    public StateMachineController StateMachineController { get; private set; }

    private void Awake()
    {
      StateMachineController = new();
      StateMachineController.Initialize(new GamePlayState(this));
    }
  }
}