using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Character.States
{
  public class CharacterNullState : State
  {
    public CharacterNullState(CharacterController characterHandler)
    {
      _characterHandler = characterHandler;
    }

    private readonly CharacterController _characterHandler;
  }
}