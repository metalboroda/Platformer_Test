using Assets.__Game.Scripts.Character.Player.States;
using Assets.__Game.Scripts.Managers;
using Assets.__Game.Scripts.Managers.GameManagerStates;
using Assets.__Game.Scripts.StateMachine;
using Lean.Pool;
using Zenject;

namespace Assets.__Game.Scripts.Character.Player
{
  public class PlayerHandler : CharacterHandler
  {
    public bool IsCanMakeDamage { get; private set; } = false;

    [Inject] private GameManager _gameManager;
    private PlayerController _playerController;

    public override void Awake()
    {
      base.Awake();
    }

    private void Start()
    {
      _gameManager.StateMachineController.OnStateUpdated += Victory;
    }

    private void OnDestroy()
    {
      _gameManager.StateMachineController.OnStateUpdated -= Victory;
    }

    public void Init(PlayerController playerController)
    {
      _playerController = playerController;
    }

    public override void Damage(int damage)
    {
      health -= damage;

      Death();
    }

    public override void Death()
    {
      if (health <= 0)
      {
        health = 0;

        LeanPool.Spawn(deathVfx, transform.position, transform.rotation);

        _playerController.StateMachineController.ChangeState(new PlayerDeathState(_playerController));
        _gameManager.StateMachineController.ChangeState(new GameLoseState(_gameManager));
      }
    }

    private void Victory(State state)
    {
      if (state is GameVictoryState)
        _playerController.StateMachineController.ChangeState(new PlayerVictoryState(_playerController));
    }

    public void IsCanMkaDamage(bool change)
    {
      IsCanMakeDamage = change;
    }
  }
}