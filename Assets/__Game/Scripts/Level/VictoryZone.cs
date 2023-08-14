using Assets.__Game.Scripts.Character.Player;
using Assets.__Game.Scripts.Managers;
using Assets.__Game.Scripts.Managers.GameManagerStates;
using UnityEngine;
using Zenject;

namespace Assets.__Game.Scripts.Level
{
  public class VictoryZone : MonoBehaviour
  {
    [Inject] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.GetComponent<PlayerController>())
        _gameManager.StateMachineController.ChangeState(new GameVictoryState(_gameManager));
    }
  }
}