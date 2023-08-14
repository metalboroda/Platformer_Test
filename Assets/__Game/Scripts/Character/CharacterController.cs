using Assets.__Game.Scripts.Character.States;
using Assets.__Game.Scripts.StateMachine;
using UnityEngine;

namespace Assets.__Game.Scripts.Character
{
  public abstract class CharacterController : MonoBehaviour
  {
    public StateMachineController StateMachineController { get; private set; }

    public virtual void Awake()
    {
      StateMachineController = new();

      StateMachineController.Initialize(new CharacterNullState(this));
    }

    private void Update()
    {
      StateMachineController.CurrentState.Update();
    }

    private void FixedUpdate()
    {
      StateMachineController.CurrentState.FixedUpdate();
    }
  }
}